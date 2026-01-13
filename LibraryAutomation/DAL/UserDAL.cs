using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using EntityLayer;

namespace DAL
{
    public class UserDAL
    {
        public int AddUser(string username, string password, string role)
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"INSERT INTO users (username, password, role)
                         VALUES (@username, @password, @role);
                         SELECT LAST_INSERT_ID();";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@role", role);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void DeleteUser(int userId)
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"DELETE FROM users WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public User GetUserByUsernameAndPassword(string username, string password)
        {
            User user = null;

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"SELECT id, username, password, role, created_at 
                                 FROM users 
                                 WHERE username = @username AND password = @password";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            Id = reader.GetInt32("id"),
                            Username = reader.GetString("username"),
                            Password = reader.GetString("password"),
                            Role = reader.GetString("role"),
                            CreatedAt = reader.GetDateTime("created_at")
                        };
                    }
                }
            }
            return user;
        }
    }
}