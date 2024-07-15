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
                }
                catch(Exception ex)
                {
                    log.Error("PLCTask 运行异常", ex);
                }

                Sleep(1000);
            }
        }

        /// <summary>
        /// 调用注册事件
        /// 调用前判断线程是否要退出，避免由于耗时操作导致线程无法终止
        /// </summary>
        /// <param name="data"></param>
        private async void InvokeEvents(PlcData data)
        {
            var invocationList = UpdateByPlcDataEvent?.GetInvocationList();
            if(invocationList != null && !cts.IsCancellationRequested)
            {
                List<Task> tasks = new List<Task>();
                foreach(UpdateByPlcDataEventHandler handler in invocationList)
                {
                    if(!cts.IsCancellationRequested)
                    {
                        var task = Task.Run(() => handler.Invoke(data));
                        tasks.Add(task);
                    }
                }

                await Task.WhenAll(tasks);
            }
        }
    }
}
