using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using tolson.BoosterStation.Adadpter;
using tolson.BoosterStation.Dto;
using tolson.BoosterStation.Schedular;
using tolson.BoosterStation.Service;
using xbd.DataConvertLib;

namespace tolson.BoosterStation.UI
{
    public partial class FormLSMotion : Form
    {
        private LSData lsData;
        private TaskManager taskManager = TaskManager.Instance;

        public FormLSMotion()
        {
            InitializeComponent();
        }

        private void FormLSMotion_Load(object sender, EventArgs e)
        {
            
        }

        private void label_Close_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button_init_Click(object sender, EventArgs e)
        {
            OperateResult<LSData> result = LSDataService.Instance.InitCard();

            if(!result.IsSuccess)
            {
                new MsgBoxNoConfirm(result.Message).ShowDialog();
                return;
            }

            // 卡号
            this.label_cardNo.Text = result.Content.CardNo.ToString();
            // 固件版本
            this.label_version.Text = result.Content.Version;

            comboBox_axis.Items.Clear();

            for(ushort i = 0; i < result.Content.TotalAxis; i++)
            {
                comboBox_axis.Items.Add(result.Content.Axies[i]);
            }
            comboBox_axis.SelectedIndex = 0;
            this.label_axis.Text = result.Content.TotalAxis.ToString();
            lsData = result.Content;
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            OperateResult result = LSDataService.Instance.CloseCard();
            if(!result.IsSuccess)
            {
                new MsgBoxNoConfirm(result.Message).ShowDialog();
            }
            else
            {
                new MsgBoxNoConfirm("关闭成功").ShowDialog();
            }
        }

        private void button_excute_Click(object sender, EventArgs e)
        {
            double startVal = Convert.ToDouble(numericUpDown_StartVal.Value);
            double stopVal = Convert.ToDouble(numericUpDown_StopVal.Value);
            double val = Convert.ToDouble(numericUpDown_Val.Value);
            double sParam = Convert.ToDouble(numericUpDown_Spara.Value);
            double acc = Convert.ToDouble(numericUpDown_Tacc.Value);
            double dec = Convert.ToDouble(numericUpDown_Tdec.Value);
            ushort axis = Convert.ToUInt16(comboBox_axis.SelectedValue);

            OperateResult res = LSDataService.Instance.SetMoveParameters(lsData.CardNo, axis, startVal, stopVal, val, sParam, acc, dec);

            if(res.IsSuccess)
            {
                int dist = Convert.ToInt32(numericUpDown_Dist.Value);
                ushort mode = (ushort)(radioButton_rel.Checked ? 0 : 1);
                res = LSDataService.Instance.Move(lsData.CardNo, axis, dist, mode);

                if(res.IsSuccess)
                {
                    new MsgBoxNoConfirm($"运行成功").ShowDialog();
                }
                else
                {
                    new MsgBoxNoConfirm($"运行失败{res.Message}").ShowDialog();
                }
            }
            else
            {
                new MsgBoxNoConfirm($"运行失败{res.Message}").ShowDialog();
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            taskManager.motionWorkTask.Stop();
        }

        private void button_mergeStop_Click(object sender, EventArgs e)
        {
            taskManager.motionWorkTask.Stop();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            taskManager.motionWorkTask.Start();
        }
    }
}
