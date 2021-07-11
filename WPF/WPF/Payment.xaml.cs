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
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        Member member;
        public Payment(Member member)
        {
            InitializeComponent();
            this.member = member;
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
            Window1 register = new Window1();
            register.Show();
            this.Close();
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            if (isValid())
            {
                MessageBox.Show("Done!");
                Member.addMember(member);
                MemberPnl memberPnl = new MemberPnl(member);
                memberPnl.Show();
                this.Close();
            }
        }

        bool isValid()
        {
            if (CVV2.Text.Length != 3 || CVV2.Text.Length != 4)
            {
                MessageBox.Show("CVV2 must have 3 or 4 digits!");
                return false;
            }
            List<int> digits = new List<int>();
            string cardNumber = First.Text + Second.Text + Third.Text + Fourth.Text;
            for (int i = 0; i < cardNumber.Length; i++) { digits.Add(int.Parse(cardNumber[i].ToString())); }
            for (int i = 0; i < digits.Count; i++)
            {
                if (i % 2 == 0) { digits[i] = digits[i] * 2; }
            }
            for (int i = 0; i < digits.Count; i++)
            {
                if (digits[i] > 9) { digits[i] = (digits[i] % 10) + 1; }
            }
            int sum = digits.Sum();
            if (sum % 10 != 0)
            {
                MessageBox.Show("Card Number is not valid!");
                return false;
            }
            return true;
        }
    }
}
