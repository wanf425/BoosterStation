using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xbd.DataConvertLib;

namespace tolson.BoosterStation.Schedular
{
    public class WorkFlowTask : BaseTask
    {
        private State _currentState = State.Start;
        public enum State
        {
            Start, State0, End, Error
        }

        protected override void DoTask()
        {
            log.Info("task is running");
            _currentState = State.Start;

            while(!cts.IsCancellationRequested)
            {
                TaskManager.Instance.taskStartEvent.WaitOne();

                log.Info($"_currentState: {_currentState}");
                switch(_currentState)
                {
                    case State.Start:
                    Sleep(1000);
                    _currentState = State.State0;
                    break;

                    case State.State0:
                    Sleep(1000);
                    // 获取0或者1的随机整数
                    int random = new Random().Next(2);
                    _currentState = random > 0 ? State.End : State.Error;
                    break;

                    case State.End:
                    log.Info("run success");
                    return;

                    case State.Error:
                    log.Error("run error");
                    return;
                }
                log.Info($"ChangedState: {_currentState}");
            }

        }
    }
}
