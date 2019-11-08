using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Enums;
using XF.Common;
using XF.ExControls;

namespace BabySwim
{
    public partial class FrmCustomerList : Form
    {
        CheckBox ckbCreate = new CheckBox();
        CheckBox ckbUpdate = new CheckBox();
        DateTimePicker dtpCreateStart = new DateTimePicker();
        DateTimePicker dtpCreateEnd = new DateTimePicker();
        DateTimePicker dtpUpdateStart = new DateTimePicker();
        DateTimePicker dtpUpdateEnd = new DateTimePicker();
        XF.BLL.Base_Customer bll = new XF.BLL.Base_Customer();
        public FrmCustomerList()
        {
            InitializeComponent();
            dtpCreateStart.Width = dtpCreateEnd.Width = dtpUpdateStart.Width = dtpUpdateEnd.Width = 120;
            ToolStripControlHost item = new ToolStripControlHost(dtpUpdateEnd);
            //增加欠缺的菜单栏项目
            toolStrip1.Items.Insert(10,item);
            item = new ToolStripControlHost(dtpUpdateStart);
            toolStrip1.Items.Insert(9, item);
            item = new ToolStripControlHost(ckbUpdate);
            toolStrip1.Items.Insert(8, item);
            item = new ToolStripControlHost(dtpCreateEnd);
            toolStrip1.Items.Insert(7, item);
            item = new ToolStripControlHost(dtpCreateStart);
            toolStrip1.Items.Insert(6, item);
            item = new ToolStripControlHost(ckbCreate);
            toolStrip1.Items.Insert(5, item);
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

        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            BindProperty();
            BindData();
        }

