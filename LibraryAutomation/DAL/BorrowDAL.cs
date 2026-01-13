using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class BorrowDAL
    {
        public void AddBorrow(Borrow borrow)
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"INSERT INTO borrows
                                (book_id, member_id, borrow_date, due_date, return_date, is_returned)
                                VALUES
                                (@bookId, @memberId, @borrowDate, @dueDate, NULL, 0)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@bookId", borrow.BookId);
                cmd.Parameters.AddWithValue("@memberId", borrow.MemberId);
                cmd.Parameters.AddWithValue("@borrowDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@dueDate", borrow.DueDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void ReturnBorrow(int borrowId)
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"UPDATE borrows
                         SET 
                             return_date = @returnDate,
                             is_returned = 1
                         WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@returnDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@id", borrowId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public List<Borrow> GetActiveBorrows()
        {
            List<Borrow> borrows = new List<Borrow>();

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"SELECT id, book_id, member_id, borrow_date, due_date
                                 FROM borrows
                                 WHERE return_date IS NULL";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    borrows.Add(new Borrow
                    {
                        Id = reader.GetInt32(0),
                        BookId = reader.GetInt32(1),
                        MemberId = reader.GetInt32(2),
                        BorrowDate = reader.GetDateTime(3),
                        DueDate = reader.GetDateTime(4),
                        isReturned = false
                    });
                }
            }

            return borrows;
        }
    }
}
