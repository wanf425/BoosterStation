namespace tolson.BoosterStation.UI
{
    partial class MsgBoxValveControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_main = new System.Windows.Forms.Panel();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.panel_top = new System.Windows.Forms.Panel();
            this.label_Close = new System.Windows.Forms.Label();
            this.label_Title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Msg = new System.Windows.Forms.Label();
            this.panel_main.SuspendLayout();
            this.panel_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.panel_main.Controls.Add(this.button_cancel);
            this.panel_main.Controls.Add(this.button_ok);
            this.panel_main.Controls.Add(this.panel_top);
            this.panel_main.Controls.Add(this.label_Msg);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(1, 1);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(368, 257);
            this.panel_main.TabIndex = 2;
            // 
            // button_cancel
            // 
            this.button_cancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_cancel.FlatAppearance.BorderSize = 0;
            this.button_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancel.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_cancel.Image = global::tolson.BoosterStation.Properties.Resources.Pink;
            this.button_cancel.Location = new System.Drawing.Point(190, 186);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(101, 34);
            this.button_cancel.TabIndex = 5;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_ok.FlatAppearance.BorderSize = 0;
            this.button_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ok.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_ok.Image = global::tolson.BoosterStation.Properties.Resources.Green;
            this.button_ok.Location = new System.Drawing.Point(71, 186);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(101, 34);
            this.button_ok.TabIndex = 5;
            this.button_ok.Text = "确定";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.label_Close);
            this.panel_top.Controls.Add(this.label_Title);
            this.panel_top.Controls.Add(this.pictureBox1);
            this.panel_top.Controls.Add(this.label1);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(368, 50);
            this.panel_top.TabIndex = 0;
            // 
            // label_Close
            // 
            this.label_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_Close.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Close.ForeColor = System.Drawing.Color.White;
            this.label_Close.Location = new System.Drawing.Point(327, 0);
            this.label_Close.Name = "label_Close";
            this.label_Close.Size = new System.Drawing.Size(41, 49);
            this.label_Close.TabIndex = 3;
            this.label_Close.Text = "X";
            this.label_Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Close.Click += new System.EventHandler(this.label_Close_Click);
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Title.ForeColor = System.Drawing.Color.White;
            this.label_Title.Location = new System.Drawing.Point(42, 11);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(88, 26);
            this.label_Title.TabIndex = 3;
            this.label_Title.Text = "阀门控制";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::tolson.BoosterStation.Properties.Resources.Question;
            this.pictureBox1.Location = new System.Drawing.Point(4, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 1);
            this.label1.TabIndex = 1;
            // 
            // label_Msg
            // 
            this.label_Msg.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Msg.ForeColor = System.Drawing.Color.White;
            this.label_Msg.Location = new System.Drawing.Point(0, 74);
            this.label_Msg.Name = "label_Msg";
            this.label_Msg.Size = new System.Drawing.Size(370, 78);
            this.label_Msg.TabIndex = 3;
            this.label_Msg.Text = "是否确认打开进水阀门？";
            this.label_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MsgBoxValveControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 259);
            this.Controls.Add(this.panel_main);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MsgBoxValveControl";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MsgBoxComfirm";
            this.panel_main.ResumeLayout(false);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Label label_Close;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Msg;
        private System.Windows.Forms.Button button_cancel;
    }
}