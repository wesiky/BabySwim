using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using XF.Common;

namespace XF.ExControls
{
    public partial class XFDataGridView : DataGridView
    {
        string columnOrderName;

        bool contextMenuScriptEnable;

        public bool ContextMenuScriptEnable
        {
            get { return contextMenuScriptEnable; }
            set 
            { 
                contextMenuScriptEnable = value;
                if (ContextMenuScriptEnable)
                {
                    this.ContextMenuStrip = cmsOption;
                }
                else
                {
                    this.ContextMenuStrip = null;
                }
            }
        }

        /// <summary>
        /// 列排序名称
        /// </summary>
        public string ColumnOrderName
        {
            get { return columnOrderName; }
            set { columnOrderName = value; }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public XFDataGridView()
        {
            InitializeComponent();
            tsmiExport.Click += tsmiExport_Click;
            ContextMenuScriptEnable = true;
        }

        public void OrderColumns()
        {
            if (columnOrderName != null && !columnOrderName.Equals(string.Empty))
            {
                //初始化完成后进行列排序
                XmlDocument xmlDoc = new XmlDocument();
                //创建配置文件
                GenerateConfigFile.CreateXFDataGrideViewConfig();
                //加载XML配置文件
                xmlDoc.Load(Application.StartupPath + @"/XFDataGridViewConfig.xml");
                XmlNode node = xmlDoc.SelectSingleNode("XFDataGridView/ColumnOrderNames/ColumnOrderName[@name='" + columnOrderName + "']");//根据排序名称获取列排序节点
                //若节点存在，进行列排序，否则不排序
                if (node != null)
                {
                    string[] columns = node.Attributes["value"].Value.Split(',');
                    for (int i = 0; i < columns.Length; i++)
                    {
                        this.Columns[columns[i]].DisplayIndex = i;
                    }
                }
            }
        }

        public void SaveOrderColumns()
        {
            if (columnOrderName != null && !columnOrderName.Equals(string.Empty))
            {
                //列顺序修改后保存列顺序
                XmlDocument xmlDoc = new XmlDocument();
                //创建配置文件
                GenerateConfigFile.CreateXFDataGrideViewConfig();
                //加载XML配置文件
                xmlDoc.Load(Application.StartupPath + @"/XFDataGridViewConfig.xml");
                XmlNode root = xmlDoc.SelectSingleNode("XFDataGridView/ColumnOrderNames");
                XmlElement node = (XmlElement)root.SelectSingleNode("ColumnOrderName[@name='" + columnOrderName + "']");//根据排序名称获取列排序节点
                //列排序
                string[] columnNames = new string[this.Columns.Count];
                for (int i = 0; i < this.Columns.Count; i++)
                {
                    columnNames[Columns[i].DisplayIndex] = Columns[i].Name;
                }
                string nodeValue = "";
                foreach (string value in columnNames)
                {
                    nodeValue += "," + value;
                }
                nodeValue = nodeValue.Substring(1);
                //若节点存在，进行更新，否则新建节点
                if (node != null)
                {
                    node.SetAttribute("value", nodeValue);
                }
                else
                {
                    //创建节点并赋值
                    XmlElement newNode = xmlDoc.CreateElement("ColumnOrderName");
                    newNode.SetAttribute("name", columnOrderName);
                    newNode.SetAttribute("value", nodeValue);
                    root.AppendChild(newNode);
                }
                xmlDoc.Save(Application.StartupPath + @"/XFDataGridViewConfig.xml");
            }
        }

        private void XFDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            System.Drawing.Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Y, this.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), this.RowHeadersDefaultCellStyle.Font, rectangle, this.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void XFDataGridView_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            
        }

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            ExportData();
        }

        public void ExportData()
        {
            string msg = "";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "保存excel文件";
            saveFileDialog1.Filter = "excel03文件(*.xls)|*.xls|excel07文件(*.xlsx)|*.xlsx";
            saveFileDialog1.RestoreDirectory = false;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XF.Common.ExcelOptioner.Export(this, saveFileDialog1.FileName, ref msg);
                MessageBox.Show(msg);
            }
        }
    }
}
