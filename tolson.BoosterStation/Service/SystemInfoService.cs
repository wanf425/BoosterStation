using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using tolson.BoosterStation.Adadpter;
using tolson.BoosterStation.Dto;
using tolson.BoosterStation.Util;
using xbd.DataConvertLib;
using xbd.s7netplus;

namespace tolson.BoosterStation.Service
{
    public class SystemInfoService : Singleton<SystemInfoService>
    {
        #region 内部属性变量
        private readonly object sysInfoLock = new object(); // 锁对象
        private SystemInfo sysInfo = null;
        private string COMM_CONFIG_PATH = Application.StartupPath + "\\PlcConfig.ini";
        private string SYS_CONFIG_PATH = Application.StartupPath + "\\SysConfig.ini";
        private static readonly ILog log = LogManager.GetLogger(typeof(SystemInfoService));

        public SystemInfo SysInfo
        {
            get
            {
                lock(sysInfoLock)
                {
                    if(sysInfo == null)
                    {
                        LoadSysInfo();
                    }

                    return sysInfo;
                }
            }
        }
        #endregion

        #region 文件内容enum
        private enum ConfigSection
        {
            通讯参数,
            系统参数
        }

        private enum CommConfigKey
        {
            IpAddress,
            CpuType,
            Slot,
            Rack
        }

        private enum SysConfigKey
        {
            AutoStart,
            ScreenTime,
            LogoffTime,
            CamaraIndex
        }
        #endregion

        // 私有构造函数，防止外部通过new关键字创建实例
        private SystemInfoService()
        {
            LoadSysInfo();
        }
        
        /// <summary>
        /// 从文件中获取系统参数,并写入到sysInfo中
        /// </summary>
        /// <returns></returns>
        private void LoadSysInfo()
        {
            try
            {
                SystemInfo newInfo =  new SystemInfo();

                newInfo.IpAddress = IniConfigHelper.ReadIniData(ConfigSection.通讯参数.ToString(), CommConfigKey.IpAddress.ToString(), "127.0.0.1", COMM_CONFIG_PATH);
                newInfo.CpuType = (CpuType)Enum.Parse(typeof(CpuType), IniConfigHelper.ReadIniData(ConfigSection.通讯参数.ToString(), CommConfigKey.CpuType.ToString(), "S71500", COMM_CONFIG_PATH));
                newInfo.Slot = short.Parse(IniConfigHelper.ReadIniData(ConfigSection.通讯参数.ToString(), CommConfigKey.Slot.ToString(), "0", COMM_CONFIG_PATH));
                newInfo.Rack = short.Parse(IniConfigHelper.ReadIniData(ConfigSection.通讯参数.ToString(), CommConfigKey.Rack.ToString(), "0", COMM_CONFIG_PATH));

                newInfo.AutoStart = IniConfigHelper.ReadIniData(ConfigSection.系统参数.ToString(), SysConfigKey.AutoStart.ToString(), "1", SYS_CONFIG_PATH) == "1";
                newInfo.ScreenTime = int.Parse(IniConfigHelper.ReadIniData(ConfigSection.系统参数.ToString(), SysConfigKey.ScreenTime.ToString(), "0", SYS_CONFIG_PATH));
                newInfo.LogoffTime = int.Parse(IniConfigHelper.ReadIniData(ConfigSection.系统参数.ToString(), SysConfigKey.LogoffTime.ToString(), "0", SYS_CONFIG_PATH));
                newInfo.CamaraIndex = int.Parse(IniConfigHelper.ReadIniData(ConfigSection.系统参数.ToString(), SysConfigKey.CamaraIndex.ToString(), "0", SYS_CONFIG_PATH));

                sysInfo = newInfo;
            }
            catch(Exception ex)
            {
                log.Error("LoadSysInfo exception", ex);
            }
        }
        /// <summary>
        /// 写入系统参数到文件
        /// </summary>
        /// <param name="sysInfo"></param>
        /// <returns></returns>
        public bool SetSysInfo(SystemInfo sysInfo)
        {
            bool result = true;

            // 写入通讯参数
            result &= IniConfigHelper.WriteIniData(ConfigSection.通讯参数.ToString(), CommConfigKey.IpAddress.ToString(), sysInfo.IpAddress, COMM_CONFIG_PATH);
            result &= IniConfigHelper.WriteIniData(ConfigSection.通讯参数.ToString(), CommConfigKey.CpuType.ToString(), sysInfo.CpuType.ToString(), COMM_CONFIG_PATH);
            result &= IniConfigHelper.WriteIniData(ConfigSection.通讯参数.ToString(), CommConfigKey.Slot.ToString(), sysInfo.Slot.ToString(), COMM_CONFIG_PATH);
            result &= IniConfigHelper.WriteIniData(ConfigSection.通讯参数.ToString(), CommConfigKey.Rack.ToString(), sysInfo.Rack.ToString(), COMM_CONFIG_PATH);

            // 写入系统参数
            result &= IniConfigHelper.WriteIniData(ConfigSection.系统参数.ToString(), SysConfigKey.AutoStart.ToString(), sysInfo.AutoStart ? "1" : "0", SYS_CONFIG_PATH);
            result &= IniConfigHelper.WriteIniData(ConfigSection.系统参数.ToString(), SysConfigKey.ScreenTime.ToString(), sysInfo.ScreenTime.ToString(), SYS_CONFIG_PATH);
            result &= IniConfigHelper.WriteIniData(ConfigSection.系统参数.ToString(), SysConfigKey.LogoffTime.ToString(), sysInfo.LogoffTime.ToString(), SYS_CONFIG_PATH);
            result &= IniConfigHelper.WriteIniData(ConfigSection.系统参数.ToString(), SysConfigKey.CamaraIndex.ToString(), sysInfo.CamaraIndex.ToString(), SYS_CONFIG_PATH);

            if(result)
            {
                LoadSysInfo();
            }

            return result;
        }
    }
}
