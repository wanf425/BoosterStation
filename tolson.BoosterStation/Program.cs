using log4net;
using log4net.Config;
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
using tolson.BoosterStation.Dto;
using xbd.DataConvertLib;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = false)]
namespace tolson.BoosterStation
{
    internal static class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
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
            log.Info("---------------Application Start-----------------");
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
                // 初始化主界面
                Application.Run(new FormMain());
                //Application.Run(new FormLSMotion());
                // 应用程序可以退出
                glExitApp = true;
                log.Info("---------------Application end-----------------");
            }
            else
            {
                log.Info("---------------Application is already running-----------------");
                new MsgBoxNoConfirm("This Application is already running").ShowDialog();
            }

        }

        /// <summary>
        /// 处理非UI线程未捕获异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string logMessage =
                $"CurrentDomain_UnhandledException\n" +
                $"IsTerminating : {e.IsTerminating}\n" +
                $"exception：{e.ExceptionObject}";
            log.Fatal(logMessage);
            while(true)
            {//循环处理，否则应用程序将会退出
                if(glExitApp)
                {//标志应用程序可以退出，否则程序退出后，进程仍然在运行
                    log.Fatal("ExitApp");
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
            log.Fatal("Application_ThreadException：", e.Exception);
        }
    }
}
