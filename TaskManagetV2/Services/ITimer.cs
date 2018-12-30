using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagetV2.Components;

namespace TaskManagetV2.Services
{
    interface ITimer
    {
        void AddTask(AlarmRow element);
        void RemoveTask(AlarmRow element);
        IEnumerable<AlarmRow> GetAll();
        void StopAll();
        void UpdateAll();
    }
}
