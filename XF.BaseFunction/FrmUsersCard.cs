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
using XF.Lib;
using XF.BLL;
using Enums;

namespace XF.BaseFunction
{
    public partial class FrmUsersCard : Form
    {
        int id = -1;
        ArrayList roles = new ArrayList();
        public FrmUsersCard()
        {
            InitializeComponent();
        }

        public FrmUsersCard(int _id)
        {
            InitializeComponent();
            this.id = _id;
            tbUserName.Enabled = false;
        }

        private void FrmUsersCard_Load(object sender, EventArgs e)
        {
            if (LoginHandler.ValidationHandle(XF_Tag.View))//是否有浏览权限
            {
                this.Icon = ConfigSetting.ProjectIcon;
                if (!LoginHandler.ValidationHandle(XF_Tag.Edit))
                {
                    btnOK.Enabled = false;
                }
                BindGroup();
                BindStatus();
                if (id > -1)
                {
                    LoadUser(id);
                }
                else
                {
                    cmbGroup.SelectedIndex = 0;
                    cmbStatus.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("您没有对应权限！");
                this.Close();
            }
        }

        /// <summary>
        /// 绑定用户组数据
        /// </summary>
        protected void BindGroup()
        {
            XF.BLL.XF_Groups gourpsbll = new XF.BLL.XF_Groups();
            DataTable dt = gourpsbll.GetGroupList("","").Tables[0];
            cmbGroup.DataSource = dt;
        }

        /// <summary>
        /// 绑定用户状态数据
        /// </summary>
        protected void BindStatus()
        {
            cmbStatus.Items.Add(new ListItem("0", "禁止登陆"));
            cmbStatus.Items.Add(new ListItem("1", "允许登陆"));
            cmbStatus.Items.Add(new ListItem("2", "锁定"));
        }

        /// <summary>
        /// 绑定角色数据
        /// </summary>
        protected void BindRole(int groupID)
        {
            XF.BLL.XF_Roles rbll = new XF.BLL.XF_Roles();
            DataTable dt = rbll.GetRoleList(" RoleGroupID = "+ groupID.ToString(),"").Tables[0];
            clbRole.Items.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                if (roles.Contains(dr["RoleID"].ToString() + ',' + dr["RoleName"].ToString()))
                {
                    clbRole.Items.Add(new ListItem(dr["RoleID"].ToString(), dr["RoleName"].ToString()), true);
                }
                else
                {
                    clbRole.Items.Add(new ListItem(dr["RoleID"].ToString(), dr["RoleName"].ToString()), false);
                }

            }
        }

        /// <summary>
        /// 用户组变更时加载对应的角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGroup.SelectedIndex >= 0)
            {
                BindRole(int.Parse(cmbGroup.SelectedValue.ToString()));
            }
        }


        protected void LoadUser(int id)
        {
            XF.BLL.XF_Users bll = new XF.BLL.XF_Users();
            XF.Model.XF_Users model = new XF.Model.XF_Users();
            model = bll.GetUserModel(id);
            tbUserName.Text = model.UserName;
            tbRealName.Text = model.RealName;
            roles = model.RoleID;
            tbPhone.Text = model.Phone;
            tbEmail.Text = model.Email;
            cmbStatus.SelectedIndex = model.Status;
            dtpCreateTime.Value = model.CreateDate;
            dtpLastLoginTime.Value = model.LastLoginTime;
            cmbGroup.SelectedValue = model.UserGroup.ToString();
            //BindRole(int.Parse(model.UserGroup.ToString()));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }
            XF.BLL.XF_Users bll = new XF.BLL.XF_Users();
            XF.Model.XF_Users model = new XF.Model.XF_Users();
            model.UserID = id;
            model.UserName = tbUserName.Text;
            model.RealName = tbRealName.Text;
            model.UserGroup = int.Parse(cmbGroup.SelectedValue.ToString());
            model.Email =tbEmail.Text;
            model.Phone = tbPhone.Text;
            model.Status = int.Parse(((ListItem)cmbStatus.SelectedItem).Value);
            model.LastUpdateDate = DateTime.Now;
            model.LastUpdateUser = LoginInfo.LoginName;
            if (id == -1)
            {
                model.Password = SecurityEncryption.MD5("123456", 32);
                model.IsLimit = false;
                model.CreateDate = DateTime.Now;
                model.CreateUser = LoginInfo.LoginName;
                int ret = bll.CreateUser(model);
                if (ret >= 0)
                {
                    MessageBox.Show("新增用户成功!");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else if(ret == -1)
                {
                    MessageBox.Show("新增用户失败，用户名已存在!");
                }
                else
                {
                    MessageBox.Show("新增用户失败!");
                }
            }
            else
            {
                if (bll.UpdateUser(model) >= 1)
                {
                    MessageBox.Show("更新用户成功!");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("更新用户失败!");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateData()
        {
            if (tbUserName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("请输入用户名！");
                return false;
            }
            if (!tbEmail.Text.Trim().Equals(string.Empty))
            {
                if (!ValidateUtil.IsEmail(tbEmail.Text.Trim()))
                {
                    MessageBox.Show("邮箱格式有误！");
                    return false;
                }
            }
            if (!tbPhone.Text.Trim().Equals(string.Empty))
            {
                if (!ValidateUtil.IsValidMobile(tbPhone.Text.Trim()))
                {
                    MessageBox.Show("联系电话格式有误！");
                    return false;
                }
            }
            return true;
        }
    }
}
