using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tolson.BoosterStation
{
    public partial class MeteShow : UserControl
    {
        public MeteShow()
        {
            InitializeComponent();
        }

        private string paramName = "属性名称";

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取属性名称")]
        public string ParamName
        {
            get { return paramName; }
            set
            {
                paramName = value;
                this.label_parameterName.Text = paramName;
            }
        }

        private float paramValue = 0.0f;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取属性值")]
        public float ParamValue
        {
            get { return paramValue; }
            set
            {
                if(paramValue != value)
                {
                    paramValue = value;
                    this.label_ParameterValue.Text = paramValue.ToString("f2") + " ";
                }
            }
        }

        private string paramUnit = "属性单位";

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取属性单位")]
        public string ParamUnit
        {
            get { return paramUnit; }
            set
            {
                paramUnit = value;
                this.label_ParameterValue.Text = paramValue.ToString("f2") + " " + ParamUnit;
            }
        }

        private float meterMax = 100.0f;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置仪表盘量程最大值")]
        public float MeterMax
        {
            get { return meterMax; }
            set
            {
                meterMax = value;
                this.xbdAnalogMeter1.MaxValue = meterMax;
            }
        }

        private float meterMin = 0.0f;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置仪表盘量程最小值")]
        public float MeterMin
        {
            get { return meterMin; }
            set
            {
                meterMin = value;
                this.xbdAnalogMeter1.MinValue = meterMin;
            }
        }

    }
}
