using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tolson.BoosterStation.Dto;
using tolson.BoosterStation.Service;
using xbd.s7netplus;

namespace tolson.BoosterStation.UI
{
    public partial class FormParamSet : Form
    {
        public FormParamSet()
        {
            InitializeComponent();
            this.comboBox_CpuType.DataSource = Enum.GetValues(typeof(CpuType));
            this.comboBox_CamaraIndex.DataSource = new List<int> { 0, 1, 2 };
            SystemInfo sysInfo = SystemInfoService.Instance.SysInfo;

            if(sysInfo != null)
            {
                this.textBox_IpAddress.Text = sysInfo.IpAddress;
                this.textBox_Rack.Text = sysInfo.Rack.ToString();
                this.textBox_Slot.Text = sysInfo.Slot.ToString();
                this.comboBox_CpuType.SelectedItem = sysInfo.CpuType;

                this.xbdToggle_AutoStart.Checked = sysInfo.AutoStart;
                this.textBox_ScreenTime.Text = sysInfo.ScreenTime.ToString();
                this.textBox_LogoffTime.Text = sysInfo.LogoffTime.ToString();
                this.comboBox_CamaraIndex.SelectedItem = sysInfo.CamaraIndex;
            }
            else
            {
                new MsgBoxNoConfirm(MsgBoxNoConfirm.Title.系统提示.ToString(), "系统参数读取失败，请检查配置文件！").ShowDialog();
            }

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

        private void label_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            SystemInfo sysInfo = new SystemInfo();
            sysInfo.IpAddress = this.textBox_IpAddress.Text;
            sysInfo.Rack = short.Parse(this.textBox_Rack.Text);
            sysInfo.Slot = short.Parse(this.textBox_Slot.Text);
            sysInfo.CpuType = (CpuType)this.comboBox_CpuType.SelectedItem;

            sysInfo.AutoStart = this.xbdToggle_AutoStart.Checked;
            sysInfo.ScreenTime = int.Parse(this.textBox_ScreenTime.Text);
            sysInfo.LogoffTime = int.Parse(this.textBox_LogoffTime.Text);
            sysInfo.CamaraIndex = (int)this.comboBox_CamaraIndex.SelectedItem;

            bool result = SystemInfoService.Instance.SetSysInfo(sysInfo);

            if(result)
            {
                this.DialogResult = DialogResult.OK;
                new MsgBoxNoConfirm(MsgBoxNoConfirm.Title.系统提示.ToString(), "保存成功！").ShowDialog();
            }             
            else
            {
                new MsgBoxNoConfirm(MsgBoxNoConfirm.Title.系统提示.ToString(), "保存失败！").ShowDialog();
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
