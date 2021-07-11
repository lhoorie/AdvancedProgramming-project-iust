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
    /// Interaction logic for MemberPnl.xaml
    /// </summary>
    public partial class MemberPnl : Window
    {
        Member member;
        public MemberPnl(Member member)
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

        private void ShowBooksToMember_Click(object sender, RoutedEventArgs e)
        {
            showBooksToMember showBooksToMember = new showBooksToMember(member);
            showBooksToMember.Show();
            this.Close();
        }

        private void MyBooks_Click(object sender, RoutedEventArgs e)
        {
            MyBorrowedBooks myBorrowedBooks = new MyBorrowedBooks(member);
            myBorrowedBooks.Show();
            this.Close();
        }

        private void Membership_Click(object sender, RoutedEventArgs e)
        {
            MembershipInfo membershipInfo = new MembershipInfo(member);
            membershipInfo.Show();
            this.Close();
        }

        private void MemberWlt_Click(object sender, RoutedEventArgs e)
        {
            MemberWallet memberWallet = new MemberWallet(member);
            memberWallet.Show();
            this.Close();
        }

        private void EditMember_Click(object sender, RoutedEventArgs e)
        {
            editMemberInfo editmemberinfo = new editMemberInfo(member);
            editmemberinfo.Show();
            this.Close();
        }
    }
}
