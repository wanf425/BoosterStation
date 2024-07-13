using log4net;
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
        private static readonly ILog log = LogManager.GetLogger(typeof(PLCDataTask));
        private PLCDataService plcDataService = PLCDataService.Instance;
        public delegate void UpdateByPlcDataEventHandler(PlcData ddata);
        public event UpdateByPlcDataEventHandler UpdateByPlcDataEvent;

        protected override void DoTask()
        {
            while(!cts.IsCancellationRequested)
            {
                try
                {
                    OperateResult<PlcData> result = plcDataService.ReadPlcData();

                    if(result.IsSuccess)
                    {
                        InvokeEvents(result.Content);
                    }
                    else
                    {
                        log.Error("get plc data fail : " + result.Message);
                    }

                    Thread.Sleep(1000);
                }
                catch(Exception ex)
                {
                    log.Error("PLCTask 运行异常", ex);
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
