using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XF.Common;
using Enums;
using XF.ExControls;
using System.Data;

namespace BabySwim
{
    public partial class FrmTeacherList : Form
    {
        XF.BLL.Base_Teacher bll = new XF.BLL.Base_Teacher();
        DataTable dtType = GenerateData.GetTeacherType(false);
        DataTable dtTeacherJob = GenerateData.GetTeacherJob(false);
        DataTable dtAdviserJob = GenerateData.GetAdviserJob(false);
        DataTable dtJobLevel = GenerateData.GetTeacherJobLevel(false);
        private static FrmTeacherCard GetFrmTeacherCard()
        {
            FrmTeacherCard frmTeacherCard = new FrmTeacherCard();
            return frmTeacherCard;
        }
        public FrmTeacherList()
        {
            InitializeComponent();
        }

        private void tsBtnAdd_Click(object sender, EventArgs e)
        {
            RowAdd();
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            RowsDelete();
        }

        private void tsBtnUpdate_Click(object sender, EventArgs e)
        {
            RowUpdate();
        }

        private void tsBtnLook_Click(object sender, EventArgs e)
        {
            RowLook();
        }

        private void tsBtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void FrmTeacherList_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            
            BindData();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void BindData()
        {
            string strWhere = string.Empty;
            if (!tsTbTeacher.Text.Equals(string.Empty))
            {
                strWhere += string.Format(" ( TeacherCode like '%{0}%' or TeacherName like '%{1}%') ", tsTbTeacher.Text, tsTbTeacher.Text);
            }
            List<XF.Model.Base_Teacher> models = bll.GetModelList(strWhere);
            xfDataGridView1.Rows.Clear();
            foreach (XF.Model.Base_Teacher model in models)
            {
                int count = xfDataGridView1.Rows.Count;
                xfDataGridView1.Rows.Add();
                xfDataGridView1.Rows[count].Cells[ColID.Name].Value = model.TeacherID;
                xfDataGridView1.Rows[count].Cells[ColCode.Name].Value = model.TeacherCode;
                xfDataGridView1.Rows[count].Cells[ColName.Name].Value = model.TeacherName;
                xfDataGridView1.Rows[count].Cells[ColAge.Name].Value = model.Age;
                xfDataGridView1.Rows[count].Cells[ColSintroduction.Name].Value = model.Sintroduction;
                xfDataGridView1.Rows[count].Cells[ColTeacherType.Name].Value = dtType.Rows[model.TeacherType][MessageText.LISTITEM_TEXT];
                if (model.TeacherType == 0)
                {
                    xfDataGridView1.Rows[count].Cells[ColJob.Name].Value = dtTeacherJob.Rows[model.Job][MessageText.LISTITEM_TEXT];
                }
                else
                {
                    xfDataGridView1.Rows[count].Cells[ColJob.Name].Value = dtAdviserJob.Rows[model.Job][MessageText.LISTITEM_TEXT];
                }
                xfDataGridView1.Rows[count].Cells[ColJobLevel.Name].Value = dtJobLevel.Rows[model.JobLevel][MessageText.LISTITEM_TEXT];
            }
        }

        /// <summary>
        /// 行数据查看
        /// </summary>
        private void RowLook()
        {
            if (xfDataGridView1.SelectedCells.Count == 1 || xfDataGridView1.SelectedRows.Count == 1)
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
                    return;
                }
                FrmTeacherCard frmTeacherCard = GetFrmTeacherCard();
                frmTeacherCard.Model = bll.GetModel(id);
                frmTeacherCard.Status = CardEnum.LOOK;
                frmTeacherCard.ShowDialog();
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

        /// <summary>
        /// 行数据增加
        /// </summary>
        private void RowAdd()
        {
            FrmTeacherCard frmTeacherCard = GetFrmTeacherCard();
            frmTeacherCard.Status = CardEnum.ADD;
            frmTeacherCard.ShowDialog();
            if (frmTeacherCard.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                int ret = bll.Add(frmTeacherCard.Model);
                if (ret == PhysicalConstants.SQL_Existed)
                {
                    QQMessageBox.Show(
                            this,
                            string.Format(MessageText.SQL_ERROR_TEACHER_ADD, frmTeacherCard.Model.TeacherCode),
                            MessageText.MESSAGEBOX_CAPTION_TIP,
                            QQMessageBoxIcon.Information,
                            QQMessageBoxButtons.OK);
                }
                else
                {
                    BindData();
                }
            }
        }

        /// <summary>
        /// 行数据更改
        /// </summary>
        private void RowUpdate()
        {
            int id = GetModelID();
            if (id >= 0)
            {
                FrmTeacherCard frmTeacherCard = GetFrmTeacherCard();
                frmTeacherCard.Model = bll.GetModel(id);
                frmTeacherCard.Status = CardEnum.UPDATE;
                frmTeacherCard.ShowDialog();
                if (frmTeacherCard.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    if (bll.Update(frmTeacherCard.Model))
                    {
                        BindData();
                    }
                    else
                    {
                        QQMessageBox.Show(
                            this,
                            string.Format(MessageText.SQL_ERROR_TEACHER_UPDATE, frmTeacherCard.Model.TeacherCode),
                            MessageText.MESSAGEBOX_CAPTION_WARN,
                            QQMessageBoxIcon.Warning,
                            QQMessageBoxButtons.OK);
                    }
                }
            }
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
                        MessageText.SQL_ERROR_TEACHER_DELETE,
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
