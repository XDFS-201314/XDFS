using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace commonalityClass.strings {
    /// <summary>
    /// 正则表达类库
    /// </summary>
    public static class regexpstr {

        #region 1.数字验证
        /// <summary>
        /// 验证电话号码格式是否正确
        /// </summary>
        /// <param name="str_telephone">电话号码信息</param>
        /// <returns>方法返回布尔值</returns>
        public static bool IsTelephone(string str_telephone) {
            return Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
        }
        /// <summary>
        /// 验证手机号是否正确
        /// </summary>
        /// <param name="str_handset">手机号码字符串</param>
        /// <returns>返回布尔值</returns>
        public static bool IsHandset(string str_handset) {
            return Regex.IsMatch(str_handset, @"^[1]+[3,5]+\d{9}$");
        }

        /// <summary>
        /// 验证字符类型的密码
        /// </summary>
        /// <param name="str_password">密码字符串</param>
        /// <returns>返回布尔值</returns>
        public static bool IsPassword(string str_password) {
            return Regex.IsMatch(str_password, @"[A-Za-z]+[0-9]");
        }
        /// <summary>
        /// 验证邮编格式是否正确
        /// </summary>
        /// <param name="str_postalcode">邮编字符串</param>
        /// <returns>返回布尔值</returns>
        public static bool IsPostalcode(string str_postalcode) {
            return Regex.IsMatch(str_postalcode, @"^\d{6}$");
        }


        /// <summary>
        /// 验证身份证号是否正确
        /// </summary>
        /// <param name="str_idcard">身份证号字符串</param>
        /// <returns>返回布尔值</returns>
        public static bool IsIDcard(string str_idcard) {
            return System.Text.RegularExpressions.Regex.//使用正则表达式判断是否匹配
                IsMatch(str_idcard, @"(^\d{18}$)|(^\d{15}$)");
        }

        /// <summary>
        /// 验证小数是否正确
        /// </summary>
        /// <param name="str_decimal">小数字符串</param>
        /// <returns>返回布尔值</returns>
        public static bool IsDecimal(string str_decimal) {
            return Regex.IsMatch(str_decimal, @"^[0-9]+(.[0-9]{2})?$");
        }


        /// <summary>
        /// 验证月份是否正确
        /// </summary>
        /// <param name="str_Month">月份信息字符串</param>
        /// <returns>返回布尔值</returns>
        public static bool IsMonth(string str_Month) {
            return Regex.IsMatch(str_Month, @"^(0?[[1-9]|1[0-2])$");
        }

        /// <summary>
        /// 验证每月的31天
        /// </summary>
        /// <param name="str_day">每月的天数</param>
        /// <returns>返回布尔值</returns>
        public static bool IsDay(string str_day) {
            return Regex.IsMatch(str_day, @"^((0?[1-9])|((1|2)[0-9])|30|31)$");
        }

        /// <summary>
        /// 验证输入是否为数字
        /// </summary>
        /// <param name="str_number">用户输入的字符串</param>
        /// <returns>方法返回布尔值</returns>
        public static bool IsNumber(string str_number) {
            return Regex.IsMatch(str_number, @"^[0-9]*$");
        }
        /// <summary>
        /// 验证密码长度是否正确[密码长度为6-18位]
        /// </summary>
        /// <param name="str_Length">密码字符串</param>
        /// <returns>方法返回布尔值</returns>
        public static bool IsPasswLength(string str_Length) {
            return Regex.IsMatch(str_Length, @"^\d{6,18}$");
        }

        /// <summary>
        /// 验证输入是否为非零正整数
        /// </summary>
        /// <param name="str_intNumber">用户输入的数值</param>
        /// <returns>方法返回布尔值</returns>
        public static bool IsIntNumber(string str_intNumber) {
            return Regex.IsMatch(str_intNumber, @"^\+?[1-9][0-9]*$");
        }


        /// <summary>
        /// 验证输入是否为非零负整数
        /// </summary>
        /// <param name="str_intNumber">用户输入的数值</param>
        /// <returns>方法返回布尔值</returns>
        public static bool IsIntNumbershu(string str_intNumber) {
            return Regex.IsMatch(str_intNumber, @"^\-[1-9][0-9]*$");
        }
        #endregion

        #region 2.字符验证
        /// <summary>
        /// 验证输入字符是否为大写字母
        /// </summary>
        /// <param name="str_UpChar">用户输入的字符串</param>
        /// <returns>方法返回布尔值</returns>
        public static bool IsUpCharbig(string str_UpChar) {
            return System.Text.RegularExpressions.Regex.//使用正则表达式判断是否匹配
                IsMatch(str_UpChar, @"^[A-Z]+$");
        }
        /// <summary>
        /// 验证输入字符是否为小写字母
        /// </summary>
        /// <param name="str_UpChar">用户输入的字符串</param>
        /// <returns>方法返回布尔值</returns>
        public static bool IsUpCharlittle(string str_UpChar) {
            return System.Text.RegularExpressions.Regex.//使用正则表达式判断是否匹配
                IsMatch(str_UpChar, @"^[a-z]+$");
        }
        #endregion

        #region 3.网络验证
        /// <summary>
        /// 验证Email格式是否正确
        /// </summary>
        /// <param name="str_Email">Email地址字符串</param>
        /// <returns>方法返回布尔值</returns>
        public static bool IsEmail(string str_Email) {
            return System.Text.RegularExpressions.Regex.IsMatch(str_Email,@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// 验证IP是否正确
        /// </summary>
        /// <param name="IP">IP地址字符串</param>
        /// <returns>方法返回布尔值</returns>
        public static bool IPCheck(string IP) {
            string num = "(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)";//创建正则表达式字符串
            return Regex.IsMatch(IP,//使用正则表达式判断是否匹配
                ("^" + num + "\\." + num + "\\." + num + "\\." + num + "$"));
        }
        /// <summary>
        /// 验证网址格式是否正确
        /// </summary>
        /// <param name="str_url">网址字符串</param>
        /// <returns>方法返回布尔值</returns>
        public static bool IsUrl(string str_url) {
            return System.Text.RegularExpressions.Regex.IsMatch(str_url,@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        }
        #endregion
    }

}