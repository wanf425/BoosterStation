using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tolson.BoosterStation.Service;

namespace tolson.BoosterStation.Schedular
{
    public class PLCHeartBeatTask : BaseTask
    {
        private PLCDataService plcDataService = PLCDataService.Instance;
        private SystemInfoService systemInfoService = SystemInfoService.Instance;
       
        protected override void DoTask()
        {
            while(!cts.IsCancellationRequested)
            {
                try
                {
                    bool isConnect = plcDataService.HeartBeat(systemInfoService.SysInfo.HeartBeatAddress);

                    if(!isConnect)
                    {
                        log.Info("PLC连接异常，尝试重连");
                        // 失败重连，重试3次
                        for(int i = 0; i < 3; i++)
                        {
                            if(!cts.IsCancellationRequested)
                            {
                                var result = plcDataService.Connect(systemInfoService.SysInfo);
                                bool isSuccess = result.IsSuccess;
                                string erroMsg = isSuccess ? "" : " msg:" + result.Message;
                                log.Info("第" + (i+1) + "次重连，连接结果：" + isSuccess + erroMsg);
                                if(isSuccess)
                                {
                                    break;
                                }
                                Sleep(100);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    log.Error("心跳检测异常", ex);
                }

                Sleep(5000);
            }
        }
    }
}
