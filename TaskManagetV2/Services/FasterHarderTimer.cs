using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using TaskManagetV2.Components;
using TaskManagetV2.Forms;

namespace TaskManagetV2.Services
{
    class FasterHarderTimer : ITimer
    {
        private System.Windows.Forms.Timer _timer;
        Mutex th = new Mutex();

        List<MessageForm> messages = new List<MessageForm>();
        List<AlarmRow> tList = new List<AlarmRow>();

        public FasterHarderTimer()
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += new EventHandler(Main_timer_Tick);
        }

        public void AddTask(AlarmRow element)
        {
            tList.Add(element);
        }

        public IEnumerable<AlarmRow> GetAll()
        {
            return tList;
        }

        public void RemoveTask(AlarmRow element)
        {
            tList.Remove(element);
        }

        public void StopAll()
        {
            tList.Clear();
        }

        public void UpdateAll()
        {
            _timer.Stop();

            if (tList.Count == 0) return;

            var arr = GetAlarmArray()
                            .Where(f => f.IsEdited == false);
            if (arr.Count() == 0) return;

            DateTime t = arr.Min(f => f.StartDate);
            int tmp = (int)(t - DateTime.Now).TotalMilliseconds;
            if (tmp <= 0) tmp = 100;
            _timer.Interval = tmp;
            _timer.Start();
        }

        private IEnumerable<AlarmRow> GetAlarmArray()
        {
            List<AlarmRow> arr = new List<AlarmRow>();
            foreach (var element in tList)
                arr.Add((AlarmRow)element);

            return arr;
        }

        private void Main_timer_Tick(object sender, EventArgs e)
        {
            th.WaitOne();
            _timer.Stop();
            List<AlarmRow> arr = new List<AlarmRow>();

            var tarr = GetAlarmArray()
                                .Where(f => f.IsEdited == false);
            if (tarr.Count() == 0)
            {
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
                RemoveTask(item);
            }

            foreach (var item in arr)
            {
                var box = new MessageForm(item.Message, closeDelegate);
                messages.Add(box);
                box.Show();

            }
            th.ReleaseMutex();

            UpdateAll();
        }

        void closeDelegate(MessageForm sender)
        {
            messages.Remove(sender);
        }
    }
}
