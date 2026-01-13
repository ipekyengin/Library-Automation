using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using EntityLayer;

namespace BLL
{
    public class BookService
    {
        private BookDAL bookDAL;

        public BookService()
        {
            bookDAL = new BookDAL();
        }

        public bool AddBook(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.ISBN) ||
                string.IsNullOrWhiteSpace(book.Name) ||
            book.Stock < 0)
            {
                return false;
            }

            bookDAL.AddBook(book);
            return true;
        }

        public List<Book> GetBooks()
        {
            return bookDAL.GetAllBooks();
        }

        public bool DeleteBook(int bookId)
        {
            if (bookId <= 0)
                return false;

            bookDAL.DeleteBook(bookId);
            return true;
        }
    }
}
