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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Data;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 Register = new Window1();
            Register.Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Employee> employees = Employee.employeesList();
            ObservableCollection<Member> members = Member.membersList();

            string username = username_tb.Text.ToLower();
            string password = pass_tb.Password;
            bool isMatch = false;
            if (username == "admin" && password == "AdminLib123")
            {
                var admin = new AdminPnl();
                admin.Show();
                isMatch = true;
                this.Close();
            }
            if (!isMatch)
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    if (employees[i].userName.ToLower() == username && employees[i].password == password)
                    {
                        var emp = new EmployeePnl(employees[i]);
                        emp.Show();
                        isMatch = true;
                        this.Close();
                    }
                }
                if (!isMatch)
                {
                    for (int i = 0; i < members.Count; i++)
                    {
                        if (members[i].userName.ToLower() == username && members[i].password == password) 
                        {
                            var emp = new MemberPnl(members[i]);
                            emp.Show();
                            isMatch = true;
                            this.Close();
                        }
                    }
                }
            }
            if (!isMatch)
            {
                MessageBox.Show("Doesn't exist!");
            }
        }

    }
}
