using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EntityLayer;

namespace BLL
{
    public class MemberService
    {
        public List<Member> GetMembers()
        {
            return memberDAL.GetAllMembers();
        }

        private UserDAL userDAL;
        private MemberDAL memberDAL;

        public MemberService()
        {
            userDAL = new UserDAL();
            memberDAL = new MemberDAL();
        }

        public bool AddMemberWithUser(
            string username,
            string password,
            Member member)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(member.FirstName) ||
                string.IsNullOrWhiteSpace(member.LastName))
            {
                return false;
            }

            int userId = userDAL.AddUser(username, password, "Member");

            member.UserId = userId;
            member.MembershipDate = DateTime.Now;

            memberDAL.AddMember(member);
            return true;
        }

        public bool DeleteMember(int memberId, int userId)
        {
            if (memberId <= 0 || userId <= 0)
                return false;

            memberDAL.DeleteMember(memberId);
            userDAL.DeleteUser(userId);

            return true;
        }
    }
}
