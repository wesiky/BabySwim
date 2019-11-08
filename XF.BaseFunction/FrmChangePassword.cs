using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XF.Common;
using XF.Lib;
using XF.BLL;
using Enums;

namespace XF.BaseFunction
{
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbPasswordOld.Text.Equals(string.Empty) || tbPasswordNew.Text.Equals(string.Empty)||tbPasswordSure.Text.Equals(string.Empty))
            {
                MessageBox.Show("请输入完整信息！");
            }
            else
            {
                int id = (int)LoginInfo.LoginId;
                XF.BLL.XF_Users bll = new XF.BLL.XF_Users();
                if (bll.VerifyPassword(id, SecurityEncryption.MD5(tbPasswordOld.Text, 32)))
                {
                    //两次密码必须输入必须相同
                    if (String.Compare(tbPasswordNew.Text, tbPasswordSure.Text, true) == 0)
                    {
                        if (bll.ChangePassword(id, SecurityEncryption.MD5(tbPasswordSure.Text, 32)))
                        {
                            Logger.Info(LoginInfo.LoginName + "修改密码成功");
                            MessageBox.Show("密码修改成功!");
                        }
                        else
                        {
                            MessageBox.Show("密码修改失败!");
                        }
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("原密码错误!");
                }
            }
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
        }
    }
}
