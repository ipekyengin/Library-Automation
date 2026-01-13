using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // şimdilik plain, ileride hashlenebilir
        public string Role { get; set; }     // Admin, Staff, Member
        public DateTime CreatedAt { get; set; }
    }
}
