using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using EntityLayer;

namespace LibraryAutomation
{
    public partial class BorrowForm : Form
    {
        private BorrowService borrowService;
        private BookService bookService;
        private MemberService memberService;

        private List<Book> books;
        private List<Member> members;

        private Form _mainForm;

        public BorrowForm(Form mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            borrowService = new BorrowService();
            bookService = new BookService();
            memberService = new MemberService();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _mainForm.Show();
            base.OnFormClosed(e);
        }


        private void BorrowForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadMembers();
            LoadBorrows();
        }

        private void LoadBooks()
        {
            books = bookService.GetBooks();
            cmbBook.DataSource = books;
            cmbBook.DisplayMember = "Name";
            cmbBook.ValueMember = "Id";
            cmbBook.SelectedIndex = -1;
        }

        private void LoadMembers()
        {
            members = memberService.GetMembers();
            cmbMember.DataSource = members;
            cmbMember.DisplayMember = "FirstName";
            cmbMember.ValueMember = "Id";
            cmbMember.SelectedIndex = -1;
        }

        private void LoadBorrows()
        {
            dgvBorrows.DataSource = null;
            dgvBorrows.DataSource = borrowService.GetBorrows();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (cmbBook.SelectedIndex == -1 || cmbMember.SelectedIndex == -1)
            {
                MessageBox.Show("Kitap ve üye seçmelisiniz.");
                return;
            }

            Borrow borrow = new Borrow
            {
                BookId = (int)cmbBook.SelectedValue,
                MemberId = (int)cmbMember.SelectedValue,
                DueDate = dtpDueDate.Value
            };

            bool result = borrowService.AddBorrow(borrow);

            if (result)
            {
                MessageBox.Show("Kitap ödünç verildi.");
                LoadBorrows();
            }
            else
            {
                MessageBox.Show("İşlem başarısız.");
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvBorrows.CurrentRow == null)
                return;

            Borrow borrow = dgvBorrows.CurrentRow.DataBoundItem as Borrow;

            borrowService.ReturnBorrow(borrow.Id, borrow.BookId);

            MessageBox.Show("Kitap iade edildi.");
            LoadBorrows();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }
    }
}
