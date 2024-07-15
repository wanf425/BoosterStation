using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tolson.BoosterStation.Dto;
using tolson.BoosterStation.Service;

namespace tolson.BoosterStation.Schedular
{
    public abstract class BaseTask
    {
        protected Task runningTask;
        protected CancellationTokenSource cts = new CancellationTokenSource();
        protected abstract void DoTask();

        /// <summary>
        /// 启动任务
        /// TODO 未考虑停止后立即启动的情况
        /// </summary>
        public void Start()
        {
            // 如果任务没有运行或者已经完成，重新启动任务
            if(runningTask == null || runningTask.IsCompleted)
            {
                cts = new CancellationTokenSource();
                runningTask = Task.Run(() =>
                {
                    DoTask();
                }, cts.Token);
            }
        }

        public void Stop()
        {
            cts.Cancel();
        }

        public void Sleep(int milliseconds)
        {
            if(!cts.IsCancellationRequested)
            {
                Thread.Sleep(milliseconds);
            }
        }
    }
}
