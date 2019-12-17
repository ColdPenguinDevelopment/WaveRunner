using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using WaveRunner.Models;
using Microsoft.Win32;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace WaveRunner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Database.Interact.Init();

            LoadWindow();
        }

        private void LoadWindow()
        {
            var categories = Database.Interact.GetCategories();
            var files = Database.Interact.GetFiles();

            foreach (var cat in categories)
            {
                cat.AudioFiles = files.Where(d => d.Category == cat.CategoryName).ToList();
            }

            if (files.Any(d => string.IsNullOrWhiteSpace(d.Category)))
            {
                categories.Add(new Models.Category { CategoryName = "Unassigned", CategoryColor = "Black", AudioFiles = files.Where(d => string.IsNullOrWhiteSpace(d.Category)).ToList() });
            }

            grdFiles.ItemsSource = categories;
        }

        private void ManageCategories_Click(object sender, RoutedEventArgs e)
        {
            var manCat = new Windows.ManageCategories();

            manCat.ShowDialog();

            LoadWindow();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var manCat = new Windows.ManageAudioFile();

            manCat.ShowDialog();

            LoadWindow();
        }

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var file = (sender as Button).DataContext as AudioFile;


                if (outputDevice == null)
                {
                    outputDevice = new WaveOutEvent();
                    outputDevice.PlaybackStopped += OnPlaybackStopped;
                }
                if (audioFile == null)
                {
                    audioFile = new AudioFileReader(file.FilePath);
                    outputDevice.Init(audioFile);
                }
                outputDevice.Play();


                var ext = System.IO.Path.GetExtension(file.FilePath);

                //switch (ext)
                //{
                //    case ".mp3":
                //        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

                //        wplayer.URL = "My MP3 file.mp3";
                //        wplayer.Controls.Play();
                //        break;
                //    case ".wav":
                //        System.Media.SoundPlayer player = new System.Media.SoundPlayer(file.FilePath);
                //        player.Play();
                //        break;
                //}
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void mnuExport_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog openFolderDialog = new System.Windows.Forms.FolderBrowserDialog();

            if (openFolderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var src = (System.Windows.Application.Current as WaveRunner.App).DatabasePath;
                var dst = System.IO.Path.Combine(openFolderDialog.SelectedPath, "WaveRunner.json");

                File.Copy(src, dst, true);

                MessageBox.Show("WaveRunner.json exported to " + openFolderDialog.SelectedPath);
            }


        }

        private void mnuImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var dst = (System.Windows.Application.Current as WaveRunner.App).DatabasePath;
                var src = openFileDialog.FileName;

                File.Copy(src, dst, true);

                MessageBox.Show("WaveRunner.json imported successfully.");

                LoadWindow();
            }
        }
    }
}
