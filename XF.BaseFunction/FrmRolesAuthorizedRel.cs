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
    public partial class FrmRolesAuthorizedRel : Form
    {
        XF.BLL.XF_Roles bllRole = new BLL.XF_Roles();
        XF.BLL.XF_Modules bllModules = new BLL.XF_Modules();
        DataTable ModuleTable = new DataTable();
        ArrayList authority = new ArrayList();
        ArrayList authorityInit = new ArrayList();
        public FrmRolesAuthorizedRel()
        {
            InitializeComponent();
            dgvRole.AutoGenerateColumns = false;
            dgvModule.AutoGenerateColumns = false;
        }

        private void FrmRolesAuthorizedRel_Load(object sender, EventArgs e)
        {
            LoginHandler.InitModule("admin_RolesAuthorizedPage");
            if (LoginHandler.ValidationHandle(XF_Tag.Browse))//是否有浏览权限
            {
                Logger.Info(LoginInfo.LoginName + "浏览admin_RolesAuthorizedPage页面");
                this.Icon = ConfigSetting.ProjectIcon;
                BindGroup();
                BindModuleType();
            }
            else
            {
                MessageBox.Show("您没有对应权限！");
                this.Close();
            }
            if (!LoginHandler.ValidationHandle(XF_Tag.Grant))
            {
                tsBtnSave.Visible = false;
                chkLstAuthority.Enabled = false;
            }
            else
            {
                chkLstAuthority.Click += chkLstAuthority_Click;
            }
        }

        /// <summary>
        /// 绑定角色组
        /// </summary>
        private void BindGroup()
        {
            XF.BLL.XF_Groups bllGroup = new BLL.XF_Groups();
            cmbGroup.DataSource = bllGroup.GetGroupList("", "").Tables[0];
        }

        /// <summary>
        /// 绑定菜单目录
        /// </summary>
        private void BindModuleType()
        {
            ModuleTable = bllModules.GetModuleTypeList("").Tables[0];  //取得所有数据得到DataTable 
            DataTable dt = ModuleTable.Copy();
            DataRow dr = dt.NewRow();
            dr["ModuleTypeID"] = 0;
            dr["ModuleTypeName"] = "无";
            dt.Rows.InsertAt(dr, 0);
            tvModulesType.Nodes.Clear();
            LoadNode(tvModulesType.Nodes, "0"); //建立节点 
            tvModulesType.ExpandAll();
        }

        /// <summary>
        /// 递归加载目录
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="MtID"></param>
        private void LoadNode(TreeNodeCollection nodes, string MtID)
        {
            DataView dvList = new DataView(ModuleTable);
            dvList.RowFilter = "ModuleTypeSuperiorID=" + MtID;  //过滤父节点 
            TreeNode nodeTemp;
            foreach (DataRowView r in dvList)
            {
                nodeTemp = new TreeNode();
                nodeTemp.Tag = r;
                nodeTemp.Name = "Node" + MtID + "-" + r["ModuleTypeID"].ToString();
                nodeTemp.Text = r["ModuleTypeName"].ToString();  //节点名称  
                nodes.Add(nodeTemp);  //加入节点      
                this.LoadNode(nodeTemp.Nodes, r["ModuleTypeID"].ToString());  //递归 
            }
        }

        /// <summary>
        /// 绑定角色
        /// </summary>
        /// <param name="roleGroupID"></param>
        private void BindRole(string roleGroupID)
        {
            dgvRole.DataSource = bllRole.GetRoleList(" RoleGroupID = " + roleGroupID, " Order By RoleOrder Asc ").Tables[0];
        }

        /// <summary>
        /// 绑定菜单
        /// </summary>
        /// <param name="ModuleTypeID"></param>
        private void BindModules(string ModuleTypeID)
        {
            dgvModule.DataSource = bllModules.GetModuleList2(ModuleTypeID).Tables[0];
        }

        /// <summary>
        /// 绑定菜单权限
        /// </summary>
        /// <param name="ModuleID"></param>
        private void BindModuleAuthorizedRel(int ModuleID)
        {
            DataTable dt = bllModules.GetModuleAuthorityList(ModuleID).Tables[0];
            chkLstAuthority.Items.Clear();
            authority.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chkLstAuthority.Items.Add(new ListItem(dt.Rows[i]["AuthorityTag"].ToString(), dt.Rows[i]["AuthorityName"].ToString()));
                authority.Add(dt.Rows[i]["AuthorityTag"].ToString());
            }
        }

        /// <summary>
        /// 绑定角色菜单权限
        /// </summary>
        private void BindRoleModuleAuthrizedRel()
        {
            for (int i = 0; i < chkLstAuthority.Items.Count; i++)
            {
                chkLstAuthority.SetItemChecked(i, false);
            }
            if (dgvModule.SelectedRows.Count > 0 && dgvRole.SelectedRows.Count > 0)
            {
                int roleID = Convert.ToInt32(dgvRole.SelectedRows[0].Cells[ColRoleID.Name].Value);
                int moduleID = Convert.ToInt32(dgvModule.SelectedRows[0].Cells[ColModuleID.Name].Value);
                DataTable dt = bllRole.GetRoleAuthorityList(roleID, moduleID).Tables[0];
                int index = -1;
                authorityInit.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    index = authority.IndexOf(dr["AuthorityTag"].ToString());
                    if (index >= 0)
                    {
                        chkLstAuthority.SetItemChecked(index, true);
                        authorityInit.Add(dr["AuthorityTag"].ToString());
                    }
                }
            }
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRole(cmbGroup.SelectedValue.ToString());
        }

        private void tvModulesType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataRowView dr = e.Node.Tag as DataRowView;
            BindModules(dr["ModuleTypeID"].ToString());
        }

        private void dgvModule_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvModule.SelectedRows.Count > 0)
            {
                int ModuleID = Convert.ToInt32(dgvModule.SelectedRows[0].Cells[ColModuleID.Name].Value);
                BindModuleAuthorizedRel(ModuleID);
                BindRoleModuleAuthrizedRel();
            }
            else
            {
                chkLstAuthority.Items.Clear();
            }
        }

        private void dgvModule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int ModuleID = Convert.ToInt32(dgvModule.Rows[e.RowIndex].Cells[ColModuleID.Name].Value);
                BindModuleAuthorizedRel(ModuleID);
                BindRoleModuleAuthrizedRel();
            }
        }

        private void dgvRole_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BindRoleModuleAuthrizedRel();
        }

        private void dgvRole_DataSourceChanged(object sender, EventArgs e)
        {
            BindRoleModuleAuthrizedRel();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (dgvModule.SelectedRows.Count > 0 && dgvRole.SelectedRows.Count > 0)
            {
                string roleID = dgvRole.SelectedRows[0].Cells[ColRoleID.Name].Value.ToString();
                string moduleID = dgvModule.SelectedRows[0].Cells[ColModuleID.Name].Value.ToString();
                ArrayList list = new ArrayList();//建立事务列表
                for (int i = 0; i < chkLstAuthority.Items.Count; i++)
                {
                    ListItem item = chkLstAuthority.Items[i] as ListItem;
                    //初始数据包含，结果未选中，为删除操作
                    if (authorityInit.Contains(item.Value) && !chkLstAuthority.GetItemChecked(i))
                    {
                        string sItem = roleID + "|" + moduleID + "|" + item.Value + "|0";//判断插入增加还是删除
                        list.Add(sItem);
                    }
                    //初始数据不包含，结果选中，为新增操作
                    if (!authorityInit.Contains(item.Value) && chkLstAuthority.GetItemChecked(i))
                    {
                        string sItem = roleID + "|" + moduleID + "|" + item.Value + "|1";//判断插入增加还是删除
                        list.Add(sItem);
                    }
                }
                //权限加入是否成功！
                if (bllRole.UpdateRoleAuthority(list, LoginInfo.LoginName))
                {
                    MessageBox.Show("保存成功！");
                }
                else
                {
                    MessageBox.Show("权限修改失败！");
                }
            }
            else
            {
                MessageBox.Show("请选择角色和菜单！");
            }
        }
        private void chkLstAuthority_Click(object sender, EventArgs e)
        {
            if (chkLstAuthority.SelectedIndex >= 0)
            {
                //取反
                bool chk = chkLstAuthority.GetItemChecked(chkLstAuthority.SelectedIndex);
                chkLstAuthority.SetItemChecked(chkLstAuthority.SelectedIndex, !chk);
            }
        }

        private void FrmRolesAuthorizedRel_Activated(object sender, EventArgs e)
        {
            BindGroup();
            BindModuleType();
        }
    }
}
