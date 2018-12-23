using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagetV2.Model;

namespace TaskManagetV2.Forms
{
    public partial class Login : Form
    {
        public delegate void UserDelegate(User user);
        public UserDelegate userDelegate;

        public delegate bool ValidateDelegate(string login, string password);

        private ValidateDelegate closeDelegate;

        public Login(ValidateDelegate closeDelegate, UserDelegate _userDelegate)
        {
            InitializeComponent();
            userDelegate = _userDelegate;
            this.closeDelegate = closeDelegate;
        }

        private bool checkData()
        {
            bool isCorrect = true;

            if (string.IsNullOrWhiteSpace(tbxLogin.Text)) {
                tbxLogin.BackColor = Color.Red;
                isCorrect = false;
            }
            if (string.IsNullOrWhiteSpace(tbxPassword.Text)) {
                tbxPassword.BackColor = Color.Red;
                isCorrect = false;
            }

            return isCorrect;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                if (closeDelegate(tbxLogin.Text, tbxPassword.Text))
                    btnCancel_Click(sender, e);
                else
                {
                    tbxLogin.BackColor = Color.Red;
                    tbxPassword.BackColor = Color.Red;
                    MessageBox.Show("Логин и/или пароль неверен!");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbxLogin_TextChanged(object sender, EventArgs e)
        {
            tbxLogin.BackColor = Color.White;
        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            tbxPassword.BackColor = Color.White;
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            new CreateNewUser(userDelegate).ShowDialog();
        }

        private void EnterPress(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return) btnOk_Click(sender, e);
        }
    }
}
