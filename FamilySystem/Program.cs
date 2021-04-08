using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Threading;
using System.Reflection;
using DevExpress.XtraEditors;

namespace FamilySystem
{
    static class Program
    {
        private static ApplicationContext context;
        private static XDFS mForm;
        private static Thread oThread;
        private static XtraForm1 sForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            //更多皮肤样式：
            //| DevExpress Style | Caramel | Money Twins | DevExpress Dark Style| iMaginary
            //| Lilian | Black | Blue | Office 2010 Blue | Office 2010 Black | Office 2010 Silver
            //| Office 2007 Blue | Office 2007 Black | Officmetre 2007 Silver | Office 2007 Green
            //| Office 2007 Pink | Seven | Seven Classic | Darkroom | McSkin | Sharp | Sharp Plus
            //| Foggy | Dark Side | Xmas(Blue) | Springtime | Summer | Pumpkin | Valentine | Stardust
            //| Coffee | Glass Oceans | High Contrast | Liquid Sky | London Liquid Sky| The Asphalt World| Blueprint |
            UserLookAndFeel.Default.SetSkinStyle("Pumpkin");
            Application.Run(new XDFS());
            //UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            ////UserLookAndFeel.Default.SkinName = "DevExpress Dark Style";
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            //bool bMutexCreated = true;
            //using (new Mutex(true, Assembly.GetExecutingAssembly().FullName, out bMutexCreated)) {
            //    if (!bMutexCreated) {
            //        DevExpress.XtraEditors.XtraMessageBox.Show("已经存在一个实例在运行!");
            //        return;
            //    }
            //    //FrmLogin frmLogin = new FrmLogin();
            //    //if (frmLogin.ShowDialog() == DialogResult.OK) {
            //    //DoStartup();
            //    //}
            //    Application.Run(new XDFS());
            //}
            //Application.Run(new FrmLogin());
            //Application.Run(new FrmMain());
        }
        static void DoStartup() {
            try {

                sForm = new XtraForm1();
                //新建一个线程
                oThread = new Thread(new ThreadStart(ShowFlash));
                //设置线程级别
                oThread.Priority = ThreadPriority.Lowest;
                //后台线程
                oThread.IsBackground = true;
                //启动flash
                oThread.Start();
                //事件订阅(在线程结束时调用OnAppIdle方法)
                Application.Idle += new EventHandler(OnAppIdle);
                mForm = new XDFS();
                //Application.Run(mForm);
                context = new ApplicationContext();
                Application.Run(context);
            } catch (Exception e) {
                XtraMessageBox.Show(e.ToString());
                Application.Exit();
            }
        }
        /// <summary>
        /// 线程结束后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnAppIdle(object sender, EventArgs e) {
            try {
                if (context.MainForm == null) {
                    //取消事件订阅
                    Application.Idle -= new EventHandler(OnAppIdle);
                    //标识状态
                    //mForm.PreLoad();
                    //为当前线程设置主窗体
                    context.MainForm = mForm;
                    //启动主界面
                    Thread.Sleep(5000);
                    context.MainForm.Show();
                    //终止flash
                    oThread.Abort();
                    GC.Collect();
                    Application.DoEvents();
                }
            } catch (Exception ex) {
                XtraMessageBox.Show(ex.ToString());
            }
        }

        static void ShowFlash() {
            sForm.ShowDialog();
        }
    }
    
}
