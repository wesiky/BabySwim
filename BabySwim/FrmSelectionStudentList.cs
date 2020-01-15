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
using System.IO;

namespace BabySwim
{
    public partial class FrmSelectionStudentList : Form
    {
        CheckBox ckbDate = new CheckBox();
        DateTimePicker dtpDateStart = new DateTimePicker();
        DateTimePicker dtpDateEnd = new DateTimePicker();
        XF.BLL.Course_SelectionStudent bll = new XF.BLL.Course_SelectionStudent();
        XF.BLL.Base_Course bllCourse = new XF.BLL.Base_Course();
        XF.BLL.SysManage bllSys = new XF.BLL.SysManage();
        public FrmSelectionStudentList()
        {
            InitializeComponent();
            ToolStripControlHost item;
            item = new ToolStripControlHost(dtpDateEnd);
            toolStrip1.Items.Insert(5, item);
            item = new ToolStripControlHost(dtpDateStart);
            toolStrip1.Items.Insert(4, item);
            item = new ToolStripControlHost(ckbDate);
            toolStrip1.Items.Insert(3, item);
            ColSelectionType.DisplayMember = MessageText.LISTITEM_TEXT;
            ColSelectionType.ValueMember = MessageText.LISTITEM_VALUE;
            ColSelectionType.DataSource = GenerateData.GetSelectionType(false);
            ColSignType.DisplayMember = MessageText.LISTITEM_TEXT;
            ColSignType.ValueMember = MessageText.LISTITEM_VALUE;
            ColSignType.DataSource = GenerateData.GetSignType(false);
            DataTable dt = bllCourse.GetAllList().Tables[0];
            tsCmbCourse.Items.Add(new ListItem("-1", "全部"));
            foreach (DataRow dr in dt.Rows)
            {
                tsCmbCourse.Items.Add(new ListItem(dr["CourseID"].ToString(), dr["CourseName"].ToString()));
            }
            tsCmbCourse.SelectedIndex = 0;
        }

        private void tsBtnAdd_Click(object sender, EventArgs e)
        {
            xfDataGridView1.Rows.Add();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            xfDataGridView1.EndEdit();
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (xfDataGridView1.SelectedCells.Count > 0)
            {
                xfDataGridView1.Rows.RemoveAt(xfDataGridView1.SelectedCells[0].RowIndex);
            }
        }

        private void FrmCourseEvaluateSearch_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            BindData();
        }

