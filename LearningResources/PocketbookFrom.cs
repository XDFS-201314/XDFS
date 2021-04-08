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
using FamilySystem.Common;
using System.Collections;

namespace LearningResources {
    /// <summary>
    /// 
    /// </summary>
    public partial class PocketbookFrom : DevExpress.XtraEditors.XtraForm {
        /// <summary>
        /// 
        /// </summary>
        public PocketbookFrom() {
            xwsoftware.Base.Common.StyleClass.froms(this);
            InitializeComponent();
            //Color _Mycolor = Color.FromArgb(0x20B2AA);                  //默认透明度为255；Red=58, Green=157, Blue=82
            //Color _Mycolor2 = Color.FromArgb(255, 255, 205);          //透明度=255 ，Red=58, Green=200, Blue=100
            ////SolidColorBrush myBrush = new SolidColorBrush(_Mycolor);     //定义纯色绘制 变量
            ////SolidColorBrush myBrush2 = new SolidColorBrush(_Mycolor2);    //定义纯色绘制 变量 
            //Color Color1 = System.Drawing.ColorTranslator.FromHtml("#83C75D");
            ////simpleButton1.ForeColor = System.Drawing.Color.FromName("A52A2A");
            //simpleButton1.ForeColor = Color1;
            //notebook.parameter (Color.Red);

        }
        /// <summary>
        /// 改变richTextBox中指定字符串的颜色
        /// 调用即可
        /// </summary>
        /// <param name="str" value="为指定的字符串"></param>
        public void changeColor(string str) {
            //    ArrayList list = getIndexArray(GrammarTxt.Text, str);
            //    for (int i = 0; i < list.Count; i++) {
            //        int index = (int)list[i];
            //        GrammarTxt.Select(index, str.Length);
            //        GrammarTxt.SelectionColor = Color.Green;
            //    }
        }

        //using System.Collections;

        //public ArrayList getIndexArray(String inputStr, String findStr) {
        //ArrayList list = new ArrayList();
        //int start = 0;
        //while (start < inputStr.Length) {
        //    int index = inputStr.IndexOf(findStr, start);
        //    if (index >= 0) {
        //        list.Add(index);
        //        start = index + findStr.Length;
        //    } else {
        //        break;
        //    }
        //}
        //return list;
        //}

    }
}