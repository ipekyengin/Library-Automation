using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class BookDAL
    {
        public void UpdateStock(int bookId, int change)
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"UPDATE books 
                         SET stock = stock + @change
                         WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@change", change);
                cmd.Parameters.AddWithValue("@id", bookId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void AddBook(Book book)
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"INSERT INTO books
                                (isbn, name, author, publisher, publish_year, stock, category_id)
                                VALUES
                                (@isbn, @name, @author, @publisher, @year, @stock, @categoryId)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@isbn", book.ISBN);
                cmd.Parameters.AddWithValue("@name", book.Name);
                cmd.Parameters.AddWithValue("@author", book.Author);
                cmd.Parameters.AddWithValue("@publisher", book.Publisher);
                cmd.Parameters.AddWithValue("@year", book.PublishYear);
                cmd.Parameters.AddWithValue("@stock", book.Stock);
                cmd.Parameters.AddWithValue("@categoryId", book.CategoryId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteBook(int bookId)
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = "DELETE FROM books WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", bookId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"SELECT id, isbn, name, author, publisher, publish_year, stock, category_id 
                             FROM books";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    books.Add(new Book
                    {
                        Id = reader.GetInt32(0),
                        ISBN = reader.GetString(1),
                        Name = reader.GetString(2),
                        Author = reader.GetString(3),
                        Publisher = reader.IsDBNull(4) ? "" : reader.GetString(4),
                        PublishYear = reader.GetInt32(5),
                        Stock = reader.GetInt32(6),
                        CategoryId = reader.GetInt32(7)
                    });
                }
            }

            return books;
        }
    }
}
