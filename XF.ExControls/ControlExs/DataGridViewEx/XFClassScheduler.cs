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
    public partial class XFClassScheduler : DataGridView
    {
        List<string> rowDescription;

        List<string> columnDescription;

        int roomCount = 6;//教室数量

        int dayCount = 10;//一天上课节数

        bool contextMenuScriptEnable;

        public int DayCount
        {
            get { return dayCount; }
        }

        public int RoomCount
        {
            get { return roomCount; }
        }

        private void LoadColumns()
        {
            this.Columns.Clear();
            for (int i = 0; i < roomCount; i++)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                col.Name = "Column" + (i + 1).ToString();
                if (columnDescription != null &&i < columnDescription.Count)
                {
                    col.HeaderText = columnDescription[i];
                }
                this.Columns.Add(col);
            }

        }

        public List<string> RowDescription
        {
            get { return rowDescription; }
        }

        public List<string> ColumnDescription
        {
            get { return columnDescription; }
        }

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
        /// 初始化
        /// </summary>
        public XFClassScheduler(int dayCount,int roomCount,string[] roomNames,string[] dayNames)
        {
            InitializeComponent();
            this.dayCount = dayCount;
            this.roomCount = roomCount;
            SetStyles();
            tsmiExport.Click += tsmiExport_Click;
            ContextMenuScriptEnable = true;
            InitData(roomNames, dayNames);
            LoadColumns();
            LoadRows();
            LoadLayout();
        }

        /// <summary>
        /// 铺满控件
        /// </summary>
        private void LoadLayout()
        {
            if (this.Rows.Count > 0)
            {
                //this.ColumnHeadersHeight = this.Height / (dayCount + 1);
                for (int i = 0; i < this.Rows.Count; i++)
                {
                    this.Rows[i].Height = (this.Height - this.ColumnHeadersHeight) / this.Rows.Count;
                }
            }
        }

        /// <summary>
        /// 加载行
        /// </summary>
        private void LoadRows()
        {
            this.Rows.Clear();
            this.Rows.Add(dayCount);
        }

        /// <summary>
        /// 初始化描述
        /// </summary>
        private void InitData(string[] roomNames, string[] dayNames)
        {
            //初始化行名
            if (rowDescription == null)
            {
                rowDescription = new List<string>();
                for (int i = 0; i < dayCount; i++)
                {
                    if (i < dayNames.Length)
                    {
                        rowDescription.Add(dayNames[i]);
                    }
                    else
                    {
                        rowDescription.Add("第" + (i + 1).ToString() + "节");
                    }
                }
            }
            //初始化列名
            if (columnDescription == null)
            {
                columnDescription = new List<string>();
                for (int i = 0; i < roomCount; i++)
                {
                    if (i < roomNames.Length)
                    {
                        columnDescription.Add(roomNames[i]);
                    }
                    else
                    {
                        columnDescription.Add("教室" + (i + 1).ToString());
                    }
                }
            }
        }

        private void XFDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //绘制行描述
            if (e.RowIndex < rowDescription.Count)
            {
                System.Drawing.Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Y, this.RowHeadersWidth - 4, e.RowBounds.Height);
                TextRenderer.DrawText(e.Graphics, rowDescription[e.RowIndex], this.RowHeadersDefaultCellStyle.Font, rectangle, this.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
        }

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            ExportData();
        }

        private void SetStyles()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            LoadLayout();
        }
    }
}
