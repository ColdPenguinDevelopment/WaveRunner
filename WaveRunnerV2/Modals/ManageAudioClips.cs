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
    public partial class ManageAudioClips : Form
    {
        public Models.ConfigModel Model { get; set; }
        public string ConfigPath { get; set; }

        public ManageAudioClips(string configPath, Models.ConfigModel model)
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
                    Model.AudioClips.Add(new Models.AudioFile
                    {
                        FileName = file,
                        NickName = System.IO.Path.GetFileNameWithoutExtension(file),
                        SortOrder = Model.AudioClips != null && Model.AudioClips.Any() ? Model.AudioClips.Max(d => d.SortOrder) + 1 : 1
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

            foreach (var file in Model.AudioClips.OrderBy(d=>d.SortOrder))
            {
                Invoke(new Action(() =>
                {
                    flpAudio.Controls.Add(new Button
                    {
                        Text = file.NickName,
                        Width = 175,
                        Height = 100,
                        ContextMenuStrip = cmsContext
                    });
                    Refresh();
                }));

                
            }


            statusLabel.Text = "Ready";
        }

        private void ctxRename_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (sender as ToolStripItem);
            if (item != null)
            {
                ContextMenuStrip owner = item.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    string input = Interaction.InputBox("Enter new name for audio clip", "Rename", owner.SourceControl.Text);

                    var selectedClip = Model.AudioClips.FirstOrDefault(d => d.NickName == owner.SourceControl.Text);
                    selectedClip.NickName = input;
                    Model.SaveChanges(ConfigPath);
                    owner.SourceControl.Text = input;
                }
            }

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
                        var selectedClip = Model.AudioClips.FirstOrDefault(d => d.NickName == owner.SourceControl.Text);
                        Model.AudioClips.Remove(selectedClip);
                        Model.SaveChanges(ConfigPath);

                        Thread thread1 = new Thread(LoadAudio);
                        thread1.Start();
                    }
                    
                    
                }
            }
        }
    }
}
