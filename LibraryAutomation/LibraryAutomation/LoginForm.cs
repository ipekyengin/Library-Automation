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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            UserService userService = new UserService();

            User user = userService.Login(txtUsername.Text, txtPassword.Text);

            if (user == null)
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                return;
            }

            // Rol bazlı yönlendirme
            MainForm mainForm = new MainForm(user);
            mainForm.Show();
            this.Hide();
        }
    }
}
