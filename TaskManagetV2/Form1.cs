using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagetV2.Forms;
using TaskManagetV2.Model;

namespace TaskManagetV2
{
    public partial class Form1 : Form
    {
        private DBHolder DB { get; }
        User current = null;

        public Form1()
        {
            InitializeComponent();

            DB = new DBHolder();

            new Login((login, password) => {
                current = DB.Users.Where(f => f.Login == login && f.Password == password).FirstOrDefault();
                return current != null;
            }, CreateNew).ShowDialog();

            if (current == null)
                Close();//(ВЕЛОР)TODO разобраться
            else
                pnlMain.Enabled = true;

        }

        public void CreateNew(User user)
        {
            if (DB.Users.Contains(user)) return;
                DB.Users.Add(user);
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            //TODO Закончить окно редактирования / создания пользователя
        }

        private void btnEditAtricle_Click(object sender, EventArgs e)
        {
            //TODO Закончить окно редактирования / создания Заметки
        }
    }
}
