using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ReportDAL
    {
        // 1. En Çok Ödünç Alınan Kitaplar
        public DataTable GetMostBorrowedBooks()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"
                    SELECT bk.name AS BookName, COUNT(*) AS BorrowCount
                    FROM borrows b
                    JOIN books bk ON b.book_id = bk.id
                    GROUP BY bk.name
                    ORDER BY BorrowCount DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 2. Geciken Kitaplar
        public DataTable GetOverdueBooks()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"
                    SELECT bk.name AS BookName,
                           CONCAT(m.first_name,' ',m.last_name) AS Member,
                           b.due_date
                    FROM borrows b
                    JOIN books bk ON b.book_id = bk.id
                    JOIN members m ON b.member_id = m.id
                    WHERE b.return_date IS NULL
                      AND b.due_date < CURDATE()";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 3. Aktif Üyeler
        public DataTable GetActiveMembers()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"
                    SELECT CONCAT(m.first_name,' ',m.last_name) AS Member,
                           COUNT(*) AS BorrowCount
                    FROM borrows b
                    JOIN members m ON b.member_id = m.id
                    GROUP BY m.id
                    ORDER BY BorrowCount DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 4. Kategori Bazlı Kitap Sayısı
        public DataTable GetBooksByCategory()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"
                    SELECT c.name AS Category, COUNT(b.id) AS BookCount
                    FROM categories c
                    LEFT JOIN books b ON b.category_id = c.id
                    GROUP BY c.name";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 5. Aylık Ödünç Alma İstatistiği
        public DataTable GetMonthlyBorrowStats()
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"
                    SELECT DATE_FORMAT(borrow_date, '%Y-%m') AS Month,
                           COUNT(*) AS Total
                    FROM borrows
                    GROUP BY Month
                    ORDER BY Month";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
