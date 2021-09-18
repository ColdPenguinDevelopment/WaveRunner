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

namespace WaveRunnerV2
{
    public partial class MainWindow : Form
    {
        public string rootPath => Application.StartupPath;
        public string configPath => System.IO.Path.Combine(rootPath, "waverunnerv2config.json");
        public Models.ConfigModel configuration { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void VerifyConfigFile()
        {
            if (!System.IO.File.Exists(configPath))
            {
                var blankModel = new Models.ConfigModel();

                File.Create(configPath);
                File.WriteAllText(configPath, );
            }    
        }
    }
}
