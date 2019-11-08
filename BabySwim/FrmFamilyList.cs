using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XF.ExControls;
using Enums;
using XF.Common;
using System.Globalization;

namespace BabySwim
{
    public partial class FrmFamilyList : Form
    {
        XF.BLL.Base_Family bll = new XF.BLL.Base_Family();
        XF.BLL.Base_Student bllStudent = new XF.BLL.Base_Student();
        XF.BLL.Base_Teacher bllTeacher = new XF.BLL.Base_Teacher();
        XF.BLL.Base_Course bllCourse = new XF.BLL.Base_Course();
        List<int> lstInsert = new List<int>();
        List<int> lstUpdate = new List<int>();
        List<int> lstStudentInsert = new List<int>();
        List<int> lstStudentUpdate = new List<int>();
        DateTimePicker dtp = new DateTimePicker();  //这里实例化一个DateTimePicker控件
        Rectangle _Rectangle;//用于显示时间控件的单元格
        ChineseLunisolarCalendar chineseDate = new ChineseLunisolarCalendar();
        public FrmFamilyList()
        {
            InitializeComponent();
        }

        private void tsBtnAdd_Click(object sender, EventArgs e)
        {
            RowAdd();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            RowsDelete();
        }

        private void tsBtnStudentAdd_Click(object sender, EventArgs e)
        {
            dtp.Visible = false;
            StudentRowAdd();
        }

        private void StudentRowAdd()
        {
            int rowIndex = xfDataGridView2.RowCount;
            xfDataGridView2.Rows.Add();
            DateTime dtChinese = new DateTime(chineseDate.GetYear(DateTime.Now), chineseDate.GetMonth(DateTime.Now), chineseDate.GetDayOfMonth(DateTime.Now));
            xfDataGridView2.Rows[xfDataGridView2.CurrentCell.RowIndex].Cells[ColBirthday.Name].Value = dtChinese;
            xfDataGridView2.Rows[rowIndex].Cells[ColBirthday.Name].Value = dtChinese;
            xfDataGridView2.Rows[rowIndex].Cells[ColBirthdate.Name].Value = DateTime.Now.ToString(MessageText.FORMAT_DATE);
            xfDataGridView2.Rows[rowIndex].Cells[ColStudentName.Name].ReadOnly = false;
            xfDataGridView2.Rows[rowIndex].Cells[ColCourse.Name].ReadOnly = true;
            xfDataGridView2.Rows[rowIndex].Cells[ColBirthdate.Name].ReadOnly = true;
            xfDataGridView2.Rows[rowIndex].Cells[ColBirthday.Name].ReadOnly = true;
            xfDataGridView2.Rows[rowIndex].Cells[ColProgress.Name].ReadOnly = true;
            if(ColTeacher.Items.Count >0)
            {
                xfDataGridView2.Rows[rowIndex].Cells[ColTeacher.Name].Value = (ColTeacher.Items[0] as ListItem).Value;
            }
            if (ColAdviser.Items.Count > 0)
            {
                xfDataGridView2.Rows[rowIndex].Cells[ColAdviser.Name].Value = (ColAdviser.Items[0] as ListItem).Value;
            }
            if (ColCourse.Items.Count > 0)
            {
                xfDataGridView2.Rows[rowIndex].Cells[ColCourse.Name].Value = (ColCourse.Items[0] as ListItem).Value;
            }
        }

        private void tsBtnStudentSave_Click(object sender, EventArgs e)
        {
            dtp.Visible = false;
            SaveStudentData();
        }

        private void tsBtnStudentDelete_Click(object sender, EventArgs e)
        {
            dtp.Visible = false;
            StudentRowsDelete();
        }

