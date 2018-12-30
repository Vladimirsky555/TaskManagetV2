using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagetV2.Components
{
    public partial class AlarmRow : UserControl
    {

        public delegate void DeleteElement (AlarmRow element);
        public delegate void EditedElement (AlarmRow element);

        public EditedElement OnEdit   { get; set; }
        public DeleteElement OnDelete { get; set; }


        public DateTime StartDate {
            get
            {
                return dtp_date.Value;
            }
            set
            {
                dtp_date.Value = value;
            }
        }
        public string Message {
            get
            {
                return tbx_text.Text;
            }
            set
            {
                tbx_text.Text = value;
            }
        }

        public bool IsEdited
        {
            get
            {
                return btn_save.Enabled;
            }
        }

        public AlarmRow()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = false;
            OnEdit?.Invoke(this);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            OnDelete?.Invoke(this);
        }

        private void tbx_text_TextChanged(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
        }

        private void dtp_date_ValueChanged(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
        }
    }
}
