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
    public partial class MessageForm : Form
    {

        public delegate void closeDelegate(MessageForm sender);

        private closeDelegate resiver;

        public MessageForm(string message, closeDelegate resiver)
        {
            InitializeComponent();

            this.resiver = resiver;
            this.textBox1.Text = message;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            resiver?.Invoke(this);
            base.OnClosing(e);
        }
    }
}
