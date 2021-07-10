using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WPF
{
    public class User
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phoneNumebr { get; set; }
        public double balance { get; set; }
        public User(string userName, string password, string email, string phoneNumber, double balance)
        {
            this.balance = balance;
            this.userName = userName;
            this.password = password;
            this.email = email;
            this.phoneNumebr = phoneNumber;
        }
    }
    public class Admin : User
    {
        public Admin(string userName, string password, string email, string phoneNumber, double balance) : base(userName, password, email, phoneNumber, balance)
        {
        }
        static public string showBank()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Downloads\99002\AP\FinalProject\database\database.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string command = "select * from employeesTable";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            SqlCommand com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            con.Close();
            return dataTable.Rows[0][0].ToString();
        }
    }
    public class Employee : User
    {
        public Employee(string userName, string password, string email, string phoneNumber, double balance) : base(userName, password, email, phoneNumber, balance)
        {
        }
        static public ObservableCollection<Employee> employeesList()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Downloads\99002\AP\FinalProject\database\database.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string command = "select * from employeesTable";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            string userName, password, email, phoneNumber;
            double balance;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                userName = dataTable.Rows[i][0].ToString();
                password = dataTable.Rows[i][1].ToString();
                email = dataTable.Rows[i][2].ToString();
                phoneNumber = dataTable.Rows[i][3].ToString();
                balance = double.Parse(dataTable.Rows[i][4].ToString());
                Employee employee = new Employee(userName, password, email, phoneNumber, balance);
                employees.Add(employee);
            }
            SqlCommand com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            con.Close();
            return employees;
        }
    }
    public class Member : User
    {
        public bool delayedInReturn { get; set; }
        public bool delayedInPay { get; set; }
        public Member(string userName, string password, string email, string phoneNumber, double balance, bool dir, bool dip) : base(userName, password, email, phoneNumber, balance)
        {
            this.delayedInPay = dip;
            this.delayedInReturn = dir;
        }
        static public ObservableCollection<Member> membersList()
        {
            ObservableCollection<Member> members = new ObservableCollection<Member>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Downloads\99002\AP\FinalProject\database\database.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string command = "select * from membersTable";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            string userName, password, email, phoneNumber;
            double balance;
            bool dip, dir;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                userName = dataTable.Rows[i][0].ToString();
                password = dataTable.Rows[i][1].ToString();
                email = dataTable.Rows[i][2].ToString();
                phoneNumber = dataTable.Rows[i][3].ToString();
                balance = double.Parse(dataTable.Rows[i][4].ToString());
                dir = bool.Parse(dataTable.Rows[i][5].ToString());
                dip = bool.Parse(dataTable.Rows[i][6].ToString());
                Member member = new Member(userName, password, email, phoneNumber, balance, dir, dip);
                members.Add(member);
            }
            SqlCommand com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            con.Close();
            return members;
        }
    }
    public class Book
    {
        public string name { get; set; }
        public string writer { get; set; }
        public string genre { get; set; }
        public string bookNumber { get; set; }
        public string id { get; set; }
        public bool flag { get; set; }
        public Book(string id, string name, string writer, string genre, string bookNumber)
        {
            this.name = name;
            this.writer = writer;
            this.genre = genre;
            this.bookNumber = bookNumber;
            this.id = id;
            this.flag = false;
        }
        static public ObservableCollection<Book> booksList()
        {
            ObservableCollection<Book> books = new ObservableCollection<Book>();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Downloads\99002\AP\FinalProject\database\database.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            string command = "select * from booksTable";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            string id, name, writer, genre, bookNumber;
            for(int i=0; i < dataTable.Rows.Count; i++)
            {
                id = dataTable.Rows[i][0].ToString();
                name = dataTable.Rows[i][1].ToString();
                writer = dataTable.Rows[i][2].ToString();
                genre = dataTable.Rows[i][3].ToString();
                bookNumber = dataTable.Rows[i][4].ToString();
                Book book = new Book(id, name, writer, genre, bookNumber);
                books.Add(book);
            }
            SqlCommand com = new SqlCommand(command, con);
            com.BeginExecuteNonQuery();
            con.Close();
            return books;
        }
    }
    public class aux
    {
        //static public bool isUsernameExisted(string username,string password)
        //{
        //    bool flag;
        //    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Downloads\99002\AP\FinalProject\database\database.mdf;Integrated Security=True;Connect Timeout=30");
        //    con.Open();
        //    string command = "select * from membersTable where username = '" + username + "' AND password = '" + password + "'";
        //    SqlDataAdapter adapter = new SqlDataAdapter(command, con);
        //    DataTable dataTable = new DataTable();
        //    adapter.Fill(dataTable);
        //    SqlCommand com = new SqlCommand(command, con);
        //    com.BeginExecuteNonQuery();
        //    con.Close();
        //}
        //static public Member returnMember(string username)
        //{

        //}
        //static public Employee returnEmployee(string username)
        //{

        //}
        //static public bool userNameIsValid(string username)
        //{

        //}
        //static public bool emailIsValid(string email)
        //{

        //}
        //static public bool phoneNumberIsValid(string phoneNumber)
        //{

        //}
        //static public bool passwordIsValid(string password)
        //{

        //}
        //static public bool cvv2IsValid(string cvv2)
        //{
        //    if(cvv2.Length == 3 || cvv2.Length == 4) { return true; }
        //    return false;
        //}
        //static public bool cardNumberIsValid(string cardNumber)
        //{
        //    List<int> digits = new List<int>();
        //    for(int i = 0; i < cardNumber.Length; i++) { digits.Add(int.Parse(cardNumber[i].ToString())); }
        //    for(int i = 0; i < digits.Count; i++)
        //    {
        //        if (i % 2 == 0) { digits[i] = digits[i] * 2; }
        //    }
        //    for(int i = 0; i < digits.Count; i++)
        //    {
        //        if (digits[i] > 9) { digits[i] = (digits[i] % 10) + 1; }
        //    }
        //    int sum = digits.Sum();
        //    if (sum % 10 == 0) { return true; }
        //    else { return false; }
        //}
        //static public bool expirationDateIsValid(string year,string month)
        //{

        //}
    }
}

