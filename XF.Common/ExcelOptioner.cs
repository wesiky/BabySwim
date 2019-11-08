using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data;
using System.Windows.Forms;

namespace XF.Common
{
    public class ExcelOptioner
    {
        /// <summary>  
        /// DataTable导出到Excel的MemoryStream Export()  
        /// </summary>  
        /// <param name="dtSource">DataTable数据源</param>  
        /// <param name="strHeaderText">Excel表头文本（例如：车辆列表）</param>  
        public static MemoryStream Export(DataTable dtSource, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "NPOI";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "文件作者信息"; //填加xls文件作者信息  
                si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息  
                si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息  
                si.Comments = "作者信息"; //填加xls文件作者信息  
                si.Title = "标题信息"; //填加xls文件标题信息  
                si.Subject = "主题信息";//填加文件主题信息  
                si.CreateDateTime = System.DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽  
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }

                    #region 表头及样式
                    {
                        IRow headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                    }
                    #endregion

                    #region 列头及样式
                    {
                        IRow headerRow = sheet.CreateRow(1);
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽  
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }
                    }
                    #endregion
                    rowIndex = 2;
                }
                #endregion

                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    ICell newCell = dataRow.CreateCell(column.Ordinal);
                    string drValue = row[column].ToString();
                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型  
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型  
                            System.DateTime dateV;
                            System.DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示  
                            break;
                        case "System.Boolean"://布尔型  
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型  
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型  
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理  
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }
                }
                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                sheet.Dispose();
                return ms;
            }
        }


        ///// <summary>
        ///// Datable导出成Excel
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <param name="file">导出路径(包括文件名与扩展名)</param>
        //public static void TableToExcel(DataTable dt, string file)
        //{
        //    IWorkbook workbook;
        //    string fileExt = Path.GetExtension(file).ToLower();
            

        //    //转为字节数组  
        //    MemoryStream stream = new MemoryStream();
        //    workbook.Write(stream);
        //    var buf = stream.ToArray();

        //    //保存为Excel文件  
        //    using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
        //    {
        //        fs.Write(buf, 0, buf.Length);
        //        fs.Flush();
        //    }
        //}
        /// <summary>  
        /// DataTable导出到Excel的MemoryStream Export()  
        /// </summary>  
        /// <param name="dtSource">DataTable数据源</param>  
        /// <param name="strHeaderText">Excel表头文本（例如：车辆列表）</param>  
        public static bool Export(DataTable dt, string filePath, ref string msg)
        {
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                ISheet sheet = workbook.CreateSheet();

                #region 右击文件 属性信息
                {
                    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                    dsi.Company = "NPOI";
                    workbook.DocumentSummaryInformation = dsi;

                    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                    si.Author = "文件作者信息"; //填加xls文件作者信息  
                    si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息  
                    si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息  
                    si.Comments = "作者信息"; //填加xls文件作者信息  
                    si.Title = "标题信息"; //填加xls文件标题信息  
                    si.Subject = "主题信息";//填加文件主题信息  
                    si.CreateDateTime = System.DateTime.Now;
                    workbook.SummaryInformation = si;
                }
                #endregion

                ICellStyle dateStyle = workbook.CreateCellStyle();
                IDataFormat format = workbook.CreateDataFormat();
                dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

                //取得列宽  
                int[] arrColWidth = new int[dt.Columns.Count];
                foreach (DataColumn item in dt.Columns)
                {
                    arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string value = "";
                        if (dt.Rows[i][j] != null)
                        {
                            value = dt.Rows[i][j].ToString();
                        }
                        int intTemp = Encoding.GetEncoding(936).GetBytes(value).Length;
                        if (intTemp > arrColWidth[j])
                        {
                            arrColWidth[j] = intTemp;
                        }
                    }
                }
                int rowIndex = 0;
                foreach (DataRow row in dt.Rows)
                {
                    #region 新建表，填充表头，填充列头，样式
                    if (rowIndex == 65535 || rowIndex == 0)
                    {
                        if (rowIndex != 0)
                        {
                            sheet = workbook.CreateSheet();
                        }

                        #region 列头及样式
                        {
                            IRow headerRow = sheet.CreateRow(1);
                            ICellStyle headStyle = workbook.CreateCellStyle();
                            headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                            IFont font = workbook.CreateFont();
                            font.FontHeightInPoints = 10;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);
                            foreach (DataColumn column in dt.Columns)
                            {
                                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                                //设置列宽  
                                sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                            }
                        }
                        #endregion
                        rowIndex = 2;
                    }
                    #endregion

                    #region 填充内容
                    IRow dataRow = sheet.CreateRow(rowIndex);
                    foreach (DataColumn column in dt.Columns)
                    {
                        ICell newCell = dataRow.CreateCell(column.Ordinal);
                        string drValue = "";
                        string drValueType = "System.String";
                        if (row[column.ColumnName] != null)
                        {
                            drValue = row[column.ColumnName].ToString();
                        }
                        if (column.DataType != null)
                        {
                            drValueType = column.DataType.ToString();
                        }
                        switch (drValueType)
                        {
                            case "System.String"://字符串类型  
                                newCell.SetCellValue(drValue);
                                break;
                            case "System.DateTime"://日期类型  
                                System.DateTime dateV;
                                System.DateTime.TryParse(drValue, out dateV);
                                newCell.SetCellValue(dateV);

                                newCell.CellStyle = dateStyle;//格式化显示  
                                break;
                            case "System.Boolean"://布尔型  
                                bool boolV = false;
                                bool.TryParse(drValue, out boolV);
                                newCell.SetCellValue(boolV);
                                break;
                            case "System.Int16"://整型  
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                                int intV = 0;
                                int.TryParse(drValue, out intV);
                                newCell.SetCellValue(intV);
                                break;
                            case "System.Decimal"://浮点型  
                            case "System.Double":
                                double doubV = 0;
                                double.TryParse(drValue, out doubV);
                                newCell.SetCellValue(doubV);
                                break;
                            case "System.DBNull"://空值处理  
                                newCell.SetCellValue("");
                                break;
                            default:
                                newCell.SetCellValue("");
                                break;
                        }
                    }
                    #endregion

                    rowIndex++;
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.Write(ms);
                    var buf = ms.ToArray();
                    //保存为Excel文件  
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(buf, 0, buf.Length);
                        fs.Flush();
                        sheet.Dispose();
                        msg = "导出成功";
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                msg = "导出失败，失败原因：" + ex.Message;
                return false;
            }
        }
        

        /// <summary>  
        /// DataTable导出到Excel的MemoryStream Export()  
        /// </summary>  
        /// <param name="dtSource">DataTable数据源</param>  
        /// <param name="strHeaderText">Excel表头文本（例如：车辆列表）</param>  
        public static bool Export(DataGridView dgv,string filePath,ref string msg)
        {
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                ISheet sheet = workbook.CreateSheet();

                #region 右击文件 属性信息
                {
                    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                    dsi.Company = "NPOI";
                    workbook.DocumentSummaryInformation = dsi;

                    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                    si.Author = "文件作者信息"; //填加xls文件作者信息  
                    si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息  
                    si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息  
                    si.Comments = "作者信息"; //填加xls文件作者信息  
                    si.Title = "标题信息"; //填加xls文件标题信息  
                    si.Subject = "主题信息";//填加文件主题信息  
                    si.CreateDateTime = System.DateTime.Now;
                    workbook.SummaryInformation = si;
                }
                #endregion

                ICellStyle dateStyle = workbook.CreateCellStyle();
                IDataFormat format = workbook.CreateDataFormat();
                dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

                //取得列宽  
                int[] arrColWidth = new int[dgv.Columns.Count];
                foreach (DataGridViewColumn item in dgv.Columns)
                {
                    arrColWidth[item.Index] = Encoding.GetEncoding(936).GetBytes(item.HeaderText.ToString()).Length;
                }
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        string value = "";
                        if (dgv.Rows[i].Cells[j].Value != null)
                        {
                            value = dgv.Rows[i].Cells[j].Value.ToString();
                        }
                        int intTemp = Encoding.GetEncoding(936).GetBytes(value).Length;
                        if (intTemp > arrColWidth[j])
                        {
                            arrColWidth[j] = intTemp;
                        }
                    }
                }
                int rowIndex = 0;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    #region 新建表，填充表头，填充列头，样式
                    if (rowIndex == 65535 || rowIndex == 0)
                    {
                        if (rowIndex != 0)
                        {
                            sheet = workbook.CreateSheet();
                        }

                        #region 列头及样式
                        {
                            IRow headerRow = sheet.CreateRow(1);
                            ICellStyle headStyle = workbook.CreateCellStyle();
                            headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                            IFont font = workbook.CreateFont();
                            font.FontHeightInPoints = 10;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);
                            foreach (DataGridViewColumn column in dgv.Columns)
                            {
                                headerRow.CreateCell(column.Index).SetCellValue(column.HeaderText);
                                headerRow.GetCell(column.Index).CellStyle = headStyle;

                                //设置列宽  
                                sheet.SetColumnWidth(column.Index, (arrColWidth[column.Index] + 1) * 256);
                            }
                        }
                        #endregion
                        rowIndex = 2;
                    }
                    #endregion

                    #region 填充内容
                    IRow dataRow = sheet.CreateRow(rowIndex);
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        ICell newCell = dataRow.CreateCell(column.Index);
                        string drValue = "";
                        string drValueType = "System.String";
                        if (row.Cells[column.Name].Value != null)
                        {
                            drValue = row.Cells[column.Name].Value.ToString();
                        }
                        if (column.ValueType != null)
                        {
                            drValueType = column.ValueType.ToString();
                        }
                        switch (drValueType)
                        {
                            case "System.String"://字符串类型  
                                newCell.SetCellValue(drValue);
                                break;
                            case "System.DateTime"://日期类型  
                                System.DateTime dateV;
                                System.DateTime.TryParse(drValue, out dateV);
                                newCell.SetCellValue(dateV);

                                newCell.CellStyle = dateStyle;//格式化显示  
                                break;
                            case "System.Boolean"://布尔型  
                                bool boolV = false;
                                bool.TryParse(drValue, out boolV);
                                newCell.SetCellValue(boolV);
                                break;
                            case "System.Int16"://整型  
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                                int intV = 0;
                                int.TryParse(drValue, out intV);
                                newCell.SetCellValue(intV);
                                break;
                            case "System.Decimal"://浮点型  
                            case "System.Double":
                                double doubV = 0;
                                double.TryParse(drValue, out doubV);
                                newCell.SetCellValue(doubV);
                                break;
                            case "System.DBNull"://空值处理  
                                newCell.SetCellValue("");
                                break;
                            default:
                                newCell.SetCellValue("");
                                break;
                        }
                    }
                    #endregion

                    rowIndex++;
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.Write(ms);
                    var buf = ms.ToArray();
                    //保存为Excel文件  
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(buf, 0, buf.Length);
                        fs.Flush();
                        sheet.Dispose();
                        msg = "导出成功";
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                msg = "导出失败，失败原因：" + ex.Message;
                return false;
            }
        }
        
        /// <summary>  
        /// 读取excel ,默认第一行为标头  
        /// </summary>  
        /// <param name="strFileName">excel文档路径</param>  
        /// <returns></returns>  
        public static DataTable Import(string strFileName)
        {
            DataTable dt = new DataTable();

            HSSFWorkbook hssfworkbook;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();
                if (row != null)
                {
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                            dataRow[j] = row.GetCell(j).ToString();
                    }
                    dt.Rows.Add(dataRow);
                }
            }
            return dt;
        } 


    }
}
