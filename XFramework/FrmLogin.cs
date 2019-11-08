using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XF.Lib;
using XF.Common;
using XF.BLL;
using System.Configuration;
using XF.ExControls;
using System.Drawing.Drawing2D;
using XF.ExControls.Methods;
using Enums;

namespace XFramework
{
    public partial class FrmLogin : FormEx
    {
        #region 变量
        bool bRememberPassword = false;
        bool bAutoLogin = false;
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Effect.DrawFromAlphaMainPart(this, e.Graphics);
        }

        #region 构造函数
        public FrmLogin()
        {
            InitializeComponent();
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2;
            //获取上次记住的账号
            tbUserName.Text = Properties.Settings.Default.UserName == null ? "" : Properties.Settings.Default.UserName;
            #region 看板调度
            bRememberPassword = XF.Common.ConfigHelper.GetConfigBool("RememberPassword");
            bAutoLogin = XF.Common.ConfigHelper.GetConfigBool("AutoLogin");
            if (bRememberPassword)
                tbPassword.Text = Properties.Settings.Default.Password == null ? "" : Properties.Settings.Default.Password;
            #endregion
            //如果账号有了，默认光标设在密码框
            if (tbUserName.Text != "")
                this.ActiveControl = tbPassword;
            ////test
            //tbUserName.Text = "admin";
            //tbPassword.Text = "123123";
            this.Text = ConfigurationManager.AppSettings["FormText"];
        }
        #endregion
        #region 登录
        private void btnYes_Click(object sender, EventArgs e)
        {
            lblState.Text = "正在登录中...";
            lblState.Update();

            XF.BLL.XF_Users bll = new XF.BLL.XF_Users();
            XF.Model.XF_Users model = new XF.Model.XF_Users();
            string sUserName = tbUserName.Text.Trim();
            string sPassword = tbPassword.Text.Trim().ToLower();

            if (sUserName.Equals(string.Empty) || sPassword.Equals(string.Empty))
            {
                MessageBox.Show("请输入完整的登录信息!");
            }
            else
            {
                if (bll.CheckLogin(sUserName, SecurityEncryption.MD5(sPassword, 32)))
                {
                    model = bll.GetUserModel(sUserName);
                    if (model.RoleID.Count != 0 || model.IsLimit == true)
                    {
                        if (model.Status != 0)
                        {
                            Properties.Settings.Default.UserName = tbUserName.Text;
                            if (bRememberPassword)
                                Properties.Settings.Default.Password = tbPassword.Text;
                            Properties.Settings.Default.Save();

                            bll.UpdateLoginTime(model.UserID);
                            LoginOptioner.SaveLoginInfo(model.UserID, model.UserName, model.RealName, DateTime.Now, model.RoleID, model.UserGroup, model.IsLimit, model.Status,model.Phone,model.Email,model.WarehouseID,model.LGORT,model.MRP);
                            Logger.Info(LoginInfo.LoginName + "登录系统");
                            this.Hide();
                            Program.frmMain = new FrmMain();
                            Program.frmMain.StartPosition = FormStartPosition.CenterScreen;
                            Program.frmMain.ShowDialog();
                            #region old
                            //System.Windows .Forms.DialogResult diaResult = frmMain.ShowDialog();
                            //if (diaResult == System.Windows.Forms.DialogResult.Retry)
                            //{
                            //    this.tbPassword.Text = string.Empty;
                            //    this.Visible = true;
                            //}
                            //else if(diaResult != System.Windows.Forms.DialogResult.Ignore)
                            //{
                            //    //this.Close();
                            //    Environment.Exit(0);
                            //}
                            #endregion
                        }
                        else
                        {
                            MessageBox.Show("用户或密码错误!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户还未激活,请与管理员联系!");
                    }
                }
                else
                {
                    MessageBox.Show("用户或密码错误!");
                }
            }
            lblState.Text = "";
        }
        #endregion
        #region 退出
        private void btnNo_Click(object sender, EventArgs e)
        {
            //this.Close();
            if (Program.frmMain != null && Program.frmMain.notifyChint != null)
                Program.frmMain.notifyChint.Dispose();
            Environment.Exit(0);
        }
        #endregion
        #region 自动登录
        private void FrmLogin_Shown(object sender, EventArgs e)
        {

            if (tbUserName.Text.IndexOf("admin") == -1 && bAutoLogin && tbPassword.Text != "")
            {
                btnYes_Click(null, null);
            }
        }
        #endregion

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.TextForeColor = ConfigSetting.TextForeColor;
            this.Text = ConfigSetting.ProjectName;
            this.Icon = ConfigSetting.ProjectIcon;
        }
    }
}
