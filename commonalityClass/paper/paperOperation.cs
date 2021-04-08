using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace commonalityClass.paper {
    public class paperOperation {
        #region 创建文件txt、INI

        private static void setUp_file(string file_Name, string natureType, ref string error, string file_Path = null) {
            var strsPath = file_Path != null ? file_Path + "\\" + file_Name + ".ini" : Path.Combine(Application.StartupPath + "\\" + file_Name + natureType);
            try {
                if (!File.Exists(strsPath)) {
                    FileStream fs = new FileStream(strsPath, FileMode.CreateNew);
                    fs.Close();
                }
            } catch (Exception ex) {
                error = ex.ToString();
            }
        }
        #endregion

        #region txt文件操作
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file_Name">文件名</param>
        /// <param name="error">反馈异常</param>
        /// <param name="file_Path">生成路径</param>
        public static void txtUp(string file_Name, ref string error, string file_Path = null) {
            if (string.IsNullOrEmpty(file_Name)) {
                file_Name = DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            setUp_file(file_Name, ".txt", ref error, file_Path);
        }

        /// <summary>
        /// 单个txt文件读取
        /// </summary>
        /// <param name="txt_path">文件路径</param>
        /// <param name="error">异常错误</param>
        /// <param name="i">反馈行数</param>
        /// <returns></returns>
        public static List<string> papertxt(string txt_path, ref string error, ref int i) {
            int txt_int_Count = 0;//记录正在读取的行数
            string txt_str_Line, txt_str_Content = "";//记录读取的内容及遍历到的内容
            List<string> list_txt = new List<string>();//存储读取的所以内容
            try {
                StreamReader SReader = new StreamReader(txt_path, Encoding.Default);//实例化流读取对象
                while ((txt_str_Line = SReader.ReadLine()) != null)//循环读取文本
                {
                    list_txt.Add(txt_str_Line);
                    txt_int_Count++;
                }
            } catch (Exception ex) {
                error = ex.ToString();
            }
            i = txt_int_Count;

            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //fbd.Description = "";// "请选择Excel所保存的文件夹";
            //if (fbd.ShowDialog() == DialogResult.OK) {
            //    buttonEdit2.Text = fbd.SelectedPath + "\\";
            //}
            return list_txt;

        }


        /// <summary>
        /// 读取一个文件夹所有的TXT 文档
        /// </summary>
        /// <param name="Readpath">读取路径</param>
        /// <param name="WritePath"></param>
        /// <param name="txtName">反馈所有文件名</param>
        /// <param name="error"></param>
        /// <returns></returns>
        public static List<string> manyTxt(string Readpath ,string WritePath ,ref string txtName,ref string error) {
            List<string> ContentTxts = new List<string>();
            try {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Readpath);
                FileInfo[] ff = di.GetFiles("*.txt");//只取文本文档  
                //File.AppendAllText([文件路径], [内容]); 给指定路径下的文档赋值
                foreach (FileInfo temp in ff) {
                    using (StreamReader sr = temp.OpenText()) {
                        string ContentTxt = sr.ReadToEnd();//.Replace("	", ",");//内容追加到zhiss中  
                        txtName += temp.Name+"__";
                        ContentTxts.Add(ContentTxt);
                    }
                }

            } catch (Exception ex) {
                error = ex.ToString();
            }

            return ContentTxts;


        }
    
             
        #endregion

        #region ini文件操作
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileType">操作类型</param>
        /// <param name="error">反馈错误</param>
        /// <param name="file_Path">文件路径</param>
        /// <param name="file_Name">文件名</param>
        /// <param name="IniName">节点名</param>
        /// <param name="key">key值</param>
        /// <param name="Inivalue">value值</param>
        /// <returns></returns>
        public static string InistrString(string fileType, ref string error, string file_Path = null, string file_Name = null, string IniName = null, string key = null, string Inivalue = null) {
            string strString = string.Empty;
            try {
                switch (fileType) {
                    case "setUp":
                        setUp_file(file_Name, ".ini", ref error, file_Path);
                        break;

                    case "read":
                        strString = GetIniFileString(IniName, key, Inivalue, file_Path);
                        break;
                    case "writeIn"://写入INI
                        WritePrivateProfileString(IniName, key, Inivalue, file_Path);
                        break;
                    default:
                        break;
                }
            } catch (Exception ex) {
                error = ex.ToString();
            }

            return strString;
        }
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <param name="retVal"></param>
        /// <param name="size"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        /// <summary>
        /// 从INI文件中读取指定节点的内容
        /// </summary>
        /// <param name="section">INI节点名</param>
        /// <param name="key">节点下的项</param>
        /// <param name="def">没有找到内容时返回的默认值</param>
        /// <param name="filePath">要读取的INI文件路径</param>
        /// <returns></returns>
        private static string GetIniFileString(string section, string key, string def, string filePath) {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, temp, 1024, filePath);
            return temp.ToString();
        }

        /// <summary>
        ///  修改ini文件内容
        /// </summary>
        /// <param name="mpAppName">INI文件名</param>
        /// <param name="mpKeyName">节点</param>
        /// <param name="mpDefault">修改的值</param>
        /// <param name="mpFileName">INI文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string mpAppName, string mpKeyName, string mpDefault, string mpFileName);


        #endregion

        #region xml文件操作

        #region 1.创建xml文件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlPath">生成文件路径</param>
        /// <param name="nodeName">顶级节点名</param>
        /// <param name="child_nodeName">子节点名</param>
        /// <param name="keyName">名</param>
        /// <param name="value">值</param>
        public static void xml_file(string xmlPath, string nodeName, string child_nodeName, string node_labelName, string node_labelValue, string keyName, string value, ref string error) {
            try {
                XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes")
                    , new XElement(nodeName
                    , new XElement(child_nodeName, new XAttribute(node_labelName, node_labelValue)
                    , new XElement(keyName, value))));
                doc.Save(xmlPath);
            } catch (Exception ex) {
                error = ex.ToString();
            }
        }
        #endregion
        #endregion
    }
}
