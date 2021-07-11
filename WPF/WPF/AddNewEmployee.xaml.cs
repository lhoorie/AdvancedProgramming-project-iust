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
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WPF
{
    /// <summary>
    /// Interaction logic for AddNewEmployee.xaml
    /// </summary>
    public partial class AddNewEmployee : Window
    {
        public AddNewEmployee()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            showEmployees showEmployees = new showEmployees();
            showEmployees.Show();
            this.Close();
        }
        private void ChoosePhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";
            if (fileDialog.ShowDialog() == true)
            {
                var uriSource = new Uri(System.IO.Path.GetFullPath(fileDialog.FileName));
                profile.Source = new BitmapImage(uriSource);
            }
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
