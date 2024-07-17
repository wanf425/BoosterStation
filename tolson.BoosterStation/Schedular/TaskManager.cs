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
        public PLCDataTask plcTask = new PLCDataTask();
        public MotionWorkTask motionWorkTask = new MotionWorkTask();
        public PLCHeartBeatTask plcHeartBeatTask = new PLCHeartBeatTask();
        

        public void StartAllTasks()
        {
            plcTask.Start();
            plcHeartBeatTask.Start();
        }

        public void StopAllTasks()
        {
            plcTask.Stop();
            plcHeartBeatTask.Stop();
        }
    }
}
