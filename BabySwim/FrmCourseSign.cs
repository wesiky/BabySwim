using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XF.Common;
using Enums;
using XF.ExControls;
using System.Collections;

namespace BabySwim
{
    public partial class FrmCourseSign : Form
    {
        XF.BLL.Course_SelectionStudent bll = new XF.BLL.Course_SelectionStudent();
        XF.BLL.Base_Student bllStudent = new XF.BLL.Base_Student();
        XF.BLL.XF_Configuration bllConfiguration = new XF.BLL.XF_Configuration();
        XF.BLL.SysManage bllSys = new XF.BLL.SysManage();
        List<int> lstUpdate = new List<int>();
        int defaultLessonNO = 0;
        public FrmCourseSign()
        {
            InitializeComponent();
        }

        private void FrmCourseSign_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            int dayCount = zDataConverter.ToInt(bllConfiguration.GetItemValueByCache("DayCount"));
            cmbLesson.Items.Add(new ListItem("-1", "全部"));
            cmbLesson.SelectedIndex = defaultLessonNO;
            for (int i = 0; i < dayCount; i++)
            {
                cmbLesson.Items.Add(new ListItem((i).ToString(), (i + 1).ToString()));
            }
            BindData();
        }

        private void BindData()
        {
            List<XF.Model.Course_SelectionStudent> models = bll.GetDetailModelListByDateLessonNO(DateTime.Now, zDataConverter.ToInt((cmbLesson.SelectedItem as ListItem).Value));
            xfDataGridView1.Rows.Clear();
            foreach (XF.Model.Course_SelectionStudent model in models)
            {
                int count = xfDataGridView1.RowCount;
                xfDataGridView1.Rows.Add();
                xfDataGridView1.Rows[count].Cells[ColSelectionStudentID.Name].Value = model.SelectionStudentID;
                xfDataGridView1.Rows[count].Cells[ColSignType.Name].Value = model.SignType;
                xfDataGridView1.Rows[count].Cells[ColStudentID.Name].Value = model.StudentID;
                xfDataGridView1.Rows[count].Cells[ColStudentName.Name].Value = model.StudentName;
                xfDataGridView1.Rows[count].Cells[ColNickName.Name].Value = model.NickName;
                if (model.ClassroomID >= 0)
                {
                    xfDataGridView1.Rows[count].Cells[ColClassRoomID.Name].Value = "教室" + MessageText.LIST_NUMBER_CHINESE[model.ClassroomID];
                }
                else
                {
                    QQMessageBox.Show(this, "教室数据异常，请联系管理员", MessageText.MESSAGEBOX_CAPTION_ERROR, QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                    return;
                }
                xfDataGridView1.Rows[count].Cells[ColCourseID.Name].Value = model.CourseID;
                xfDataGridView1.Rows[count].Cells[ColCourse.Name].Value = model.CourseName;
                xfDataGridView1.Rows[count].Cells[ColSectionNO.Name].Value = model.SectionNO;
                xfDataGridView1.Rows[count].Cells[ColTeacherID.Name].Value = model.TeacherID;
                xfDataGridView1.Rows[count].Cells[ColTeacher.Name].Value = string.Format("{0}-{1}", model.TeacherCode, model.TeacherName);
                switch ((SignTypeEnum)model.SignType)
                {
                    case SignTypeEnum.NORMAL:
                        xfDataGridView1.Rows[count].Cells[ColNormal.Name].Value = true;
                        break;
                    case SignTypeEnum.LATE:
                        xfDataGridView1.Rows[count].Cells[ColLate.Name].Value = true;
                        break;
                    case SignTypeEnum.EARLY:
                        xfDataGridView1.Rows[count].Cells[ColEarly.Name].Value = true;
                        break;
                    case SignTypeEnum.LEAVE:
                        xfDataGridView1.Rows[count].Cells[ColLeave.Name].Value = true;
                        break;
                    default:
                        break;
                }
            }
            lstUpdate.Clear();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            //保存学生签到数据
            ArrayList lstSql = new ArrayList();
            foreach (int rowIndex in lstUpdate)
            {
                int selectionStudentID = zDataConverter.ToInt(xfDataGridView1.Rows[rowIndex].Cells[ColSelectionStudentID.Name].Value);
                int signTypeOld = zDataConverter.ToInt(xfDataGridView1.Rows[rowIndex].Cells[ColSignType.Name].Value);
                int signType = GetSignType(rowIndex);
                int courseID = zDataConverter.ToInt(xfDataGridView1.Rows[rowIndex].Cells[ColCourseID.Name].Value);
                int sectionNO = zDataConverter.ToInt(xfDataGridView1.Rows[rowIndex].Cells[ColSectionNO.Name].Value);
                int teacherID = zDataConverter.ToInt(xfDataGridView1.Rows[rowIndex].Cells[ColTeacherID.Name].Value);
                lstSql.Add(bll.GetUpdateSignTypeSql(selectionStudentID, signTypeOld, signType,courseID,sectionNO,teacherID));
            }
            if (!bllSys.ExecuteSqlTran(lstSql))
            {
                QQMessageBox.Show(this, MessageText.SQL_ERROR_SELECTIONSTUDENT_SIGNTYPE_SAVE, MessageText.MESSAGEBOX_CAPTION_ERROR, QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                return;
            }
            QQMessageBox.Show(this, MessageText.TIP_SUCCESS_SAVE, MessageText.MESSAGEBOX_CAPTION_TIP, QQMessageBoxIcon.Information, QQMessageBoxButtons.OK);
            BindData();
        }

        /// <summary>
        /// 获取签到类型
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private int GetSignType(int rowIndex)
        {
            if (zDataConverter.ToBool(xfDataGridView1.Rows[rowIndex].Cells[ColNormal.Name].Value))
            {
                return 1;
            }
            else if (zDataConverter.ToBool(xfDataGridView1.Rows[rowIndex].Cells[ColLate.Name].Value))
            {
                return 2;
            }
            else if (zDataConverter.ToBool(xfDataGridView1.Rows[rowIndex].Cells[ColEarly.Name].Value))
            {
                return 3;
            }
            else if (zDataConverter.ToBool(xfDataGridView1.Rows[rowIndex].Cells[ColLeave.Name].Value))
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }

        private void cmbLesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUpdate.Count > 0)
            {
                if (QQMessageBox.Show(this, MessageText.TIP_DONT_SAVE_DATA, MessageText.MESSAGEBOX_CAPTION_TIP, QQMessageBoxIcon.Question, QQMessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BindData();
                }
            }
            else
            {
                BindData();
            }
        }

        private void xfDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == ColNormal.Index)
                {
                    SaveChangedRowIndex(e.RowIndex);
                    if (zDataConverter.ToBool(xfDataGridView1.Rows[e.RowIndex].Cells[ColNormal.Name].Value))
                    {
                        xfDataGridView1.Rows[e.RowIndex].Cells[ColNormal.Name].Value = false;
                    }
                    else
                    {
                        xfDataGridView1.Rows[e.RowIndex].Cells[ColNormal.Name].Value = true;
                    }
                    xfDataGridView1.Rows[e.RowIndex].Cells[ColLate.Name].Value = false;
                    xfDataGridView1.Rows[e.RowIndex].Cells[ColEarly.Name].Value = false;
                    xfDataGridView1.Rows[e.RowIndex].Cells[ColLeave.Name].Value = false;
                }
                if (e.ColumnIndex == ColLate.Index)
                {
                    SaveChangedRowIndex(e.RowIndex);
                    xfDataGridView1.Rows[e.RowIndex].Cells[ColNormal.Name].Value = false;
                    if (zDataConverter.ToBool(xfDataGridView1.Rows[e.RowIndex].Cells[ColLate.Name].Value))
                    {
                        xfDataGridView1.Rows[e.RowIndex].Cells[ColLate.Name].Value = false;
                    }
                    else
                    {
                        xfDataGridView1.Rows[e.RowIndex].Cells[ColLate.Name].Value = true;
                    }
                    xfDataGridView1.Rows[e.RowIndex].Cells[ColEarly.Name].Value = false;
                    xfDataGridView1.Rows[e.RowIndex].Cells[ColLeave.Name].Value = false;
                }
                if (e.ColumnIndex == ColEarly.Index)
                {
                    SaveChangedRowIndex(e.RowIndex);
                    xfDataGridView1.Rows[e.RowIndex].Cells[ColNormal.Name].Value = false;
                    xfDataGridView1.Rows[e.RowIndex].Cells[ColLate.Name].Value = false;
                    if (zDataConverter.ToBool(xfDataGridView1.Rows[e.RowIndex].Cells[ColEarly.Name].Value))
                    {
                        xfDataGridView1.Rows[e.RowIndex].Cells[ColEarly.Name].Value = false;
                    }
                    else
                    {
                        xfDataGridView1.Rows[e.RowIndex].Cells[ColEarly.Name].Value = true;
                    }
                    xfDataGridView1.Rows[e.RowIndex].Cells[ColLeave.Name].Value = false;
                }
                if (e.ColumnIndex == ColLeave.Index)
                {
                    SaveChangedRowIndex(e.RowIndex);
                    xfDataGridView1.Rows[e.RowIndex].Cells[ColNormal.Name].Value = false;
                    xfDataGridView1.Rows[e.RowIndex].Cells[ColLate.Name].Value = false;
                    xfDataGridView1.Rows[e.RowIndex].Cells[ColEarly.Name].Value = false;
                    if (zDataConverter.ToBool(xfDataGridView1.Rows[e.RowIndex].Cells[ColLeave.Name].Value))
                    {
                        xfDataGridView1.Rows[e.RowIndex].Cells[ColLeave.Name].Value = false;
                    }
                    else
                    {
                        xfDataGridView1.Rows[e.RowIndex].Cells[ColLeave.Name].Value = true;
                    }
                }
            }
        }

        private void SaveChangedRowIndex(int rowIndex)
        {
            if (!lstUpdate.Contains(rowIndex))
            {
                lstUpdate.Add(rowIndex);
            }
        }
    }
}