        /// <summary>
        /// 学员信息删除
        /// </summary>
        private void StudentRowsDelete()
        {
            List<int> indexs = GetSelectedRowsIndex(xfDataGridView2);
            if (indexs.Count > 0)
            {
                string sIDs = string.Empty;
                string sID;
                //构建删除ID
                foreach (int i in indexs)
                {
                    sID = zDataConverter.ToString(xfDataGridView2.Rows[i].Cells[ColStudentID.Name].Value);
                    if (sID.Length > 0)
                    {
                        sIDs += MessageText.KEY_COMMA + sID;
                    }
                }
                if (sIDs.Length > 0)
                {
                    //执行数据库删除
                    if (!bllStudent.DeleteMultiple(sIDs.Substring(1)))
                    {
                        QQMessageBox.Show(
                        this,
                        MessageText.SQL_ERROR_STUDENT_DELETE,
                        MessageText.MESSAGEBOX_CAPTION_ERROR,
                        QQMessageBoxIcon.Error,
                        QQMessageBoxButtons.OK);
                        return;
                    }
                }
                BindStudentData();
                QQMessageBox.Show(
                            this,
                            MessageText.TIP_SUCCESS_DELETE,
                            MessageText.MESSAGEBOX_CAPTION_TIP,
                            QQMessageBoxIcon.OK,
                            QQMessageBoxButtons.OK);
            }
            else
            {
                QQMessageBox.Show(
                            this,
                            MessageText.TIP_ERROR_SELECTCOUNT_NULL,
                            MessageText.MESSAGEBOX_CAPTION_TIP,
                            QQMessageBoxIcon.Information,
                            QQMessageBoxButtons.OK);
            }
        }

        private void tsBtnRefresh_Click(object sender, EventArgs e)
        {
            dtp.Visible = false;
            BindStudentData();
        }

        private void FrmFamilyList_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            BindDateTimePicker();
            BindProperty();
            BindData();
        }

