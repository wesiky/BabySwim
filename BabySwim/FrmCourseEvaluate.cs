using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Enums;
using XF.Common;
using XF.ExControls;
using System.Drawing;

namespace BabySwim
{
    public partial class FrmCourseEvaluate : XFFormEx
    {
        int rowIndexOld = -1;
        private XF.Model.Course_Selection model;

        public XF.Model.Course_Selection Model
        {
            get { return model; }
            set
            {
                model = value;
                LoadFormData();
            }
        }

        public FrmCourseEvaluate()
        {
            InitializeComponent();
            ColSignType.DisplayMember = MessageText.LISTITEM_TEXT;
            ColSignType.ValueMember = MessageText.LISTITEM_VALUE;
            ColSignType.DataSource = GenerateData.GetSignType(false);
        }

        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnSure_Click(object sender, EventArgs e)
        {
            SetModelData();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 设置Model数据
        /// </summary>
        private void SetModelData()
        {
            xfDataGridView1.Rows[rowIndexOld].Cells[ColEvaluate.Name].Value = rtcEvaluate.ContentRtf;
            model.SelectionStudents.Clear();
            foreach (DataGridViewRow dgvr in xfDataGridView1.Rows)
            {
                XF.Model.Course_SelectionStudent student = new XF.Model.Course_SelectionStudent();
                student.SelectionStudentID = zDataConverter.ToInt(dgvr.Cells[ColSelectionStudentID.Name].Value);
                student.Evaluate = zDataConverter.ToString(dgvr.Cells[ColEvaluate.Name].Value);
                model.SelectionStudents.Add(student);
            }
        }

        /// <summary>
        /// 设置界面数据
        /// </summary>
        private void LoadFormData()
        {
            if (model != null)
            {
                tbCourseDate.Text = model.CourseDate.ToString(MessageText.FORMAT_DATE);
                tbSectionNO.Text = zDataConverter.ToString(model.SectionNO);
                if (model.SelectionID >= 0)
                {
                    tbCourse.Text = model.CourseName;
                    tbSectionNO.Text = zDataConverter.ToString( model.SectionNO);
                    tbTeacher.Text = string.Format("{0}-{1}", model.TeacherCode, model.TeacherName);
                    BindStudentData(model.SelectionStudents);
                }
            }
        }

        /// <summary>
        /// 绑定学员信息
        /// </summary>
        /// <param name="models"></param>
        private void BindStudentData(List<XF.Model.Course_SelectionStudent> models)
        {
            xfDataGridView1.Rows.Clear();
            foreach (XF.Model.Course_SelectionStudent model in models)
            {
                int count = xfDataGridView1.Rows.Count;
                xfDataGridView1.Rows.Add();
                xfDataGridView1.Rows[count].Cells[ColSelectionStudentID.Name].Value = model.SelectionStudentID;
                xfDataGridView1.Rows[count].Cells[ColStudentID.Name].Value = model.StudentID;
                xfDataGridView1.Rows[count].Cells[ColStudentCode.Name].Value = model.StudentCode;
                xfDataGridView1.Rows[count].Cells[ColStudentName.Name].Value = model.StudentName;
                xfDataGridView1.Rows[count].Cells[ColSignType.Name].Value = model.SignType;
                xfDataGridView1.Rows[count].Cells[ColEvaluate.Name].Value = model.Evaluate;
            }
        }

        private void xfDataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            ShowStudentEvalute();
        }

        /// <summary>
        /// 显示学员评价信息
        /// </summary>
        /// <param name="models"></param>
        private void ShowStudentEvalute()
        {
            if (xfDataGridView1.CurrentCell != null && xfDataGridView1.CurrentCell.RowIndex >= 0)
            {
                if (rowIndexOld != xfDataGridView1.CurrentCell.RowIndex)
                {
                    if (rowIndexOld >= 0)
                    {
                        xfDataGridView1.Rows[rowIndexOld].Cells[ColEvaluate.Name].Value = rtcEvaluate.ContentRtf;
                    }
                    rowIndexOld = xfDataGridView1.CurrentCell.RowIndex;
                    rtcEvaluate.ContentRtf = zDataConverter.ToString(xfDataGridView1.Rows[xfDataGridView1.CurrentCell.RowIndex].Cells[ColEvaluate.Name].Value);
                }
            }
        }

        private void FrmCourseEvaluate_Load(object sender, EventArgs e)
        {
            this.TextForeColor = ConfigSetting.TextForeColor;
            this.Icon = ConfigSetting.ProjectIcon;
        }
    }
}
