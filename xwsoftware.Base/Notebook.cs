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

namespace xwsoftware.Base {
    /// <summary>
    /// 
    /// </summary>
    public partial class Notebook : DevExpress.XtraEditors.XtraUserControl {
        private int Count = 1;//当前行数
        /// <summary>
        /// 
        /// </summary>
        public Notebook() {
            InitializeComponent();
            memoEdit1.ForeColor = this.ForeColor;
            listBoxControl1.ForeColor = this.ForeColor;

        }
        /// <summary>
        /// 字体颜色设置
        /// </summary>
        /// <param name="color"></param>
        public void parameter(Color color) {

        }
        private void memoEdit1_EditValueChanged(object sender, EventArgs e) {
            List<string> list = new List<string>();
            for (int i = 1; i <= memoEdit1.Lines.Count(); i++) {
                list.Add(i.ToString());
                //listBoxControl1.SetSelected(System.Text.RegularExpressions.Regex.Matches(Convert.ToString(memoEdit1.EditValue), "\r\n").Count, true);
                Count = i;
            }
            listBoxControl1.DataSource = list;
            listBoxControl1.SetSelected(Count-1, true);
        }
    }
}
