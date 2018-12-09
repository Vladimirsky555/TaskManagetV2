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

namespace TaskManagetV2
{
    public partial class Form1 : Form
    {
        private DBHolder DB { get; }
        public Form1()
        {
            InitializeComponent();

            DB = new DBHolder();

            //TODO вызвать окно логина
            //Забрать оттуда логин и пароль
            //Сохранить его в этом классе
            //Разблокировать pnlMain
        }
    }
}