        private void BindData()
        {
            int sum = 0;
            int course = -1;
            string strWhere = string.Empty;
            if (ckbDate.Checked)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, string.Format(" CourseDate Between '{0}' and '{1}'", dtpDateStart.Value.ToString(MessageText.FORMAT_DATE), dtpDateEnd.Value.AddDays(1).ToString(MessageText.FORMAT_DATE)));
            }
            course = zDataConverter.ToInt((tsCmbCourse.SelectedItem as ListItem).Value);
            if (course >= 0)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " CourseID = " + course + " ");
            }
            else
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " CourseID <> " + ConfigSetting.TryOutCourseID + " ");
            }
            if (!tsTbStudent.Text.Equals(string.Empty))
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " (StudentName like '%" + tsTbStudent.Text + "%' or NickName like '%" + tsTbStudent.Text + "%') ");
            }
            if (!tsTbTeacher.Text.Equals(string.Empty))
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " (TeacherCode like '" + tsTbTeacher.Text + "%' or TeacherName like '%" + tsTbTeacher.Text + "%') ");
            }
            if (!strWhere.Equals(string.Empty))
            {
                strWhere = " and " + strWhere;
            }
            string strOrder = " CourseDate,LessonNO,ClassRoomID,CourseID desc";
            List<XF.Model.Course_SelectionStudent> models = bll.GetModelListByPage(strWhere, strOrder, pagerControl1.PageIndex, pagerControl1.PageSize, ref sum);
            pagerControl1.DrawControl(sum);
            xfDataGridView1.Rows.Clear();
            foreach (XF.Model.Course_SelectionStudent model in models)
            {
                int count = xfDataGridView1.Rows.Count;
                xfDataGridView1.Rows.Add();
                xfDataGridView1.Rows[count].Cells[ColID.Name].Value = model.SelectionStudentID;
                xfDataGridView1.Rows[count].Cells[ColCourseDate.Name].Value = model.CourseDate;
                xfDataGridView1.Rows[count].Cells[ColClassRoom.Name].Value = "教室" + MessageText.LIST_NUMBER_CHINESE[model.ClassroomID];
                xfDataGridView1.Rows[count].Cells[ColLessonNO.Name].Value = model.LessonNO;
                xfDataGridView1.Rows[count].Cells[ColCourseID.Name].Value = model.CourseID;
                xfDataGridView1.Rows[count].Cells[ColCourseName.Name].Value = model.CourseName;
                xfDataGridView1.Rows[count].Cells[ColProgress.Name].Value = model.SectionNO;
                xfDataGridView1.Rows[count].Cells[ColStudentName.Name].Value = model.StudentName;
                xfDataGridView1.Rows[count].Cells[ColNickName.Name].Value = model.NickName;
                xfDataGridView1.Rows[count].Cells[ColSelectionType.Name].Value = model.SelectionType;
                xfDataGridView1.Rows[count].Cells[ColTeacherID.Name].Value = model.TeacherID;
                xfDataGridView1.Rows[count].Cells[ColTeacher.Name].Value = model.TeacherCode + "-" + model.TeacherName;
                xfDataGridView1.Rows[count].Cells[ColSignType.Name].Value = model.SignType;
                xfDataGridView1.Rows[count].Cells[ColDescription.Name].Value = model.Description;
            }
        }

        private void tsBtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void tsBtnUpdate_Click(object sender, EventArgs e)
        {
            RowUpdate();
        }

        /// <summary>
        /// 行数据更改
        /// </summary>
        private void RowUpdate()
        {
            int id = GetModelID();
            if (id >= 0)
            {
                FrmSelectionStudentCard frmSelectionStudentCard = new FrmSelectionStudentCard();
                frmSelectionStudentCard.Model = bll.GetDetailModel(id);
                frmSelectionStudentCard.ShowDialog();
                if (frmSelectionStudentCard.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    int signType = zDataConverter.ToInt(xfDataGridView1.Rows[xfDataGridView1.SelectedCells[0].RowIndex].Cells[ColSignType.Name].Value);
                    int courseID = zDataConverter.ToInt(xfDataGridView1.Rows[xfDataGridView1.SelectedCells[0].RowIndex].Cells[ColCourseID.Name].Value);
                    int sectionNO = zDataConverter.ToInt(xfDataGridView1.Rows[xfDataGridView1.SelectedCells[0].RowIndex].Cells[ColProgress.Name].Value);
                    int teacherID = zDataConverter.ToInt(xfDataGridView1.Rows[xfDataGridView1.SelectedCells[0].RowIndex].Cells[ColTeacherID.Name].Value);
                    string evaluateFilePath = ConfigSetting.EvaluateFilePath + frmSelectionStudentCard.Model.SelectionStudentID.ToString() + ".txt";
                    //更新评价
                    ArrayList lstSql = new ArrayList();
                    lstSql.Add(bll.GetUpdateEvaluateSql(frmSelectionStudentCard.Model));
                    lstSql.Add(bll.GetUpdateSignTypeSql(frmSelectionStudentCard.Model.SelectionStudentID, signType, frmSelectionStudentCard.Model.SignType, courseID, sectionNO, teacherID));
                    if (!bllSys.ExecuteSqlTran(lstSql))
                    {
                        QQMessageBox.Show(this, MessageText.SQL_ERROR_SELECTIONSTUDENT_UPDATE, MessageText.MESSAGEBOX_CAPTION_ERROR, QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                        return;
                    }
                    QQMessageBox.Show(this, MessageText.TIP_SUCCESS_SAVE, MessageText.MESSAGEBOX_CAPTION_TIP, QQMessageBoxIcon.Information, QQMessageBoxButtons.OK);
                    BindData();
                }
            }
        }

        /// <summary>
        /// 获取ID
        /// </summary>
        /// <returns></returns>
        private int GetModelID()
        {
            if (CheckSelectedCount(1))
            {
                int rowIndex = xfDataGridView1.SelectedCells[0].RowIndex;
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
                    return PhysicalConstants.ERROR_ID;
                }
                return id;
            }
            else
            {
                return PhysicalConstants.ERROR_SELECT_COUNT;
            }
        }

        /// <summary>
        /// 校验选中行数
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private bool CheckSelectedCount(int count)
        {
            List<int> indexs = GetSelectedRowsIndex();

            if (indexs.Count == count)
            {
                return true;
            }
            else
            {
                QQMessageBox.Show(
                this,
                MessageText.TIP_ERROR_SELECTCOUNT_ONE,
                MessageText.MESSAGEBOX_CAPTION_TIP,
                QQMessageBoxIcon.Information,
                QQMessageBoxButtons.OK);
                return false;
            }
        }

        /// <summary>
        /// 获取选中行索引
        /// </summary>
        /// <returns></returns>
        private List<int> GetSelectedRowsIndex()
        {
            List<int> indexs = new List<int>();
            for (int i = 0; i < xfDataGridView1.SelectedCells.Count; i++)
            {
                if (!indexs.Contains(xfDataGridView1.SelectedCells[i].RowIndex))
                {
                    indexs.Add(xfDataGridView1.SelectedCells[i].RowIndex);
                }
            }
            return indexs;
        }
    }
}
