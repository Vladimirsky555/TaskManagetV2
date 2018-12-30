using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagetV2.Components;

namespace TaskManagetV2.Forms
{
    public partial class Timer_form : Form
    {
        Mutex th = new Mutex();

        List<MessageForm> messages = new List<MessageForm>();


        private void startNew()
        {
            main_timer.Stop();

            if (tlp_main.Controls.Count == 0) return;

            var arr = GetAlarmArray()
                            .Where(f => f.IsEdited == false);
            if (arr.Count() == 0) return;

            DateTime t = arr.Min(f => f.StartDate);
            int tmp = (int)(t - DateTime.Now).TotalMilliseconds;
            if (tmp <= 0) tmp = 100;
            main_timer.Interval = tmp;
            main_timer.Start();
        }

        private IEnumerable<AlarmRow> GetAlarmArray()
        {
            List<AlarmRow> arr = new List<AlarmRow>();
            foreach (var element in tlp_main.Controls)
                arr.Add((AlarmRow)element);

            return arr;
        }

        public Timer_form()
        {
            InitializeComponent();

            startNew();
        }

        private void Main_timer_Tick(object sender, EventArgs e)
        {
            th.WaitOne();
            main_timer.Stop();
            List<AlarmRow> arr = new List<AlarmRow>();

            var tarr = GetAlarmArray()
                                .Where(f => f.IsEdited == false);
            if (tarr.Count() == 0) {
                th.ReleaseMutex();
                return;
            }

            foreach (var item in tarr)
            {
                var tmp = DateTime.Now;

                if (item.StartDate <= tmp)
                {
                    arr.Add(item);
                }
            }

            foreach (var item in arr)
            {
                tlp_main.Controls.Remove(item);
            }

            foreach (var item in arr)
            {
                var box = new MessageForm(item.Message, closeDelegate);
                messages.Add(box);
                box.Show();

            }
            th.ReleaseMutex();

            startNew();
        }

        void closeDelegate(MessageForm sender)
        {
            messages.Remove(sender);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            main_timer.Stop();
            foreach (var element in messages.ToArray())
                element.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var element = new AlarmRow();
            element.OnDelete = OnItemDelete;
            element.OnEdit = OnItemEdit;

            tlp_main.Controls.Add(element);
        }

        void OnItemDelete (AlarmRow element)
        {
            tlp_main.Controls.Remove(element);
            startNew();
        }

        void OnItemEdit(AlarmRow element)
        {
            startNew();
        }
    }
}
