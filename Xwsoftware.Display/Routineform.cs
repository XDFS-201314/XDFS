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

namespace Xwsoftware.Display {
    public partial class Routineform : DevExpress.XtraEditors.XtraForm {
        public Routineform() {
            xwsoftware.Base.Common.StyleClass.froms(this);
            InitializeComponent();
            xwsoftware.Base.Common.StyleClass.RibbonControlStyle(ribbonControl1);
            xwsoftware.Base.Common.StyleClass.RibbonPageGroupStyle(ribbonPageGroup1);
            xwsoftware.Base.Common.StyleClass.BarButtonItemStyle(barButtonItem2);
        }
    }
}