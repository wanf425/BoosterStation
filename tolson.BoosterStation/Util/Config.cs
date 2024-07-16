using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tolson.BoosterStation.Util
{
    public class Config
    {
        public static string GetSystemConfigPath()
        {
            return System.Windows.Forms.Application.StartupPath + "\\Config\\SysConfig.ini";
        }

        public static string GetPlcConfigPath()
        {
            return System.Windows.Forms.Application.StartupPath + "\\Config\\PlcConfig.ini";
        }

        public static string GetMySQLConfigPath()
        {
            return System.Windows.Forms.Application.StartupPath + "\\Config\\MySQLConfig.ini";
        }
    }
}
