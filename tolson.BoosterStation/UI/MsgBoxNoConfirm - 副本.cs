using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static tolson.BoosterStation.MsgBoxNoConfirm;

namespace tolson.BoosterStation
{
    public partial class MsgBoxNoConfirm : Form
    {
        public enum Title
        {
            系统提示,
            错误提示,
        }

        public MsgBoxNoConfirm(string msg)
        {
            InitializeComponent();
            this.TopMost = true;
            this.label_Title.Text = Title.系统提示.ToString();
            this.label_Msg.Text = msg;
        }

        public MsgBoxNoConfirm(string title, string msg)
        {
            InitializeComponent();
            this.TopMost = true;
            this.label_Title.Text = title;
            this.label_Msg.Text = msg; 
        }

        private void button_ok_click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void label_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
