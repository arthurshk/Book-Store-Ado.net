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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        RegistrationWindow registrationWindow = new RegistrationWindow
            ();
        MainWindow mainWindow = new MainWindow();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //this.Close();
            registrationWindow.ShowDialog();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(mainWindow.connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM registeredUsers WHERE username = '{logintb.Text}' AND password = '{passwordtb.Password}';", sqlConnection);
                    var reader = command.ExecuteReader();
                    if(reader.Read())
                    {
                        mainWindow.ShowDialog();
                    }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("USERNAME OR PASSWORD IS NOT CORRECT!!!");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
