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
    public class CategoryDAL
    {
        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = "SELECT id, name FROM categories";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categories.Add(new Category
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
            }

            return categories;
        }
    }
}
