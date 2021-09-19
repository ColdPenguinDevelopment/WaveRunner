using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;

namespace WaveRunnerV2.Modals
{
    public partial class ManageMusic : Form
    {
        public Models.ConfigModel Model { get; set; }
        public string ConfigPath { get; set; }

        public ManageMusic(string configPath, Models.ConfigModel model)
        {
            InitializeComponent();
            Model = model;
            ConfigPath = configPath;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var fbd = new OpenFileDialog()
            {
                InitialDirectory = Environment.SpecialFolder.MyMusic.ToString(),
                Multiselect = true
            };

            var dResult = fbd.ShowDialog();

            if (dResult == DialogResult.OK)
            {
                foreach (var file in fbd.FileNames)
                {
                    Model.Music.Add(new Models.MusicFile
                    {
                        FileName = file,
                        SortOrder = Model.Music != null && Model.Music.Any() ? Model.Music.Max(d => d.SortOrder) + 1 : 1
                    });
                }

                Model.SaveChanges(ConfigPath);

                Thread thread1 = new Thread(LoadAudio);
                thread1.Start();
            }

            
        }

        private void ManageAudioClips_Shown(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(LoadAudio);
            thread1.Start();
        }

        private void ManageAudioClips_Load(object sender, EventArgs e)
        {
            statusLabel.Text = "Loading...";
            Refresh();
        }

        private void LoadAudio()
        {
            flpAudio.Controls.Clear();

            foreach (var file in Model.Music.OrderBy(d=>d.SortOrder))
            {
                Invoke(new Action(() =>
                {
                    TagLib.File tagFile = TagLib.File.Create(file.FileName);

                    flpAudio.Controls.Add(new Button
                    {
                        Text = tagFile.Tag.Title + Environment.NewLine + string.Join(",", tagFile.Tag.Performers),
                        Width = flpAudio.Width,
                        Height = 100,
                        ContextMenuStrip = cmsContext,
                        TextAlign = ContentAlignment.MiddleLeft
                    });
                    Refresh();
                }));

                
            }


            statusLabel.Text = "Ready";
        }

        

        private void ctxDelete_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (sender as ToolStripItem);
            if (item != null)
            {
                ContextMenuStrip owner = item.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    var confirm = MessageBox.Show("Are you sure", "Remove Audio Clip", MessageBoxButtons.YesNo);

                    if (confirm == DialogResult.Yes)
                    {
                        var selectedClip = Model.Music.FirstOrDefault(d => d.FileName == owner.SourceControl.Text);
                        Model.Music.Remove(selectedClip);
                        Model.SaveChanges(ConfigPath);

                        Thread thread1 = new Thread(LoadAudio);
                        thread1.Start();
                    }
                    
                    
                }
            }
        }
    }
}