        private void BindDateTimePicker()
        {
            xfDataGridView2.Controls.Add(dtp);  //把时间控件加入DataGridView
            dtp.Visible = false;  //先不让它显示
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = MessageText.FORMAT_DATE;
            dtp.TextChanged += new EventHandler(dtp_TextChange); //为时间控件加入事件dtp_TextChange
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

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void BindData()
        {
            BindFamilyData();
        }

        /// <summary>
        /// 家长数据绑定
        /// </summary>
        private void BindFamilyData()
        {
            int sum = 0;
            string strWhere = string.Empty;
            if (!tsTbFamily.Text.Equals(string.Empty))
            {
                strWhere += string.Format(" and ( FamilyCode like '%{0}%' or FamilyName like '%{1}%') ", tsTbFamily.Text, tsTbFamily.Text);
            }
            List<XF.Model.Base_Family> models = bll.GetModelListByPage(strWhere, " FamilyCode Asc ", pagerControl1.PageIndex, pagerControl1.PageSize, ref sum);
            pagerControl1.DrawControl(sum);
            xfDataGridView1.Rows.Clear();
            if (models.Count > 0)
            {
                foreach (XF.Model.Base_Family model in models)
                {
                    int count = xfDataGridView1.RowCount;
                    xfDataGridView1.Rows.Add();
                    xfDataGridView1.Rows[count].Cells[ColFamilyID.Name].Value = model.FamilyID;
                    xfDataGridView1.Rows[count].Cells[ColFamilyCode.Name].Value = model.FamilyCode;
                    xfDataGridView1.Rows[count].Cells[ColFamilyName.Name].Value = model.FamilyName;
                    xfDataGridView1.Rows[count].Cells[ColCourseCount.Name].Value = model.CourseCount;
                    xfDataGridView1.Rows[count].Cells[ColPhone.Name].Value = model.Phone;
                    xfDataGridView1.Rows[count].Cells[ColDescription.Name].Value = model.Description;
                    xfDataGridView1.Rows[count].Cells[ColFamilyID.Name].ReadOnly = true;
                    xfDataGridView1.Rows[count].Cells[ColFamilyCode.Name].ReadOnly = true;
                }
            }
            lstInsert.Clear();
            lstUpdate.Clear();
        }

        /// <summary>
        /// 学员数据绑定
        /// </summary>
        private void BindStudentData()
        {
            if (xfDataGridView1.CurrentCell != null)
            {

                int rowIndex = xfDataGridView1.CurrentCell.RowIndex;
                if (zDataConverter.ToString(xfDataGridView1.Rows[rowIndex].Cells[ColFamilyID.Name].Value).Equals(string.Empty))
                {
                    tsBtnStudentAdd.Enabled = false;
                    tsBtnStudentSave.Enabled = false;
                    tsBtnStudentDelete.Enabled = false;
                    tsBtnRefresh.Enabled = false;
                    xfDataGridView2.Rows.Clear();
                }
                else
                {
                    tsBtnStudentAdd.Enabled = true;
                    tsBtnStudentSave.Enabled = true;
                    tsBtnStudentDelete.Enabled = true;
                    tsBtnRefresh.Enabled = true;
                    string strWhere = string.Empty;
                    strWhere += " FamilyID = " + zDataConverter.ToString(xfDataGridView1.Rows[rowIndex].Cells[ColFamilyID.Name].Value);
                    List<XF.Model.Base_Student> models = bllStudent.GetModelList(strWhere);
                    xfDataGridView2.Rows.Clear();
                    foreach (XF.Model.Base_Student model in models)
                    {
                        int count = xfDataGridView2.RowCount;
                        xfDataGridView2.Rows.Add();
                        xfDataGridView2.Rows[count].Cells[ColStudentID.Name].Value = model.StudentID;
                        xfDataGridView2.Rows[count].Cells[ColStudentCode.Name].Value = model.StudentCode;
                        xfDataGridView2.Rows[count].Cells[ColStudentName.Name].Value = model.StudentName;
                        xfDataGridView2.Rows[count].Cells[ColNickName.Name].Value = model.NickName;
                        xfDataGridView2.Rows[count].Cells[ColBirthday.Name].Value = model.Birthday;
                        xfDataGridView2.Rows[count].Cells[ColTeacher.Name].Value = zDataConverter.ToString(model.TeacherID);
                        xfDataGridView2.Rows[count].Cells[ColAdviser.Name].Value = zDataConverter.ToString(model.AdviserID);
                        xfDataGridView2.Rows[count].Cells[ColBirthdate.Name].Value = model.Birthdate;
                        xfDataGridView2.Rows[count].Cells[ColCourse.Name].Value = model.CourseID.ToString();
                        xfDataGridView2.Rows[count].Cells[ColProgress.Name].Value = model.Progress;
                        xfDataGridView2.Rows[count].Cells[ColStudentDescription.Name].Value = model.Description;
                        xfDataGridView2.Rows[count].Cells[ColStudentID.Name].ReadOnly = true;
                        xfDataGridView2.Rows[count].Cells[ColStudentCode.Name].ReadOnly = true;
                        xfDataGridView2.Rows[count].Cells[ColBirthdate.Name].ReadOnly = true;
                        xfDataGridView2.Rows[count].Cells[ColBirthday.Name].ReadOnly = true;
                        xfDataGridView2.Rows[count].Cells[ColCourse.Name].ReadOnly = true;
                        xfDataGridView2.Rows[count].Cells[ColProgress.Name].ReadOnly = true;
                    }
                }
                lstStudentInsert.Clear();
                lstStudentUpdate.Clear();
            }
            else
            {
                xfDataGridView2.Rows.Clear();
            }
        }

        /// <summary>
        /// 多行记录删除
        /// </summary>
        private void RowsDelete()
        {
            List<int> indexs = GetSelectedRowsIndex(xfDataGridView1);
            if (indexs.Count > 0)
            {
                string sIDs = string.Empty;
                string sID;
                //构建删除ID
                foreach (int i in indexs)
                {
                    sID = zDataConverter.ToString(xfDataGridView1.Rows[i].Cells[ColFamilyID.Name].Value);
                    if (sID.Length > 0)
                    {
                        sIDs += MessageText.KEY_COMMA + sID;
                    }
                }
                if (sIDs.Length > 0)
                {
                    //执行数据库删除
                    if (!bll.DeleteMultiple(sIDs.Substring(1)))
                    {
                        QQMessageBox.Show(
                        this,
                        MessageText.SQL_ERROR_FAMILY_DELETE,
                        MessageText.MESSAGEBOX_CAPTION_ERROR,
                        QQMessageBoxIcon.Error,
                        QQMessageBoxButtons.OK);
                        return;
                    }
                }
                BindData();
                QQMessageBox.Show(
                            this,
                            MessageText.TIP_SUCCESS_DELETE,
                            MessageText.MESSAGEBOX_CAPTION_TIP,
                            QQMessageBoxIcon.OK,
                            QQMessageBoxButtons.OK);
            }
            else
            {
                QQMessageBox.Show(
                            this,
                            MessageText.TIP_ERROR_SELECTCOUNT_NULL,
                            MessageText.MESSAGEBOX_CAPTION_TIP,
                            QQMessageBoxIcon.Information,
                            QQMessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 获取选中行索引
        /// </summary>
        /// <returns></returns>
        private List<int> GetSelectedRowsIndex(DataGridView dgv)
        {
            List<int> indexs = new List<int>();
            for (int i = 0; i < dgv.SelectedCells.Count; i++)
            {
                if (!indexs.Contains(dgv.SelectedCells[i].RowIndex))
                {
                    indexs.Add(dgv.SelectedCells[i].RowIndex);
                }
            }
            return indexs;
        }

        /// <summary>
        /// 行数据新增
        /// </summary>
        private void RowAdd()
        {
            int count = xfDataGridView1.RowCount;
            xfDataGridView1.Rows.Add();
            xfDataGridView1.Rows[count].Cells[ColFamilyCode.Name].ReadOnly = false;
            xfDataGridView1.Rows[count].Cells[ColFamilyName.Name].ReadOnly = false;
            xfDataGridView1.Rows[count].Cells[ColCourseCount.Name].ReadOnly = false;
            xfDataGridView1.Rows[count].Cells[ColDescription.Name].ReadOnly = false;
        }

        /// <summary>
        /// 数据保存
        /// </summary>
        private void SaveData()
        {
            string msg = string.Empty;
            xfDataGridView1.EndEdit();
            if (lstInsert.Count + lstUpdate.Count == 0)
            {
                BindData();
            }
            else
            {
                msg = CheckChangedInput();
                if (msg.Equals(string.Empty))
                {
                    msg += AddData();
                    msg += UpdateData();
                    if (msg.Equals(string.Empty))
                    {
                        QQMessageBox.Show(
                        this,
                        MessageText.TIP_SUCCESS_SAVE,
                        MessageText.MESSAGEBOX_CAPTION_TIP,
                        QQMessageBoxIcon.OK,
                        QQMessageBoxButtons.OK);
                        BindData();
                    }
                    else
                    {
                        QQMessageBox.Show(
                        this,
                        msg,
                        MessageText.MESSAGEBOX_CAPTION_ERROR,
                        QQMessageBoxIcon.Error,
                        QQMessageBoxButtons.OK);
                    }
                }
                else
                {
                    QQMessageBox.Show(
                        this,
                        msg,
                        MessageText.MESSAGEBOX_CAPTION_TIP,
                        QQMessageBoxIcon.Information,
                        QQMessageBoxButtons.OK);
                    return;
                }
            }
        }

        /// <summary>
        /// 新增家长数据
        /// </summary>
        /// <returns></returns>
        private string AddData()
        {
            string result = string.Empty;
            List<int> successRowIndex = new List<int>();
            XF.Model.Base_Family model;
            foreach (int index in lstInsert)
            {
                model = new XF.Model.Base_Family();
                model.FamilyCode = zDataConverter.ToString(xfDataGridView1.Rows[index].Cells[ColFamilyCode.Name].Value);
                model.FamilyName = zDataConverter.ToString(xfDataGridView1.Rows[index].Cells[ColFamilyName.Name].Value);
                model.CourseCount = zDataConverter.ToDecimal(xfDataGridView1.Rows[index].Cells[ColCourseCount.Name].Value);
                model.Phone = zDataConverter.ToString(xfDataGridView1.Rows[index].Cells[ColPhone.Name].Value);
                model.Description = zDataConverter.ToString(xfDataGridView1.Rows[index].Cells[ColDescription.Name].Value);
                int ret = bll.Add(model);
                if (ret == PhysicalConstants.SQL_Existed)
                {
                    result += string.Format(MessageText.SQL_ERROR_FAMILY_EXIST, index + 1) + MessageText.KEY_ENTER;
                }
                else
                {
                    xfDataGridView1.Rows[index].Cells[ColFamilyID.Name].Value = ret;
                    successRowIndex.Add(index);
                }
            }
            foreach (int rowIndex in successRowIndex)
            {
                lstInsert.Remove(rowIndex);
            }
            return result;
        }

        /// <summary>
        /// 更新家长数据
        /// </summary>
        /// <returns></returns>
        private string UpdateData()
        {
            string result = string.Empty;
            List<int> successRowIndex = new List<int>();
            XF.Model.Base_Family model;
            foreach (int index in lstUpdate)
            {
                model = new XF.Model.Base_Family();
                model.FamilyID = zDataConverter.ToInt(xfDataGridView1.Rows[index].Cells[ColFamilyID.Name].Value);
                model.FamilyCode = zDataConverter.ToString(xfDataGridView1.Rows[index].Cells[ColFamilyCode.Name].Value);
                model.FamilyName = zDataConverter.ToString(xfDataGridView1.Rows[index].Cells[ColFamilyName.Name].Value);
                model.CourseCount = zDataConverter.ToDecimal(xfDataGridView1.Rows[index].Cells[ColCourseCount.Name].Value);
                model.Phone = zDataConverter.ToString(xfDataGridView1.Rows[index].Cells[ColPhone.Name].Value);
                model.Description = zDataConverter.ToString(xfDataGridView1.Rows[index].Cells[ColDescription.Name].Value);
                if (bll.Update(model))
                {
                    successRowIndex.Add(index);
                }
                else
                {
                    result += MessageText.SQL_ERROR_UPDATE + MessageText.KEY_ENTER;
                }
            }
            foreach (int rowIndex in successRowIndex)
            {
                lstUpdate.Remove(rowIndex);
            }
            return result;
        }

        /// <summary>
        /// 校验家长新增和更改的数据
        /// </summary>
        /// <returns></returns>
        private string CheckChangedInput()
        {
            string checkResult = string.Empty;
            string result;
            foreach (int rowIndex in lstInsert)
            {
                result = CheckFamilyInput(rowIndex);
                if (!result.Equals(string.Empty))
                {
                    checkResult += result + MessageText.KEY_ENTER;
                }
            }
            foreach (int rowIndex in lstUpdate)
            {
                result = CheckFamilyInput(rowIndex);
                if (!result.Equals(string.Empty))
                {
                    checkResult += result + MessageText.KEY_ENTER;
                }
            }
            return checkResult;
        }

        /// <summary>
        /// 家长数据校验
        /// </summary>
        /// <returns>校验结果信息，为空表示校验通过</returns>
        private string CheckFamilyInput(int rowIndex)
        {
            decimal tempDecimal;
            if (zDataConverter.ToString(xfDataGridView1.Rows[rowIndex].Cells[ColFamilyCode.Name].Value).Equals(string.Empty))
            {
                return string.Format(MessageText.CHECK_ERROR_FAMILY_CODE, rowIndex + 1);
            }
            if (zDataConverter.ToString(xfDataGridView1.Rows[rowIndex].Cells[ColFamilyName.Name].Value).Equals(string.Empty))
            {
                return string.Format(MessageText.CHECK_ERROR_FAMILY_NAME, rowIndex + 1);
            }
            if (!decimal.TryParse(zDataConverter.ToString(xfDataGridView1.Rows[rowIndex].Cells[ColCourseCount.Name].Value).Trim(), out tempDecimal))
            {
                return string.Format(MessageText.CHECK_ERROR_FAMILY_COURSECOUNT, rowIndex + 1);
            }
            return string.Empty;
        }

        private void tsBtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void xfDataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //记录新增和修改行
            if (zDataConverter.ToString(xfDataGridView1.Rows[e.RowIndex].Cells[ColFamilyID.Name].Value).Equals(string.Empty))
            {
                if (!lstInsert.Contains(e.RowIndex))
                {
                    lstInsert.Add(e.RowIndex);
                }
            }
            else
            {
                if (!lstUpdate.Contains(e.RowIndex))
                {
                    lstUpdate.Add(e.RowIndex);
                }
            }
        }

        private void xfDataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SaveStudentChangedRowIndex(e.RowIndex);
        }

        private void SaveStudentChangedRowIndex(int rowIndex)
        {
            //记录新增和修改行
            if (zDataConverter.ToString(xfDataGridView2.Rows[rowIndex].Cells[ColStudentID.Name].Value).Equals(string.Empty))
            {
                if (!lstStudentInsert.Contains(rowIndex))
                {
                    lstStudentInsert.Add(rowIndex);
                }
            }
            else
            {
                if (!lstStudentUpdate.Contains(rowIndex))
                {
                    lstStudentUpdate.Add(rowIndex);
                }
            }
        }

        /// <summary>
        /// 学员数据校验
        /// </summary>
        /// <returns>校验结果信息，为空表示校验通过</returns>
        private string CheckStudentInput(int rowIndex)
        {
            DateTime tempDateTime;
            if (zDataConverter.ToString(xfDataGridView2.Rows[rowIndex].Cells[ColStudentCode.Name].Value).Equals(string.Empty))
            {
                return string.Format(MessageText.CHECK_ERROR_STUDENT_CODE, rowIndex + 1);
            }
            if (zDataConverter.ToString(xfDataGridView2.Rows[rowIndex].Cells[ColStudentName.Name].Value).Equals(string.Empty))
            {
                return string.Format(MessageText.CHECK_ERROR_STUDENT_NAME, rowIndex + 1);
            }
            if (zDataConverter.ToString(xfDataGridView2.Rows[rowIndex].Cells[ColNickName.Name].Value).Equals(string.Empty))
            {
                return string.Format(MessageText.CHECK_ERROR_STUDENT_NICKNAME, rowIndex + 1);
            }
            if (!DateTime.TryParse(zDataConverter.ToString(xfDataGridView2.Rows[rowIndex].Cells[ColBirthdate.Name].Value), out tempDateTime))
            {
                return string.Format(MessageText.CHECK_ERROR_STUDENT_BIRTHDATE, rowIndex + 1);
            }
            if (!DateTime.TryParse(zDataConverter.ToString(xfDataGridView2.Rows[rowIndex].Cells[ColBirthday.Name].Value), out tempDateTime))
            {
                return string.Format(MessageText.CHECK_ERROR_STUDENT_BIRTHDAY, rowIndex + 1);
            }
            return string.Empty;
        }

        /// <summary>
        /// 数据保存
        /// </summary>
        private void SaveStudentData()
        {
            string msg = string.Empty;
            xfDataGridView2.EndEdit();
            if (lstStudentInsert.Count + lstStudentUpdate.Count == 0)
            {
                BindStudentData();
            }
            else
            {
                msg = CheckStudentChangedInput();
                if (msg.Equals(string.Empty))
                {
                    msg += AddStudentData();
                    msg += UpdateStudentData();
                    if (msg.Equals(string.Empty))
                    {
                        QQMessageBox.Show(
                        this,
                        MessageText.TIP_SUCCESS_SAVE,
                        MessageText.MESSAGEBOX_CAPTION_TIP,
                        QQMessageBoxIcon.OK,
                        QQMessageBoxButtons.OK);
                        BindData();
                    }
                    else
                    {
                        QQMessageBox.Show(
                        this,
                        msg,
                        MessageText.MESSAGEBOX_CAPTION_ERROR,
                        QQMessageBoxIcon.Error,
                        QQMessageBoxButtons.OK);
                    }
                }
                else
                {
                    QQMessageBox.Show(
                        this,
                        msg,
                        MessageText.MESSAGEBOX_CAPTION_TIP,
                        QQMessageBoxIcon.Information,
                        QQMessageBoxButtons.OK);
                    return;
                }
            }
        }

        /// <summary>
        /// 校验学员新增和更改的数据
        /// </summary>
        /// <returns></returns>
        private string CheckStudentChangedInput()
        {
            string checkResult = string.Empty;
            string result;
            foreach (int rowIndex in lstStudentInsert)
            {
                result = CheckStudentInput(rowIndex);
                if (!result.Equals(string.Empty))
                {
                    checkResult += result + MessageText.KEY_ENTER;
                }
            }
            foreach (int rowIndex in lstStudentUpdate)
            {
                result = CheckStudentInput(rowIndex);
                if (!result.Equals(string.Empty))
                {
                    checkResult += result + MessageText.KEY_ENTER;
                }
            }
            return checkResult;
        }

        /// <summary>
        /// 新增学员数据
        /// </summary>
        /// <returns></returns>
        private string AddStudentData()
        {
            string result = string.Empty;
            List<int> successRowIndex = new List<int>();
            XF.Model.Base_Student model;
            int familyRowIndex = xfDataGridView1.CurrentCell.RowIndex;
            foreach (int index in lstStudentInsert)
            {
                model = new XF.Model.Base_Student();
                model.StudentCode = zDataConverter.ToString(xfDataGridView2.Rows[index].Cells[ColStudentCode.Name].Value);
                model.StudentName = zDataConverter.ToString(xfDataGridView2.Rows[index].Cells[ColStudentName.Name].Value);
                model.NickName = zDataConverter.ToString(xfDataGridView2.Rows[index].Cells[ColNickName.Name].Value);
                model.Birthday = Convert.ToDateTime(zDataConverter.ToString(xfDataGridView2.Rows[index].Cells[ColBirthday.Name].Value));
                model.TeacherID = zDataConverter.ToInt(xfDataGridView2.Rows[index].Cells[ColTeacher.Name].Value);
                model.AdviserID = zDataConverter.ToInt(xfDataGridView2.Rows[index].Cells[ColAdviser.Name].Value);
                model.Birthdate = Convert.ToDateTime(zDataConverter.ToString(xfDataGridView2.Rows[index].Cells[ColBirthdate.Name].Value)); ;
                model.Description = zDataConverter.ToString(xfDataGridView2.Rows[index].Cells[ColStudentDescription.Name].Value);
                model.FamilyID = zDataConverter.ToInt(xfDataGridView1.Rows[familyRowIndex].Cells[ColFamilyID.Name].Value);
                int ret = bllStudent.Add(model);
                if (ret == PhysicalConstants.SQL_Existed)
                {
                    result += string.Format(MessageText.SQL_ERROR_STUDENT_EXIST, index + 1) + MessageText.KEY_ENTER;
                }
                else
                {
                    xfDataGridView2.Rows[index].Cells[ColStudentID.Name].Value = ret;
                    successRowIndex.Add(index);
                }
            }
            foreach (int rowIndex in successRowIndex)
            {
                lstStudentInsert.Remove(rowIndex);
            }
            return result;
        }

        /// <summary>
        /// 更新学员数据
        /// </summary>
        /// <returns></returns>
        private string UpdateStudentData()
        {
            string result = string.Empty;
            List<int> successRowIndex = new List<int>();
            XF.Model.Base_Student model;
            int familyRowIndex = xfDataGridView1.CurrentCell.RowIndex;
            foreach (int index in lstStudentUpdate)
            {
                model = new XF.Model.Base_Student();
                model.StudentID = zDataConverter.ToInt(xfDataGridView2.Rows[index].Cells[ColStudentID.Name].Value);
                model.StudentCode = zDataConverter.ToString(xfDataGridView2.Rows[index].Cells[ColStudentCode.Name].Value);
                model.StudentName = zDataConverter.ToString(xfDataGridView2.Rows[index].Cells[ColStudentName.Name].Value);
                model.NickName = zDataConverter.ToString(xfDataGridView2.Rows[index].Cells[ColNickName.Name].Value);
                model.Birthday = Convert.ToDateTime(zDataConverter.ToString(xfDataGridView2.Rows[index].Cells[ColBirthday.Name].Value));
                model.TeacherID = zDataConverter.ToInt(xfDataGridView2.Rows[index].Cells[ColTeacher.Name].Value);
                model.AdviserID = zDataConverter.ToInt(xfDataGridView2.Rows[index].Cells[ColAdviser.Name].Value);
                model.Birthdate = Convert.ToDateTime(zDataConverter.ToString(xfDataGridView2.Rows[index].Cells[ColBirthdate.Name].Value)); ;
                model.Description = zDataConverter.ToString(xfDataGridView2.Rows[index].Cells[ColStudentDescription.Name].Value);
                model.FamilyID = zDataConverter.ToInt(xfDataGridView1.Rows[familyRowIndex].Cells[ColFamilyID.Name].Value);
                if (bllStudent.Update(model))
                {
                    successRowIndex.Add(index);
                }
                else
                {
                    result += MessageText.SQL_ERROR_UPDATE + MessageText.KEY_ENTER;
                }
            }
            foreach (int rowIndex in successRowIndex)
            {
                lstStudentUpdate.Remove(rowIndex);
            }
            return result;
        }

        private void xfDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /****************单元格被单击，判断是否是放时间控件的那一列*******************/
            if (e.ColumnIndex == ColBirthdate.Index)
            {
                _Rectangle = xfDataGridView2.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //得到所在单元格位置和大小
                dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height); //把单元格大小赋给时间控件
                dtp.Location = new Point(_Rectangle.X, _Rectangle.Y); //把单元格位置赋给时间控件
                DateTime dt;
                if (DateTime.TryParse(xfDataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out dt))
                {
                    dtp.Value = dt;
                }
                dtp.Visible = true;  //可以显示控件了
            }
            else
                dtp.Visible = false;
        }

