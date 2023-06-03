using DLL.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace BookStoreAdo.NetProject.Windows
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        MainWindow mainWindow = new MainWindow();
        People people = new People();
        User user = new User();
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            user.Login = logintb.Text;
            user.Password = passwordtb.Text;
            people.Name = nametb.Text;
            people.LastName = lastNametb.Text;
            people.Gender = gendercb.Text;
            people.Birthday = birsdayc.DisplayDate;
            people.Phone = phonetb.Text;
            people.Email = emailtb.Text;

            Register(user.Login, user.Password, people.Name, people.LastName, people.Gender, people.Birthday,people.Phone,people.Email);
            MessageBox.Show($"User {people.Name} {people.LastName} has been created!");
            this.Close();
        }
     
        private void Register(string user, string password, string first, string last, string gender, DateTime birthday, string phone, string email)
        {
            using (SqlConnection sqlConnection = new SqlConnection(mainWindow.connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand($"INSERT INTO registeredUsers(username, password, firstName, lastName, Gender, Birthday, phone, email) VALUES ('{user}', '{password}', '{first}', '{last}', '{gender}', '{birthday}', '{phone}', '{email}');", sqlConnection);
                    command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("USERNAME OR PASSWORD IS NOT CORRECT");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
