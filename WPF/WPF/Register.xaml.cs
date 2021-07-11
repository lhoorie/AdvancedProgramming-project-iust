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
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string ImageAddress = null;
        public Window1()
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
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            if (isValid())
            {
                Member member = new Member(name_tb.Text, pass_tb.Password, email_tb.Text, phoneNumber_tb.Text, 0, false, false, ImageAddress, DateTime.Now.ToString("dd/MM/yyyy"));
                if (!Member.existMember(member))
                {
                    Payment payment = new Payment(member);
                    payment.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You have already registered!");
                }
                
            }
        }

        private void ChoosePhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png";
            if (fileDialog.ShowDialog() == true)
            {
                ImageAddress = fileDialog.FileName;
                var uriSource = new Uri(System.IO.Path.GetFullPath(fileDialog.FileName));
                profile.Source = new BitmapImage(uriSource);
            }
        }
        private bool isValid()
        {
            //Check Name
            if (name_tb.Text == "")
            {
                MessageBox.Show("Please enter the name!");
                return false;
            }
            else if(!Regex.IsMatch(name_tb.Text, "^([A-z]|[a-z]){3,32}$", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Name must be from 3 to 32 letters!");
                return false;
            }
            //Check Email
            if (email_tb.Text == "")
            {
                MessageBox.Show("Please enter the email!");
                return false;
            }
            else
            {
                if (!Regex.IsMatch(email_tb.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                {
                    MessageBox.Show("Email is not in correct form!");
                    return false;
                }

            }
            //Check PhoneNumber
            if (phoneNumber_tb.Text == "")
            {
                System.Windows.MessageBox.Show("Please enter the phone number!");
                return false;
            }
            else
            {
                if (!Regex.IsMatch(phoneNumber_tb.Text, "^(09)\\d{9}$", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("Phone number is not in correcr form!");
                    return false;
                }
            }
            //Check Password
            if (pass_tb.Password != "")
            {
                if (!Regex.IsMatch(pass_tb.Password,"^(?=.*[a-z])(?=.*[A-Z])(?=.*)[a-zA-Z]{8,32}$", RegexOptions.IgnoreCase))
                {
                    MessageBox.Show("Password is not in correcr form!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Please enter the password!");
                return false;
            }
            if (ImageAddress == null)
            {
                MessageBox.Show("Please choose a profile Photo!");
                return false;
            }
            return true;
        }
    }
}