        /*************时间控件选择时间时****************/
        private void dtp_TextChange(object sender, EventArgs e)
        {
            int year = chineseDate.GetYear(dtp.Value);
            int month = chineseDate.GetMonth(dtp.Value);
            if (month > 12)
            {
                month = 12;
            }
            int day = chineseDate.GetDayOfMonth(dtp.Value);

            DateTime dtChinese = new DateTime(year, month, day);
            xfDataGridView2.CurrentCell.Value = dtp.Value.ToString(MessageText.FORMAT_DATE);  //时间控件选择时间时，就把时间赋给所在的单元格
            xfDataGridView2.Rows[xfDataGridView2.CurrentCell.RowIndex].Cells[ColBirthday.Name].Value = dtChinese;
            SaveStudentChangedRowIndex(xfDataGridView2.CurrentCell.RowIndex);
        }

        private void xfDataGridView2_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
        }

        private void xfDataGridView2_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }

        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void xfDataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            BindStudentData();
        }

        private void xfDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColFamilyID.Index && xfDataGridView1.CurrentCell != null)
            {
                if (e.RowIndex == xfDataGridView1.CurrentCell.RowIndex)
                {
                    BindStudentData();
                }
            }
        }

        private void xfDataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == ColTeacher.Index)
            {
                xfDataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ColTeacher.DefaultCellStyle.NullValue;
            }
            else if (e.ColumnIndex == ColAdviser.Index)
            {
                xfDataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ColAdviser.DefaultCellStyle.NullValue;
            }
            else if (e.ColumnIndex == ColCourse.Index)
            {
                xfDataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ColCourse.DefaultCellStyle.NullValue;
            }
        }
    }
}
