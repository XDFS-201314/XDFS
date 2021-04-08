using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace commonalityClass.time {
    public partial class timehandle {

        //实例053 动态获得系统当前日期和时间 67

        #region 获取系统时间
        /// <summary>
        /// 
        /// </summary>
        /// <param name="openTime"></param>
        /// <param name="time_ms"></param>
        /// <param name="error">反馈错误</param>
        /// <returns></returns>
        public static string system_time(bool openTime, int time_ms, ref string error) {
            string data_Time = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            //System.Threading.Thread P_thread =
            //    new System.Threading.Thread(

            //() => {
            //    while (openTime) {

            //        Thread.Sleep(time_ms);

            //    }
            //});
            return data_Time;
        }
        #endregion

        #region 设置系统时间 [待改进]

        /// <summary>
        /// 设置系统日期 
        /// </summary>
        private class SetSystemDateTime {
            [DllImportAttribute("Kernel32.dll")]
            protected internal static extern void GetLocalTime(SystemTime st);

            [DllImportAttribute("Kernel32.dll")]
            protected internal static extern void SetLocalTime(SystemTime st);
        }
        private class SystemTime {//系统时间类
            protected internal ushort vYear;//年
            protected internal ushort vMonth;//月
            protected internal ushort vDayOfWeek;//星期
            protected internal ushort vDay;//日
            protected internal ushort vHour;//小时
            protected internal ushort vMinute;//分
            protected internal ushort vSecond;//秒
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="dateTimePicker1"></param>
        /// <param name="dateTimePicker2"></param>
        public static void systemDate(ref string error, DateTimePicker dateTimePicker1 = null, DateTimePicker dateTimePicker2 = null) {
            try {
                SystemTime MySystemTime = new SystemTime();//创建系统时间类的对象
                DateTime Year = dateTimePicker1.Value;//得到时间信息
                SetSystemDateTime.GetLocalTime(MySystemTime);//得到系统时间
                MySystemTime.vYear = (ushort)dateTimePicker1.Value.Year;//设置年
                MySystemTime.vMonth = (ushort)dateTimePicker1.Value.Month;//设置月
                MySystemTime.vDay = (ushort)dateTimePicker1.Value.Day;//设置日
                MySystemTime.vHour = (ushort)dateTimePicker2.Value.Hour;//设置小时
                MySystemTime.vMinute = (ushort)dateTimePicker2.Value.Minute;//设置分
                MySystemTime.vSecond = (ushort)dateTimePicker2.Value.Second;//设置秒
                SetSystemDateTime.SetLocalTime(MySystemTime);//设置系统时间
            } catch (Exception ex) {
                error = ex.ToString();
            }
        }

        #endregion

        #region 根据年份判断十二生肖 71
        /// <summary>
        /// 获取指定时间的生肖属性
        /// </summary>
        /// <param name="timr">指定的时间</param>
        /// <returns></returns>
        public static string Animal_Date(DateTime timr) {
            System.Globalization.ChineseLunisolarCalendar chinseCaleander =//创建日历对象
                new System.Globalization.ChineseLunisolarCalendar();
            string TreeYear = "鼠牛虎兔龙蛇马羊猴鸡狗猪";//创建字符串对象
            int intYear = chinseCaleander.GetSexagenaryYear(timr);//计算年信息
            return TreeYear.Substring(chinseCaleander.//得到生肖信息
                GetTerrestrialBranch(intYear) - 1, 1);
        }
        #endregion

        #region 获取当前日期是星期几
        /// <summary>
        ///  获取当前日期是星期几
        /// </summary>
        /// <param name="datetime">指定的时间</param>
        /// <returns></returns>
        public static string week_Date(DateTime datetime) {
            return datetime.ToString("dddd");
        }
        #endregion
        
        #region 获取当指定的天数
        /// <summary>
        ///  获取当指定的天数
        /// </summary>
        /// <param name="datetime">指定的时间</param>
        /// <returns></returns>
        public static string LeapYear(DateTime datetime) {
            string days = string.Empty;
            if (DateTime.IsLeapYear(int.Parse(datetime.ToString("yyyy")))) {
                days = "366";
            } else {
                days = "365";
            }
            return days;
        }
        #endregion

        #region 获取当前月的天数
        /// <summary>
        /// 获取当前月的天
        /// </summary>
        /// <param name="datetime">指定的时间</param>
        /// <returns></returns>
        public static string LeapDays(DateTime datetime) {
            int P_Cont = DateTime.DaysInMonth(datetime.Year, datetime.Month);
            return P_Cont.ToString();
        }
        #endregion

        #region 日期值修改
        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol">选择运算方式</param>
        /// <param name="Cont">修改的值</param>
        /// <param name="datetime">指定的时间</param>
        /// <returns></returns>
        public static DateTime Date_Operation(string symbol, int Cont, DateTime datetime) {
            DateTime date_time = datetime;
            switch (symbol) {
                case "add":
                    date_time = datetime.AddDays(+Cont);
                    break;
                case "subtract":
                    date_time = datetime.AddDays(-Cont);
                    break;
                default:
                    break;
            }
            return date_time;
        }
        #endregion

        #region 将日期格式化为指定格式
        /// <summary>
        /// 将日期格式化为指定格式
        /// </summary>
        /// <param name="datetime">转换格式的时间</param>
        /// <param name="typeDate">格式类型</param>
        /// <param name="custom">自定义的时间类型</param>
        /// <returns></returns>
        public static string date_format(DateTime datetime, string typeDate = null, string custom = null) {
            string date_time = string.Empty;
            switch (typeDate) {
                case "d":
                    date_time = datetime.ToString("d");
                    break;
                case "D":
                    date_time = datetime.ToString("D");
                    break;
                case "f":
                    date_time = datetime.ToString("f");
                    break;
                case "F":
                    date_time = datetime.ToString("F");
                    break;
                case "g":
                    date_time = datetime.ToString("g");
                    break;
                case "G":
                    date_time = datetime.ToString("G");
                    break;
                case "R":
                    date_time = datetime.ToString("R");
                    break;
                case "y":
                    date_time = datetime.ToString("y");
                    break;
                case "general":
                    date_time = datetime.ToString("yyyy年MM月dd日 HH时mm分ss秒");
                    break;
                default:
                    date_time = datetime.ToString(custom);
                    break;
            }
            return date_time;
        }

        #endregion

        #region 使用DateDiff方法获取日期时间的间隔数
        /// <summary>
        /// 使用DateDiff方法获取日期时间的间隔数
        /// </summary>
        /// <param name="Date1">指定的时间</param>
        /// <param name="Date2">指定的时间</param>
        /// <returns></returns>
        public static string DateDiffs(DateTime Date1, DateTime Date2) {
            return DateAndTime.DateDiff(DateInterval.Day, Date1, Date2, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1).ToString();
        }
        #endregion

        #region  使用DateAdd方法向指定日期添加一段时间间隔
        /// <summary>
        ///  使用DateAdd方法向指定日期添加一段时间间隔
        /// </summary>
        /// <param name="AddDateType">选择添加的类型[分,时,天]</param>
        /// <param name="Date_details">添加的具体时间</param>
        /// <param name="date">在指定的时间上添加【参数】</param>
        /// <param name="error">反馈错误</param>
        /// <returns></returns>
        public static DateTime DateAdd(string AddDateType, int Date_details, DateTime date, ref string error) {
            DateTime G_datetime = date;
            try {
                switch (AddDateType) {
                    case "Minute"://向时间字段中添加分钟
                        G_datetime = DateAndTime.DateAdd(DateInterval.Minute, Date_details, date);
                        break;
                    case "Hour"://添加小时
                        G_datetime = DateAndTime.DateAdd(DateInterval.Hour, Date_details, date);
                        break;
                    case "Day"://添加天数
                        G_datetime = DateAndTime.DateAdd(DateInterval.Day, Date_details, date);
                        break;
                    default:
                        break;
                }
            } catch (Exception ex) {
                error = ex.ToString();
            }

            return G_datetime;
        }
        #endregion

        #region 使用TimeSpan对象获取时间间隔
        /// <summary>
        /// 使用TimeSpan对象获取时间间隔
        /// </summary>
        public static string TimeSpan(DateTime data1, DateTime data2) {
            //P_timespan_temp.Days,天
            //P_timespan_temp.Hours,时
            //    P_timespan_temp.Minutes,分
            //P_timespan_temp.Seconds,秒
            //    P_timespan_temp.Milliseconds 毫秒

            TimeSpan P_timespan_temp = data1 > data2 ? data1 - data2 : data2 - data1;
            var dataString = date_format(Convert.ToDateTime(P_timespan_temp.ToString()), "general");
            return dataString;
        }
        #endregion

        #region 时间运算
        /// <summary>
        /// 时间运算
        /// </summary>
        /// <returns></returns>
        public static DateTime DateTimeOperation(string operation_type, string Typeid, int time, DateTime data) {
            DateTime da = DateTime.Now;
            switch (operation_type) {
                case "YEAR"://年
                    if (Typeid =="+") {
                        data.AddYears(+time);
                    } else {
                        data.AddYears(-time);
                    }
                    break;
                case "":
                    data.AddMonths(-1);
                    break;
                case "AddDAYS"://天
                    if (Typeid == "+") {
                        da = data.AddDays(+time);
                    } else {
                        da = data.AddDays(-time);
                    }
                    break;
                default:
                    break;
            }
            return da;
        }
        #endregion

        #region 获取周次
        /// <summary>
        /// 获取周次
        /// </summary>
        /// <returns></returns>
        public static int isweek() {
            //string str_week=  DayOfWeek.Sunday;\
//var curWeek = Esquel.BaseManager.FilesManager.GetWeekOfYear(DateTime.Now);
         return  Convert.ToInt32(DateTime.Now.DayOfYear / 7 + 1);
        }
        #endregion
    }
}
