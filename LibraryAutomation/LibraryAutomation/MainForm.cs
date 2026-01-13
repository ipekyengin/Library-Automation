using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;

namespace LibraryAutomation
{
    public partial class MainForm : Form
    {
        private User currentUser;

        // Login sonrası kullanılan constructor
        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ApplyRolePermissions();
        }

        private void ApplyRolePermissions()
        {
            // Admin: her şeye erişir
            if (currentUser.Role == "Admin")
            {
                return;
            }

            // Staff: üye yönetimi ve raporlar kapalı
            if (currentUser.Role == "Staff")
            {
                menuUserManagement.Visible = false;
                menuReports.Visible = false;
            }

            // Member: sadece kendi işlemleri
            if (currentUser.Role == "Member")
            {
                menuBookManagement.Visible = false;
                menuBorrow.Visible = false;
                menuUserManagement.Visible = false;
                menuReports.Visible = false;
            }
        }

        private void menuBookManagement_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm(this);
            this.Hide();
            bookForm.Show();
        }

        private void menuBorrow_Click(object sender, EventArgs e)
        {
            BorrowForm borrowForm = new BorrowForm(this);
            this.Hide();
            borrowForm.Show();
        }

        private void menuUserManagement_Click(object sender, EventArgs e)
        {
            MemberForm memberForm = new MemberForm(this);
            this.Hide();
            memberForm.Show();
        }

        private void menuReports_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm(this);
            this.Hide();
            reportForm.Show();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
