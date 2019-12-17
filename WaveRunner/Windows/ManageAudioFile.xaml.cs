using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;
using WaveRunner.Models;
namespace WaveRunner.Windows
{
    /// <summary>
    /// Interaction logic for ManageAudioFile.xaml
    /// </summary>
    public partial class ManageAudioFile : Window
    {
        public ObservableCollection<AudioFile> AudioFileList { get; set; }

        public ManageAudioFile()
        {
            InitializeComponent();
            var files = Database.Interact.GetFiles();
            var categories = Database.Interact.GetCategories();

            AudioFileList = new ObservableCollection<AudioFile>(files);
            lstCategories.ItemsSource = AudioFileList;
            ddCatagories.ItemsSource = categories.Select(d => d.CategoryName);

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lstCategories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = lstCategories.SelectedItem as AudioFile;
            Database.Interact.RemoveFile(item.Title);

            Refresh();

        }

        private void Refresh()
        {
            var files = Database.Interact.GetFiles();
            AudioFileList = new ObservableCollection<AudioFile>(files);
            lstCategories.ItemsSource = AudioFileList;
            lstCategories.Items.Refresh();
        }

        private void txtPath_GotFocus(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtPath.Text = openFileDialog.FileName;
            }
        }

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            var aud = new AudioFile
            {
                Title = txtTitle.Text,
                Category = ddCatagories.SelectedItem.ToString(),
                FilePath = txtPath.Text
            };

            Database.Interact.SaveNewFile(aud);

            txtTitle.Text = string.Empty;
            ddCatagories.SelectedIndex = -1;
            txtPath.Text = String.Empty;

            Refresh();

        }
    }
}
