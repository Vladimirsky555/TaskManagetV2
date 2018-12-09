using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagetV2.Forms
{
    public partial class Login : Form
    {
        public delegate bool ValidateDelegate(string login, string password);

        private ValidateDelegate closeDelegate;

        public Login(ValidateDelegate closeDelegate)
        {
            InitializeComponent();
            //TODO закончить инициализацию
        }

        private bool checkData()
        {
            //TODO сделатьл проверку на заполнение полей
            //Если поле не заполнено то подсветить его красным
            //Как только пользователь начнет в это поле что то вводить
            //То поле становится белым

            return false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //TODO Вызвать проверку на заполение
            //TODO опросить делегат
            //TODO вызвать btnCancel_Click
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //TODO закрыть окно
        }
    }
}
