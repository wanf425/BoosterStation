using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using tolson.BoosterStation.Dto;
using tolson.BoosterStation.Service;
using xbd.DataConvertLib;

namespace tolson.BoosterStation.Schedular
{
    public class PLCDataTask : BaseTask
    {
        private PLCDataService PLCDataService = PLCDataService.Instance;
        public delegate void UpdateByPlcDataEventHandler(PlcData ddata);
        public event UpdateByPlcDataEventHandler UpdateByPlcDataEvent;

        protected override void DoTask()
        {
            while(!cts.IsCancellationRequested)
            {
                try
                {
                    if(PLCDataService.IsConnect)
                    {
                        OperateResult<PlcData> result = PLCDataService.ReadPlcData();

                        if(result.IsSuccess)
                        {
                            InvokeEvents(result.Content);
                        }

                        PLCDataService.IsConnect = result.IsSuccess;
                    }
                    else
                    {
                        var reuslt = PLCDataService.Connect(SystemInfoService.Instance.SysInfo);
                        if(!reuslt.IsSuccess)
                        {
                            throw new Exception("PLC连接异常,异常信息" + reuslt.Message);
                        }
                    }

                    Thread.Sleep(1000);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("PLCTask 运行异常，异常消息{0}", ex.Message);
                    Thread.Sleep(5000);
                }
            }
        }
        private void InvokeEvents(PlcData data)
        {
            var invocationList = UpdateByPlcDataEvent?.GetInvocationList();
            if(invocationList != null && !cts.IsCancellationRequested)
            {
                foreach(UpdateByPlcDataEventHandler handler in invocationList)
                {
                    if(!cts.IsCancellationRequested)
                    {
                        handler.Invoke(data);
                    }
                }
            }
        }
    }
}
