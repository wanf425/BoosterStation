namespace tolson.BoosterStation
{
    partial class MeteShow
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label_parameterName = new System.Windows.Forms.Label();
            this.xbdAnalogMeter1 = new xbd.ControlLib.xbdAnalogMeter();
            this.label_ParameterValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_parameterName
            // 
            this.label_parameterName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_parameterName.ForeColor = System.Drawing.Color.White;
            this.label_parameterName.Location = new System.Drawing.Point(0, 126);
            this.label_parameterName.Name = "label_parameterName";
            this.label_parameterName.Size = new System.Drawing.Size(122, 24);
            this.label_parameterName.TabIndex = 0;
            this.label_parameterName.Text = "属性名称";
            this.label_parameterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xbdAnalogMeter1
            // 
            this.xbdAnalogMeter1.BodyColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.xbdAnalogMeter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xbdAnalogMeter1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xbdAnalogMeter1.Location = new System.Drawing.Point(0, 0);
            this.xbdAnalogMeter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.xbdAnalogMeter1.MaxValue = 100D;
            this.xbdAnalogMeter1.MinValue = 0D;
            this.xbdAnalogMeter1.Name = "xbdAnalogMeter1";
            this.xbdAnalogMeter1.NeedleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.xbdAnalogMeter1.Renderer = null;
            this.xbdAnalogMeter1.ScaleColor = System.Drawing.Color.White;
            this.xbdAnalogMeter1.ScaleDivisions = 11;
            this.xbdAnalogMeter1.ScaleSubDivisions = 4;
            this.xbdAnalogMeter1.Size = new System.Drawing.Size(122, 126);
            this.xbdAnalogMeter1.TabIndex = 1;
            this.xbdAnalogMeter1.Value = 0D;
            this.xbdAnalogMeter1.ViewGlass = false;
            // 
            // label_ParameterValue
            // 
            this.label_ParameterValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label_ParameterValue.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ParameterValue.ForeColor = System.Drawing.Color.Black;
            this.label_ParameterValue.Location = new System.Drawing.Point(20, 103);
            this.label_ParameterValue.Name = "label_ParameterValue";
            this.label_ParameterValue.Size = new System.Drawing.Size(83, 26);
            this.label_ParameterValue.TabIndex = 2;
            this.label_ParameterValue.Text = "0.00 ℃";
            this.label_ParameterValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MeteShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(9)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.label_ParameterValue);
            this.Controls.Add(this.xbdAnalogMeter1);
            this.Controls.Add(this.label_parameterName);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MeteShow";
            this.Size = new System.Drawing.Size(122, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_parameterName;
        private xbd.ControlLib.xbdAnalogMeter xbdAnalogMeter1;
        private System.Windows.Forms.Label label_ParameterValue;
    }
}
