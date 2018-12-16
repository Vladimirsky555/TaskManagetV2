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
    public partial class CreateEdit : Form
    {
        private User user { get; set; }

        public CreateEdit(User user)
        {
            InitializeComponent();

            this.user = user;
            tbxFIO.Text = user.FIO;
            tbxLogin.Text = user.Login;
            tbxNickname.Text = user.NickName;
            tbxPassword.Text = user.Password;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            user.FIO = string.IsNullOrWhiteSpace(tbxFIO.Text) ?  user.FIO : tbxFIO.Text;
            user.Login = string.IsNullOrWhiteSpace(tbxLogin.Text) ? user.Login : tbxLogin.Text;
            user.NickName = string.IsNullOrWhiteSpace(tbxNickname.Text) ? user.NickName : tbxNickname.Text;
            user.Password = string.IsNullOrWhiteSpace(tbxPassword.Text) ? user.Password : tbxPassword.Text;

            btnCancel_Click(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        } 
    }
}
