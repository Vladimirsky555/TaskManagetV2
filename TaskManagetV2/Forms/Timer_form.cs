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

namespace TaskManagetV2.Forms
{
    public partial class Timer_form : Form
    {
        List<DateTime> times = new List<DateTime>();
        Mutex th = new Mutex();

        List<MessageForm> messages = new List<MessageForm>();

        private void initTimers()
        {
            var d = DateTime.Now;
            d = d.AddMilliseconds(3000);

            times.Add(d);

            d = DateTime.Now;
            d = d.AddMilliseconds(5000);

            times.Add(d);

            d = DateTime.Now;
            d = d.AddMilliseconds(8000);

            times.Add(d);

            d = DateTime.Now;
            d = d.AddMilliseconds(12000);

            times.Add(d);
        }


        private void startNew()
        {
            main_timer.Stop();

            if (times.Count == 0) return;

            DateTime t = times.Min();
            int tmp = (int)(t - DateTime.Now).TotalMilliseconds;
            if (tmp <= 0) tmp = 100;
            main_timer.Interval = (int)(t - DateTime.Now).TotalMilliseconds;
            main_timer.Start();
        }

        public Timer_form()
        {
            InitializeComponent();


            initTimers();
            startNew();
        }

        private void Main_timer_Tick(object sender, EventArgs e)
        {
            th.WaitOne();
            main_timer.Stop();
            List<DateTime> arr = new List<DateTime>();
            foreach (var item in times)
            {
                var tmp = DateTime.Now;

                if (item <= tmp)
                {
                    arr.Add(item);
                }
            }

            foreach (var item in arr)
            {
                times.Remove(item);
            }

            foreach (var item in arr)
            {
                var box = new MessageForm("Time Now " + item.ToLongTimeString(), closeDelegate);
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
    }
}
