using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tolson.BoosterStation.UI
{
    public partial class MsgBoxComfirm : Form
    {
        public MsgBoxComfirm(string msg)
        {
            InitializeComponent();
            this.TopMost = true;
            this.label_Msg.Text = msg;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
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
