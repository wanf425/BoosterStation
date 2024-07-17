using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tolson.BoosterStation.Dto;
using tolson.BoosterStation.Service;
using xbd.DataConvertLib;

namespace tolson.BoosterStation.Schedular
{
    public abstract class BaseTask
    {
        protected ILog log => LogManager.GetLogger(GetType());
        protected Task runningTask;
        protected CancellationTokenSource cts = new CancellationTokenSource();
        protected abstract void DoTask();

        /// <summary>
        /// 启动任务
        /// </summary>
        public OperateResult Start()
        {
            OperateResult result = OperateResult.CreateFailResult();

            try
            {
                // 如果任务没有运行或者已经完成，重新启动任务
                if(runningTask == null || runningTask.IsCompleted)
                {
                    log.Info("task is " + (runningTask == null?"not created" : "completed"));
                    RunNewTask();
                } 
                // 如果任务已经取消，但是还没有结束，等待任务结束后再重新启动
                else if(runningTask != null && cts.IsCancellationRequested && !runningTask.IsCompleted)
                {
                    log.Info("task is canceled but not completed");
                    runningTask.ContinueWith((t) =>
                    {
                        RunNewTask();
                    });
                } else
                {
                    log.Info("task is running");
                }

                result = OperateResult.CreateSuccessResult();
            }
            catch(Exception ex)
            {
                log.Error("start task error", ex);
                result = OperateResult.CreateFailResult(ex.Message);
            }

            return result;
        }

        private void RunNewTask()
        {
            cts = new CancellationTokenSource();
            runningTask = Task.Run(() =>
            {
                DoTask();
            }, cts.Token);
            log.Info("start new task success");
        }

        public void Stop()
        {
            log.Info("send stop signal begin");
            cts.Cancel();
            log.Info("send stop signal end");
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
