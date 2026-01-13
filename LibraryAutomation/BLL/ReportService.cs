using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ReportService
    {
        private ReportDAL reportDAL;

        public ReportService()
        {
            reportDAL = new ReportDAL();
        }

        public DataTable MostBorrowedBooks() => reportDAL.GetMostBorrowedBooks();
        public DataTable OverdueBooks() => reportDAL.GetOverdueBooks();
        public DataTable ActiveMembers() => reportDAL.GetActiveMembers();
        public DataTable BooksByCategory() => reportDAL.GetBooksByCategory();
        public DataTable MonthlyBorrowStats() => reportDAL.GetMonthlyBorrowStats();
    }
}
