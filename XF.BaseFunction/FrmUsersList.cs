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
    public partial class FrmUsersList : Form
    {
        XF.BLL.XF_Users bll = new XF.BLL.XF_Users();
        public FrmUsersList()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            pagerControl1.OnPageChanged += pagerControl1_OnPageChanged;
        }

        void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void FrmUsersList_Load(object sender, EventArgs e)
        {
            LoginHandler.InitModule("admin_ListUsers");
            if (LoginHandler.ValidationHandle(XF_Tag.Browse))//是否有浏览权限
            {
                Logger.Info(LoginInfo.LoginName + "浏览admin_ListUsers页面");
                this.Icon = ConfigSetting.ProjectIcon;
                ColStatus.DisplayMember = "Text";
                ColStatus.ValueMember = "Value";
                ColStatus.DataSource = GenerateData.GetUserStatus();
                BindGroup();
                BindData();
            }
            else
            {
                MessageBox.Show("您没有对应权限！");
                this.Close();
            }
            if (!LoginHandler.ValidationHandle(XF_Tag.Add))//是否有浏览权限
            {
                tsBtnAdd.Visible = false;
            }
            if (!LoginHandler.ValidationHandle(XF_Tag.Edit))
            {
                tsBtnUpdate.Visible = false;
            }
            if (!LoginHandler.ValidationHandle(XF_Tag.Delete))//是否有浏览权限
            {
                tsBtnDelete.Visible = false;
            }
            if (!LoginHandler.ValidationHandle(XF_Tag.Grant))//是否有浏览权限
            {
                toolStripSeparator1.Visible = false;
                tsBtnGrant.Visible = false;
            }
            if (!LoginHandler.ValidationHandle(XF_Tag.Search))//是否有浏览权限
            {
                toolStripSeparator2.Visible = false;
                toolStripLabel1.Visible = false;
                tsCmbGroup.Visible = false;
                toolStripLabel2.Visible = false;
                tsTbName.Visible = false;
                tsBtnQuery.Visible = false;
            }
        }

        /// <summary>
        /// 绑定用户组数据
        /// </summary>
        protected void BindGroup()
        {
            //XF.BLL.XF_UserGroup ugbll = new XF.BLL.XF_UserGroup();
            XF.BLL.XF_Groups groupsbll = new XF_Groups();
            DataView dvList = new DataView(groupsbll.GetGroupList("", "").Tables[0]);
            //DataView dvList = new DataView(ugbll.GetXF_UserGroupList("").Tables[0]);
            LoadGroupList("0", 0, dvList);
            tsCmbGroup.Items.Insert(0, new ListItem("all", "全部"));
            tsCmbGroup.SelectedIndex = 0;
        }

        /// <summary>
        /// 加载用户分组
        /// </summary>
        /// <param name="UG_TID">分类上级ID</param>
        /// <param name="Depth">分类级别深度</param>
        protected void LoadGroupList(string UG_TID, int Depth, DataView dvList)
        {
            //dvList.RowFilter = "UG_SuperiorID=" + UG_TID;  //过滤父节点 
            foreach (DataRowView dv in dvList)
            {
                string depth = string.Empty;
                for (int i = 0; i < Depth; i++)
                {
                    depth = depth + "-";
                }
                tsCmbGroup.Items.Add(new ListItem(dv["GroupID"].ToString(), depth + dv["GroupName"].ToString()));

                //LoadGroupList(dv["GroupID"].ToString(), int.Parse(dv["UG_Depth"].ToString()) + 1, dvList);  //递归 
            }
        }


        /// <summary>
        /// 绑定用户数据
        /// </summary>
        protected void BindData()
        {
            string strWhere = " and (V_Users.UserGroup <> 0) and V_Users.UserName<>'" + LoginInfo.LoginName + "' and IsLimit<>1 ";
            ListItem item = (ListItem)tsCmbGroup.SelectedItem;
            if (tsTbName.Text == "")
            {
                if (item.Value != "all")
                {
                    strWhere += " and V_Users.UserGroup=" + item.Value;
                }
            }
            else
            {
                strWhere = "";
                strWhere += " and V_Users.UserName='" + tsTbName.Text + "'";
            }
            int count = 0;
            DataTable dt = bll.GetUserListByPage(strWhere, " V_Users.CreateDate DESC ", pagerControl1.PageIndex, pagerControl1.PageSize, ref count);

            pagerControl1.DrawControl(count);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void tsBtnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            string IDs = "";
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                IDs += "," + r.Cells["ColID"].Value.ToString();
            }
            if (bll.DeleteUsers(IDs.Substring(1)))
            {
                BindData();
            }
            else
            {
                MessageBox.Show("删除操作失败!");
            }
        }

        private void tsBtnAdd_Click(object sender, EventArgs e)
        {
            FrmUsersCard frmUserCard = new FrmUsersCard();
            frmUserCard.StartPosition = FormStartPosition.CenterScreen;
            if (frmUserCard.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BindData();
            }
        }

        private void tsBtnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行记录进行修改！");
                return;
            }
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells["ColID"].Value.ToString());
            FrmUsersCard frmUserCard = new FrmUsersCard(id);
            frmUserCard.StartPosition = FormStartPosition.CenterScreen;
            if (frmUserCard.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BindData();
            }
        }

        private void tsBtnGrant_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行记录进行修改！");
                return;
            }
            int userID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[ColID.Name].Value);
            int userGroupID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[ColGroupID.Name].Value);
            FrmUserGrantRel frmUserGrantRel = new FrmUserGrantRel(userID, userGroupID);
            frmUserGrantRel.StartPosition = FormStartPosition.CenterScreen;
            frmUserGrantRel.ShowDialog();
        }

        private void FrmUsersList_Activated(object sender, EventArgs e)
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
