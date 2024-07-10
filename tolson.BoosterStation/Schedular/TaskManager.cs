using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tolson.BoosterStation.Util;

namespace tolson.BoosterStation.Schedular
{
    public class TaskManager : Singleton<TaskManager>
    {
        public static AutoResetEvent AutoResetEvent = new AutoResetEvent(true);
        public PLCTask PlcTask = new PLCTask();

        public void StartAllTasks()
        {
            PlcTask.Start();
        }

        public void StopAllTasks()
        {
            PlcTask.Stop();
        }
    }
}
