using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Collectforms {
    public partial class HumorForm : DevExpress.XtraEditors.XtraForm {
        public HumorForm() {
            InitializeComponent();
        }

        private void HumorForm_Load(object sender, EventArgs e) {
            //WebBrowser webBrowser1 = new WebBrowser();
            //webBrowser1.Url = new Uri("https://www.baidu.com/");//加载网址链接到控件
            //webBrowser1.Refresh(); //刷新页面
            //panelControl1.Controls.Add(webBrowser1);//向panel1控件里添加页面
        }
    }
}