using DevExpress.Data;
using DevExpress.Utils;
using Esquel.ExcelHelper;
using Microsoft.Office.Interop.Excel;
using NPOI.HPSF;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace commonalityClass.Esquels {
    /// <summary>
    /// Excel操作类
    /// </summary>
    public partial class ExcelHelpers {

        #region excel连接
        private static bool linkOpen(string editionName, bool open) {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();//实例化Excel对象
            OleDbConnection conn = null;
            var a = excel.Version;
            string connName = string.Empty;
            switch (a) {
                case "12.0":
                    conn = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={editionName};");//连接Access2007及以上版本
                    break;
                default:
                    conn = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={editionName};");//连接Access2000及2003版本
                    break;
            }
            conn.Open();
            return true;
        }
        #endregion

        #region 数据导出Excel
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFileName"></param>
        /// <param name="dsSource"></param>
        /// <param name="pwd"></param>
        /// <param name="rowIndex"></param>
        /// <param name="wait"></param>
        /// <param name="isAppend"></param>
        /// <param name="dateFormat"></param>
        public static void IsScv(string strFileName, DataSet dsSource, string pwd, ref int rowIndex, WaitDialogForm wait = null, bool isAppend = false, string dateFormat = "yyyy-MM-dd") {
            string error = string.Empty;
            DataTableToExcel(ref error, strFileName, dsSource, pwd, ref  rowIndex,  wait = null,  isAppend = false,  dateFormat = "yyyy-MM-dd");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="strFileName"></param>
        /// <param name="dsSource"></param>
        /// <param name="pwd"></param>
        /// <param name="rowIndex"></param>
        /// <param name="wait"></param>
        /// <param name="isAppend"></param>
        /// <param name="dateFormat"></param>
        public static void DataTableToExcel(ref string error, string strFileName, DataSet dsSource, string pwd, ref int rowIndex, WaitDialogForm wait = null, bool isAppend = false, string dateFormat = "yyyy-MM-dd") {
            try {
                error = string.Empty;
                FileStream fs = null;
                XSSFWorkbook workbook = null;
                if (!isAppend) {
                    fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write);
                    workbook = new XSSFWorkbook();
                } else {
                    fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    workbook = new XSSFWorkbook(fs);//将文件读到内存，在内存中操作excel
                }
                fs.Close();

                #region 右击文件 属性信息
                {
                    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                    dsi.Company = "Xw";
                    //     workbook.DocumentSummaryInformation = dsi;

                    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                    si.Author = "xw"; //填加xls文件作者信息
                    si.ApplicationName = "xw"; //填加xls文件创建程序信息
                    si.LastAuthor = "xw"; //填加xls文件最后保存者信息
                    si.Comments = "xw"; //填加xls文件作者信息
                    si.Title = "xw"; //填加xls文件标题信息
                    si.Subject = "xw";//填加文件主题信息
                    si.CreateDateTime = System.DateTime.Now;
                    //    workbook.SummaryInformation = si;
                }
                #endregion
                XSSFCellStyle dateStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFDataFormat format = (XSSFDataFormat)workbook.CreateDataFormat();
                dateStyle.DataFormat = format.GetFormat(dateFormat);
                XSSFCellStyle headStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFCellStyle rowStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFFont fontRow = (XSSFFont)workbook.CreateFont();
                XSSFFont font = (XSSFFont)workbook.CreateFont();
                font.FontHeightInPoints = 9;
                font.FontName = "微软雅黑";
                //font.Boldweight = 700;
                headStyle.SetFont(font);

                fontRow.FontHeightInPoints = 9;
                fontRow.FontName = "微软雅黑";
                rowStyle.SetFont(fontRow);

                for (int k = 0; k < dsSource.Tables.Count; k++) {
                    var dtSource = dsSource.Tables[k];

                    XSSFSheet sheet = null;
                    if (!isAppend) {
                        rowIndex = 0;
                        sheet = (XSSFSheet)workbook.CreateSheet();
                        if (!string.IsNullOrEmpty(pwd)) {
                            sheet.ProtectSheet(pwd);
                        }
                        workbook.SetSheetName(k, dtSource.TableName);
                    } else {
                        sheet = (XSSFSheet)workbook.GetSheet(dtSource.TableName);
                        if (sheet == null) {
                            isAppend = false;
                            rowIndex = 0;
                            sheet = (XSSFSheet)workbook.CreateSheet();
                            if (!string.IsNullOrEmpty(pwd)) {
                                sheet.ProtectSheet(pwd);
                            }
                            workbook.SetSheetName(k, dtSource.TableName);
                        }
                    }

                    if (wait != null)
                        wait.SetCaption(string.Format("正在创建第 {0} / {1} Excel的Sheet中", (k + 1), dsSource.Tables.Count));//"（" + (k + 1) + " /" + dsSource.Tables.Count + "）Excel的Sheet中...");
                                                                                                                       //取得列宽
                    int[] arrColWidth = new int[dtSource.Columns.Count];
                    foreach (DataColumn item in dtSource.Columns) {
                        arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
                    }
                    for (int i = 0; i < dtSource.Rows.Count; i++) {
                        for (int j = 0; j < dtSource.Columns.Count; j++) {
                            int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                            if (intTemp > arrColWidth[j]) {
                                arrColWidth[j] = intTemp;
                            }
                        }
                    }

                    foreach (DataRow row in dtSource.Rows) {
                        #region 新建表，填充表头，填充列头，样式
                        if (!isAppend) {
                            //if (rowIndex != 0) {
                            //sheet = (XSSFSheet)workbook.CreateSheet();
                            //if (!string.IsNullOrEmpty(pwd)) {
                            //    sheet.ProtectSheet(pwd);
                            //}
                            //}
                            #region 表头及样式
                            //    if (!string.IsNullOrEmpty(strHeaderText)) {
                            //        rowIndex++;
                            //        XSSFRow headerRow = (XSSFRow)sheet.CreateRow(rowIndex);
                            //        headerRow.HeightInPoints = 25;
                            //        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                            //        XSSFCellStyle headStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                            //        //  headStyle.Alignment = CellHorizontalAlignment.CENTER;
                            //        XSSFFont font = (XSSFFont)workbook.CreateFont();
                            //        font.FontHeightInPoints = 20;
                            //        font.Boldweight = 700;
                            //        headStyle.SetFont(font);
                            //        headerRow.GetCell(0).CellStyle = headStyle;
                            //        // sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                            //        //headerRow.Dispose();
                            //    }
                            #endregion
                            #region 列头及样式
                            XSSFRow headerRow = (XSSFRow)sheet.CreateRow(0);
                            foreach (DataColumn column in dtSource.Columns) {
                                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                headerRow.GetCell(column.Ordinal).CellStyle = headStyle;
                                //headerRow.GetCell(column.Ordinal).CellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                                //headerRow.GetCell(column.Ordinal).CellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                                //headerRow.GetCell(column.Ordinal).CellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                                //headerRow.GetCell(column.Ordinal).CellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                                //设置列宽
                                // sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                            }

                            #endregion
                            isAppend = true;
                            rowIndex = 1;
                        }
                        #endregion

                        if (wait != null)
                            wait.SetCaption(string.Format("正在将数据写入Excel第 {0} / {1} 行中...", rowIndex, dtSource.Rows.Count));//"正在写入第（" + (k + 1) + "/" + dsSource.Tables.Count + "个ExcelSheet表格中的第 " + rowIndex + "/" + dtSource.Rows.Count + " 行数据...");

                        #region 填充内容
                        XSSFRow dataRow = (XSSFRow)sheet.CreateRow(rowIndex);
                        foreach (DataColumn column in dtSource.Columns) {
                            XSSFCell newCell = (XSSFCell)dataRow.CreateCell(column.Ordinal);
                            newCell.CellStyle = rowStyle;

                            //newCell.CellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                            //newCell.CellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                            //newCell.CellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                            //newCell.CellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                            var obj = row[column];
                            if (obj == null) continue;

                            string drValue = row[column].ToString();

                            switch (column.DataType.ToString()) {
                                case "System.String"://字符串类型
                                    double tempVal = 0;
                                    var isflg = double.TryParse(drValue, out tempVal);
                                    if (isflg) {
                                        newCell.SetCellValue(tempVal);
                                        newCell.SetCellType(CellType.Numeric);
                                    } else {
                                        newCell.SetCellValue(drValue);
                                        newCell.SetCellType(CellType.String);
                                    }
                                    break;
                                case "System.DateTime"://日期类型
                                    System.DateTime dateV;
                                    isflg = System.DateTime.TryParse(drValue, out dateV);
                                    if (isflg) {
                                        newCell.SetCellValue(drValue);
                                    } else
                                        newCell.SetCellValue(string.Empty);

                                    break;
                                case "System.Boolean"://布尔型
                                    bool boolV = false;
                                    bool.TryParse(drValue, out boolV);
                                    newCell.SetCellValue(boolV);
                                    break;
                                case "System.Int16"://整型
                                case "System.Int32":
                                case "System.Int64":
                                case "System.UInt16"://整型
                                case "System.UInt32":
                                case "System.UInt64":
                                    int intV = 0;
                                    isflg = int.TryParse(drValue, out intV);
                                    if (isflg) {
                                        newCell.SetCellValue(intV);
                                        newCell.SetCellType(CellType.Numeric);
                                    }
                                    break;
                                case "System.Single"://浮点型
                                case "System.Decimal"://浮点型
                                case "System.Double":
                                    double doubV = 0;
                                    isflg = double.TryParse(drValue, out doubV);
                                    if (isflg) {
                                        newCell.SetCellValue(doubV);
                                        newCell.SetCellType(CellType.Numeric);
                                    }
                                    break;
                                case "System.DBNull"://空值处理
                                    newCell.SetCellValue("");
                                    newCell.SetCellType(CellType.String);
                                    break;
                                default:
                                    tempVal = 0;
                                    isflg = double.TryParse(drValue, out tempVal);
                                    if (isflg) {
                                        newCell.SetCellValue(tempVal);
                                        newCell.SetCellType(CellType.Numeric);
                                    } else {
                                        newCell.SetCellValue(drValue);
                                        newCell.SetCellType(CellType.String);
                                    }
                                    break;
                            }

                        }
                        #endregion

                        rowIndex++;
                    }
                    if (sheet != null) {
                        sheet.ForceFormulaRecalculation = true;
                    }
                }

                //将内存数据写到文件
                using (FileStream fs1 = File.OpenWrite(strFileName)) {
                    workbook.Write(fs1);
                    workbook.Close();
                }
            } catch (Exception ex) {
                error = $"导出数据出错{ex.Message}";
            }
        }
        public static Type ConvertUnboundColumnTypeToType(UnboundColumnType dataType) {
            Type unboundType = typeof(object);
            switch (dataType) {
                case UnboundColumnType.String:
                    unboundType = typeof(String);
                    break;
                case UnboundColumnType.DateTime:
                    unboundType = typeof(DateTime);
                    break;
                case UnboundColumnType.Integer:
                    unboundType = typeof(System.Int32);
                    break;
                case UnboundColumnType.Decimal:
                    unboundType = typeof(System.Decimal);
                    break;
                case UnboundColumnType.Boolean:
                    unboundType = typeof(Double);
                    break;
                case UnboundColumnType.Bound:
                    unboundType = typeof(object);
                    break;
            }

            return unboundType;
        }

        #endregion

        #region 生成Excel文件
        #region 1.生成Excel文件方法
        /// <summary>
        /// 生成Excel文件方法1
        /// </summary>
        /// <param name="Excelpath">文件保存路径</param>
        /// <param name="error">反馈异常错误</param>
        /// <param name="ExcelName">保存的Excel名</param>
        /// <param name="ExcelType">保结束存类型(.xls)</param>
        /// <returns></returns>
        public static bool produceExcel01(string Excelpath, ref string error, string ExcelName = null, string ExcelType = "xls") {
            bool Excelresult = false;//反馈执行结果
            try {
                if (string.IsNullOrEmpty(ExcelName)) {
                    ExcelName = DateTime.Now.ToString("yyyyMMddhhmmss");
                }
                Application excel = new Application();//实例化Excel对象
                Workbook newWorkBook = excel.Application.Workbooks.Add(true);//添加新的工作溥
                object missing = System.Reflection.Missing.Value;//获取缺少的object类型值
                newWorkBook.Worksheets.Add(missing, missing, missing, missing);//向Excel文件中添加工作表
                if (Excelpath.EndsWith("\\"))//判断路径是否\结尾
                {
                    newWorkBook.SaveCopyAs(Excelpath + ExcelName + "." + ExcelType);
                    Excelresult = true;
                } else {
                    newWorkBook.SaveCopyAs(Excelpath + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls");//保存Excel文件
                    Excelresult = true;
                }
            } catch (Exception ex) {
                error = ex.ToString();
            } finally {
                //System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");//实例化进程对象
                //foreach (System.Diagnostics.Process p in excelProcess)
                //{
                //    p.Kill();//关闭进程
                //}
                CloseProcess();
            }

            return Excelresult;
        }

        #endregion

        #region 2.生成EXCEL及数据
        //DataTableToExcel(ref errMsg, strFileName, ds, "", ref rowIndex, wait, false);
        public static void DataTableToExcels(ref string errMsg, string strFileName, DataSet dsSource, string pwd, ref int rowIndex, WaitDialogForm wait = null, bool isAppend = false, string dateFormat = "yyyy-MM-dd") {
            try {
                errMsg = string.Empty;
                FileStream fs = null;
                XSSFWorkbook workbook = null;
                if (!isAppend) {
                    fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write);
                    workbook = new XSSFWorkbook();
                } else {
                    fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    workbook = new XSSFWorkbook(fs);//将文件读到内存，在内存中操作excel
                }
                fs.Close();

                #region 右击文件 属性信息
                {
                    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                    dsi.Company = "SuperCom";
                    //     workbook.DocumentSummaryInformation = dsi;

                    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                    si.Author = "xw"; //填加xls文件作者信息
                    si.ApplicationName = "xw"; //填加xls文件创建程序信息
                    si.LastAuthor = "xw"; //填加xls文件最后保存者信息
                    si.Comments = "xw"; //填加xls文件作者信息
                    si.Title = "xw"; //填加xls文件标题信息
                    si.Subject = "xw";//填加文件主题信息
                    si.CreateDateTime = System.DateTime.Now;
                    //    workbook.SummaryInformation = si;
                }
                #endregion
                XSSFCellStyle dateStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFDataFormat format = (XSSFDataFormat)workbook.CreateDataFormat();
                dateStyle.DataFormat = format.GetFormat(dateFormat);
                XSSFCellStyle headStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFCellStyle rowStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                XSSFFont fontRow = (XSSFFont)workbook.CreateFont();
                XSSFFont font = (XSSFFont)workbook.CreateFont();
                font.FontHeightInPoints = 9;
                font.FontName = "微软雅黑";
                //font.Boldweight = 700;
                headStyle.SetFont(font);

                fontRow.FontHeightInPoints = 9;
                fontRow.FontName = "微软雅黑";
                rowStyle.SetFont(fontRow);

                for (int k = 0; k < dsSource.Tables.Count; k++) {
                    var dtSource = dsSource.Tables[k];

                    XSSFSheet sheet = null;
                    if (!isAppend) {
                        rowIndex = 0;
                        sheet = (XSSFSheet)workbook.CreateSheet();
                        if (!string.IsNullOrEmpty(pwd)) {
                            sheet.ProtectSheet(pwd);
                        }
                        workbook.SetSheetName(k, dtSource.TableName);
                    } else {
                        sheet = (XSSFSheet)workbook.GetSheet(dtSource.TableName);
                    }

                    if (wait != null)
                        wait.SetCaption(string.Format("正在创建第 {0} / {1} Excel的Sheet中", (k + 1), dsSource.Tables.Count));//"（" + (k + 1) + " /" + dsSource.Tables.Count + "）Excel的Sheet中...");
                                                                                                                       //取得列宽
                    int[] arrColWidth = new int[dtSource.Columns.Count];
                    foreach (DataColumn item in dtSource.Columns) {
                        arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
                    }
                    for (int i = 0; i < dtSource.Rows.Count; i++) {
                        for (int j = 0; j < dtSource.Columns.Count; j++) {
                            int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                            if (intTemp > arrColWidth[j]) {
                                arrColWidth[j] = intTemp;
                            }
                        }
                    }

                    foreach (DataRow row in dtSource.Rows) {
                        #region 新建表，填充表头，填充列头，样式
                        if (!isAppend) {
                            //if (rowIndex != 0) {
                            //sheet = (XSSFSheet)workbook.CreateSheet();
                            //if (!string.IsNullOrEmpty(pwd)) {
                            //    sheet.ProtectSheet(pwd);
                            //}
                            //}
                            #region 表头及样式
                            //    if (!string.IsNullOrEmpty(strHeaderText)) {
                            //        rowIndex++;
                            //        XSSFRow headerRow = (XSSFRow)sheet.CreateRow(rowIndex);
                            //        headerRow.HeightInPoints = 25;
                            //        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                            //        XSSFCellStyle headStyle = (XSSFCellStyle)workbook.CreateCellStyle();
                            //        //  headStyle.Alignment = CellHorizontalAlignment.CENTER;
                            //        XSSFFont font = (XSSFFont)workbook.CreateFont();
                            //        font.FontHeightInPoints = 20;
                            //        font.Boldweight = 700;
                            //        headStyle.SetFont(font);
                            //        headerRow.GetCell(0).CellStyle = headStyle;
                            //        // sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                            //        //headerRow.Dispose();
                            //    }
                            #endregion
                            #region 列头及样式
                            XSSFRow headerRow = (XSSFRow)sheet.CreateRow(0);
                            foreach (DataColumn column in dtSource.Columns) {
                                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                headerRow.GetCell(column.Ordinal).CellStyle = headStyle;
                                //headerRow.GetCell(column.Ordinal).CellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                                //headerRow.GetCell(column.Ordinal).CellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                                //headerRow.GetCell(column.Ordinal).CellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                                //headerRow.GetCell(column.Ordinal).CellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                                //设置列宽
                                // sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                            }

                            #endregion
                            isAppend = true;
                            rowIndex = 1;
                        }
                        #endregion

                        if (wait != null)
                            wait.SetCaption(string.Format("正在将数据写入Excel第 {0} / {1} 行中...", rowIndex, dtSource.Rows.Count));//"正在写入第（" + (k + 1) + "/" + dsSource.Tables.Count + "个ExcelSheet表格中的第 " + rowIndex + "/" + dtSource.Rows.Count + " 行数据...");

                        #region 填充内容
                        XSSFRow dataRow = (XSSFRow)sheet.CreateRow(rowIndex);
                        foreach (DataColumn column in dtSource.Columns) {
                            XSSFCell newCell = (XSSFCell)dataRow.CreateCell(column.Ordinal);
                            newCell.CellStyle = rowStyle;

                            //newCell.CellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                            //newCell.CellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                            //newCell.CellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                            //newCell.CellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                            var obj = row[column];
                            if (obj == null) continue;

                            string drValue = row[column].ToString();

                            switch (column.DataType.ToString()) {
                                case "System.String"://字符串类型
                                    double tempVal = 0;
                                    var isflg = double.TryParse(drValue, out tempVal);
                                    if (isflg) {
                                        newCell.SetCellValue(tempVal);
                                        newCell.SetCellType(CellType.Numeric);
                                    } else {
                                        newCell.SetCellValue(drValue);
                                        newCell.SetCellType(CellType.String);
                                    }
                                    break;
                                case "System.DateTime"://日期类型
                                    System.DateTime dateV;
                                    isflg = System.DateTime.TryParse(drValue, out dateV);
                                    if (isflg) {
                                        newCell.SetCellValue(drValue);
                                    } else
                                        newCell.SetCellValue(string.Empty);

                                    break;
                                case "System.Boolean"://布尔型
                                    bool boolV = false;
                                    bool.TryParse(drValue, out boolV);
                                    newCell.SetCellValue(boolV);
                                    break;
                                case "System.Int16"://整型
                                case "System.Int32":
                                case "System.Int64":
                                case "System.UInt16"://整型
                                case "System.UInt32":
                                case "System.UInt64":
                                    int intV = 0;
                                    isflg = int.TryParse(drValue, out intV);
                                    if (isflg) {
                                        newCell.SetCellValue(intV);
                                        newCell.SetCellType(CellType.Numeric);
                                    }
                                    break;
                                case "System.Single"://浮点型
                                case "System.Decimal"://浮点型
                                case "System.Double":
                                    double doubV = 0;
                                    isflg = double.TryParse(drValue, out doubV);
                                    if (isflg) {
                                        newCell.SetCellValue(doubV);
                                        newCell.SetCellType(CellType.Numeric);
                                    }
                                    break;
                                case "System.DBNull"://空值处理
                                    newCell.SetCellValue("");
                                    newCell.SetCellType(CellType.String);
                                    break;
                                default:
                                    tempVal = 0;
                                    isflg = double.TryParse(drValue, out tempVal);
                                    if (isflg) {
                                        newCell.SetCellValue(tempVal);
                                        newCell.SetCellType(CellType.Numeric);
                                    } else {
                                        newCell.SetCellValue(drValue);
                                        newCell.SetCellType(CellType.String);
                                    }
                                    break;
                            }

                        }
                        #endregion

                        rowIndex++;
                    }
                    if (sheet != null) {
                        sheet.ForceFormulaRecalculation = true;
                    }
                }

                //将内存数据写到文件
                using (FileStream fs1 = File.OpenWrite(strFileName)) {
                    workbook.Write(fs1);
                    workbook.Close();
                }
            } catch (Exception ex) {
                errMsg = $"导出数据出错{ex.Message}";
            }
        }
        #endregion

          #region 3.导出数据生成EXCEL[调用第三方架包]
        public static int rowDate(DataSet ds,string fileName) {
            int writerRow = ExcelHelper.DataTableToExcel(ds, fileName, string.Empty);
            return writerRow;
        }
        #endregion
        #endregion

        #region 设置Excel密码
        /// <summary>
        /// 设置Excel密码
        /// </summary>
        /// <param name="Excelpath">选择文件的路径</param>
        /// <param name="Excelpwd">设置的密码</param>
        /// <param name="error">反馈异常</param>
        /// <returns></returns>
        public static bool Excelpassword01(string Excelpath, string Excelpwd, ref string error) {
            bool pwdresult = false;
            try {
                Application excel = new Application();//实例化Excel对象
                object missing = Missing.Value;//获取缺少的object类型值
                Workbook workbook = excel.Application.Workbooks.Open(Excelpath, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                workbook.Password = Excelpwd;//设置Excel密码
                excel.Application.DisplayAlerts = false;//不显示提示对话框
                workbook.Save();//保存工作表
                workbook.Close(false, missing, missing);//关闭工作表
                pwdresult = true;
            } catch (Exception ex) {
                error = ex.ToString();
            }
            return pwdresult;
        }
        #endregion

        #region 添加Excel的sheel
        /// <summary>
        /// 添加Excel的sheel[添加成功之后wps打开此文件会显示只能读取，不能修改的情况，待修改bug]
        /// </summary>
        /// <param name="Excelpath">文件路径</param>
        /// <param name="number">添加个数</param>
        /// <param name="error">反馈异常错误</param>
        public static void Exceladdsheel(string Excelpath, int numberCount, ref string error) {
            try {
                CloseProcess();
                Application excel = new Application();//实例化Excel对象
                object missing = Missing.Value;//获取缺少的object类型值
                Workbook workbook = excel.Application.Workbooks.Open(Excelpath, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                Worksheet newWorksheet = workbook.Worksheets.Add(missing, missing, numberCount, missing);
                excel.Application.DisplayAlerts = false;//不显示提示对话框
                workbook.Save();//保存工作表
                workbook.Close(false, missing, missing);//关闭工作表
                CloseProcess();
            } catch (Exception ex) {
                error = ex.ToString();
            }
        }
        private static void CloseProcess() {
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");//实例化进程对象
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();//关闭进程
            System.Threading.Thread.Sleep(10);//使线程休眠10毫秒
        }
        #endregion

        #region 删除指定的sheel
        public static void deleteExcel() {

        }
        #endregion
    }
}