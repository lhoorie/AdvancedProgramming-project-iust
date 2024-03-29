﻿using System;
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
    /// Interaction logic for showBooksToMember.xaml
    /// </summary>
    public partial class showBooksToMember : Window
    {
        Member member;
        public ObservableCollection<Book> bookListToShow { get; set; } = Book.booksList();
        public showBooksToMember(Member member)
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
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MemberPnl memberPnl = new MemberPnl(member);
            memberPnl.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BorrowBookButton_Click(object sender, RoutedEventArgs e)
        {
            BorrowBook borrowBook = new BorrowBook(member);
            borrowBook.Show();
            this.Close();
        }

        private void SearchBookButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
