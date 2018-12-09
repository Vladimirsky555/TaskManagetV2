using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using TaskManagetV2.Model;
using TaskManagetV2.Forms;

namespace TaskManagetV2
{
    public partial class CreateNewUser : Form
    {

        public Login.UserDelegate userDelegate;
        int i = 0;
        User user = new User();
        public CreateNewUser(Login.UserDelegate _userDelegate)
        {
            InitializeComponent();
            userDelegate = _userDelegate;
            Init();
        }

        private void Init()
        {
            Type type = user.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();

            foreach (PropertyInfo info in propertyInfos)
            {
                if (info.PropertyType != typeof(string)) continue;
                Controls.Add(new Label()
                {
                    Text = info.Name,
                    Top = i * 40 + 5,
                    Left = 5,
                    Width = 80
                }
                );
                Controls.Add(new TextBox()
                {
                    Top = i * 40 + 5,
                    Left = 100,
                    Width = 150,
                    Tag = info
                }
                );
                i++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Control control in Controls)
            {
                if(control is TextBox)
                {
                    PropertyInfo p = (PropertyInfo)control.Tag;
                    if (p.GetType() != typeof(string)) continue;
                    p.SetValue(user, control.Text);
                }
            }

            userDelegate(user);
            Close();
        }
    }
}
