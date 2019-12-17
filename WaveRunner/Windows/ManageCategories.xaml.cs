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
    /// Interaction logic for ManageCategories.xaml
    /// </summary>
    public partial class ManageCategories : Window
    {
        public ObservableCollection<Category> CategoryList { get; set; }
        public ManageCategories()
        {
            InitializeComponent();
            var categories = Database.Interact.GetCategories();

            CategoryList = new ObservableCollection<Category>(categories);
            lstCategories.ItemsSource = CategoryList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Database.Interact.SaveNewCategory(new Category { CategoryName = txtCategory.Text, CategoryColor = txtCategoryColor.Text });
            
            txtCategory.Text = string.Empty;
            txtCategoryColor.Text = string.Empty;
            txtCategory.Focus();
            txtCategoryColor.Focus();
            lstCategories.Focus();

            Refresh();
        }

        private void lstCategories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = lstCategories.SelectedItem as Category;
            Database.Interact.RemoveCategory(item.CategoryName);

            Refresh();

        }

        private void Refresh()
        {
            var categories = Database.Interact.GetCategories();
            CategoryList = new ObservableCollection<Category>(categories);
            lstCategories.ItemsSource = CategoryList;
            lstCategories.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
