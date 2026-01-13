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
using EntityLayer;

namespace LibraryAutomation
{
    public partial class MemberForm : Form
    {
        private Form _mainForm;
        private MemberService memberService;

        public MemberForm(Form mainForm)
        {
            _mainForm = mainForm;
            memberService = new MemberService();
            InitializeComponent();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _mainForm.Show();
            base.OnFormClosed(e);
        }


        private void MemberForm_Load(object sender, EventArgs e)
        {
            LoadMembers();
        }
        void LoadMembers()
        {
            MemberService memberService = new MemberService();
            dgvMembers.DataSource = memberService.GetMembers();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MemberService memberService = new MemberService();

            Member member = new Member
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text
            };

            bool result = memberService.AddMemberWithUser(
                txtUsername.Text,
                txtPassword.Text,
                member);

            if (result)
            {
                MessageBox.Show("Üye başarıyla eklendi.");
                LoadMembers();
            }
            else
            {
                MessageBox.Show("Eksik veya hatalı bilgi girdiniz.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek üyeyi seçin.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bu üyeyi silmek istediğinize emin misiniz?",
                "Onay",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            int memberId = Convert.ToInt32(dgvMembers.SelectedRows[0].Cells["Id"].Value);
            int userId = Convert.ToInt32(dgvMembers.SelectedRows[0].Cells["UserId"].Value);

            bool success = memberService.DeleteMember(memberId, userId);

            if (success)
            {
                MessageBox.Show("Üye başarıyla silindi.");
                LoadMembers();
            }
            else
            {
                MessageBox.Show("Silme işlemi başarısız.");
            }
        }
    }
}
