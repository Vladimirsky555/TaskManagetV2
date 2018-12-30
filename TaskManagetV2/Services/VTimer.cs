using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagetV2.Components;
using TaskManagetV2.Forms;

namespace TaskManagetV2.Services
{
    class VTimer : ITimer
    {

        Timer timer;
        List<AlarmRow> events = new List<AlarmRow>();

        public event DeleteEvent DeleteDelegate;

        public VTimer()
        {
            timer = new Timer();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            List<AlarmRow> arr = new List<AlarmRow>();

            var tarr = events.Where(f => f.IsEdited == false);
            if (tarr.Count() == 0)
            {
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
                events.Remove(item);
                DeleteDelegate(item);
            }

            foreach (var item in arr)
            {
                var box = new MessageForm(item.Message, closeDelegate);
                box.Show();

            }

            UpdateAll();
        }

        public void AddTask(AlarmRow element)
        {
            events.Add(element);
        }

        public void RemoveTask(AlarmRow element)
        {
            events.Remove(element);
            DeleteDelegate(element);
        }

        public IEnumerable<AlarmRow> GetAll()
        {
            return events.ToArray();
        }

        public void StopAll()
        {
            timer.Stop();
        }

        public void UpdateAll()
        {
            timer.Stop();

            if (events.Count == 0) return;

            var arr = events.Where(f => f.IsEdited == false);
            if (arr.Count() == 0) return;

            DateTime t = arr.Min(f => f.StartDate);
            int tmp = (int)(t - DateTime.Now).TotalMilliseconds;
            if (tmp <= 0) tmp = 100;
            timer.Interval = tmp;
            timer.Start();
        }


        void closeDelegate(MessageForm sender)
        {
            //messages.Remove(sender);
        }
    }
}
