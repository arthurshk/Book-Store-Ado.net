using BLL.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookStoreAdo.NetProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        private BookServices bookServices;
        public MainWindow()
        {
            InitializeComponent();
            generateDB();
        }
        private void generateDB()
        {
            bookServices = new BookServices();
        }

        private void addBookbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(bookNametxt.Text) && !String.IsNullOrEmpty(authorNametxt.Text) && !String.IsNullOrEmpty(authorSurnametxt.Text))
                {
                    BookInventory tempBook = new BookInventory() { authorForename = authorNametxt.Text, AuthorSurname = authorSurnametxt.Text, title = bookNametxt.Text, pages = Convert.ToInt32(pgstxt.Text), price = pricetxt.Text };
                    bookServices.Add(tempBook);
                    ClearTextBox();
                    dgInfo.ItemsSource = bookServices.GetAll();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Record already exists!");
            }
           
        }
        private void ClearTextBox()
        {
            bookNametxt.Text = "";
            authorNametxt.Text = "";
            authorSurnametxt.Text = "";
            pgstxt.Text = "";
            pricetxt.Text = "";
        }

        private void deleteBookbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(bookNametxt.Text))
                {
                    
                    BookInventory tempbook = new BookInventory() { title = bookNametxt.Text };
                    bookServices.Delete(tempbook);
                    dgInfo.ItemsSource = bookServices.GetAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Book cannot be deleted!");
            }
        }

        private void findBookbtn_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (!String.IsNullOrEmpty(bookNametxt.Text))
                {
                   
                    BookInventory tempbook = new BookInventory() { title = bookNametxt.Text };
                    dgInfo.ItemsSource = bookServices.Find(tempbook);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Book not found!");
            }
        }
        private void showAllbtn_Click(object sender, RoutedEventArgs e)
        {
            this.dgInfo.ItemsSource = bookServices.GetAll();
        }
    }
}
