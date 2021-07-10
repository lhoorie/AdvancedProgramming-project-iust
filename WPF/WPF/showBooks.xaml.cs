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
using System.Collections.ObjectModel;


namespace WPF
{
    /// <summary>
    /// Interaction logic for showBooks.xaml
    /// </summary>
    public partial class showBooks : Window
    {
        public ObservableCollection<Book> bookListToShow { get; set; } = Book.booksList();
        
        public showBooks()
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

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPnl adminPnl = new AdminPnl();
            adminPnl.Show();
            this.Close();
        }
    }
}
