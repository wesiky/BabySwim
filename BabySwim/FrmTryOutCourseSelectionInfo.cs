using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XF.ExControls;
using Enums;
using XF.Common;
using System.Drawing;

namespace BabySwim
{
    public partial class FrmTryOutCourseSelectionInfo : XFFormEx
    {
        private XF.BLL.Base_Course bllCourse = new XF.BLL.Base_Course();
        private XF.Model.Course_Selection model;
        private CardEnum status = CardEnum.LOOK;

        public CardEnum Status
        {
            get { return status; }
            set
            {
                status = value;
                SetControlStatus();
            }
        }

        public XF.Model.Course_Selection Model
        {
            get { return model; }
            set
            {
                model = value;
                LoadFormData();
            }
        }
        public FrmTryOutCourseSelectionInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置界面控件状态
        /// </summary>
        private void SetControlStatus()
        {
            switch (status)
            {
                case CardEnum.LOOK:
                    tsBtnSave.Enabled = false;
                    tsBtnCloseCourse.Enabled = false;
                    tsBtnAdd.Enabled = false;
                    tsBtnDelete.Enabled = false;
                    break;
                case CardEnum.ADD:
                    tsBtnSave.Enabled = true;
                    tsBtnCloseCourse.Enabled = false;
                    tsBtnAdd.Enabled = true;
                    tsBtnDelete.Enabled = true;
                    break;
                case CardEnum.UPDATE:
                    tsBtnSave.Enabled = true;
                    tsBtnCloseCourse.Enabled = true;
                    tsBtnAdd.Enabled = true;
                    tsBtnDelete.Enabled = true;
                    break;
                default:
                    break;
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
                    tbTeacher.Text = string.Format("{0}-{1}", model.TeacherCode, model.TeacherName);
                    tbAdviser.Text = string.Format("{0}-{1}", model.AdviserCode, model.AdviserName);
                    BindStudentData(model.SelectionStudents);
                }
            }
        }

        private void BindStudentData(List<XF.Model.Course_SelectionStudent> models)
        {
            xfDataGridView1.Rows.Clear();
            foreach (XF.Model.Course_SelectionStudent model in models)
            {
                int count = xfDataGridView1.Rows.Count;
                xfDataGridView1.Rows.Add();
                xfDataGridView1.Rows[count].Cells[ColID.Name].Value = model.SelectionStudentID;
                xfDataGridView1.Rows[count].Cells[ColStudentID.Name].Value = model.StudentID;
                xfDataGridView1.Rows[count].Cells[ColStudentCode.Name].Value = model.StudentCode;
                xfDataGridView1.Rows[count].Cells[ColName.Name].Value = model.StudentName;
            }
        }

        /// <summary>
        /// 设置Model数据
        /// </summary>
        private void SetModelData()
        {
            if (model == null)
            {
                model = new XF.Model.Course_Selection();
            }
            model.CourseID = zDataConverter.ToInt(ConfigSetting.TryOutCourseID);
            model.SectionNO = zDataConverter.ToInt(tbSectionNO.Text);
            model.SelectionStudents.Clear();
            foreach (DataGridViewRow dgvr in xfDataGridView1.Rows)
            {
                if (!zDataConverter.ToString(dgvr.Cells[ColStudentID.Name].Value).Equals(string.Empty))
                {
                    XF.Model.Course_SelectionStudent student = new XF.Model.Course_SelectionStudent(); 
                    student.SelectionID = model.SelectionID;
                    student.StudentID = zDataConverter.ToInt(dgvr.Cells[ColStudentID.Name].Value);
                    model.SelectionStudents.Add(student);
                }
            }
        }

        /// <summary>
        /// 数据校验
        /// </summary>
        /// <returns>校验结果信息，为空表示校验通过</returns>
        private string CheckInput()
        {
            int sectionNO;
            if (tbTeacher.Text.Trim().Equals(string.Empty))
            {
                return MessageText.CHECK_ERROR_SELECTION_TEACHER;
            }
            if (tbAdviser.Text.Trim().Equals(string.Empty))
            {
                return MessageText.CHECK_ERROR_SELECTION_ADVISER;
            }
            if (!int.TryParse(tbSectionNO.Text.Trim(), out sectionNO))
            {
                return MessageText.CHECK_ERROR_SELECTION_SECTIONNO;
            }
            return string.Empty;
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            string msg = CheckInput();
            if (msg.Equals(string.Empty))
            {
                SetModelData();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                QQMessageBox.Show(
                this,
                msg,
                MessageText.MESSAGEBOX_CAPTION_TIP,
                QQMessageBoxIcon.Information,
                QQMessageBoxButtons.OK);
            }
        }

        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnCloseCourse_Click(object sender, EventArgs e)
        {
            if (QQMessageBox.Show(this, "确定关闭课程吗？", MessageText.MESSAGEBOX_CAPTION_WARN, QQMessageBoxIcon.Warning, QQMessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.No;
                this.Close();
            }
            
        }

        private void tsBtnAdd_Click(object sender, EventArgs e)
        {
            RowsAdd();
        }

        /// <summary>
        /// 新增记录
        /// </summary>
        private void RowsAdd()
        {
            int count = xfDataGridView1.RowCount;
            xfDataGridView1.Rows.Add();
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            RowsDelete();
        }

        /// <summary>
        /// 多行记录删除
        /// </summary>
        private void RowsDelete()
        {
            List<int> indexs = GetSelectedRowsIndex();
            if (indexs.Count > 0)
            {
                //由下向上移除行
                indexs.Sort();
                for (int i = indexs.Count - 1; i >= 0; i--)
                {
                    xfDataGridView1.Rows.RemoveAt(indexs[i]);
                }
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

        private void tbTeacher_Click(object sender, EventArgs e)
        {
            if (status != CardEnum.LOOK)
            {
                FrmDialogTeacher frmDialogTeacher = new FrmDialogTeacher();
                if (frmDialogTeacher.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    model.TeacherID = frmDialogTeacher.TeacherID;
                    tbTeacher.Text = string.Format("{0}-{1}", frmDialogTeacher.TeacherCode, frmDialogTeacher.TeacherName);
                }
            }
        }

        private void xfDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == ColName.Index || e.ColumnIndex == ColStudentCode.Index)
                {
                    FrmDialogCustomer frmDialogCustomer = new FrmDialogCustomer();
                    if (frmDialogCustomer.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        xfDataGridView1.Rows[e.RowIndex].Cells[ColStudentID.Name].Value = frmDialogCustomer.StudentID;
                        xfDataGridView1.Rows[e.RowIndex].Cells[ColStudentCode.Name].Value = frmDialogCustomer.StudentCode;
                        xfDataGridView1.Rows[e.RowIndex].Cells[ColName.Name].Value = frmDialogCustomer.StudentName;
                    }
                }
            }
        }

        private void FrmCourseSelectionInfo_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            this.TextForeColor = ConfigSetting.TextForeColor;
            tbCourse.Text = model.CourseName;
        }

        private void tbAdviser_Click(object sender, EventArgs e)
        {
            if (status != CardEnum.LOOK)
            {
                FrmDialogAdviser frmDialogAdviser = new FrmDialogAdviser();
                if (frmDialogAdviser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    model.AdviserID = frmDialogAdviser.TeacherID;
                    tbAdviser.Text = string.Format("{0}-{1}", frmDialogAdviser.TeacherCode, frmDialogAdviser.TeacherName);
                }
            }
        }
    }
}
