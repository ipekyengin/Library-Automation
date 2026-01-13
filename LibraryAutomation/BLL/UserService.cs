using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EntityLayer;

namespace BLL
{
    public class UserService
    {
        private UserDAL userDAL;

        public UserService()
        {
            userDAL = new UserDAL();
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            return userDAL.GetUserByUsernameAndPassword(username, password);
        }
    }
}