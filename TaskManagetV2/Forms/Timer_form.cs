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
using TaskManagetV2.Services;

namespace TaskManagetV2.Forms
{
    public partial class Timer_form : Form
    {
        ITimer timer;

        public Timer_form(ITimer timer)
        {
            InitializeComponent();

            this.timer = timer;
            this.timer.UpdateAll();

            this.timer.DeleteDelegate += Timer_DeleteDelegate;

            foreach (var item in timer.GetAll())
                tlp_main.Controls.Add(item);
        }

        private void Timer_DeleteDelegate(AlarmRow e)
        {
            tlp_main.Controls.Remove(e);
        }

        //Mutex th = new Mutex();

        //List<MessageForm> messages = new List<MessageForm>();


        //private void startNew()
        //{
        //    main_timer.Stop();

        //    if (tlp_main.Controls.Count == 0) return;

        //    var arr = GetAlarmArray()
        //                    .Where(f => f.IsEdited == false);
        //    if (arr.Count() == 0) return;

        //    DateTime t = arr.Min(f => f.StartDate);
        //    int tmp = (int)(t - DateTime.Now).TotalMilliseconds;
        //    if (tmp <= 0) tmp = 100;
        //    main_timer.Interval = tmp;
        //    main_timer.Start();
        //}

        //private IEnumerable<AlarmRow> GetAlarmArray()
        //{
        //    List<AlarmRow> arr = new List<AlarmRow>();
        //    foreach (var element in tlp_main.Controls)
        //        arr.Add((AlarmRow)element);

        //    return arr;
        //}


        //private void Main_timer_Tick(object sender, EventArgs e)
        //{
        //    th.WaitOne();
        //    main_timer.Stop();
        //    List<AlarmRow> arr = new List<AlarmRow>();

        //    var tarr = GetAlarmArray()
        //                        .Where(f => f.IsEdited == false);
        //    if (tarr.Count() == 0) {
        //        th.ReleaseMutex();
        //        return;
        //    }

        //    foreach (var item in tarr)
        //    {
        //        var tmp = DateTime.Now;

        //        if (item.StartDate <= tmp)
        //        {
        //            arr.Add(item);
        //        }
        //    }

        //    foreach (var item in arr)
        //    {
        //        tlp_main.Controls.Remove(item);
        //    }

        //    foreach (var item in arr)
        //    {
        //        var box = new MessageForm(item.Message, closeDelegate);
        //        messages.Add(box);
        //        box.Show();

        //    }
        //    th.ReleaseMutex();

        //    startNew();
        //}

        //void closeDelegate(MessageForm sender)
        //{
        //    messages.Remove(sender);
        //}

        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    base.OnClosing(e);

        //    main_timer.Stop();
        //    foreach (var element in messages.ToArray())
        //        element.Close();
        //}

        private void btn_add_Click(object sender, EventArgs e)
        {
            var element = new AlarmRow();
            element.OnDelete = OnItemDelete;
            element.OnEdit = OnItemEdit;

            tlp_main.Controls.Add(element);
            timer.AddTask(element);
        }

        void OnItemDelete (AlarmRow element)
        {
            tlp_main.Controls.Remove(element);
            timer.RemoveTask(element);
            timer.UpdateAll();
        }

        void OnItemEdit(AlarmRow element)
        {
            timer.UpdateAll();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            while (tlp_main.Controls.Count > 0)
            {
                //var el = tlp_main.Controls[0];
                tlp_main.Controls.RemoveAt(0);
                //el.Dispose();
            }

            base.OnClosing(e);
        }
    }
}
