using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XF.Common;
using System.Collections;
using XF.BLL;
using Enums;

namespace XF.BaseFunction
{
    public partial class FrmConfigList : Form
    {
        XF.BLL.XF_Configuration bll = new XF.BLL.XF_Configuration();
        List<int> lstInsert = new List<int>();
        List<int> lstUpdate = new List<int>();

        public FrmConfigList()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            pagerControl1.OnPageChanged += pagerControl1_OnPageChanged;
        }


        /// <summary>
        /// 数据绑定
        /// </summary>
        public void BindData()
        {
            int count = 0;
            string strWhere = "";
            if (!tsTbItemName.Text.Trim().Equals(string.Empty))
            {
                strWhere += " and ItemName like '%" + tsTbItemName.Text.Trim() + "%'";
            }
            DataTable dt = bll.GetItemListByPage(strWhere, " ItemName Asc ", pagerControl1.PageIndex, pagerControl1.PageSize, ref count);
            dataGridView1.Rows.Clear();
            for(int i =0;i<dt.Rows.Count;i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[ColID.Name].Value = dt.Rows[i]["ItemID"].ToString();
                dataGridView1.Rows[i].Cells[ColItemName.Name].Value = dt.Rows[i]["ItemName"].ToString();
                dataGridView1.Rows[i].Cells[ColValue.Name].Value = dt.Rows[i]["ItemValue"].ToString();
                dataGridView1.Rows[i].Cells[ColDescription.Name].Value = dt.Rows[i]["ItemDescription"].ToString();
                dataGridView1.Rows[i].Cells[ColCreateDate.Name].Value = dt.Rows[i]["CreateDate"].ToString();
                dataGridView1.Rows[i].Cells[ColCreateUser.Name].Value = dt.Rows[i]["CreateUser"].ToString();
                dataGridView1.Rows[i].Cells[ColLastUpdateDate.Name].Value = dt.Rows[i]["LastUpdateDate"].ToString();
                dataGridView1.Rows[i].Cells[ColLastUpdateUser.Name].Value = dt.Rows[i]["LastUpdateUser"].ToString();
                dataGridView1.Rows[i].Cells[ColItemName.Name].ReadOnly = true;
                dataGridView1.Rows[i].Cells[ColCreateDate.Name].ReadOnly = true;
                dataGridView1.Rows[i].Cells[ColCreateUser.Name].ReadOnly = true;
                dataGridView1.Rows[i].Cells[ColLastUpdateDate.Name].ReadOnly = true;
                dataGridView1.Rows[i].Cells[ColLastUpdateUser.Name].ReadOnly = true;
            }
            pagerControl1.DrawControl(count);
            lstInsert.Clear();
            lstUpdate.Clear();
        }

        private void FrmConfigList_Load(object sender, EventArgs e)
        {

            LoginHandler.InitModule("admin_ConfigPage");
            if (LoginHandler.ValidationHandle(XF_Tag.Browse))//是否有浏览权限
            {
                Logger.Info(LoginInfo.LoginName + "浏览admin_ConfigPage页面");
                this.Icon = ConfigSetting.ProjectIcon;
                BindData();
            }
            else
            {
                MessageBox.Show("您没有对应的权限！");
                this.Close();
            }
            if (!LoginHandler.ValidationHandle(XF_Tag.Add))//是否有浏览权限
            {
                tsBtnAdd.Visible = false;
            }
            if (!LoginHandler.ValidationHandle(XF_Tag.Add) && !LoginHandler.ValidationHandle(XF_Tag.Edit))
            {
                tsBtnSave.Visible = false;
            }
            if (!LoginHandler.ValidationHandle(XF_Tag.Delete))//是否有浏览权限
            {
                tsBtnDelete.Visible = false;
            }
            if (!LoginHandler.ValidationHandle(XF_Tag.Search))//是否有浏览权限
            {
                toolStripSeparator1.Visible = false;
                toolStripLabel1.Visible = false;
                tsTbItemName.Visible = false;
                tsBtnQuery.Visible = false;
            }
        }

