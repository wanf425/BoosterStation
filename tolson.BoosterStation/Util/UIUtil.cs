using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tolson.BoosterStation.Util
{
    public class UIUtil
    {
        /// <summary>
        /// 在parentControl中切换childControl
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="childControl"></param>
        public static void UISwitch(Control parentControl, Control childControl)
        {
            // 填充整个父控件，Size不匹配时，会自动缩放
            childControl.Dock = DockStyle.Fill;

            // 保证线程安全
            if(parentControl.InvokeRequired)
            {
                parentControl.Invoke(new Action(() => AddChildControl(parentControl, childControl)));
            } else
            {
                AddChildControl(parentControl, childControl);
            }
        }

        private static void AddChildControl(Control parentControl, Control childControl)
        {
            parentControl.Controls.Clear();
            parentControl.Controls.Add(childControl);
        }
    }
}
