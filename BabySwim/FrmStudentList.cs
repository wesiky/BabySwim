using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XF.Common;

namespace BabySwim
{
    public partial class FrmStudentList : Form
    {
        XF.BLL.Base_Student bllStudent = new XF.BLL.Base_Student();
        XF.BLL.Base_Teacher bllTeacher = new XF.BLL.Base_Teacher();
        XF.BLL.Base_Course bllCourse = new XF.BLL.Base_Course();

        public FrmStudentList()
        {
            InitializeComponent();
        }

        private void FrmStudentList_Load(object sender, EventArgs e)
        {
            xfDataGridView1.AutoGenerateColumns = false;
            BindProperty();
            BindData();
        }

        private void tsBtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 绑定属性值
        /// </summary>
        private void BindProperty()
        {
            ColTeacher.DisplayMember = MessageText.LISTITEM_TEXT;
            ColTeacher.ValueMember = MessageText.LISTITEM_VALUE;
            ColAdviser.DisplayMember = MessageText.LISTITEM_TEXT;
            ColAdviser.ValueMember = MessageText.LISTITEM_VALUE;
            ColCourse.DisplayMember = MessageText.LISTITEM_TEXT;
            ColCourse.ValueMember = MessageText.LISTITEM_VALUE;
            DataTable dt = bllTeacher.GetEnableList().Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                if (zDataConverter.ToInt(dr["TeacherType"]) == 0)
                {
                    ColTeacher.Items.Add(new ListItem(zDataConverter.ToString(dr["TeacherID"]), zDataConverter.ToString(dr["TeacherName"])));
                    if (ColTeacher.DefaultCellStyle.NullValue.Equals(string.Empty))
                    {
                        ColTeacher.DefaultCellStyle.NullValue = zDataConverter.ToString(dr["TeacherID"]);
                    }
                }
                else
                {
                    ColAdviser.Items.Add(new ListItem(zDataConverter.ToString(dr["TeacherID"]), zDataConverter.ToString(dr["TeacherName"])));
                    if (ColAdviser.DefaultCellStyle.NullValue.Equals(string.Empty))
                    {
                        ColAdviser.DefaultCellStyle.NullValue = zDataConverter.ToString(dr["TeacherID"]);
                    }
                }
            }

            dt = bllCourse.GetEnableList().Tables[0];
            if (dt.Rows.Count > 0)
            {
                ColCourse.DefaultCellStyle.NullValue = zDataConverter.ToString(dt.Rows[0]["CourseID"]);
            }
            foreach (DataRow dr in dt.Rows)
            {
                ColCourse.Items.Add(new ListItem(zDataConverter.ToString(dr["CourseID"]), zDataConverter.ToString(dr["CourseName"])));
            }
        }

        private void BindData()
        {
            int sum = 0;
            string strWhere = string.Empty;
            List<XF.Model.Base_Student> models = bllStudent.GetModelListByPage(strWhere, " StudentCode Asc ", pagerControl1.PageIndex, pagerControl1.PageSize, ref sum);
            pagerControl1.DrawControl(sum);
            xfDataGridView1.Rows.Clear();
            foreach (XF.Model.Base_Student model in models)
            {
                int count = xfDataGridView1.RowCount;
                xfDataGridView1.Rows.Add();
                xfDataGridView1.Rows[count].Cells[ColStudentId.Name].Value = model.StudentID;
                xfDataGridView1.Rows[count].Cells[ColStudentCode.Name].Value = model.StudentCode;
                xfDataGridView1.Rows[count].Cells[ColStudentName.Name].Value = model.StudentName;
                xfDataGridView1.Rows[count].Cells[ColNickName.Name].Value = model.NickName;
                xfDataGridView1.Rows[count].Cells[ColBirthday.Name].Value = model.Birthday;
                xfDataGridView1.Rows[count].Cells[ColTeacher.Name].Value = zDataConverter.ToString(model.TeacherID);
                xfDataGridView1.Rows[count].Cells[ColAdviser.Name].Value = zDataConverter.ToString(model.AdviserID);
                xfDataGridView1.Rows[count].Cells[ColBirthdate.Name].Value = model.Birthdate;
                xfDataGridView1.Rows[count].Cells[ColCourse.Name].Value = model.CourseID.ToString();
                xfDataGridView1.Rows[count].Cells[ColProgress.Name].Value = model.Progress;
                xfDataGridView1.Rows[count].Cells[ColStudentDescription.Name].Value = model.Description;
                xfDataGridView1.Rows[count].Cells[ColStudentId.Name].ReadOnly = true;
                xfDataGridView1.Rows[count].Cells[ColStudentCode.Name].ReadOnly = true;
                xfDataGridView1.Rows[count].Cells[ColBirthdate.Name].ReadOnly = true;
                xfDataGridView1.Rows[count].Cells[ColBirthday.Name].ReadOnly = true;
                xfDataGridView1.Rows[count].Cells[ColCourse.Name].ReadOnly = true;
                xfDataGridView1.Rows[count].Cells[ColProgress.Name].ReadOnly = true;
            }
        }
        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void xfDataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == ColTeacher.Index)
            {
                xfDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ColTeacher.DefaultCellStyle.NullValue;
            }
            else if (e.ColumnIndex == ColAdviser.Index)
            {
                xfDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ColAdviser.DefaultCellStyle.NullValue;
            }
            else if (e.ColumnIndex == ColCourse.Index)
            {
                xfDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ColCourse.DefaultCellStyle.NullValue;
            }
        }
    }
}