        private void tsBtnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            string IDs = "";
            string names = "";
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                if (!r.Cells[ColID.Name].Value.ToString().Equals(string.Empty))
                {
                    IDs += "," + r.Cells[ColID.Name].Value.ToString();
                    names += "," + r.Cells[ColItemName.Name].Value.ToString();
                }
            }
            if (bll.DeleteItems(IDs.Substring(1)))
            {
                Logger.Info(LoginInfo.LoginName + "删除配置项" + names.Substring(1));
                BindData();
            }
            else
            {
                Logger.Warn(LoginInfo.LoginName + "删除配置项" + names.Substring(1) + "失败");
                MessageBox.Show("删除操作失败!");
            }
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            XF.Model.XF_Configuration model;

            //新增数据
            foreach (int index in lstInsert)
            {
                if (CheckInput(index))
                {
                    model = new XF.Model.XF_Configuration();
                    model.ItemName = dataGridView1.Rows[index].Cells[ColItemName.Name].Value.ToString();
                    model.ItemValue = dataGridView1.Rows[index].Cells[ColValue.Name].Value.ToString();
                    if (dataGridView1.Rows[index].Cells[ColDescription.Name].Value == null)
                    {
                        model.ItemDescription = "";
                    }
                    else
                    {
                        model.ItemDescription = dataGridView1.Rows[index].Cells[ColDescription.Name].Value.ToString();
                    }
                    model.CreateDate = DateTime.Now;
                    model.CreateUser = LoginInfo.LoginName;
                    model.LastUpdateDate = DateTime.Now;
                    model.LastUpdateUser = LoginInfo.LoginName;
                    int ret = bll.CreateItem(model.ItemName, model.ItemValue, model.ItemDescription, LoginInfo.LoginName);
                    if (ret == -1)
                    {
                        Logger.Warn(LoginInfo.LoginName + "新增配置项" + model.ItemName + "失败，配置项已存在!");
                        MessageBox.Show("新增配置项" + model.ItemName + "失败，配置项已存在!");
                        return;
                    }
                    else
                    {
                        Logger.Info(LoginInfo.LoginName + "新增配置项" + model.ItemName);
                        dataGridView1.Rows[index].Cells[ColItemName.Name].ReadOnly = true;
                    }
                }
                else
                {
                    return;
                }
            }
            //更新数据
            foreach (int index in lstUpdate)
            {
                if (CheckInput(index))
                {
                    model = new XF.Model.XF_Configuration();
                    model.ItemID = int.Parse(dataGridView1.Rows[index].Cells[ColID.Name].Value.ToString());
                    model.ItemName = dataGridView1.Rows[index].Cells[ColItemName.Name].Value.ToString();
                    model.ItemValue = dataGridView1.Rows[index].Cells[ColValue.Name].Value.ToString();
                    if (dataGridView1.Rows[index].Cells[ColDescription.Name].Value == null)
                    {
                        model.ItemDescription = "";
                    }
                    else
                    {
                        model.ItemDescription = dataGridView1.Rows[index].Cells[ColDescription.Name].Value.ToString();
                    }
                    model.LastUpdateDate = DateTime.Now;
                    model.LastUpdateUser = LoginInfo.LoginName;
                    if (!bll.UpdateItem(model.ItemID, model.ItemName, model.ItemValue, model.ItemDescription,LoginInfo.LoginName))
                    {
                        Logger.Warn(LoginInfo.LoginName + "更新配置项" + model.ItemName + "失败");
                        MessageBox.Show("配置项" + model.ItemName + "更新失败!");
                        return;
                    }
                    Logger.Info(LoginInfo.LoginName + "更新配置项" + model.ItemName);
                }
                else
                {
                    return;
                }
            }
            BindData();
        }

        /// <summary>
        /// 检查输入项
        /// </summary>
        /// <param name="index"></param>
        private bool CheckInput(int index)
        {
            if (dataGridView1.Rows[index].Cells[ColItemName.Name].Value == null || dataGridView1.Rows[index].Cells[ColItemName.Name].Value.ToString().Equals(string.Empty))
            {
                MessageBox.Show("配置项不能为空！");
                return false;
            }
            if (dataGridView1.Rows[index].Cells[ColValue.Name].Value == null || dataGridView1.Rows[index].Cells[ColValue.Name].Value.ToString().Equals(string.Empty))
            {
                MessageBox.Show("配置值不能为空！");
                return false;
            }
            return true;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[ColID.Name].Value == null ||dataGridView1.Rows[e.RowIndex].Cells[ColID.Name].Value.ToString().Equals(string.Empty))
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

        private void tsBtnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[ColItemName.Name].Value = "";
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[ColValue.Name].Value = "";
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[ColDescription.Name].Value = "";
        }

        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void FrmConfigList_Activated(object sender, EventArgs e)
        {
            BindData();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            System.Drawing.Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Y, this.dataGridView1.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), this.dataGridView1.RowHeadersDefaultCellStyle.Font, rectangle, this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
}
