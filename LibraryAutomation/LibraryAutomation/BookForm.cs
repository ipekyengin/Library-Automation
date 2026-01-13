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
    public partial class BookForm : Form
    {
        private BookService bookService;
        private CategoryDAL categoryDAL;
        private Form _mainForm;

        public BookForm(Form mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            bookService = new BookService();
            categoryDAL = new CategoryDAL();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _mainForm.Show();
            base.OnFormClosed(e);
        }


        private void BookForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadBooks();
        }

        void LoadCategories()
        {
            cmbCategory.DataSource = categoryDAL.GetAllCategories();
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
        }

        void LoadBooks()
        {
            dgvBooks.DataSource = bookService.GetBooks();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Book book = new Book
            {
                ISBN = txtISBN.Text,
                Name = txtName.Text,
                Author = txtAuthor.Text,
                Publisher = txtPublisher.Text,
                PublishYear = int.Parse(txtPublishYear.Text),
                Stock = int.Parse(txtStock.Text),
                CategoryId = Convert.ToInt32(cmbCategory.SelectedValue)
            };

            bool result = bookService.AddBook(book);

            if (result)
            {
                MessageBox.Show("Kitap başarıyla eklendi.");
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Eksik veya hatalı bilgi.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek kitabı seçin.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bu kitabı silmek istediğinize emin misiniz?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["Id"].Value);

            bool success = bookService.DeleteBook(bookId);

            if (success)
            {
                MessageBox.Show("Kitap silindi.");
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Silme işlemi başarısız.");
            }
        }
    }
}
