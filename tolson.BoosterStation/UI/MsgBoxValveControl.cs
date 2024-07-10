using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tolson.BoosterStation.Service;
using tolson.BoosterStation.UI;

namespace tolson.BoosterStation.UI
{
    public partial class MsgBoxValveControl : Form
    {
        private string valveName;
        private bool state;
        private PLCDataService pLCDataService;

        public MsgBoxValveControl(string valveName, bool state,PLCDataService pLCDataService)
        {
            InitializeComponent();

            this.TopMost = true;
            this.valveName = valveName;
            this.state = state;
            this.pLCDataService = pLCDataService;

            this.label_Msg.Text = "是否确定要" + (this.state?"关闭":"打开") + this.valveName + "?";
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if(pLCDataService.IsConnect)
            {
                bool result = true;
                switch(valveName)
                {
                    case "进水阀":
                        result = pLCDataService.ValveInControl(!this.state);
                        break;
                    case "出水阀":
                        result = pLCDataService.ValveOutControl(!this.state);
                        break;
                    default:
                        new MsgBoxNoConfirm("阀门名称错误").ShowDialog();
                        break;
                }

                if(result)
                {
                    this.DialogResult = DialogResult.OK;
                } else
                {
                    new MsgBoxNoConfirm("操作失败！").ShowDialog();
                }
            } else
            {
                new MsgBoxNoConfirm("PLC连接异常").ShowDialog();
            }
            
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void label_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
