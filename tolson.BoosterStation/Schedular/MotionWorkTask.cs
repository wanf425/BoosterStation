using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tolson.BoosterStation.Schedular
{
    public class MotionWorkTask : BaseTask
    {
        protected override void DoTask()
        {
            int step = 0;
            while(!cts.IsCancellationRequested)
            {
                switch(step)
                {
                    case 0:
                        log.Info("do step " + step);
                        Sleep(1000);
                        step = 1;
                        break;

                    case 1:
                        log.Info("do step " + step);
                        Sleep(1000);
                        step = 2;
                        break;

                    default:
                        log.Info("done all steps");
                        //step = 0;
                        //break;
                        return;
                }
            }

        }
    }
}
