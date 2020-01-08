using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XF.Common;
using Enums;
using XF.ExControls;
using System.Data;
using System.Drawing;

namespace BabySwim
{
    public partial class FrmTeachingReport : Form
    {
        DateTimePicker dtpDateStart = new DateTimePicker();
        DateTimePicker dtpDateEnd = new DateTimePicker();
        XF.BLL.Base_Teacher bll = new XF.BLL.Base_Teacher();
        XF.BLL.Base_Course bllCourse = new XF.BLL.Base_Course();
        List<int> courseIDs = new List<int>();
        int initColumnCount;
        private static FrmTeacherCard GetFrmTeacherCard()
        {
            FrmTeacherCard frmTeacherCard = new FrmTeacherCard();
            return frmTeacherCard;
        }
        public FrmTeachingReport()
        {
            InitializeComponent();
            initColumnCount = xfDataGridView1.Columns.Count;
            dtpDateStart.Value = new DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, 1);
            dtpDateEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            ToolStripControlHost item;
            item = new ToolStripControlHost(dtpDateEnd);
            toolStrip1.Items.Insert(4, item);
            item = new ToolStripControlHost(dtpDateStart);
            toolStrip1.Items.Insert(3, item);
            xfDataGridView1.AutoGenerateColumns = false;
            ColJob.DisplayMember = MessageText.LISTITEM_TEXT;
            ColJob.ValueMember = MessageText.LISTITEM_VALUE;
            ColJob.DataSource = GenerateData.GetTeacherJob(false);
            ColJobLevel.DisplayMember = MessageText.LISTITEM_TEXT;
            ColJobLevel.ValueMember = MessageText.LISTITEM_VALUE;
            ColJobLevel.DataSource = GenerateData.GetTeacherJobLevel(false);
            Init();
        }

        private void tsBtnLook_Click(object sender, EventArgs e)
        {
            RowLook();
        }

        private void tsBtnSearch_Click(object sender, EventArgs e)
        {
            //this.xfDataGridView1.AutoGenerateColumns = true;
            BindData();
            //this.xfDataGridView1.SummaryColumns = new string[] { "Freight" };
            ////Show the SummaryBox
            //this.xfDataGridView1.SummaryRowVisible = true;        
        }

        private void FrmTeacherList_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            BindData();
        }

        /// <summary>
        /// 初始化数据和界面
        /// </summary>
        private void Init()
        {
            ColTotle.Tag = -1;
            List<XF.Model.Base_Course> courses = bllCourse.GetModelList(string.Empty);
            for(int i=0;i<courses.Count;i++)
            {
                //增加显示列
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = courses[i].CourseName;
                column.Name = "Course" + courses[i].CourseID;
                column.DataPropertyName = "Course" + courses[i].CourseID;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                column.Tag = courses[i].CourseID;
                column.ReadOnly = true;
                this.xfDataGridView1.Columns.Add(column);

                //构建课程ID
                courseIDs.Add(courses[i].CourseID);
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void BindData()
        {
            DataTable dt = bll.GetTeacherReport(dtpDateStart.Value, dtpDateEnd.Value, courseIDs.ToArray());
            //xfDataGridView1.DataSource = dt;
            xfDataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int count = xfDataGridView1.RowCount;
                xfDataGridView1.Rows.Add();
                xfDataGridView1.Rows[count].Cells[ColID.Name].Value = dr["TeacherID"];
                xfDataGridView1.Rows[count].Cells[ColCode.Name].Value = dr["TeacherCode"];
                xfDataGridView1.Rows[count].Cells[ColName.Name].Value = dr["TeacherName"];
                xfDataGridView1.Rows[count].Cells[ColJob.Name].Value = dr["Job"];
                xfDataGridView1.Rows[count].Cells[ColJobLevel.Name].Value = dr["JobLevel"];
                xfDataGridView1.Rows[count].Cells[ColTotle.Name].Value = dr["Totle"];
                foreach (int courseID in courseIDs)
                {
                    xfDataGridView1.Rows[count].Cells["Course" + courseID.ToString()].Value = dr["Course" + courseID.ToString()];
                }
            }
            ////增加统计列
            xfDataGridView1.Rows.Add();
            xfDataGridView1.Rows[xfDataGridView1.RowCount - 1].Cells[ColID.Name].Value = -1;
            xfDataGridView1.Rows[xfDataGridView1.RowCount - 1].Cells[ColCode.Name].Value = "总计：";
            xfDataGridView1.Rows[xfDataGridView1.RowCount - 1].Cells[ColTotle.Name].Value = dt.Compute("sum(Totle)", "TRUE"); ;
            foreach (int courseID in courseIDs)
            {
                xfDataGridView1.Rows[xfDataGridView1.RowCount - 1].Cells["Course" + courseID.ToString()].Value = dt.Compute("sum(Course" + courseID.ToString() + ")", "TRUE"); ;
            }
        }

        /// <summary>
        /// 行数据查看
        /// </summary>
        private void RowLook()
        {
            if (xfDataGridView1.CurrentCell != null && xfDataGridView1.CurrentCell.ColumnIndex > initColumnCount - 2)
            {
                int rowIndex = xfDataGridView1.CurrentCell.RowIndex;
                int columnIndex = xfDataGridView1.CurrentCell.ColumnIndex;
                int id = PhysicalConstants.ERROR_ID;
                try
                {
                    id = Convert.ToInt32(xfDataGridView1.Rows[rowIndex].Cells[ColID.Name].Value);
                }
                catch (Exception ex)
                {
                    QQMessageBox.Show(
                            this,
                            string.Format(MessageText.TIP_ERROR_ID, ex.Message),
                            MessageText.MESSAGEBOX_CAPTION_ERROR,
                            QQMessageBoxIcon.Error,
                            QQMessageBoxButtons.OK);
                    return;
                }
                FrmTeachingDetail frmTeachingDetail = new FrmTeachingDetail();
                frmTeachingDetail.TeacherID = id;
                frmTeachingDetail.DtStart = dtpDateStart.Value;
                frmTeachingDetail.DtEnd = dtpDateEnd.Value;
                frmTeachingDetail.CourseID = Convert.ToInt32(xfDataGridView1.Columns[xfDataGridView1.CurrentCell.ColumnIndex].Tag);
                frmTeachingDetail.ShowDialog();
            }
        }
    }
}
