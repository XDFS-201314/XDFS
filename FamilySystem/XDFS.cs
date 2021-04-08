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
using DevExpress.XtraTab;
using DevExpress.Utils;
using FamilySystem.Common;

namespace FamilySystem
{
    public partial class XDFS : DevExpress.XtraEditors.XtraForm
    {
        public XDFS()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-Hans");
            InitializeComponent();
        }
        //CefSharp.WinForms.ChromiumWebBrowser webCom = null;
        private void XDFS_Load(object sender, EventArgs e) {
            timer1.Start();
        }

        #region 实现页面加载
        ///<summary>
        ///将控件添加到标签页中
        ///</summary>
        ///<param name="PageName">窗体名</param>
        ///<param name="ctrl">添加的From/CefSharp.WinForms.ChromiumWebBrowser webComhtml = null</param>
        private void AddControlToPage(string PageName, Form frm =null, XtraTabControl xtraTabControl =null)
        {
            WaitDialogForm waitFrm = new WaitDialogForm("x x", "xxx");
            try
            {
                foreach (XtraTabPage page in xtraTabControl.TabPages)
                {
                    if (page.Text == PageName)
                    {
                        xtraTabControl.SelectedTabPage = page;//显示该页面
                        return;
                    }
                }
                XtraTabPage xpage = new XtraTabPage();
                xpage.Name = PageName;
                xpage.Text = PageName;
                if (frm != null) {
                    //frm.MdiParent = this;
                    frm.Visible = true;
                    frm.Dock = DockStyle.Fill;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.TopLevel = false;
                    xpage.Controls.Add(frm);//添加要增加的页面
                    
                }
                //if (webComhtml != null) {
                //    xpage.Controls.Add(webComhtml);//添加要增加的页面
                //}
                xtraTabControl.TabPages.Add(xpage);
                xtraTabControl.SelectedTabPage = xpage;
            }
            catch (Exception ex)
            {
                waitFrm.Refresh();
                waitFrm.SetCaption($"加载异常{ex.ToString()}");
                XtraMessageBox.Show(ex.ToString());
            } finally {
                waitFrm.Close();
            }
           
        }
        /// <summary>
        /// 关掉窗体
        /// </summary>
        /// <param name="pageName"></param>
        /// <param name="xtraTabControl"></param>
        private void RemoveControlToPage(string pageName, XtraTabControl xtraTabControl)
        {
            foreach (XtraTabPage page in xtraTabControl.TabPages)
            {
                if (page.Text == pageName)
                {
                    xtraTabControl.TabPages.Remove(page);
                    page.Dispose();
                    return;
                }
            }
        }
        #endregion
        private void xd_routine_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //
            //CommonClass.fromWidth = xtraTabControl1.Width;
            //CommonClass.fromHeight = xtraTabControl1.Height;
            AddControlToPage(xd_routine.Caption, new LearningResources.PocketbookFrom(), xtraTabControl1);
            //
        }

        private void Pr_flat_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            AddControlToPage(Pr_flat.Caption, new Xwsoftware.Display.Routineform(), xtraTabControl1);
            //Task.Run(() => {
            //});
        }

        private void setting_Up_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
                 AddControlToPage(setting_Up.Caption, new xwsoftware.Base.frmSeting(), xtraTabControl1);
        }

        private void timer1_Tick(object sender, EventArgs e) {
            //labelControl1.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
        }

        private void Collectchk_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            AddControlToPage(Collectchk.Caption, new Collectforms.Collectform(), xtraTabControl1);
        }

      

        private void Everyday_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            AddControlToPage(Everyday.Caption, new Xwsoftware.Family.EverydayForm(), xtraTabControl1);
        }

        private void Expense_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            AddControlToPage(Expense.Caption, new Xwsoftware.Family.ExpenseForm(), xtraTabControl1);
        }

        private void Video_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            AddControlToPage(Video.Caption, new Xwsoftware.Family.VideoForm(), xtraTabControl1);
        }

        private void Favour_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
                AddControlToPage(Favour.Caption, new Xwsoftware.Family.FavourForm(), xtraTabControl1);
        }

        private void Diary_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
                AddControlToPage(Diary.Caption, new Xwsoftware.Family.DiaryForm(), xtraTabControl1);
        }

        private void plan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
                AddControlToPage(plan.Caption, new Xwsoftware.Family.PlanForm(), xtraTabControl1);
        }

        private void Humor_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            AddControlToPage(Humor.Caption, new Collectforms.HumorForm(), xtraTabControl1);
        }

        private void Love_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
             AddControlToPage(Love.Caption, new Collectforms.LoveForm(), xtraTabControl1);
        }

        private void Rest_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
             AddControlToPage(Rest.Caption, new Collectforms.RestForm(), xtraTabControl1);
        }

        private void photography_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
                 AddControlToPage(photography.Caption, new LearningResources.PhotographyForm(), xtraTabControl1);
        }

        private void letter_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
                AddControlToPage(letter.Caption, new LearningResources.LetterForm(), xtraTabControl1);
        }

        private void restnote_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
                  AddControlToPage(restnote.Caption, new LearningResources.RestnoteForm(), xtraTabControl1);
        }

        private void television_resource_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
                 AddControlToPage(television_resource.Caption, new Xwsoftware.Display.Television_ResourceForm(), xtraTabControl1);
        }

        private void Letter__Resource_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
                  AddControlToPage(Letter__Resource.Caption, new Xwsoftware.Display.Letter__ResourceForm(), xtraTabControl1);
        }

        private void Rest_Resource_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
                  AddControlToPage(Rest_Resource.Caption, new Xwsoftware.Display.Rest_ResourceForm(), xtraTabControl1);
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs eArg = (DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs)e;
            RemoveControlToPage(eArg.Page.Text, xtraTabControl1);
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            //string url = Application.StartupPath + "\\test.html";//请求页面地址
            //webCom = new CefSharp.WinForms.ChromiumWebBrowser(url);//传入地址，实例化页面对象
            //webCom.Dock = DockStyle.Fill;//指定页面停靠位置和方式
            //AddControlToPage(plan.Caption, null, xtraTabControl1, webCom);
        }
    }
}