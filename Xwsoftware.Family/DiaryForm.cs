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

namespace Xwsoftware.Family {
    public partial class DiaryForm : DevExpress.XtraEditors.XtraForm {
        public DiaryForm() {
            xwsoftware.Base.Common.StyleClass.froms(this);
            InitializeComponent();
        }
    }
}