        /// <summary>
        /// 绑定单元格数据项
        /// </summary>
        private void BindProperty()
        {
            ColVisitInfo.DisplayMember = MessageText.LISTITEM_TEXT;
            ColVisitInfo.ValueMember = MessageText.LISTITEM_VALUE;
            ColVisitInfo.DataSource = GenerateData.GetYesNo();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void BindData()
        {
            int sum = 0;
            string strWhere = string.Empty;
            if (ckbCreate.Checked)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, string.Format(" CreateDate Between '{0}' and '{1}'", dtpCreateStart.Value.ToString(MessageText.FORMAT_DATE), dtpCreateEnd.Value.AddDays(1).ToString(MessageText.FORMAT_DATE)));
            }
            if (ckbUpdate.Checked)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, string.Format(" LastUpdateDate Between '{0}' and '{1}'", dtpUpdateStart.Value.ToString(MessageText.FORMAT_DATE), dtpUpdateEnd.Value.AddDays(1).ToString(MessageText.FORMAT_DATE)));
            }
            if (!tsTbInfoSource.Text.Equals(string.Empty))
            {
                strWhere = zDataConverter.AppendSQL(strWhere, string.Format(" InfoSource like '%{0}%'", tsTbInfoSource.Text));
            }
            if (!tsTbFollowInfo.Text.Equals(string.Empty))
            {
                strWhere = zDataConverter.AppendSQL(strWhere, string.Format(" FollowInfo like '%{0}%'", tsTbFollowInfo.Text));
            }
            if (!tsTbFollowUser.Text.Equals(string.Empty))
            {
                strWhere = zDataConverter.AppendSQL(strWhere, string.Format(" FollowUser like '%{0}%'", tsTbFollowUser.Text));
            }
            List<XF.Model.Base_Customer> models = bll.GetModelListByPage(strWhere, " StudentCode Asc ", pagerControl1.PageIndex, pagerControl1.PageSize, ref sum);
            pagerControl1.DrawControl(sum);
            dataGridView1.Rows.Clear();
            foreach (XF.Model.Base_Customer model in models)
            {
                int count = dataGridView1.Rows.Count;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[count].Cells[ColID.Name].Value = model.CustomerID;
                dataGridView1.Rows[count].Cells[ColCode.Name].Value = model.CustomerCode;
                dataGridView1.Rows[count].Cells[ColName.Name].Value = model.CustomerName;
                dataGridView1.Rows[count].Cells[ColPhone.Name].Value = model.Phone;
                dataGridView1.Rows[count].Cells[ColAge.Name].Value = model.Age;
                dataGridView1.Rows[count].Cells[ColBirthday.Name].Value = model.Birthday;
                dataGridView1.Rows[count].Cells[ColCoursePrice.Name].Value = model.CoursePrice;
                dataGridView1.Rows[count].Cells[ColInfoSource.Name].Value = model.InfoSource;
                dataGridView1.Rows[count].Cells[ColFollowInfo.Name].Value = model.FollowInfo;
                dataGridView1.Rows[count].Cells[ColFollowUser.Name].Value = model.FollowUser;
                dataGridView1.Rows[count].Cells[ColVisitInfo.Name].Value = model.IsVisit;
                dataGridView1.Rows[count].Cells[ColVisitDate.Name].Value = model.VisitDate;
                dataGridView1.Rows[count].Cells[ColDescription.Name].Value = model.Description;
            }
        }

        private void tsBtnSearch_Click(object sender, EventArgs e)
        {
            BindData();
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
                    sID = zDataConverter.ToString(dataGridView1.Rows[i].Cells[ColID.Name].Value);
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
                        MessageText.SQL_ERROR_CUSTOMER_DELETE,
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
                    dataGridView1.Rows.RemoveAt(indexs[i]);
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
        /// 获取选中行索引
        /// </summary>
        /// <returns></returns>
        private List<int> GetSelectedRowsIndex()
        {
            List<int> indexs = new List<int>();
            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
            {
                if (!indexs.Contains(dataGridView1.SelectedCells[i].RowIndex))
                {
                    indexs.Add(dataGridView1.SelectedCells[i].RowIndex);
                }
            }
            return indexs;
        }

        private void tsBtnLook_Click(object sender, EventArgs e)
        {
            RowLook();
        }

        /// <summary>
        /// 行数据查看
        /// </summary>
        private void RowLook()
        {
            if (dataGridView1.SelectedCells.Count == 1 || dataGridView1.SelectedRows.Count == 1)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                int id = PhysicalConstants.ERROR_ID;
                try
                {
                    id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[ColID.Name].Value);
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
                FrmCustomerCard frmCustomerCard = new FrmCustomerCard();
                frmCustomerCard.Model = bll.GetModel(id);
                frmCustomerCard.Status = CardEnum.LOOK;
                frmCustomerCard.ShowDialog();
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
            FrmCustomerCard frmCustomerCard = new FrmCustomerCard();
            frmCustomerCard.Status = CardEnum.ADD;
            frmCustomerCard.ShowDialog();
            if (frmCustomerCard.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                int ret = bll.Add(frmCustomerCard.Model);
                if (ret == PhysicalConstants.SQL_Existed)
                {
                    QQMessageBox.Show(
                            this,
                            string.Format(MessageText.SQL_ERROR_CUSTOMER_ADD, frmCustomerCard.Model.CustomerName),
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
                FrmCustomerCard frmCustomerCard = new FrmCustomerCard();
                frmCustomerCard.Model = bll.GetModel(id);
                frmCustomerCard.Status = CardEnum.UPDATE;
                frmCustomerCard.ShowDialog();
                if (frmCustomerCard.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    if (bll.Update(frmCustomerCard.Model))
                    {
                        BindData();
                    }
                    else
                    {
                        QQMessageBox.Show(
                            this,
                            string.Format(MessageText.SQL_ERROR_CUSTOMER_UPDATE, frmCustomerCard.Model.CustomerName),
                            MessageText.MESSAGEBOX_CAPTION_WARN,
                            QQMessageBoxIcon.Warning,
                            QQMessageBoxButtons.OK);
                    }
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
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                int id = PhysicalConstants.ERROR_ID;
                try
                {
                    id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[ColID.Name].Value);
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

        private void tsBtnImport_Click(object sender, EventArgs e)
        {

            FrmImportCustomer frmImportCustomer = new FrmImportCustomer();
            frmImportCustomer.ShowDialog();
            if (frmImportCustomer.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                BindData();
            }
        }

        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
