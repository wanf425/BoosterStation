using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using tolson.BoosterStation.Adadpter;
using tolson.BoosterStation.Service;
using tolson.BoosterStation.UI;

namespace tolson.BoosterStation
{
    internal static class Program
    {
        /// <summary>
        /// 是否退出应用程序
        /// </summary>
        public static bool glExitApp = false;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool runone;
            // 防止应用重复开启
            System.Threading.Mutex run = new System.Threading.Mutex(true, Process.GetCurrentProcess().ProcessName, out runone);//设置互斥信号量
            if(runone)
            {
                run.ReleaseMutex();
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                // 处理UI线程异常
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                // 处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                // 页面设置
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                // 初始化数据库连接
                MySqlHelper.ConnString = GetSQLConnectString();
                // 初始化主界面
                Application.Run(new FormMain());
                //Application.Run(new FormLSMotion());
                // 应用程序可以退出
                glExitApp = true;
            }
            else
            {
                new MsgBoxNoConfirm("This Application is already running").ShowDialog();
            }

        }

        /// <summary>
        /// 获取数据库连接信息
        /// </summary>
        /// <returns></returns>
        private static string GetSQLConnectString()
        {
            string path = Application.StartupPath + "\\MySQLConfig.ini"; // string iniName = System.IO.Directory.GetCurrentDirectory() + @"\LocatSet.ini"; // MessageBox.Show(iniName);

            if(System.IO.File.Exists(path))
            {
                string Server = IniConfigHelper.ReadIniData("MySQL", "Server", "127.0.0.1", path);
                int Port = Convert.ToInt16(IniConfigHelper.ReadIniData("MySQL", "Port", "3306", path));
                string Database = IniConfigHelper.ReadIniData("MySQL", "Database", "", path);
                string User = IniConfigHelper.ReadIniData("MySQL", "User", "", path);
                string Password = IniConfigHelper.ReadIniData("MySQL", "Password", "", path);
                string CharacterSet = IniConfigHelper.ReadIniData("MySQL", "CharacterSet", "UTF8", path);

                return $"Server='{Server}';Port={Port};Database='{Database}';User='{User}';Password='{Password}';charset='{CharacterSet}';pooling=true;SslMode='none'";                                                                                                                                                        // MessageBox.Show(MySqlHelper.Conn);
            }

            return string.Empty;
        }

        /// <summary>
        /// 处理非UI线程未捕获异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            SaveLog("-----------------------begin--------------------------");
            SaveLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss "));
            SaveLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ") + "CurrentDomain_UnhandledException");
            SaveLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ") + "IsTerminating : " + e.IsTerminating.ToString());
            SaveLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ") + e.ExceptionObject.ToString());
            SaveLog("-----------------------end----------------------------");
            while(true)
            {//循环处理，否则应用程序将会退出
                if(glExitApp)
                {//标志应用程序可以退出，否则程序退出后，进程仍然在运行
                    SaveLog("ExitApp");
                    return;
                }
                System.Threading.Thread.Sleep(2 * 1000);
            };
        }

        /// <summary>
        /// 处理UI主线程未捕获异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            SaveLog("-----------------------begin--------------------------");
            SaveLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ") + "Application_ThreadException:" + e.Exception.Message);
            SaveLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ") + e.Exception.StackTrace);
            SaveLog("-----------------------end----------------------------");
        }

        /// <summary>
        /// 保存未捕获异常日志
        /// </summary>
        /// <param name="log"></param>
        public static void SaveLog(string log)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\UnHandledException.txt";
            //采用using关键字，会自动释放
            using(FileStream fs = new FileStream(filePath, FileMode.Append))
            {
                using(StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default))
                {
                    sw.WriteLine(log);
                }
            }
        }

    }
}
