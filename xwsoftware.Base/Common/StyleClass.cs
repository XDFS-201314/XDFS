using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xwsoftware.Base.Common {
    /// <summary>
    /// 控件样式类型
    /// </summary>
    public static class StyleClass {

        /// <summary>
        /// 窗体初始化
        /// </summary>
        /// <param name="frm"></param>
        public static void froms(Form frm) {
            frm.Visible = true;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
        }

        #region
        /// <summary>
        /// RibbonControl控件样式
        /// </summary>
        /// <param name="ribbonControl1"></param>
        public static void RibbonControlStyle(RibbonControl ribbonControl1) {
            ribbonControl1.ShowToolbarCustomizeItem = false; //隐藏快捷访问工具栏按钮，默认为true
            ribbonControl1.ShowCategoryInCaption = false; //不显示
            ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;//隐藏右上角箭头图标
            ribbonControl1.ShowFullScreenButton = DevExpress.Utils.DefaultBoolean.True; //设置全屏按钮不显示
            ribbonControl1.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
            ribbonControl1.DrawGroupCaptions = DevExpress.Utils.DefaultBoolean.False;//去掉RibbonPageGroup1名的显示
            ribbonControl1.Minimized = false;
            ribbonControl1.ShowToolbarCustomizeItem = false;
            ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            //ribbonControl1./*ShowCategoryInCaption*/
        }
        /// <summary>
        /// RibbonPageGroup样式
        /// </summary>
        /// <param name="RibbonPageGroup1"></param>
        public static void RibbonPageGroupStyle(RibbonPageGroup RibbonPageGroup1) {
            RibbonPageGroup1.ShowCaptionButton = false; //隐藏页面组标题按钮
        }
        /// <summary>
        /// 设置自动适应模式，图片和文字自动换行，各个barButton之间横排。
        /// </summary>
        /// <param name="barButtonItem1"></param>
        public static void BarButtonItemStyle(BarButtonItem barButtonItem1) {
            barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.All; //设置自动适应模式，图片和文字自动换行，各个barButton之间横排。
        }




        /// <summary>
        /// RibbonForm的设置
        /// </summary>
        /// <param name="ribbonForm1"></param>
        public static void RibbonFormStyle(RibbonForm ribbonForm1) {
            ribbonForm1.MinimizeBox = false;
            ribbonForm1.MaximizeBox = false;
            ribbonForm1.CloseBox = false;
            //ribbonForm1.FormBorderStyle = FormBorderStyle.None;
            ribbonForm1.Text = "";
            ribbonForm1.ControlBox = false;
            //没有标题            
            ribbonForm1.FormBorderStyle = FormBorderStyle.None;
            //任务栏不显示            
            ribbonForm1.ShowInTaskbar = false;
        }


        #endregion

        #region 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="gridColumnlist"></param>
        public static void GridViewStyle(GridView gridView,List<GridColumn> gridColumnlist) {
            foreach (GridColumn gridColumn in gridColumnlist) {
                gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                    gridColumn
                } );
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gridColumn"></param>
        public static void GridColumnStyle(GridColumn gridColumn) {
            gridColumn.AppearanceCell.BackColor = System.Drawing.Color.Red;
            gridColumn.AppearanceCell.BackColor2 = System.Drawing.Color.Lime;
            gridColumn.AppearanceCell.BorderColor = System.Drawing.Color.Black;
            gridColumn.AppearanceCell.Options.UseBackColor = true;
            gridColumn.AppearanceCell.Options.UseBorderColor = true;
            gridColumn.Caption = "gridColumn1";
            gridColumn.FieldName = "id";
            gridColumn.MinWidth = 10;
            gridColumn.Name = "gridColumn1";
            gridColumn.ToolTip = "XW";
            gridColumn.Visible = true;
            gridColumn.VisibleIndex = 0;
            gridColumn.Width = 100;
            //
            gridColumn.DisplayFormat.FormatString = "F2";// 数据：Numeric ="F2"  时间:DateTime = "yyyy-MM-DD HH:ss:mm" 自定义格式:Custom = 这是自定义格式:{0}
            gridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
        }

     
        #endregion
    }
}
