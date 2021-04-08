using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace xwsoftware.Base
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TimeControls : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public TimeControls()
        {
            InitializeComponent();
            simpleButton5.ForeColor = simpleButton8.ForeColor = simpleButton11.ForeColor = simpleButton14.ForeColor = simpleButton17.ForeColor = simpleButton20.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F09C42");
        }

        private void TimeControls_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            var data = DateTime.Now.ToString("yyyyMMddHHmmss");
            for (int i = 0; i < data.Length; i++)
            {
                //年
                if (i == 0) { simpleButton1.Text = data.Substring(0, 4);}
                //月
                if (i == 4) { simpleButton6.Text = data.Substring(4, 2);}
                //日
                if (i == 6) { simpleButton9.Text = data.Substring(6, 2);}
                //
                if (i == 8) { simpleButton12.Text = data.Substring(8, 2);}
                //
                if (i == 10) { simpleButton15.Text = data.Substring(10, 2);}
                //
                if (i == 12) { simpleButton18.Text = data.Substring(12, 2);}
            }
        }
    }
}
