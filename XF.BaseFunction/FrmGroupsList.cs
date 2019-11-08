using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XF.Common;
using XF.BLL;
using Enums;

namespace XF.BaseFunction
{
    public partial class FrmGroupsList : Form
    {
        XF.BLL.XF_Groups bll = new XF.BLL.XF_Groups();
        List<int> lstInsert = new List<int>();
        List<int> lstUpdate = new List<int>();

        public FrmGroupsList()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            tsCmbType.Items.Add(new ListItem("1", "角色分组"));
            tsCmbType.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void BindData()
        {
            int count = 0;
            string strWhere = "";
            strWhere = " and GroupType = " + ((ListItem)tsCmbType.SelectedItem).Value;
            if (!tsTbName.Text.Trim().Equals(string.Empty))
            {
                strWhere += " and GroupName like '%" + tsTbName.Text.Trim() + "%'";
            }
            DataTable dt = bll.GetGroupListByPage(strWhere, " GroupOrder Asc ", pagerControl1.PageIndex, pagerControl1.PageSize, ref count);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[ColID.Name].Value = dt.Rows[i]["GroupID"].ToString();
                dataGridView1.Rows[i].Cells[ColName.Name].Value = dt.Rows[i]["GroupName"].ToString();
                dataGridView1.Rows[i].Cells[ColDescription.Name].Value = dt.Rows[i]["GroupDescription"].ToString();
                dataGridView1.Rows[i].Cells[ColOrder.Name].Value = dt.Rows[i]["GroupOrder"].ToString();
                dataGridView1.Rows[i].Cells[ColCreateDate.Name].Value = dt.Rows[i]["CreateDate"].ToString();
                dataGridView1.Rows[i].Cells[ColCreateUser.Name].Value = dt.Rows[i]["CreateUser"].ToString();
                dataGridView1.Rows[i].Cells[ColLastUpdateDate.Name].Value = dt.Rows[i]["LastUpdateDate"].ToString();
                dataGridView1.Rows[i].Cells[ColLastUpdateUser.Name].Value = dt.Rows[i]["LastUpdateUser"].ToString();
                dataGridView1.Rows[i].Cells[ColName.Name].ReadOnly = true;
                dataGridView1.Rows[i].Cells[ColCreateDate.Name].ReadOnly = true;
                dataGridView1.Rows[i].Cells[ColCreateUser.Name].ReadOnly = true;
                dataGridView1.Rows[i].Cells[ColLastUpdateDate.Name].ReadOnly = true;
                dataGridView1.Rows[i].Cells[ColLastUpdateUser.Name].ReadOnly = true;
            }
            pagerControl1.DrawControl(count);
            lstInsert.Clear();
            lstUpdate.Clear();
        }

