using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Enums;
using XF.Common;
using XF.ExControls;
using System.Collections;

namespace BabySwim
{
    public partial class FrmTeachingDetail : XFFormEx
    {
        XF.BLL.Course_SelectionStudent bll = new XF.BLL.Course_SelectionStudent();
        DateTime dtStart;
        DateTime dtEnd;
        int courseID = -1;
        int teacherID = -1;

        public DateTime DtStart
        {
            get 
            {
                if (dtStart == null)
                {
                    dtStart = new DateTime();
                }
                return dtStart; 
            }
            set { dtStart = value; }
        }

        public DateTime DtEnd
        {
            get 
            {
                if (dtEnd == null)
                {
                    dtEnd = new DateTime();
                }
                return dtEnd; 
            }
            set { dtEnd = value; }
        }

        public int CourseID
        {
            get { return courseID; }
            set { courseID = value; }
        }

        public int TeacherID
        {
            get { return teacherID; }
            set { teacherID = value; }
        }
        public FrmTeachingDetail()
        {
            InitializeComponent();
        }

        private void FrmCourseEvaluateSearch_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            this.TextForeColor = ConfigSetting.TextForeColor; 
            BindData();
        }

        private void BindData()
        {
            List<XF.Model.Course_SelectionStudent> models = bll.GetDetailModelList(dtStart, dtEnd, teacherID, courseID);
            xfDataGridView1.Rows.Clear();
            foreach (XF.Model.Course_SelectionStudent model in models)
            {
                int count = xfDataGridView1.Rows.Count;
                xfDataGridView1.Rows.Add();
                xfDataGridView1.Rows[count].Cells[ColSelectionID.Name].Value = model.SelectionID;
                xfDataGridView1.Rows[count].Cells[ColCourseDate.Name].Value = model.CourseDate;
                xfDataGridView1.Rows[count].Cells[ColClassRoom.Name].Value = "教室" + MessageText.LIST_NUMBER_CHINESE[model.ClassroomID];
                xfDataGridView1.Rows[count].Cells[ColLessonNO.Name].Value = model.LessonNO;
                xfDataGridView1.Rows[count].Cells[ColCourseName.Name].Value = model.CourseName;
                xfDataGridView1.Rows[count].Cells[ColProgress.Name].Value = model.SectionNO;
                xfDataGridView1.Rows[count].Cells[ColStudentCode.Name].Value = model.StudentCode;
                xfDataGridView1.Rows[count].Cells[ColStudentName.Name].Value = model.StudentName;
            }
        }
    }
}
