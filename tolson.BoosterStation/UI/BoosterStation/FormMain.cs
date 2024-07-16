﻿using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using tolson.BoosterStation.Adadpter;
using tolson.BoosterStation.Dto;
using tolson.BoosterStation.Schedular;
using tolson.BoosterStation.Service;
using tolson.BoosterStation.UI;
using xbd.ControlLib;
using xbd.DataConvertLib;
using xbd.s7netplus;

namespace tolson.BoosterStation.UI
{
    public partial class FormMain : Form
    {
        private CancellationTokenSource cts = new CancellationTokenSource();
        private PLCDataService plcDataService = PLCDataService.Instance;
        private SystemInfoService systemInfoService = SystemInfoService.Instance;
        private TaskManager taskManager = TaskManager.Instance;
        private static readonly ILog log = LogManager.GetLogger(typeof(FormMain));

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // 初始化数据库连接
            MySqlHelper.ConnString = GetSQLConnectString();

            // 读取系统配置
            SystemInfo sysInfo = systemInfoService.SysInfo;

            if(sysInfo == null)
            {
                new MsgBoxNoConfirm(MsgBoxNoConfirm.Title.系统提示.ToString(), "系统参数读取失败，请检查配置文件！").ShowDialog();
            }

            // 连接PLC
            OperateResult result = plcDataService.Connect(sysInfo);
            if(!result.IsSuccess)
            {
                new MsgBoxNoConfirm(MsgBoxNoConfirm.Title.系统提示.ToString(), "连接PLC失败，错误信息：" + result.Message).ShowDialog();
            }

            // 启动线程
            taskManager.StartAllTasks();
            // 如何将注册代码封装转到taskManager中 TODO
            taskManager.plcTask.UpdateByPlcDataEvent += InvokeUpdatePLCUI;
            taskManager.plcTask.UpdateByPlcDataEvent += HistoryDataService.Instance.UpdateByPLCData;
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

