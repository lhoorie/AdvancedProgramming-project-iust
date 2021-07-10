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
    /// Interaction logic for IncreaseBalanceMember.xaml
    /// </summary>
    public partial class IncreaseBalanceMember : Window
    {
        public IncreaseBalanceMember()
        {
            InitializeComponent();
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
            MemberWallet memberWallet = new MemberWallet();
            memberWallet.Show();
            this.Close();
        }
    }
}
