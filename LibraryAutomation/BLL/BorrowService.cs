using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EntityLayer;

namespace BLL
{
    public class BorrowService
    {
        private BorrowDAL borrowDAL;
        private BookDAL bookDAL;

        public BorrowService()
        {
            borrowDAL = new BorrowDAL();
            bookDAL = new BookDAL();
        }

        public bool AddBorrow(Borrow borrow)
        {
            if (borrow.BookId <= 0 || borrow.MemberId <= 0)
                return false;

            borrowDAL.AddBorrow(borrow);
            bookDAL.UpdateStock(borrow.BookId, -1);

            return true;
        }

        public void ReturnBorrow(int borrowId, int bookId)
        {
            borrowDAL.ReturnBorrow(borrowId);
            bookDAL.UpdateStock(bookId, +1);
        }

        public List<Borrow> GetBorrows()
        {
            return borrowDAL.GetActiveBorrows();
        }
    }
}
