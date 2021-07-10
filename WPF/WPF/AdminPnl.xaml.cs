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

namespace WPF
{
    /// <summary>
    /// Interaction logic for AdminPnl.xaml
    /// </summary>
    public partial class AdminPnl : Window
    {
        public AdminPnl()
        {
            InitializeComponent();
        }

        private void AdminToEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Bank_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AdminToBooks_Click(object sender, RoutedEventArgs e)
        {
            showBooks showbook = new showBooks();
            showbook.Show();
            this.Close();
        }
    }
}
