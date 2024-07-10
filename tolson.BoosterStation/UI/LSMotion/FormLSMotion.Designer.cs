namespace tolson.BoosterStation.UI
{
    partial class FormLSMotion
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox_axis = new System.Windows.Forms.ComboBox();
            this.numericUpDown_Dist = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDown_Tdec = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown_Spara = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown_Tacc = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_StopVal = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown_Val = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown_StartVal = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_abs = new System.Windows.Forms.RadioButton();
            this.radioButton_rel = new System.Windows.Forms.RadioButton();
            this.button_excute = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_init = new System.Windows.Forms.Button();
            this.label_version = new System.Windows.Forms.Label();
            this.button_close = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label_axis = new System.Windows.Forms.Label();
            this.label_cardNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_top = new System.Windows.Forms.Panel();
            this.label_Close = new System.Windows.Forms.Label();
            this.label_Title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_main.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Dist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Tdec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Spara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Tacc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_StopVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Val)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_StartVal)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.panel_main.Controls.Add(this.groupBox3);
            this.panel_main.Controls.Add(this.groupBox2);
            this.panel_main.Controls.Add(this.button_excute);
            this.panel_main.Controls.Add(this.groupBox1);
            this.panel_main.Controls.Add(this.panel_top);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(1, 1);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(412, 627);
            this.panel_main.TabIndex = 2;
            this.panel_main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panel_main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox_axis);
            this.groupBox3.Controls.Add(this.numericUpDown_Dist);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.numericUpDown_Tdec);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.numericUpDown_Spara);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.numericUpDown_Tacc);
            this.groupBox3.Controls.Add(this.numericUpDown_StopVal);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.numericUpDown_Val);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.numericUpDown_StartVal);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(22, 354);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(362, 195);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "运动参数";
            // 
            // comboBox_axis
            // 
            this.comboBox_axis.FormattingEnabled = true;
            this.comboBox_axis.Location = new System.Drawing.Point(100, 151);
            this.comboBox_axis.Name = "comboBox_axis";
            this.comboBox_axis.Size = new System.Drawing.Size(70, 29);
            this.comboBox_axis.TabIndex = 7;
            // 
            // numericUpDown_Dist
            // 
            this.numericUpDown_Dist.Location = new System.Drawing.Point(278, 151);
            this.numericUpDown_Dist.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_Dist.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.numericUpDown_Dist.Name = "numericUpDown_Dist";
            this.numericUpDown_Dist.Size = new System.Drawing.Size(70, 29);
            this.numericUpDown_Dist.TabIndex = 6;
            this.numericUpDown_Dist.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(182, 153);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 25);
            this.label12.TabIndex = 5;
            this.label12.Text = "运动位置:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_Tdec
            // 
            this.numericUpDown_Tdec.DecimalPlaces = 2;
            this.numericUpDown_Tdec.Location = new System.Drawing.Point(278, 116);
            this.numericUpDown_Tdec.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Tdec.Name = "numericUpDown_Tdec";
            this.numericUpDown_Tdec.Size = new System.Drawing.Size(70, 29);
            this.numericUpDown_Tdec.TabIndex = 6;
            this.numericUpDown_Tdec.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(182, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 25);
            this.label10.TabIndex = 5;
            this.label10.Text = "减速时间:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_Spara
            // 
            this.numericUpDown_Spara.DecimalPlaces = 2;
            this.numericUpDown_Spara.Location = new System.Drawing.Point(278, 81);
            this.numericUpDown_Spara.Name = "numericUpDown_Spara";
            this.numericUpDown_Spara.Size = new System.Drawing.Size(70, 29);
            this.numericUpDown_Spara.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(182, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 25);
            this.label8.TabIndex = 5;
            this.label8.Text = "S段时间:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_Tacc
            // 
            this.numericUpDown_Tacc.DecimalPlaces = 2;
            this.numericUpDown_Tacc.Location = new System.Drawing.Point(100, 116);
            this.numericUpDown_Tacc.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_Tacc.Name = "numericUpDown_Tacc";
            this.numericUpDown_Tacc.Size = new System.Drawing.Size(70, 29);
            this.numericUpDown_Tacc.TabIndex = 6;
            this.numericUpDown_Tacc.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // numericUpDown_StopVal
            // 
            this.numericUpDown_StopVal.Location = new System.Drawing.Point(278, 46);
            this.numericUpDown_StopVal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_StopVal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_StopVal.Name = "numericUpDown_StopVal";
            this.numericUpDown_StopVal.Size = new System.Drawing.Size(70, 29);
            this.numericUpDown_StopVal.TabIndex = 6;
            this.numericUpDown_StopVal.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(4, 153);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 25);
            this.label11.TabIndex = 5;
            this.label11.Text = "运动轴号:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_Val
            // 
            this.numericUpDown_Val.Location = new System.Drawing.Point(100, 81);
            this.numericUpDown_Val.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Val.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Val.Name = "numericUpDown_Val";
            this.numericUpDown_Val.Size = new System.Drawing.Size(70, 29);
            this.numericUpDown_Val.TabIndex = 6;
            this.numericUpDown_Val.Value = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(4, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 25);
            this.label9.TabIndex = 5;
            this.label9.Text = "加速时间:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(182, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "停止速度:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(4, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "运行速度:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_StartVal
            // 
            this.numericUpDown_StartVal.Location = new System.Drawing.Point(100, 46);
            this.numericUpDown_StartVal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_StartVal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_StartVal.Name = "numericUpDown_StartVal";
            this.numericUpDown_StartVal.Size = new System.Drawing.Size(70, 29);
            this.numericUpDown_StartVal.TabIndex = 6;
            this.numericUpDown_StartVal.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "起始速度:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_abs);
            this.groupBox2.Controls.Add(this.radioButton_rel);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(22, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 85);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "运动模式";
            // 
            // radioButton_abs
            // 
            this.radioButton_abs.AutoSize = true;
            this.radioButton_abs.Location = new System.Drawing.Point(199, 37);
            this.radioButton_abs.Name = "radioButton_abs";
            this.radioButton_abs.Size = new System.Drawing.Size(60, 25);
            this.radioButton_abs.TabIndex = 0;
            this.radioButton_abs.Text = "绝对";
            this.radioButton_abs.UseVisualStyleBackColor = true;
            // 
            // radioButton_rel
            // 
            this.radioButton_rel.AutoSize = true;
            this.radioButton_rel.Checked = true;
            this.radioButton_rel.Location = new System.Drawing.Point(103, 37);
            this.radioButton_rel.Name = "radioButton_rel";
            this.radioButton_rel.Size = new System.Drawing.Size(60, 25);
            this.radioButton_rel.TabIndex = 0;
            this.radioButton_rel.TabStop = true;
            this.radioButton_rel.Text = "相对";
            this.radioButton_rel.UseVisualStyleBackColor = true;
            // 
            // button_excute
            // 
            this.button_excute.BackgroundImage = global::tolson.BoosterStation.Properties.Resources.Border;
            this.button_excute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_excute.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_excute.FlatAppearance.BorderSize = 0;
            this.button_excute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_excute.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_excute.ForeColor = System.Drawing.Color.White;
            this.button_excute.Location = new System.Drawing.Point(142, 568);
            this.button_excute.Name = "button_excute";
            this.button_excute.Size = new System.Drawing.Size(129, 39);
            this.button_excute.TabIndex = 4;
            this.button_excute.Text = "执行运动";
            this.button_excute.UseVisualStyleBackColor = true;
            this.button_excute.Click += new System.EventHandler(this.button_excute_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_init);
            this.groupBox1.Controls.Add(this.label_version);
            this.groupBox1.Controls.Add(this.button_close);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label_axis);
            this.groupBox1.Controls.Add(this.label_cardNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(22, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 179);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "卡控制";
            // 
            // button_init
            // 
            this.button_init.BackgroundImage = global::tolson.BoosterStation.Properties.Resources.Border;
            this.button_init.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_init.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_init.FlatAppearance.BorderSize = 0;
            this.button_init.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_init.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_init.ForeColor = System.Drawing.Color.White;
            this.button_init.Location = new System.Drawing.Point(78, 28);
            this.button_init.Name = "button_init";
            this.button_init.Size = new System.Drawing.Size(92, 39);
            this.button_init.TabIndex = 4;
            this.button_init.Text = "初始化卡";
            this.button_init.UseVisualStyleBackColor = true;
            this.button_init.Click += new System.EventHandler(this.button_init_Click);
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.ForeColor = System.Drawing.Color.White;
            this.label_version.Location = new System.Drawing.Point(197, 146);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(107, 21);
            this.label_version.TabIndex = 5;
            this.label_version.Text = "label_version";
            // 
            // button_close
            // 
            this.button_close.BackgroundImage = global::tolson.BoosterStation.Properties.Resources.Border;
            this.button_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button_close.FlatAppearance.BorderSize = 0;
            this.button_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_close.ForeColor = System.Drawing.Color.White;
            this.button_close.Location = new System.Drawing.Point(199, 28);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(92, 39);
            this.button_close.TabIndex = 4;
            this.button_close.Text = "关闭轴卡";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(60, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "固件版本:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_axis
            // 
            this.label_axis.AutoSize = true;
            this.label_axis.ForeColor = System.Drawing.Color.White;
            this.label_axis.Location = new System.Drawing.Point(197, 115);
            this.label_axis.Name = "label_axis";
            this.label_axis.Size = new System.Drawing.Size(81, 21);
            this.label_axis.TabIndex = 5;
            this.label_axis.Text = "label_axis";
            // 
            // label_cardNo
            // 
            this.label_cardNo.AutoSize = true;
            this.label_cardNo.ForeColor = System.Drawing.Color.White;
            this.label_cardNo.Location = new System.Drawing.Point(197, 85);
            this.label_cardNo.Name = "label_cardNo";
            this.label_cardNo.Size = new System.Drawing.Size(109, 21);
            this.label_cardNo.TabIndex = 5;
            this.label_cardNo.Text = "label_cardNo";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(60, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "卡号:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(60, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "轴数:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.panel_top.Size = new System.Drawing.Size(412, 50);
            this.panel_top.TabIndex = 0;
            this.panel_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panel_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // label_Close
            // 
            this.label_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_Close.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Close.ForeColor = System.Drawing.Color.White;
            this.label_Close.Location = new System.Drawing.Point(371, 0);
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
            this.label_Title.Size = new System.Drawing.Size(126, 26);
            this.label_Title.TabIndex = 3;
            this.label_Title.Text = "雷赛卡Demo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::tolson.BoosterStation.Properties.Resources.Param;
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
            this.label1.Size = new System.Drawing.Size(412, 1);
            this.label1.TabIndex = 1;
            // 
            // FormLSMotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 629);
            this.Controls.Add(this.panel_main);
            this.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormLSMotion";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模板窗体";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            this.panel_main.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Dist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Tdec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Spara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Tacc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_StopVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Val)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_StartVal)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Label label_Close;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_init;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_version;
        private System.Windows.Forms.Label label_axis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_cardNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton_abs;
        private System.Windows.Forms.RadioButton radioButton_rel;
        private System.Windows.Forms.NumericUpDown numericUpDown_StartVal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_StopVal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown_Dist;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDown_Tdec;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown_Spara;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown_Tacc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown_Val;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button_excute;
        private System.Windows.Forms.ComboBox comboBox_axis;
    }
}