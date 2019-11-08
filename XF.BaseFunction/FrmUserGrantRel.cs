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
    public partial class FrmUserGrantRel : Form
    {
        XF.BLL.XF_Users bll = new BLL.XF_Users();
        int userID = -1;
        int userGroupID = -1;
        ArrayList initUserRole = new ArrayList();
        public FrmUserGrantRel(int _userID,int _groupID)
        {
            InitializeComponent();
            this.userID = _userID;
            this.userGroupID = _groupID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            XF.BLL.XF_Users bll = new XF.BLL.XF_Users();
            ArrayList insertItem = new ArrayList();//加加表
            ArrayList deleteItem = new ArrayList();//删除表
            ArrayList userRole = new ArrayList();
            //新增记录
            foreach (object obj in lstBoxUserRole.Items)
            {
                ListItem item = obj as ListItem;
                if (!initUserRole.Contains(item.Value))
                {
                    insertItem.Add(userID.ToString() + "|" + item.Value); 
                }
                userRole.Add(item.Value);
            }
            //删除记录
            foreach (string roleID in initUserRole)
            {
                if (!userRole.Contains(roleID))
                {
                    deleteItem.Add(userID.ToString() + "|" + roleID);
                }
            }
            if (insertItem.Count != 0) 
            { 
                bll.addUserRole(insertItem,LoginInfo.LoginName); 
            }
            if (deleteItem.Count != 0) 
            { 
                bll.DeleteUserRole(deleteItem); 
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnMoveRightAll_Click(object sender, EventArgs e)
        {
            while (lstBoxUserRole.Items.Count > 0)
            {
                lstBoxAllRole.Items.Add(lstBoxUserRole.Items[0]);
                lstBoxUserRole.Items.RemoveAt(0);
            }
        }

        private void btnMoveLeftAll_Click(object sender, EventArgs e)
        {
            while (lstBoxAllRole.Items.Count > 0)
            {
                lstBoxUserRole.Items.Add(lstBoxAllRole.Items[0]);
                lstBoxAllRole.Items.RemoveAt(0);
            }
        }

        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            if (lstBoxUserRole.SelectedIndex >= 0)
            {
                lstBoxAllRole.Items.Add(lstBoxUserRole.Items[lstBoxUserRole.SelectedIndex]);
                lstBoxUserRole.Items.Remove(lstBoxUserRole.Items[lstBoxUserRole.SelectedIndex]);
            }
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            if (lstBoxAllRole.SelectedIndex >= 0)
            {
                lstBoxUserRole.Items.Add(lstBoxAllRole.Items[lstBoxAllRole.SelectedIndex]);
                lstBoxAllRole.Items.Remove(lstBoxAllRole.Items[lstBoxAllRole.SelectedIndex]);
            }
        }

        private void FrmUserGrantRel_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            BindUserRoles();
            BindRoles();
        }

        private void BindRoles()
        {
            XF.BLL.XF_Roles bllRole = new BLL.XF_Roles();
            DataTable dt = bllRole.GetRoleList("RoleGroupID = "+ userGroupID, "").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                if (!initUserRole.Contains(dr["RoleID"].ToString()))
                {
                    lstBoxAllRole.Items.Add(new ListItem(dr["RoleID"].ToString(), dr["RoleName"].ToString()));
                }
            }
        }

        private void BindUserRoles()
        {
            DataTable dt = bll.GetUserRole(userID).Tables[0];
            initUserRole.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                lstBoxUserRole.Items.Add(new ListItem(dr["RoleID"].ToString(), dr["RoleName"].ToString()));
                initUserRole.Add(dr["RoleID"].ToString());
            }
        }
    }
}
