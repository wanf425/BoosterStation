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
using tolson.BoosterStation.Util;

namespace tolson.BoosterStation.UI
{
    public partial class FormHistory : Form
    {
        public FormHistory()
        {
            InitializeComponent();

            // 关闭自动生成列
            dataGridView_history.AutoGenerateColumns = false;
            dateTimePicker_StartTime.Value = DateTime.Now.AddDays(-7);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startTime = this.dateTimePicker_StartTime.Value;
            DateTime endTime = this.dateTimePicker_EndTime.Value;
            List<HistoryData> historyList = HistoryDataService.Instance.Query(startTime, endTime);

            if(historyList == null || historyList.Count == 0)
            {
                new MsgBoxNoConfirm("没有查询到数据").ShowDialog();
            }
            else
            {
                this.dataGridView_history.DataSource = historyList;
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

        private void dataGridView_history_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // 添加行号
            DataGridViewHelper.DgvRowPostPaint(dataGridView_history, e);
        }
    }
}
