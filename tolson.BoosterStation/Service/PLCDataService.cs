using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using tolson.BoosterStation.Adadpter;
using tolson.BoosterStation.Dto;
using tolson.BoosterStation.Util;
using xbd.ControlLib;
using xbd.DataConvertLib;

namespace tolson.BoosterStation.Service
{
    public class PLCDataService : Singleton<PLCDataService>
    {
        private S7NetLib s7NetLib;
        private PLCDataService() { }
        public bool IsConnect => s7NetLib.IsConnect;
        private static readonly ILog log = LogManager.GetLogger(typeof(PLCDataService));

        public OperateResult Connect(SystemInfo sysInfo)
        {
            log.Info("Connect plc start");
            Disconnect();

            S7NetLib s7NetLib = new S7NetLib();
            s7NetLib.CpuType = sysInfo.CpuType;
            s7NetLib.IpAddress = sysInfo.IpAddress;
            s7NetLib.Rack = sysInfo.Rack;
            s7NetLib.Slot = sysInfo.Slot;
            OperateResult result = s7NetLib.Connect();
            this.s7NetLib = s7NetLib;
            string msg = result.IsSuccess ? "" : (",error msg:" + result.Message);
            log.Info("Connect plc end, result:" + result.IsSuccess + ",IsConnect:" + IsConnect + msg);
            return result;
        }

        public void Disconnect()
        {
            log.Info("Disconnect plc start");
            if(s7NetLib != null)
            {
                s7NetLib.Disconnect();
                log.Info("Disconnect plc end, IsConnect:" + IsConnect);
            }
        }

        public OperateResult<PlcData> ReadPlcData()
        {
            // [1]读取单个变量
            //result = s7NetLib.ReadVariable("DB1.DBD4");
            //if(data1.IsSuccess)
            //{
            //    MessageBox.Show(Convert.ToUInt32(data1.Content).ConvertToFloat().ToString());
            //}

            //// [2]批量读取字节数组
            //result = s7NetLib.ReadByteArray(DataType.DataBlock, 1, 0, 20);

            //if(data2.IsSuccess)
            //{
            //    MessageBox.Show(BitConverter.ToString(data2.Content));
            //}

            // [3]读取类
            return s7NetLib.ReadClass<PlcData>(1, 0);
        }

        /// <summary>
        /// 心跳检测
        /// 只实现了简单版本，能够读取到值就认为连接正常
        /// 更好的做法是读取一个固定的地址，如果读取成功，再写入一个固定的地址，然后再读取，如果读取成功，认为连接正常
        /// </summary>
        /// <returns></returns>
        public bool HeartBeat(string address)
        {
            OperateResult result = s7NetLib.ReadVariable(address);
            return result.IsSuccess;
        }

        /// <summary>
        /// 1号进水泵控制
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool InPump1Control(bool value)
        {
            string startAddress = "DB1.DBX100.0";
            string stopAddress = "DB1.DBX100.1";
            string controlAddress = value ? startAddress : stopAddress;
            bool result = s7NetLib.WriteVariable(controlAddress, true).IsSuccess;
            Thread.Sleep(50);
            result &= s7NetLib.WriteVariable(controlAddress, false).IsSuccess;

            return result;
        }

        /// <summary>
        /// 2号进水泵控制
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool InPump2Control(bool value)
        {
            string startAddress = "DB1.DBX100.2";
            string stopAddress = "DB1.DBX100.3";
            string controlAddress = value ? startAddress : stopAddress;
            bool result = s7NetLib.WriteVariable(controlAddress, true).IsSuccess;
            Thread.Sleep(50);
            result &= s7NetLib.WriteVariable(controlAddress, false).IsSuccess;

            return result;
        }

        /// <summary>
        /// 1号循环泵控制
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool CirclePump1Control(bool value)
        {
            string startAddress = "DB1.DBX100.4";
            string stopAddress = "DB1.DBX100.5";
            string controlAddress = value ? startAddress : stopAddress;
            bool result = s7NetLib.WriteVariable(controlAddress, true).IsSuccess;
            Thread.Sleep(50);
            result &= s7NetLib.WriteVariable(controlAddress, false).IsSuccess;

            return result;
        }

        /// <summary>
        /// 2号循环泵控制
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool CirclePump2Control(bool value)
        {
            string startAddress = "DB1.DBX100.6";
            string stopAddress = "DB1.DBX100.7";
            string controlAddress = value ? startAddress : stopAddress;
            bool result = s7NetLib.WriteVariable(controlAddress, true).IsSuccess;
            Thread.Sleep(50);
            result &= s7NetLib.WriteVariable(controlAddress, false).IsSuccess;

            return result;
        }

        /// <summary>
        /// 进水阀控制
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ValveInControl(bool value)
        {
            string startAddress = "DB1.DBX101.0";
            string stopAddress = "DB1.DBX101.1";
            string controlAddress = value ? startAddress : stopAddress;
            bool result = s7NetLib.WriteVariable(controlAddress, true).IsSuccess;
            Thread.Sleep(50);
            result &= s7NetLib.WriteVariable(controlAddress, false).IsSuccess;

            return result;
        }

        /// <summary>
        /// 出水阀控制
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ValveOutControl(bool value)
        {
            string startAddress = "DB1.DBX101.2";
            string stopAddress = "DB1.DBX101.3";
            string controlAddress = value ? startAddress : stopAddress;
            bool result = s7NetLib.WriteVariable(controlAddress, true).IsSuccess;
            Thread.Sleep(50);
            result &= s7NetLib.WriteVariable(controlAddress, false).IsSuccess;

            return result;
        }
    }
}