        private void FrmGroupsList_Load(object sender, EventArgs e)
        {
            LoginHandler.InitModule("admin_GroupsPage");
            if (LoginHandler.ValidationHandle(XF_Tag.Browse))//是否有浏览权限
            {
                Logger.Info(LoginInfo.LoginName + "浏览admin_GroupsPage页面");
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
                tsCmbType.Visible = false;
                toolStripLabel2.Visible = false;
                tsTbName.Visible = false;
                tsBtnQuery.Visible = false;
            }
        }

        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void tsBtnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void tsBtnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[ColName.Name].Value = "";
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[ColOrder.Name].Value = "";
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[ColDescription.Name].Value = "";
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
                    names += "," + r.Cells[ColName.Name].Value.ToString();
                }
            }
            int ret = bll.DeleteGroups(IDs.Substring(1));
            if (ret == 1)
            {
                Logger.Info(LoginInfo.LoginName + "删除分组" + names.Substring(1));
                BindData();
            }
            else if(ret == 2)
            {
                Logger.Warn(LoginInfo.LoginName + "删除操作失败!分组下有用户，不能删除");
                MessageBox.Show("删除操作失败!分组下有用户，不能删除");
            }
            else if(ret ==3)
            {
                Logger.Warn(LoginInfo.LoginName + "删除操作失败!分组下有角色，不能删除");
                MessageBox.Show("删除操作失败!分组下有角色，不能删除");
            }
            else
            {
                Logger.Warn(LoginInfo.LoginName + "删除操作失败!");
                MessageBox.Show("删除操作失败!");
            }
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            XF.Model.XF_Groups model;

            //新增数据
            foreach (int index in lstInsert)
            {
                if (CheckInput(index))
                {
                    model = new XF.Model.XF_Groups();
                    model.GroupName = dataGridView1.Rows[index].Cells[ColName.Name].Value.ToString();
                    model.GroupOrder = int.Parse(dataGridView1.Rows[index].Cells[ColOrder.Name].Value.ToString());
                    if (dataGridView1.Rows[index].Cells[ColDescription.Name].Value == null)
                    {
                        model.GroupDescription = "";
                    }
                    else
                    {
                        model.GroupDescription = dataGridView1.Rows[index].Cells[ColDescription.Name].Value.ToString();
                    }
                    model.GroupType = int.Parse(((ListItem)tsCmbType.SelectedItem).Value);
                    model.CreateDate = DateTime.Now;
                    model.CreateUser = LoginInfo.LoginName;
                    model.LastUpdateDate = DateTime.Now;
                    model.LastUpdateUser = LoginInfo.LoginName;
                    int ret = bll.CreateGroup(model);
                    if (ret == -1)
                    {
                        Logger.Warn(LoginInfo.LoginName + "新增分组" + model.GroupName + "失败，分组已存在!");
                        MessageBox.Show("新增分组" + model.GroupName + "失败，分组已存在!");
                        return;
                    }
                    else
                    {
                        Logger.Info(LoginInfo.LoginName + "新增分组" + model.GroupName);
                        dataGridView1.Rows[index].Cells[ColName.Name].ReadOnly = true;
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
                    model = new XF.Model.XF_Groups();
                    model.GroupID = int.Parse(dataGridView1.Rows[index].Cells[ColID.Name].Value.ToString());
                    model.GroupName = dataGridView1.Rows[index].Cells[ColName.Name].Value.ToString();
                    model.GroupOrder = int.Parse(dataGridView1.Rows[index].Cells[ColOrder.Name].Value.ToString());
                    if (dataGridView1.Rows[index].Cells[ColDescription.Name].Value == null)
                    {
                        model.GroupDescription = "";
                    }
                    else
                    {
                        model.GroupDescription = dataGridView1.Rows[index].Cells[ColDescription.Name].Value.ToString();
                    }
                    model.GroupType = int.Parse(((ListItem)tsCmbType.SelectedItem).Value);
                    model.LastUpdateDate = DateTime.Now;
                    model.LastUpdateUser = LoginInfo.LoginName;
                    if (!bll.UpdateGroup(model))
                    {
                        Logger.Warn(LoginInfo.LoginName + "更新分组" + model.GroupName + "失败!");
                        MessageBox.Show("分组" + model.GroupName + "更新失败!");
                        return;
                    }
                    Logger.Info(LoginInfo.LoginName + "更新分组" + model.GroupName);
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
            if (dataGridView1.Rows[index].Cells[ColName.Name].Value == null || dataGridView1.Rows[index].Cells[ColName.Name].Value.ToString().Equals(string.Empty))
            {
                MessageBox.Show("名称不能为空！");
                return false;
            }
            if (dataGridView1.Rows[index].Cells[ColOrder.Name].Value == null || dataGridView1.Rows[index].Cells[ColOrder.Name].Value.ToString().Equals(string.Empty))
            {
                MessageBox.Show("排序不能为空！");
                return false;
            }
            else
            {
                int tmp = 0;
                if (!int.TryParse(dataGridView1.Rows[index].Cells[ColOrder.Name].Value.ToString(), out tmp))
                {
                    MessageBox.Show("排序必须为数字！");
                    return false;
                }
            }
            return true;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[ColID.Name].Value == null || dataGridView1.Rows[e.RowIndex].Cells[ColID.Name].Value.ToString().Equals(string.Empty))
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

        private void tsCmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void FrmGroupsList_Activated(object sender, EventArgs e)
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
