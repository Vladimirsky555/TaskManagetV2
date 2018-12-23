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

        public Timer_form()
        {
            InitializeComponent();

            var d = DateTime.Now;
            d = d.AddMilliseconds(3000);

            times.Add(d);

            d = DateTime.Now;
            d = d.AddMilliseconds(5000);

            times.Add(d);

            main_timer.Interval = 1000;
            main_timer.Tick += Main_timer_Tick;
            main_timer.Start();
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
                MessageBox.Show("asdfasdf");
            }
            main_timer.Start();
            th.ReleaseMutex();
        }
    }
}
