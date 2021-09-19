using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using AxWMPLib;

namespace WaveRunnerV2
{
    public partial class MainWindow : Form
    {
        public string rootPath => Application.StartupPath;
        public string configPath => System.IO.Path.Combine(rootPath, "waverunnerv2config.json");
        public string audioPath => System.IO.Path.Combine(rootPath, "audio");
        public string musicPath => System.IO.Path.Combine(rootPath, "music");
        public Models.ConfigModel Model { get; set; }
        public System.Windows.Forms.Timer tmr { get; set; }
        public int CurrentVolume { get; set; }
        public int Reducer { get; set; }
        public int Ticks { get; set; }

        private AxWindowsMediaPlayer mPlayer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            VerifyConfigFile();
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 1000;
            tmr.Tick += fadeOutTimer;
            mPlayer = mpLayer;
            mPlayer.BeginInit();
            mPlayer.EndInit();
            mPlayer.Ctlenabled = true;
        }

        private void fadeOutTimer(object sender, EventArgs e)
        {
            Ticks = Ticks - 1;

            if (Ticks <= 0)
            {
                mPlayer.settings.volume = 0;
                mPlayer.close();
                mPlayer.settings.volume = CurrentVolume;
                tmr.Stop();
            }

            mPlayer.settings.volume = mPlayer.settings.volume - Reducer;

        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(LoadAudio);
            Thread thread2 = new Thread(LoadMusic);
            thread1.Start();
            thread2.Start();
        }

        private void LoadAudio()
        {
            
            foreach (var file in Model.AudioClips.OrderBy(d => d.SortOrder))
            {
                Invoke(new Action(() =>
                {
                    TagLib.File tagFile = TagLib.File.Create(file.FileName);

                    var minutes = (int)tagFile.Properties.Duration.TotalSeconds / 60;
                    var seconds = (int)tagFile.Properties.Duration.TotalSeconds - (minutes * 60);
                    var secondDisplay = seconds.ToString();

                    if (seconds < 10)
                        secondDisplay = "0" + seconds.ToString();

                    var audioButton = new Button
                    {
                        Text = file.NickName + Environment.NewLine + minutes + ":" + secondDisplay,
                        Width = 175,
                        Height = 100,
                    };

                    audioButton.Click += PlayAudio_Click;

                    flpAudio.Controls.Add(audioButton);
                    Refresh();
                }));
            }

        }

        private void LoadMusic()
        {
            dgvMusic.Rows.Clear();

            foreach (var file in Model.Music.OrderBy(d => d.SortOrder))
            {
                Invoke(new Action(() =>
                {
                    TagLib.File tagFile = TagLib.File.Create(file.FileName);

                    var dgRow = new DataGridViewRow();
                    dgRow.CreateCells(dgvMusic);
                    dgRow.Cells[0].Tag = file.FileName;

                    dgRow.Cells[0].Value = file.SortOrder;
                    dgRow.Cells[1].Value = tagFile.Tag.Title + Environment.NewLine + string.Join(",", tagFile.Tag.Performers);

                    var minutes = (int)tagFile.Properties.Duration.TotalSeconds / 60;
                    var seconds = (int)tagFile.Properties.Duration.TotalSeconds - (minutes * 60);
                    var secondDisplay = seconds.ToString();

                    if (seconds < 10)
                        secondDisplay = "0" + seconds.ToString();

                    dgRow.Cells[2].Value = minutes + ":" + secondDisplay;


                    //musicButton.Click += MusicButton_Click;

                    dgvMusic.Rows.Add(dgRow);
                    Refresh();
                }));


            }
        }

        private void MusicButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var selectedAudio = Model.Music.FirstOrDefault(d => d.FileName == button.Tag);

            mPlayer.URL = selectedAudio.FileName;
            mPlayer.Ctlcontrols.play();

        }

        private void PlayAudio_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var selectedAudio = Model.AudioClips.FirstOrDefault(d => d.NickName == button.Text);

            mPlayer.URL = selectedAudio.FileName;
            mPlayer.Ctlcontrols.play();


        }

        private void MpLayer_MediaError(object sender, AxWMPLib._WMPOCXEvents_MediaErrorEvent e)
        {
            MessageBox.Show(e.pMediaObject.ToString());
        }

        private void VerifyConfigFile()
        {
            // Check if the configuration file exists, if not create it

            if (!System.IO.File.Exists(configPath))
            {
                var blankModel = new Models.ConfigModel()
                {
                    AudioClips = new List<Models.AudioFile>(),
                    Music = new List<Models.MusicFile>(),
                    FadeOutTimer = 10
                };

                File.WriteAllText(configPath, JsonConvert.SerializeObject(blankModel));
            }

            try
            {
                Model = JsonConvert.DeserializeObject<Models.ConfigModel>(File.ReadAllText(configPath));
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Configuration Format : A backup will be created of the current file and then a new configuration file will be created");
                File.Copy(configPath, configPath + ".bak");
                File.Delete(configPath);
                VerifyConfigFile();

            }
            
        }

        private void mnuManageAudio_Click(object sender, EventArgs e)
        {
            var mac = new Modals.ManageAudioClips(configPath, Model);
            mac.ShowDialog(this);

            flpAudio.Controls.Clear();
            Thread thread1 = new Thread(LoadAudio);
            thread1.Start();
        }

        private void btnFade_Click(object sender, EventArgs e)
        {
            Ticks = Model.FadeOutTimer;
            CurrentVolume = mPlayer.settings.volume;
            Reducer = CurrentVolume / Model.FadeOutTimer;
            tmr.Start();

        }

        private void mnuManageMusic_Click(object sender, EventArgs e)
        {
            var mac = new Modals.ManageMusic(configPath, Model);
            mac.ShowDialog(this);

            flpAudio.Controls.Clear();
            Thread thread1 = new Thread(LoadAudio);
            thread1.Start();
        }
        string prevText = "";

        private void dgvMusic_SelectionChanged(object sender, EventArgs e)
        {
            dgvMusic.ClearSelection();
        }

       

        private void dgvMusic_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            prevText = dgvMusic.Rows[e.RowIndex].Cells[0].Value.ToString();
            dgvMusic.Rows[e.RowIndex].Cells[0].Value = "Play";

        }

        private void dgvMusic_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            dgvMusic.Rows[e.RowIndex].Cells[0].Value = prevText;

        }

        private void dgvMusic_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dgvMusic_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != 0) return;

            mPlayer.URL = dgvMusic.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag.ToString();
            mPlayer.Ctlcontrols.play();


        }

        private void btnFadeFast_Click(object sender, EventArgs e)
        {
            Ticks = 1;
            CurrentVolume = mPlayer.settings.volume;
            Reducer = CurrentVolume / Ticks;
            tmr.Start();

        }

        private void btnFadeSlow_Click(object sender, EventArgs e)
        {
            Ticks = 10;
            CurrentVolume = mPlayer.settings.volume;
            Reducer = CurrentVolume / Ticks;
            tmr.Start();

        }
    }
}
