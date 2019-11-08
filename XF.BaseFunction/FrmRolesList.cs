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
    public partial class FrmRolesList : Form
    {
        XF.BLL.XF_Roles bll = new XF.BLL.XF_Roles();
        List<int> lstInsert = new List<int>();
        List<int> lstUpdate = new List<int>();
        public FrmRolesList()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            BindGroup();
            tsCmbGroup.SelectedIndex = 0;
        }

        private void BindGroup()
        {
            //绑定组信息
            XF.BLL.XF_Groups bllGroup = new XF.BLL.XF_Groups();
            DataTable dt = bllGroup.GetGroupList("GroupType=1", "order by GroupOrder asc").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                tsCmbGroup.Items.Add(new ListItem(dr["GroupID"].ToString(), dr["GroupName"].ToString()));
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void BindData()
        {
            int count = 0;
            string strWhere = "";
            if (!((ListItem)tsCmbGroup.SelectedItem).Value.Equals("all"))
            {
                strWhere += " and RoleGroupID = " + ((ListItem)tsCmbGroup.SelectedItem).Value;
            }
            if (!tsTbName.Text.Trim().Equals(string.Empty))
            {
                strWhere += " and RoleName like '%" + tsTbName.Text.Trim() + "%'";
            }
            DataTable dt = bll.GetRoleListByPage(strWhere, " RoleOrder Asc ", pagerControl1.PageIndex, pagerControl1.PageSize, ref count);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[ColID.Name].Value = dt.Rows[i]["RoleID"].ToString();
                dataGridView1.Rows[i].Cells[ColName.Name].Value = dt.Rows[i]["RoleName"].ToString();
                dataGridView1.Rows[i].Cells[ColDescription.Name].Value = dt.Rows[i]["RoleDescription"].ToString();
                dataGridView1.Rows[i].Cells[ColOrder.Name].Value = dt.Rows[i]["RoleOrder"].ToString();
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

        private void FrmRolesList_Load(object sender, EventArgs e)
        {
            LoginHandler.InitModule("admin_RolesPage");
            if (LoginHandler.ValidationHandle(XF_Tag.Browse))//是否有浏览权限
            {
                Logger.Info(LoginInfo.LoginName + "浏览admin_RolesPage页面");
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
                tsCmbGroup.Visible = false;
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
            int ret = 0;
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                if (!r.Cells[ColID.Name].Value.ToString().Equals(string.Empty))
                {
                    IDs += "," + r.Cells[ColID.Name].Value.ToString();
                }
            }
            ret = bll.DeleteRoles(IDs.Substring(1));
            if (ret == 1)
            {
                BindData();
            }
            else if(ret == 2)
            {
                MessageBox.Show("角色下有用户存在,请先删除用户!");
            }
            else
            {
                MessageBox.Show("删除操作失败!");
            }
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            XF.Model.XF_Roles model;

            //新增数据
            foreach (int index in lstInsert)
            {
                if (CheckInput(index))
                {
                    model = new XF.Model.XF_Roles();
                    model.RoleName = dataGridView1.Rows[index].Cells[ColName.Name].Value.ToString();
                    model.RoleOrder = int.Parse(dataGridView1.Rows[index].Cells[ColOrder.Name].Value.ToString());
                    if (dataGridView1.Rows[index].Cells[ColDescription.Name].Value == null)
                    {
                        model.RoleDescription = "";
                    }
                    else
                    {
                        model.RoleDescription = dataGridView1.Rows[index].Cells[ColDescription.Name].Value.ToString();
                    }
                    model.RoleGroupID = int.Parse(((ListItem)tsCmbGroup.SelectedItem).Value);
                    model.CreateDate = DateTime.Now;
                    model.CreateUser = LoginInfo.LoginName;
                    model.LastUpdateDate = DateTime.Now;
                    model.LastUpdateUser = LoginInfo.LoginName;
                    int ret = bll.CreateRole(model);
                    if (ret == -1)
                    {
                        MessageBox.Show("新增角色" + model.RoleName + "失败，角色已存在!");
                        return;
                    }
                    else
                    {
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
                    model = new XF.Model.XF_Roles();
                    model.RoleID = int.Parse(dataGridView1.Rows[index].Cells[ColID.Name].Value.ToString());
                    model.RoleName = dataGridView1.Rows[index].Cells[ColName.Name].Value.ToString();
                    model.RoleOrder = int.Parse(dataGridView1.Rows[index].Cells[ColOrder.Name].Value.ToString());
                    if (dataGridView1.Rows[index].Cells[ColDescription.Name].Value == null)
                    {
                        model.RoleDescription = "";
                    }
                    else
                    {
                        model.RoleDescription = dataGridView1.Rows[index].Cells[ColDescription.Name].Value.ToString();
                    }
                    model.RoleGroupID = int.Parse(((ListItem)tsCmbGroup.SelectedItem).Value);
                    model.LastUpdateDate = DateTime.Now;
                    model.LastUpdateUser = LoginInfo.LoginName;
                    if (!bll.UpdateRole(model))
                    {
                        MessageBox.Show("角色" + model.RoleName + "更新失败!");
                        return;
                    }
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

        private void tsCmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void FrmRolesList_Activated(object sender, EventArgs e)
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
