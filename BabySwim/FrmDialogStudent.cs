using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using XF.ExControls;
using XF.Common;
using Enums;
using System.Drawing;

namespace BabySwim
{
    public partial class FrmDialogStudent : XFFormEx
    {
        int studentid;
        string studentcode;
        string studentname;
        string nickname;
        DateTime birthdate;
        int teacherid;
        int adviserid;
        string teachercode;
        string teachername;
        string advisercode;
        string advisername;
        DateTime birthday;
        int courseid;
        int progress;
        int familyid;
        string familycode;
        string familyname;
        decimal coursecount;

        public string StudentCode
        {
            get { return studentcode; }
            set { studentcode = value; }
        }

        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        public int TeacherID
        {
            get { return teacherid; }
            set { teacherid = value; }
        }

        public int AdviserID
        {
            get { return adviserid; }
            set { adviserid = value; }
        }

        public string TeacherCode
        {
            get { return teachercode; }
            set { teachercode = value; }
        }

        public string TeacherName
        {
            get { return teachername; }
            set { teachername = value; }
        }

        public string AdviserCode
        {
            get { return advisercode; }
            set { advisercode = value; }
        }

        public string AdviserName
        {
            get { return advisername; }
            set { advisername = value; }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public int CourseID
        {
            get { return courseid; }
            set { courseid = value; }
        }

        public int Progress
        {
            get { return progress; }
            set { progress = value; }
        }

        public int StudentID
        {
            get { return studentid; }
            set { studentid = value; }
        }

        public string StudentName
        {
            get { return studentname; }
            set { studentname = value; }
        }

        public string NickName
        {
            get { return nickname; }
            set { nickname = value; }
        }

        public int FamilyID
        {
            get { return familyid; }
            set { familyid = value; }
        }

        public string FamilyCode
        {
            get { return familycode; }
            set { familycode = value; }
        }

        public string FamilyName
        {
            get { return familyname; }
            set { familyname = value; }
        }

        public decimal CourseCount
        {
            get { return coursecount; }
            set { coursecount = value; }
        }

        XF.BLL.Base_Student bll = new XF.BLL.Base_Student();

        public FrmDialogStudent()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        public FrmDialogStudent(string studentName,string  familyName)
        {
            InitializeComponent();
            tsTbStudent.Text = studentName;
            tsTbFamily.Text = familyName;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void tsBtnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void FrmDialogComponent_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            this.TextForeColor = ConfigSetting.TextForeColor;
            BindData();
        }

        private void BindData()
        {
            string strWhere = string.Empty;
            if (!tsTbStudent.Text.Trim().Equals(string.Empty))
            {
                strWhere += string.Format(" and (A.StudentName LIKE '%{0}%' or A.NickName LIKE '%{1}%')", tsTbStudent.Text.Trim(), tsTbStudent.Text.Trim());
            }
            if (!tsTbFamily.Text.Trim().Equals(string.Empty))
            {
                strWhere += string.Format(" and (B.FamilyCode LIKE '%{0}%' or A.FamilyName LIKE '%{1}%')", tsTbFamily.Text.Trim(), tsTbFamily.Text.Trim());
            }
            int count = 0;
            DataTable dt = bll.GetListByPage(strWhere, " A.CreateDate DESC ", pagerControl1.PageIndex, pagerControl1.PageSize, ref count);

            pagerControl1.DrawControl(count);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DateTime dt ;
                this.studentid = zDataConverter.ToInt(dataGridView1.SelectedRows[0].Cells[ColStudentID.Name].Value);
                this.studentcode = zDataConverter.ToString(dataGridView1.SelectedRows[0].Cells[ColStudentCode.Name].Value);
                this.studentname = zDataConverter.ToString( dataGridView1.SelectedRows[0].Cells[ColStudentName.Name].Value);
                this.nickname = zDataConverter.ToString(dataGridView1.SelectedRows[0].Cells[ColNickName.Name].Value);
                this.teacherid = zDataConverter.ToInt(dataGridView1.SelectedRows[0].Cells[ColTeacherID.Name].Value);
                this.teachercode = zDataConverter.ToString(dataGridView1.SelectedRows[0].Cells[ColTeacherCode.Name].Value);
                this.teachername = zDataConverter.ToString(dataGridView1.SelectedRows[0].Cells[ColTeacherName.Name].Value);
                this.adviserid = zDataConverter.ToInt(dataGridView1.SelectedRows[0].Cells[ColAdviserID.Name].Value);
                this.advisercode = zDataConverter.ToString(dataGridView1.SelectedRows[0].Cells[ColAdviserCode.Name].Value);
                this.advisername = zDataConverter.ToString(dataGridView1.SelectedRows[0].Cells[ColAdviserName.Name].Value);
                if(DateTime.TryParse(zDataConverter.ToString(dataGridView1.SelectedRows[0].Cells[ColBirthDate.Name].Value),out dt))
                {
                    this.birthdate = dt;
                }
                this.courseid = zDataConverter.ToInt(dataGridView1.SelectedRows[0].Cells[ColCourseID.Name].Value);
                this.progress = zDataConverter.ToInt(dataGridView1.SelectedRows[0].Cells[ColProgress.Name].Value);
                if(DateTime.TryParse(zDataConverter.ToString(dataGridView1.SelectedRows[0].Cells[ColBirthday.Name].Value),out dt))
                {
                    this.birthday = dt;
                }
                this.familyid = zDataConverter.ToInt(dataGridView1.SelectedRows[0].Cells[ColFamilyID.Name].Value);
                this.familycode = zDataConverter.ToString(dataGridView1.SelectedRows[0].Cells[ColFamilyCode.Name].Value);
                this.familyname = zDataConverter.ToString(dataGridView1.SelectedRows[0].Cells[ColFamilyName.Name].Value);
                this.coursecount = zDataConverter.ToDecimal(dataGridView1.SelectedRows[0].Cells[ColCourseCount.Name].Value);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                QQMessageBox.Show(
                            this,
                            MessageText.TIP_ERROR_SELECTCOUNT_ONE,
                            MessageText.MESSAGEBOX_CAPTION_TIP,
                            QQMessageBoxIcon.Information,
                            QQMessageBoxButtons.OK);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SaveData();
        }
    }
}
