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
            Invoke(new Action(() =>
            {
                flpAudio.Controls.Clear();
                flpAudio.AllowDrop = true;
                

            }));


            foreach (var file in Model.Music.OrderBy(d=>d.SortOrder))
            {
                Invoke(new Action(() =>
                {
                    TagLib.File tagFile = TagLib.File.Create(file.FileName);
                    var newButton = new Button
                    {
                        Text = tagFile.Tag.Title + Environment.NewLine + string.Join(",", tagFile.Tag.Performers),
                        Width = flpAudio.Width - 10,
                        Height = 100,
                        ContextMenuStrip = cmsContext,
                        TextAlign = ContentAlignment.MiddleLeft,
                        AllowDrop = true,
                        Tag = file.FileName
                    };
                    newButton.MouseDown += NewButton_MouseDown;
                    newButton.DragOver += NewButton_DragOver;
                    flpAudio.Controls.Add(newButton);
                    Refresh();
                }));

                
            }


            statusLabel.Text = "Ready";
        }

        private void NewButton_DragOver(object sender, DragEventArgs e)
        {
            base.OnDragOver(e);
            // is another dragable
            if (e.Data.GetData(typeof(Button)) != null)
            {
                FlowLayoutPanel p = (FlowLayoutPanel)(sender as Button).Parent;
                //Current Position             
                int myIndex = p.Controls.GetChildIndex((sender as Button));

                //Dragged to control to location of next picturebox
                Button q = (Button)e.Data.GetData(typeof(Button));
                p.Controls.SetChildIndex(q, myIndex);
            }

        }

        private void NewButton_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            DoDragDrop(sender, DragDropEffects.All);

            int i = 1;

            foreach (var item in flpAudio.Controls)
            {
                var thisItem = Model.Music.FirstOrDefault(d => d.FileName == (item as Button).Tag.ToString());
                thisItem.SortOrder = i;
                i++;
            }

            Model.SaveChanges(ConfigPath);
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
