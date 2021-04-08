using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commonalityClass.strings {
    public class stringhandle {

        #region 字符操作方法
        //1.字符截取str.Substring(0,1);
        //2.字符差分str.Split('');根据指定char类型字符进行差分
        //3.字符删除str.Remove(0,2);
        //4.字符查询str.IndexOf();
        #endregion
            
        /// <summary>
        /// 字母全部转换为大写或小写
        /// </summary>
        /// <param name="btn_type">类型</param>
        /// <param name="contents">转换内容类型</param>
        /// <returns></returns>
        public static string rbtn_upper(bool btn_type, string contents) {
            if (btn_type) {
                contents.ToUpper();
            } else {
                contents.ToLower();
            }
            return contents;
        }

        /// <summary>
        /// 字符转换ASCII
        /// </summary>
        /// <param name="str_ASCII">输入内容</param>
        /// <returns></returns>
        public static string assii_str(string str_ASCII) {
            string str = string.Empty;
            if (Encoding.GetEncoding("unicode").GetBytes(new char[] { str_ASCII[0] })[1] == 0) {//判断输入是为字母
                str = Encoding.GetEncoding("unicode").GetBytes(str_ASCII)[0].ToString(); //获得字符的ASCII码值
            } else {
                str = string.Empty;
            }


            return "str";
        }
        /// <summary>
        /// ASCII转换为字符
        /// </summary>
        /// <param name="str_ASCII"></param>
        /// <returns></returns>
        public static string str_assii(string str_ASCII) {
            string str = string.Empty;
            int P_int_Num;
            if (int.TryParse(str_ASCII, out P_int_Num)) {
                str = ((char)P_int_Num).ToString();
                //string P_str = Encoding.GetEncoding("unicode").GetBytes(new char[] { str_ASCII[0] })[0].ToString();
            }
            return "str";
        }

        /// <summary>
        /// 得到汉字区位码方法
        /// </summary>
        /// <param name="strChinese">汉字字符</param>
        /// <returns>返回汉字区位码</returns>
        public static string getCode(string Chinese) {
            byte[] P_bt_array = Encoding.Default.GetBytes(Chinese);//得到汉字的Byte数组
            int front = (short)(P_bt_array[0] - '\0');//将字节数组的第一位转换成short类型
            int back = (short)(P_bt_array[1] - '\0');//将字节数组的第二位转换成short类型
            return (front - 160).ToString() + (back - 160).ToString();//计算并返回区位码
        }
        /// <summary>
        /// 汉字转换拼音
        /// </summary>
        /// <param name="ChineseString">输入的汉字</param>
        /// <returns></returns>
        public static string txt_Chinese(string ChineseString) {
            return new PinYin().GetABC(ChineseString);//调用拼音类的GetABC方法得到拼音字符串
        }
        /// <summary>
        /// 字符串按，换行
        /// </summary>
        /// <param name="txt_string">字符</param>
        /// <returns></returns>
        public static string btn_true(string txt_string,char P_chr) {
            StringBuilder P_stringbuilder = new StringBuilder(txt_string);//创建字符处理对象
            for (int i = 0; i < P_stringbuilder.Length; i++) {
                if (P_stringbuilder[i]== P_chr && P_stringbuilder[i]== P_chr) {//判断是否出现(,)号
                    P_stringbuilder.Insert(++i,//向字符串内添加换行符
                        Environment.NewLine);
                }
            }
            return P_stringbuilder.ToString();
        }

        /// <summary>
        /// 字符反转
        /// </summary>
        /// <param name="str_ipt">字符</param>
        /// <returns></returns>
        public static string txt_Iput(string str_ipt) {
            char[] P_chr = str_ipt.ToCharArray();
            Array.Reverse(P_chr,0, str_ipt.Length);//反转字节数组
            return new StringBuilder().Append(P_chr).ToString();
        }

        /// <summary>
        /// 数组方式去字符的空格
        /// 其他方法
        /// str.trim(); //去掉首尾空格
        /// str.replace(" ", ""); //去除所有空格，包括首尾、中间
        /// str.replaceAll(" ", ""); //去掉所有空格，包括首尾、中间
        /// str.replaceAll(" +", "");  //去掉所有空格，包括首尾、中间
        /// str.replaceAll("\\s*", ""); //可以替换大部分空白字符， 不限于空格 ；
        /// </summary>
        /// <param name="str_string"></param>
        /// <returns></returns>
        public static string str_null(string S_str) {   
            char[] P_chr = S_str.ToCharArray();//得到字符数组
            IEnumerator P_ienumerator_chr = P_chr.GetEnumerator();//得到枚举器
            StringBuilder P_stringbuilder = new StringBuilder();
            while (P_ienumerator_chr.MoveNext()) {//开始枚举
                P_stringbuilder.Append(
                    (char)P_ienumerator_chr.Current != ' '?P_ienumerator_chr.Current.ToString():string.Empty
                    );
            }
            return P_stringbuilder.ToString();
        }
        #region 字符去重
        /// <summary>
        /// 方法1
        /// </summary>
        /// <param name="str">字符串内容</param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string removedb(string str ,string tailed) {
            return string.Join(",",str.Split(',').Distinct().ToArray());
        }
        /// <summary>
        /// 方法2
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string removedb2(string str) {
            string result = string.Empty;
            ArrayList list = array(str);
            for (int i = 0; i < list.Count; i++) {
                if (i==list.Count - 1) {
                    result += list[i];
                } else {
                    result += list[i] + ",";
                }
            }
            return result;
        }
        private static ArrayList array(string str) {
            ArrayList aimArr = new ArrayList();
            ArrayList strArr = new ArrayList();
            string[] strs = str.Split(',');
            foreach (string s in strs) {
                strArr.Add(s);
            }
            for (int i = 0; i < strs.Length; i++) {
                if (!aimArr.Contains(strs[i])) {
                    aimArr.Add(strs[i]);
                }
            }
            return aimArr;
        }
        /// <summary>
        /// 方法3[正则表达式]
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string removedb3(string str) {
         string input = System.Text.RegularExpressions.Regex.Replace(str + ",", @"(?:([^,]+,))(?=.*?\1)", "");
            return input.Substring(0,input.Length-1);
        }
        #endregion

        #region 字符分离
        //string P_str_all = openFileDialog1.FileName;//记录选择的文件全路径
        //string P_str_path = //获取文件路径
        //    P_str_all.Substring(0, P_str_all.LastIndexOf("\\") + 1);
        //string P_str_filename = //获取文件名
        //    P_str_all.Substring(P_str_all.LastIndexOf("\\") + 1,
        //    P_str_all.LastIndexOf(".") -
        //    (P_str_all.LastIndexOf("\\") + 1));
        //string P_str_fileexc = //获取文件扩展名
        //    P_str_all.Substring(P_str_all.LastIndexOf(".") + 1,
        //    P_str_all.Length - P_str_all.LastIndexOf(".") - 1);
        //lb_filepath.Text = "文件路径： " + P_str_path;//显示文件路径
        //        lb_filename.Text = "文件名称： " + P_str_filename;//显示文件名
        //        lb_fileexc.Text = "文件扩展名： " + P_str_fileexc;//显示扩展名
        #endregion



        
    }
}
