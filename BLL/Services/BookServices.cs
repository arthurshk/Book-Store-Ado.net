using BLL.Interfaces;
using BLL.Models;

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

namespace BLL.Services
{
   public class BookServices : IBookService<BookInventory>
    {
        private SqlConnection _sqlConnection;
        public string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
       
        public BookServices()
        {
            _sqlConnection = new SqlConnection(connectionString);
        }

        public void Add(BookInventory value)
        {
            List<BookInventory> inventories = new List<BookInventory>();
            inventories = GetAll();
            try
            {
                _sqlConnection.Open();
                var commandInsertBook = new SqlCommand($"Insert Books values (@authorForename, @AuthorSurname, @title, @pageCount, @priceAmount)", _sqlConnection);
                commandInsertBook.Parameters.AddWithValue("@authorForename", value.authorForename);
                commandInsertBook.Parameters.AddWithValue("@AuthorSurname", value.AuthorSurname);
                commandInsertBook.Parameters.AddWithValue("@title", value.title);
                commandInsertBook.Parameters.AddWithValue("@pageCount", value.pages);
                commandInsertBook.Parameters.AddWithValue("@priceAmount", value.price);

                commandInsertBook.Transaction = _sqlConnection.BeginTransaction(IsolationLevel.Serializable);
                commandInsertBook.ExecuteNonQuery();
                commandInsertBook.Transaction.Save("a1");
                foreach (var item in inventories)
                {
                    if (item.authorForename == value.authorForename && item.AuthorSurname == value.AuthorSurname && item.title == value.title && item.pages == value.pages && item.price == value.price)
                    {
                        commandInsertBook.Transaction.Rollback("a1");
                        return;
                    }
                }
                commandInsertBook.Transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public void Delete(BookInventory value)
        {
            
            try
            {
                _sqlConnection.Open();
                SqlCommand deleteCommand = new SqlCommand($"DELETE FROM Books WHERE Title = @title", _sqlConnection);
                deleteCommand.Parameters.AddWithValue("@title", value.title);
                var result = deleteCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public List<BookInventory> Find(BookInventory book)
        {
            List<BookInventory> inventories = new List<BookInventory>();
            try
                {
                _sqlConnection.Open();
                
                SqlCommand findCommand = new SqlCommand($"SELECT * FROM Books WHERE Title = @title", _sqlConnection);
                findCommand.Parameters.AddWithValue("@title", book.title);
                var reader = findCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        BookInventory tempBook = new BookInventory()
                        {
                            Id = reader.GetFieldValue<int>(0),
                            authorForename = reader.GetFieldValue<string>(1),
                            AuthorSurname = reader.GetFieldValue<string>(2),
                            title = reader.GetFieldValue<string>(3),
                            pages = reader.GetFieldValue<int>(4),
                            price = reader.GetFieldValue<string>(5)
                        };
                        inventories.Add(tempBook);
                        
                    }
                }
            }
                catch (Exception ex)
                {
                    MessageBox.Show("Did not find any titles");
                }
                finally
                {
                _sqlConnection.Close();
                }
            return inventories;
        }

        public List<BookInventory> GetAll()
        {
            List<BookInventory> inventories = new List<BookInventory>();
            
            try
            {
                _sqlConnection.Open();
                var commandSelectBook = new SqlCommand(@"Select * from Books", _sqlConnection);
                var reader = commandSelectBook.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        BookInventory tempBook = new BookInventory()
                        {
                            Id = reader.GetFieldValue<int>(0),
                            authorForename = reader.GetFieldValue<string>(1),
                            AuthorSurname = reader.GetFieldValue<string>(2),
                            title = reader.GetFieldValue<string>(3),
                            pages = reader.GetFieldValue<int>(4),
                            price = reader.GetFieldValue<string>(5)
                            //,
                            //publisher = new PublisherInventory()
                            //{
                            //    publisherName = reader.GetFieldValue<string>(6),
                            //    publishingYear = reader.GetFieldValue<int>(7),
                            //    bookType = reader.GetFieldValue<string>(8),
                            //}
                        }; 
                        inventories.Add(tempBook);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }
            return inventories;
        }
    }
}
