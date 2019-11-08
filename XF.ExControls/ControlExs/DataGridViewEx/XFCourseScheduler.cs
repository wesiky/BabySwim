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
    public partial class XFCourseScheduler : DataGridView
    {
        private string[] dayOfWeekChn = new string[7]{"周一", "周二", "周三", "周四", "周五", "周六", "周日"};
        List<String> rowDescription;

        Color rowcolor = Color.White;

        Color crossrowcolor = Color.Blue;

        bool crossrowflag = false;

        int dayCount;

        bool contextMenuScriptEnable;

        public int DayCount
        {
            get { return dayCount; }
            set 
            { 
                dayCount = value;
                LoadRows();
                LoadLayout();
            }
        }

        public Color RowColor
        {
            get { return rowcolor; }
            set 
            { 
                rowcolor = value;
                SetRowBackColor();
            }
        }

        public Color CrossRowColor
        {
            get { return crossrowcolor; }
            set 
            { 
                crossrowcolor = value;
                SetRowBackColor();
            }
        }

        public List<String> RowDescription
        {
            get { return rowDescription; }
            set 
            { 
                rowDescription = value; 
            }
        }

        /// <summary>
        /// 跨行标记
        /// </summary>
        public bool CrossRowFlag
        {
            get { return crossrowflag; }
            set
            {
                crossrowflag = value;
                SetRowBackColor();
            }
        }

        /// <summary>
        /// 设置行背景色
        /// </summary>
        private void SetRowBackColor()
        {
            if (crossrowflag)
            {
                for (int i = 0; i < this.Rows.Count; i ++)
                {
                    if (i % 2 == 0)
                    {
                        this.Rows[i].HeaderCell.Style.BackColor = rowcolor;
                        this.Rows[i].DefaultCellStyle.BackColor = rowcolor;
                    }
                    else
                    {
                        this.Rows[i].HeaderCell.Style.BackColor = crossrowcolor;
                        this.Rows[i].DefaultCellStyle.BackColor = crossrowcolor;
                    }
                }

            }
            else
            {
                for (int i = 0; i < this.Rows.Count; i++)
                {
                    this.Rows[i].HeaderCell.Style.BackColor = rowcolor;
                    this.Rows[i].DefaultCellStyle.BackColor = rowcolor;
                }
            }
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
        public XFCourseScheduler()
        {
            InitializeComponent();
            SetStyles();
            tsmiExport.Click += tsmiExport_Click;
            ContextMenuScriptEnable = true;
            InitData();
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
                SetRowBackColor();
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
        private void InitData()
        {
            dayCount = 10;
            if (rowDescription == null)
            {
                rowDescription = new List<String>();
                rowDescription.Add("第一节");
                rowDescription.Add("第二节");
                rowDescription.Add("第三节");
                rowDescription.Add("第四节");
                rowDescription.Add("第五节");
                rowDescription.Add("第六节");
                rowDescription.Add("第七节");
                rowDescription.Add("第八节");
                rowDescription.Add("第九节");
                rowDescription.Add("第十节");
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

        private void LoadColumns()
        {
            if (this.Columns.Count == 0)
            {
                for (int i = 0; i < 7; i++)
                {
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                    col.Name = "Column" + (i + 1).ToString();
                    col.HeaderText = dayOfWeekChn[i];
                    this.Columns.Add(col);
                }
            }
        }
    }
}
