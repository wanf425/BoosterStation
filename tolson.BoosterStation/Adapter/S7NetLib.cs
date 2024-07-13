using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xbd.DataConvertLib;
using xbd.s7netplus;
using DataType = xbd.s7netplus.DataType;

namespace tolson.BoosterStation.Adadpter
{
    public class S7NetLib
    {
        private Plc s7plc;
        private static object lockObj = new object();
        public CpuType CpuType { get; set; }
        public string IpAddress { get; set; }
        public short Rack { get; set; }
        public short Slot { get; set; }
        public bool IsConnect => s7plc.IsConnected;

        public S7NetLib()
        {

        }

        public S7NetLib(CpuType cpuType, string ipAddress, short rack, short slot)
        {
            CpuType = cpuType;
            IpAddress = ipAddress;
            Rack = rack;
            Slot = slot;
        }
       
        public OperateResult Connect()
        {
            lock(lockObj)
            {
                try
                {
                    if(s7plc != null && s7plc.IsConnected)
                    {
                        s7plc.Close();
                    }
                    s7plc = new Plc(CpuType, IpAddress, Rack, Slot);
                    s7plc.Open();
                    return OperateResult.CreateSuccessResult();
                }
                catch(Exception ex)
                {
                    return OperateResult.CreateFailResult(ex.Message);
                }
            }
        }

        public void Disconnect()
        {
            lock(lockObj)
            {
                if(s7plc != null && s7plc.IsConnected)
                {
                    s7plc.Close();
                }
            }
        }

        /// <summary>
        /// 读取字节数组
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public OperateResult<byte[]> ReadByteArray(DataType dataType, int db, int start, int count)
        {
            if(s7plc != null && s7plc.IsConnected)
            {
                try
                {
                    lock(lockObj)
                    {
                        byte[] result = s7plc.ReadBytes(dataType, db, start, count);
                        return OperateResult.CreateSuccessResult(result);
                    }
                }
                catch(Exception ex)
                {
                    return OperateResult.CreateFailResult<byte[]>("读取失败：" + ex.Message);
                }
            }
            else
            {
                return OperateResult.CreateFailResult<byte[]>("请检查PLC连接是否正常");
            }
        }

        /// <summary>
        /// 读取单个变量
        /// </summary>
        /// <param name="varAddress"></param>
        /// <returns></returns>
        public OperateResult<object> ReadVariable(string varAddress)
        {
            if(s7plc != null && s7plc.IsConnected)
            {
                try
                {
                    lock(lockObj)
                    {
                        object result = s7plc.Read(varAddress);
                        return OperateResult.CreateSuccessResult(result);
                    }
                }
                catch(Exception ex)
                {
                    return OperateResult.CreateFailResult<object>("读取失败：" + ex.Message);
                }
            }
            else
            {
                return OperateResult.CreateFailResult<object>("请检查PLC连接是否正常");
            }
        }

        /// <summary>
        /// 读取类对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public OperateResult<T> ReadClass<T>(int db, int start) where T : class
        {
            if(s7plc != null && s7plc.IsConnected)
            {
                try
                {
                    lock(lockObj)
                    {
                        T result = s7plc.ReadClass<T>(db, start);
                        return OperateResult.CreateSuccessResult(result);
                    }
                }
                catch(Exception ex)
                {
                    return OperateResult.CreateFailResult<T>("读取失败：" + ex.Message);
                }
            }
            else
            {
                return OperateResult.CreateFailResult<T>("PLC未连接");
            }
        }

        public OperateResult WriteVariable(string varAddress, object value)
        {
            if(s7plc != null && s7plc.IsConnected)
            {
                try
                {
                    lock(lockObj)
                    {
                        s7plc.Write(varAddress, value);
                        return OperateResult.CreateSuccessResult();
                    }
                }
                catch(Exception ex)
                {
                    return OperateResult.CreateFailResult("写入失败：" + ex.Message);
                }
            }
            else
            {
                return OperateResult.CreateFailResult("请检查PLC连接是否正常");
            }
        }
    }
}