        private void InvokeUpdatePLCUI(PlcData plcData)
        {
            if(plcData == null)
            {
                log.Info("InvokeUpdatePLCUI, plcData is null"); 
                return;
            }

            if(this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    UpdatePLCUI(plcData);
                });
            } else
            {
                UpdatePLCUI(plcData);
            }
        }

        private void UpdatePLCUI(PlcData plcData)
        {
            // 左侧仪表
            this.meter_PressuerIn.Value = plcData.PressureIn;
            this.label_PressureIn.Text = plcData.PressureIn.ToString("f2") + " bar";
            this.meter_PressureOut.Value = plcData.PressureOut;
            this.label_PressureOut.Text = plcData.PressureOut.ToString("f2") + " bar";

            // 底测仪表
            this.ms_TempIn1.ParamValue = plcData.TempIn1;
            this.ms_TempIn2.ParamValue = plcData.TempIn2;
            this.ms_TempOut.ParamValue = plcData.TempOut;
            this.ms_PressureTank1.ParamValue = plcData.PressureTank1;
            this.ms_PressureTank2.ParamValue = plcData.PressureTank2;
            this.ms_PressureTankOut.ParamValue = plcData.PressureTankOut;

            // 系统状态
            this.state_System.State = plcData.SysRunState;
            this.state_Alarm.State = !plcData.SysAlarmState;

            // 系统参数
            this.label_PressureTank1.Text = plcData.PressureTank1.ToString("f2");
            this.label_PressureLevel1.Text = plcData.LevelTank1.ToString("f2");
            this.label_PressureTank2.Text = plcData.PressureTank2.ToString("f2");
            this.label_PressureLevel2.Text = plcData.LevelTank2.ToString("f2");
            this.label_PressureTankOut.Text = plcData.PressureTankOut.ToString("f2");

            // 流程图数据
            this.label_TempIn1.Text = plcData.TempIn1.ToString("f2");
            this.label_TempIn2.Text = plcData.TempIn2.ToString("f2");
            this.label_TempOut.Text = plcData.TempOut.ToString("f2");
            this.pump_In1.IsRun = plcData.InPump1State;
            this.pump_In2.IsRun = plcData.InPump2State;
            this.toggle_Pump1.Checked = plcData.InPump1State;
            this.toggle_Pump2.Checked = plcData.InPump2State;
            this.valve_In.State = plcData.ValveInState;
            this.valve_Out.State = plcData.ValveOutState;
            this.motor_1.PumpState = plcData.CirclePump1State ? PumpState.运行 : PumpState.停止;
            this.motor_2.PumpState = plcData.CirclePump2State ? PumpState.运行 : PumpState.停止;
            this.label_PreTankOut.Text = plcData.PressureTankOut.ToString("f2");

            // 量程
            this.wave_Tank1.Value = Convert.ToInt32((plcData.LevelTank1 / 2.0f) * 100.0f);
            this.wave_Tank2.Value = Convert.ToInt32((plcData.LevelTank2 / 2.0f) * 100.0f);
            this.button_pump1.Text = plcData.CirclePump1State ? "停止" : "启动";
            this.button_pump2.Text = plcData.CirclePump2State ? "停止" : "启动";
        }

        #region 无边框拖动 

        private Point mPoint;
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        #endregion

        private void buttonConfigue_Click(object sender, EventArgs e)
        {
            new FormParamSet().ShowDialog();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            taskManager.StopAllTasks();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_pump1_Click(object sender, EventArgs e)
        {
            if(this.button_pump1.Text == "启动")
            {
                plcDataService.CirclePump1Control(true);
            } else
            {
                plcDataService.CirclePump1Control(false);
            }
        }

        private void button_pump2_Click(object sender, EventArgs e)
        {
            if(this.button_pump2.Text == "启动")
            {
                plcDataService.CirclePump2Control(true);
            }
            else
            {
                plcDataService.CirclePump2Control(false);
            }
        }

        private void toggle_Pump1_CheckedChanged(object sender, EventArgs e)
        {
            // 修改pump1状态
            bool result = plcDataService.InPump1Control(toggle_Pump1.Checked);

            // 操作失败，恢复状态
            if(!result)
            {
                this.toggle_Pump1.CheckedChanged -= toggle_Pump1_CheckedChanged;
                this.toggle_Pump1.Checked = !this.toggle_Pump1.Checked;
                this.toggle_Pump1.CheckedChanged += toggle_Pump1_CheckedChanged;
            }
        }

        private void toggle_Pump2_CheckedChanged(object sender, EventArgs e)
        {
            // 修改pump2状态
            bool result = plcDataService.InPump2Control(toggle_Pump2.Checked);

            // 操作失败，恢复状态
            if(!result)
            {
                this.toggle_Pump2.CheckedChanged -= toggle_Pump2_CheckedChanged;
                this.toggle_Pump2.Checked = !this.toggle_Pump2.Checked;
                this.toggle_Pump2.CheckedChanged += toggle_Pump2_CheckedChanged;
            }
        }

        private void valve_in_DoubleClick(object sender, EventArgs e)
        {
            if(sender is xbdValve valve)
            {
                DialogResult result = new MsgBoxComfirm("是否确定要" + (valve.State ? "关闭" : "打开") + valve.ValveName + "?").ShowDialog();
                if(result == DialogResult.OK)
                {
                    plcDataService.ValveInControl(!valve.State);
                }
            }
        }

        private void valve_out_DoubleClick(object sender, EventArgs e)
        {
            if(sender is xbdValve valve)
            {
                DialogResult result = new MsgBoxComfirm("是否确定要" + (valve.State ? "关闭" : "打开") + valve.ValveName + "?").ShowDialog();
                if(result == DialogResult.OK)
                {
                    plcDataService.ValveOutControl(!valve.State);
                }
            }
        }

        private void timer_UpdateUI_Tick(object sender, EventArgs e)
        {
            // 更新时间
            DateTime now = DateTime.Now;
            // 创建一个指定为中文（中国）的CultureInfo对象
            CultureInfo ci = new CultureInfo("zh-CN");
            // 使用指定的CultureInfo格式化日期和时间
            string formattedDate = now.ToString("yyyy-MM-dd HH:mm dddd", ci);
            this.label_nowTime.Text = formattedDate;

            // 更新PLC连接状态
            this.state_Plc.State = plcDataService.IsConnect;
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            new FormHistory().ShowDialog();
        }
    }

}