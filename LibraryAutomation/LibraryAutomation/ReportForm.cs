using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;


namespace LibraryAutomation
{
    public partial class ReportForm : Form
    {
        private Form _mainForm;

        public ReportForm(Form mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _mainForm.Show();
            base.OnFormClosed(e);
        }

        ReportService reportService = new ReportService();

        private void ReportForm_Load(object sender, EventArgs e)
        {

        }

        private void btnMostBorrowed_Click(object sender, EventArgs e)
        {
            dgvReport.DataSource = reportService.MostBorrowedBooks();
        }

        private void btnOverdue_Click(object sender, EventArgs e)
        {
            dgvReport.DataSource = reportService.OverdueBooks();
        }

        private void btnActiveMembers_Click(object sender, EventArgs e)
        {
            dgvReport.DataSource = reportService.ActiveMembers();
        }

        private void btnCategoryReport_Click(object sender, EventArgs e)
        {
            dgvReport.DataSource = reportService.BooksByCategory();
        }

        private void btnMonthlyStats_Click(object sender, EventArgs e)
        {
            dgvReport.DataSource = reportService.MonthlyBorrowStats();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }
    }
}
