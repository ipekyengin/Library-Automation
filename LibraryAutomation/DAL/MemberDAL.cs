using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using EntityLayer;

namespace DAL
{
    public class MemberDAL
    {
        public List<Member> GetAllMembers()
        {
            List<Member> members = new List<Member>();

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"SELECT id, user_id, first_name, last_name, phone, email, membership_date 
                         FROM members";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    members.Add(new Member
                    {
                        Id = reader.GetInt32(0),          // id
                        UserId = reader.GetInt32(1),      // user_id
                        FirstName = reader.GetString(2),  // first_name
                        LastName = reader.GetString(3),   // last_name
                        Phone = reader.IsDBNull(4) ? "" : reader.GetString(4), // phone
                        Email = reader.IsDBNull(5) ? "" : reader.GetString(5), // email
                        MembershipDate = reader.GetDateTime(6) // membership_date
                    });
                }
            }

            return members;
        }

        public void AddMember(Member member)
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"INSERT INTO members 
                                (user_id, first_name, last_name, phone, email, membership_date)
                                VALUES 
                                (@userId, @firstName, @lastName, @phone, @email, @date)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", member.UserId);
                cmd.Parameters.AddWithValue("@firstName", member.FirstName);
                cmd.Parameters.AddWithValue("@lastName", member.LastName);
                cmd.Parameters.AddWithValue("@phone", member.Phone);
                cmd.Parameters.AddWithValue("@email", member.Email);
                cmd.Parameters.AddWithValue("@date", member.MembershipDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteMember(int memberId)
        {
            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                string query = @"DELETE FROM members WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", memberId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
