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
    public partial class FrmConfirmedStudentList : XFFormEx
    {
        XF.BLL.Course_ConfirmedStudent bll = new XF.BLL.Course_ConfirmedStudent();
        public FrmConfirmedStudentList()
        {
            InitializeComponent();
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
                string sIDs = string.Empty;
                string sID;
                //构建删除ID
                foreach (int i in indexs)
                {
                    sID = zDataConverter.ToString(xfDataGridView1.Rows[i].Cells[ColConfirmedID.Name].Value);
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
                        MessageText.SQL_ERROR_CONFIRMEDSTUDENT_DELETE,
                        MessageText.MESSAGEBOX_CAPTION_ERROR,
                        QQMessageBoxIcon.Error,
                        QQMessageBoxButtons.OK);
                        return;
                    }
                }
                //由下向上移除行
                indexs.Sort();
                for (int i = indexs.Count - 1; i >= 0; i--)
                {
                    xfDataGridView1.Rows.RemoveAt(indexs[i]);
                }
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

        private void FrmCourseEvaluateSearch_Load(object sender, EventArgs e)
        {
            this.TextForeColor = ConfigSetting.TextForeColor;
            this.Icon = ConfigSetting.ProjectIcon;
            BindData();

        }

        private void BindData()
        {
            string strWhere = string.Empty;
            List<XF.Model.Course_ConfirmedStudent> models = bll.GetModelDetailList(strWhere);
            xfDataGridView1.Rows.Clear();
            foreach (XF.Model.Course_ConfirmedStudent model in models)
            {
                int count = xfDataGridView1.Rows.Count;
                xfDataGridView1.Rows.Add();
                xfDataGridView1.Rows[count].Cells[ColConfirmedID.Name].Value = model.ConfirmedID;
                xfDataGridView1.Rows[count].Cells[ColStudentName.Name].Value = model.StudentName;
                xfDataGridView1.Rows[count].Cells[ColNickName.Name].Value = model.NickName;
                xfDataGridView1.Rows[count].Cells[ColFamilyID.Name].Value = model.FamilyID;
                xfDataGridView1.Rows[count].Cells[ColFamilyCode.Name].Value = model.FamilyCode;
                xfDataGridView1.Rows[count].Cells[ColFamilyName.Name].Value = model.FamilyName;
                xfDataGridView1.Rows[count].Cells[ColDayOfWeek.Name].Value = PhysicalConstants.DAY_OF_WEEK_CHN[model.DayOfWeek];
                xfDataGridView1.Rows[count].Cells[ColClassRoom.Name].Value = "教室" + MessageText.LIST_NUMBER_CHINESE[model.ClassRoomID];
                xfDataGridView1.Rows[count].Cells[ColLessonNO.Name].Value = model.LessonNO;
                xfDataGridView1.Rows[count].Cells[ColCourseName.Name].Value = model.CourseName;
                xfDataGridView1.Rows[count].Cells[ColTeacher.Name].Value = model.TeacherCode + "-" + model.TeacherName;
                xfDataGridView1.Rows[count].Cells[ColDescription.Name].Value = model.Description;
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
                    id = Convert.ToInt32(xfDataGridView1.Rows[rowIndex].Cells[ColConfirmedID.Name].Value);
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
