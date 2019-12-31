using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XF.ExControls;
using XF.Common;
using Enums;

namespace BabySwim
{
    public partial class FrmCourseList : Form
    {
        XF.BLL.Base_Course bll = new XF.BLL.Base_Course();
        List<int> lstInsert = new List<int>();
        List<int> lstUpdate = new List<int>();
        ColorDialog cd = new ColorDialog();//这里实例化一个ColorDialog控件 

        public FrmCourseList()
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

        private void xfDataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SaveChangedRowIndex(e.RowIndex);
        }

        private void SaveChangedRowIndex(int rowIndex)
        {
            //记录新增和修改行
            if (zDataConverter.ToString(xfDataGridView1.Rows[rowIndex].Cells[ColID.Name].Value).Equals(string.Empty))
            {
                if (!lstInsert.Contains(rowIndex))
                {
                    lstInsert.Add(rowIndex);
                }
            }
            else
            {
                if (!lstUpdate.Contains(rowIndex))
                {
                    lstUpdate.Add(rowIndex);
                }
            }
        }

        private void FrmCourseList_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            BindData();
        }

        /// <summary>
        /// 行数据新增
        /// </summary>
        private void RowAdd()
        {
            xfDataGridView1.Rows.Add();
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
        /// 新增数据
        /// </summary>
        /// <returns></returns>
        private string AddData()
        {
            string result = string.Empty;
            List<int> successRowIndex = new List<int>();
            XF.Model.BaseCourse model;
            foreach (int index in lstInsert)
            {
                model = new XF.Model.BaseCourse();
                model.CourseName = zDataConverter.ToString(xfDataGridView1.Rows[index].Cells[ColName.Name].Value);
                model.MaxCount = zDataConverter.ToInt(xfDataGridView1.Rows[index].Cells[ColMaxCount.Name].Value);
                model.MaxSection = zDataConverter.ToInt(xfDataGridView1.Rows[index].Cells[ColMaxSection.Name].Value);
                model.Color = zDataConverter.ToString(xfDataGridView1.Rows[index].Cells[ColColor.Name].Value);
                model.Description = zDataConverter.ToString(xfDataGridView1.Rows[index].Cells[ColDescription.Name].Value);
                int ret = bll.Add(model);
                if (ret == PhysicalConstants.SQL_Existed)
                {
                    result += string.Format(MessageText.SQL_ERROR_COURSE_EXIST,index+1) + MessageText.KEY_ENTER;
                }
                else
                {
                    xfDataGridView1.Rows[index].Cells[ColID.Name].Value = ret;
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
        /// 更新数据
        /// </summary>
        /// <returns></returns>
        private string UpdateData()
        {
            string result = string.Empty;
            List<int> successRowIndex = new List<int>();
            XF.Model.BaseCourse model;
            foreach (int index in lstUpdate)
            {
                model = new XF.Model.BaseCourse();
                model.CourseID = zDataConverter.ToInt(xfDataGridView1.Rows[index].Cells[ColID.Name].Value);
                model.CourseName = zDataConverter.ToString(xfDataGridView1.Rows[index].Cells[ColName.Name].Value);
                model.MaxCount = zDataConverter.ToInt(xfDataGridView1.Rows[index].Cells[ColMaxCount.Name].Value);
                model.MaxSection = zDataConverter.ToInt(xfDataGridView1.Rows[index].Cells[ColMaxSection.Name].Value);
                model.Color =zDataConverter.ToString(xfDataGridView1.Rows[index].Cells[ColColor.Name].Value);
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
                    sID = zDataConverter.ToString(xfDataGridView1.Rows[i].Cells[ColID.Name].Value);
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
                        MessageText.SQL_ERROR_COURSE_DELETE,
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

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void BindData()
        {
            string strWhere = string.Empty;
            List<XF.Model.BaseCourse> models = bll.GetModelList(strWhere);
            xfDataGridView1.Rows.Clear();
            foreach (XF.Model.BaseCourse model in models)
            {
                int count = xfDataGridView1.Rows.Count;
                xfDataGridView1.Rows.Add();
                xfDataGridView1.Rows[count].Cells[ColID.Name].Value = model.CourseID;
                xfDataGridView1.Rows[count].Cells[ColName.Name].Value = model.CourseName;
                xfDataGridView1.Rows[count].Cells[ColMaxCount.Name].Value = model.MaxCount;
                xfDataGridView1.Rows[count].Cells[ColMaxSection.Name].Value = model.MaxSection;
                if (!model.Color.Equals(string.Empty))
                {
                    xfDataGridView1.Rows[count].Cells[ColColor.Name].Value = model.Color;
                    xfDataGridView1.Rows[count].DefaultCellStyle.BackColor = ColorTranslator.FromHtml(model.Color);
                }
                xfDataGridView1.Rows[count].Cells[ColDescription.Name].Value = model.Description;
            }
            lstInsert.Clear();
            lstUpdate.Clear();
        }

        /// <summary>
        /// 校验新增和更改的数据
        /// </summary>
        /// <returns></returns>
        private string CheckChangedInput()
        {
            string checkResult = string.Empty;
            string result;
            foreach (int rowIndex in lstInsert)
            {
                result = CheckInput(rowIndex);
                if (!result.Equals(string.Empty))
                {
                    checkResult += result + MessageText.KEY_ENTER;
                }
            }
            foreach (int rowIndex in lstUpdate)
            {
                result = CheckInput(rowIndex);
                if (!result.Equals(string.Empty))
                {
                    checkResult += result + MessageText.KEY_ENTER;
                }
            }
            return checkResult;
        }

        /// <summary>
        /// 数据校验
        /// </summary>
        /// <returns>校验结果信息，为空表示校验通过</returns>
        private string CheckInput(int rowIndex)
        {
            int tempInt;
            if (zDataConverter.ToString(xfDataGridView1.Rows[rowIndex].Cells[ColName.Name].Value).Equals(string.Empty))
            {
                return string.Format(MessageText.CHECK_ERROR_COUTSE_NAME, rowIndex+1);
            }
            if (!int.TryParse(zDataConverter.ToString(xfDataGridView1.Rows[rowIndex].Cells[ColMaxCount.Name].Value).Trim(), out tempInt))
            {
                return string.Format(MessageText.CHECK_ERROR_COUTSE_MAXCOUNT, rowIndex+1);
            }
            if (!int.TryParse(zDataConverter.ToString(xfDataGridView1.Rows[rowIndex].Cells[ColMaxSection.Name].Value).Trim(), out tempInt))
            {
                return string.Format(MessageText.CHECK_ERROR_COUTSE_MAXSECTION, rowIndex+1);
            }
            return string.Empty;
        }

        private void tsBtnRefresh_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void xfDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /****************单元格被单击，判断是否是放时间控件的那一列*******************/
            if (e.ColumnIndex == ColColor.Index)
            {
                if (cd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    xfDataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = cd.Color;
                    xfDataGridView1.Rows[e.RowIndex].Cells[ColColor.Name].Value = ColorTranslator.ToHtml(cd.Color);
                    SaveChangedRowIndex(e.RowIndex);
                }
            }
        }
    }
}
