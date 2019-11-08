using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XF.Common;
using System.Reflection;
using XF.BLL;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.WindowsAPICodePack.Taskbar;
using XF.ExControls;
using XF.ExControls.Methods;
using System.IO;
using XF.ExControls.ControlExs;
using System.Configuration;
using Enums;
//using System.Configuration;

namespace XFramework
{
    public partial class FrmMain : FormEx
    {
        #region 自定义变量
        private DataTable ModuleTable;
        /// <summary>
        /// 鼠标划过的Tab页的序号
        /// </summary>
        private int PageIndex = -1;
        /// <summary>
        /// frmMaim页面当前状态
        /// </summary>
        public FormState frmState = FormState.Normal;
        /// <summary>
        /// pnlLoginInfo是否停留（鼠标离开不消失）
        /// </summary>
        public bool bpnlLoginInfoRemain = false;
        /// <summary>
        /// 是否已经检查提醒
        /// </summary>
        public bool bCheckRemain = false;
        /// <summary>
        /// 自动打开菜单
        /// </summary>
        bool bAutoOpenItem = false;
        /// <summary>
        /// 自动全屏
        /// </summary>
        bool bAutoFullScreen = false;
        #endregion
        #region 构造函数和Load方法
        public FrmMain()
        {
            InitializeComponent();
            Rectangle rec = Screen.GetWorkingArea(this);
            this.Height = rec.Height;
            this.Width = rec.Width;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Effect.DrawFromAlphaMainPart(this, e.Graphics);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.TextForeColor = ConfigSetting.TextForeColor;
                this.Icon = ConfigSetting.ProjectIcon;
                //this.WindowState = FormWindowState.Maximized;
                this.Text = ConfigSetting.ProjectName+"  正在加载菜单...";
                //this.Text = ConfigurationManager.AppSettings["FormText"] + "  正在加载菜单...";
                //正常状态
                frmState = FormState.Normal;

                InitMenu();
                //InitWelcome();
                //this.Text = ConfigurationManager.AppSettings["FormText"];
                this.Text = ConfigSetting.ProjectName;
                tsslblRealName.Text = LoginInfo.RealName;
                BabySwim.GDATA generate = new BabySwim.GDATA();
                generate.GenerateNotice(this);
                //打开通知菜单
                op_MenuClick("通知", "BabySwim.dll&BabySwim.Entry&Notice&1");
            }
            catch
            {
                toolStrip.Items.Clear();
            }
        }
        #endregion
        #region 初始化菜单
        /// <summary>
        /// 初始化菜单
        /// </summary>
        protected void InitMenu()
        {
            XF.BLL.XF_Modules bll = new XF.BLL.XF_Modules();
            TreeNode node = new TreeNode();
            ModuleTable = bll.GetModuleTypeList("").Tables[0];  //取得所有数据得到DataTable 
            LoadTopNode();
            ToolStripMenuItem item1 = new ToolStripMenuItem();
            item1.Name = "FormClose";
            item1.Text = "退出";  //节点名称   
            item1.Click += FormClose;
            item1.Alignment = ToolStripItemAlignment.Right;
            toolStrip.Items.Add(item1);
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Name = "LogOff";
            item.Text = "注销";  //节点名称   
            item.Click += LogOff;
            item.Alignment = ToolStripItemAlignment.Right;
            toolStrip.Items.Add(item);
            ToolStripMenuItem item2 = new ToolStripMenuItem();
            item2.Name = "FormFullScreen";
            item2.Text = "全屏";  //节点名称   
            item2.Click += FormFullScreen;
            item2.Alignment = ToolStripItemAlignment.Right;
            toolStrip.Items.Add(item2);
            //自动全屏
            if (bAutoFullScreen)
                FormFullScreen(null, null);
        }
        #endregion
        #region 增加顶级菜单菜单
        /// <summary>
        /// 增加顶级菜单菜单
        /// </summary>
        protected void LoadTopNode()
        {
            string MtID = "0";
            DataView dvList = new DataView(ModuleTable);
            dvList.RowFilter = "ModuleTypeSuperiorID=" + MtID;  //过滤父节点 
            foreach (DataRowView dv in dvList)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Name = dv["ModuleTypeID"].ToString() + ",0";
                item.Text = dv["ModuleTypeName"].ToString();  //节点名称   
                //为保证系统正常运行，图片加载异常不进行处理
                try
                {
                    string icon = zDataConverter.ToString(dv["Icon"]);
                    if (File.Exists(icon))
                    {
                        item.Image = Image.FromFile(icon);
                        item.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                    }
                }
                catch { }

                if (this.LoadNode(item, item.Name.Split(',')[0]) > 0)  //递归 
                {
                    toolStrip.Items.Add(item);  //加入节点 
                }
                else
                {
                    item.Dispose();
                }
            }
        }
        #endregion
        #region 递归菜单和权限菜单（子菜单列表）
        /// <summary>
        /// 递归菜单和权限菜单（子菜单列表）
        /// </summary>
        /// <param name="node">子菜单</param>
        /// <param name="MtID">子菜单上级ID</param>
        protected int LoadNode(ToolStripMenuItem parentItem, string MtID)
        {
            DataView dvList = new DataView(ModuleTable);
            dvList.RowFilter = "ModuleTypeSuperiorID=" + MtID;  //过滤父节点 
            int count = 0;
            foreach (DataRowView dv in dvList)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Name = dv["ModuleTypeID"].ToString() + ",0";
                item.Text = dv["ModuleTypeName"].ToString();  //节点名称       
                //为保证系统正常运行，图片加载异常不进行处理
                try
                {
                    string icon = zDataConverter.ToString(dv["Icon"]);
                    if (File.Exists(icon))
                    {
                        item.Image = Image.FromFile(icon);
                        item.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                    }
                }
                catch { }

                if (this.LoadNode(item, item.Name.Split(',')[0]) > 0)  //递归 
                {
                    parentItem.DropDownItems.Add(item);//加入节点 
                    count++;
                }
                else
                {
                    item.Dispose();
                }
            }

            count += LoadModules(parentItem, MtID);
            //删除不必要的菜单分类节点。
            return count;
        }
        #endregion
        #region 增加权限菜单
        /// <summary>
        /// 增加权限菜单
        /// </summary>
        /// <param name="parentItem"></param>
        /// <param name="dv"></param>
        private int LoadModules(ToolStripMenuItem parentItem, string ModuleTypeID)
        {
            XF.BLL.XF_Modules bll = new XF.BLL.XF_Modules();
            DataSet Module = bll.GetModuleList(" and ModuleTypeID=" + ModuleTypeID);
            int i = 0;
            foreach (DataRow child_dr in Module.Tables[0].Rows)
            {
                //登陆账户未无限制或有权限的就添加菜单
                if ((LoginInfo.IsLimit == true
                        || (child_dr["ModuleDisabled"].ToString().ToLower() == "true"
                        && LoginHandler.ValidationModule(int.Parse(child_dr["ModuleID"].ToString()), XF_Tag.Browse)))
                        && child_dr["IsMenu"].ToString().ToLower() == "true")
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = child_dr["ModuleName"].ToString();
                    item.Name = child_dr["ModuleID"].ToString() + ",1";
                    item.AutoSize = true;

                    //为保证系统正常运行，图片加载异常不进行处理
                    try
                    {
                        string icon = zDataConverter.ToString(child_dr["Icon"]);
                        if (File.Exists(icon))
                        {
                            item.Image = Image.FromFile(icon);
                            item.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                        }
                    }
                    catch { }

                    //if (child_dr["ModuleTag"].ToString() == "Cell-01-DelayedCheck")
                    //{
                    //    item.Image = new Bitmap(@"Checked.png");
                    //}

                    //后续需要改为执行方法
                    item.Tag = child_dr["ModuleURL"].ToString() + "&" + child_dr["ShowType"].ToString();  //节点信息 
                    item.Click += new EventHandler(MenuClick);

                    parentItem.DropDownItems.Add(item);

                    //自动打开
                    if (bAutoOpenItem)
                        MenuClick(item, null);

                    i++;
                }
            }
            return i;
        }
        #endregion
        #region 菜单点击
        public void MenuClick(object sender, EventArgs e)
        {
            //执行方法配置有误，请联系管理员
            try
            {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                op_MenuClick(item.ToString(), item.Tag.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("菜单方法配置有误，请联系管理员!原因：" + ex.Message);
            }
        }

        public void op_MenuClick(string TabName, string TabTag)
        {
            string[] excuteSet = TabTag.Split('&');
            if (excuteSet.Length != 4)
            {
                MessageBox.Show("菜单方法配置有误，请联系管理员!");
                return;
            }
            //加载配置DLL
            Assembly assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + excuteSet[0]);
            //加载配置类
            Type type = assembly.GetType(excuteSet[1]);

            object o = assembly.CreateInstance(type.FullName);

            MethodInfo methodInfo = type.GetMethod(excuteSet[2]);

            object obj = methodInfo.Invoke(o, null);
            //ShowType 0:直接执行方法；1:作为子窗体加载；2：作为弹出框加载
            if (int.Parse(excuteSet[3]) == 0)
            {
                MessageBox.Show(obj.ToString());
            }
            else if (int.Parse(excuteSet[3]) == 1)
            {
                Form frm = obj as Form;
                if (!ShowChildrenForm(TabName))
                {
                    //新增一个TabPage页
                    TabPage tp = new TabPage();
                    tabMain.Controls.Add(tp);
                    tp.SuspendLayout();
                    tp.ResumeLayout(false);
                    tp.Location = new System.Drawing.Point(4, 22);
                    tp.Padding = new System.Windows.Forms.Padding(3);
                    tp.Size = new System.Drawing.Size(1206, 719);
                    tp.TabIndex = tabMain.TabCount;
                    tp.Name = "tab" + tabMain.TabCount.ToString();
                    tp.Text = TabName;
                    tp.UseVisualStyleBackColor = true;
                    //把窗体加载到TabPage页中并显示
                    frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    frm.TopLevel = false;
                    //frm.WindowState = FormWindowState.Maximized;
                    frm.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                    frm.Name = "frm" + tabMain.TabCount.ToString();
                    frm.Size = new Size(tabMain.Width - 8, tabMain.Height - 26);

                    tp.Controls.Add(frm);
                    tabMain.SelectedTab = tp;
                    frm.Show();
                    ////显示最右边的关闭按钮
                    //btnClose.Visible = true;

                    ////old
                    //frm.MdiParent = this;
                    //frm.WindowState = FormWindowState.Maximized;
                    //frm.Show();
                }
                else
                {
                    frm.Dispose();
                }
            }
            else if (int.Parse(excuteSet[3]) == 2)
            {
                Form frm = obj as Form;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
        #endregion
        #region 注销LogOff
        public void LogOff(object sender, EventArgs e)
        {
            #region 窗体注销，tab页中的窗体先关闭
            if (tabMain.TabCount > 0)
            {
                foreach (TabPage tp in tabMain.TabPages)
                {
                    if (tp.Name != "tabWelcome" && tp.Name != "tabNotice")
                    {
                        try
                        {
                            Form frm = (Form)tp.Controls.Find(tp.Name.Replace("tab", "frm"), false)[0];
                            frm.Close();
                        }
                        catch { }
                    }
                }
                GC.Collect();
            }
            #endregion
            //注销状态
            frmState = FormState.Logoff;
            LoginOptioner.LogOffUser();
            Logger.Info(LoginInfo.LoginName + "进行注销操作");
            //this.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.Close();
        }
        #endregion
        #region 退出
        public void FormClose(object sender, EventArgs e)
        {
            if (notifyChint != null)
            {
                notifyChint.Dispose();
            }
            #region 窗体关闭，tab页中的窗体先关闭
            if (tabMain.TabCount > 0)
            {
                foreach (TabPage tp in tabMain.TabPages)
                {
                    if (tp.Name != "tabWelcome" && tp.Name != "tabNotice")
                    {
                        try
                        {
                            Form frm = (Form)tp.Controls.Find(tp.Name.Replace("tab", "frm"), false)[0];
                            frm.Close();
                        }
                        catch { }
                    }
                }
                GC.Collect();
            }
            #endregion
            Environment.Exit(0);
        }
        #endregion
        #region 全屏
        public void FormFullScreen(object sender, EventArgs e)
        {
            try
            {
                if (tabMain.SelectedIndex != -1)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Left = 0;
                    this.Top = -3;
                    toolStrip.Visible = false;
                    statusStrip1.Visible = false;
                    tabMain.ItemSize = new Size(0, 1);
                    tabMain.Appearance = TabAppearance.FlatButtons;
                    this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                    this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height + 3;
                }
            }
            catch { }
        }
        #endregion
        #region 取消全屏
        private void tabMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.WindowState = FormWindowState.Maximized;
                toolStrip.Visible = true;
                statusStrip1.Visible = true;
                tabMain.ItemSize = new Size(100, 20);
                tabMain.Appearance = TabAppearance.Normal;
            }
        }
        #endregion
        #region ShowChildrenForm
        public bool ShowChildrenForm(string formName)
        {
            ////old
            //for (int i = 0; i < this.MdiChildren.Length; i++)
            //{
            //    if (this.MdiChildren[i].Name.Equals(formName))
            //    {
            //        this.MdiChildren[i].Activate();
            //        return true;
            //    }
            //}
            //判断tabMain中是否已经有了这个窗体
            for (int i = 0; i < tabMain.TabCount; i++)
            {
                if (tabMain.TabPages[i].Text.Equals(formName))
                {
                    tabMain.SelectedIndex = i;
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region tabMain相关
        #region tabWelcome大小变化，始终保持首页居中
        /// <summary>
        /// tabWelcome大小变化，始终保持首页居中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabWelcome_Resize(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {

            }
        }
        #endregion
        #region 关闭标签页
        #region 最右边的关闭按钮
        /// <summary>
        /// 最右边的关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbClose_Click(object sender, EventArgs e)
        {
            TpClose(tabMain.SelectedIndex);
        }
        #endregion
        #region 选中被右键的TabPage页
        /// <summary>
        /// 选中被右键的TabPage页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < tabMain.TabCount; i++)
                {
                    if (tabMain.GetTabRect(i).Contains(new Point(e.X, e.Y)))
                    {
                        tabMain.SelectedTab = tabMain.TabPages[i];
                    }
                }
            }
        }
        #endregion
        #region 右键菜单中的关闭
        /// <summary>
        /// 右键菜单中的关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiColse_Click(object sender, EventArgs e)
        {
            if (tabMain.TabPages[tabMain.SelectedIndex].Name == "tabWelcome" || tabMain.TabPages[tabMain.SelectedIndex].Name == "tabNotice")
            {
                return;
            }
            TpClose(tabMain.SelectedIndex);
        }
        #endregion
        #region 右键菜单中的退出全屏
        /// <summary>
        /// 右键菜单中的关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiExitFullScreen_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            toolStrip.Visible = true;
            statusStrip1.Visible = true;
            tabMain.ItemSize = new Size(100, 20);
            tabMain.Appearance = TabAppearance.Normal;
        }
        #endregion
        #region 关闭指定序号的TabPage页，关闭方法
        /// <summary>
        /// 关闭指定序号的TabPage页
        /// </summary>
        /// <param name="index"></param>
        private void TpClose(int index)
        {
            if (index > -1)
            {
                if (tabMain.SelectedIndex == index)
                    tabMain.SelectedIndex = index - 1 < 0 ? 0 : index - 1;

                try
                {
                    Form frm = (Form)tabMain.TabPages[index].Controls.Find(tabMain.TabPages[index].Name.Replace("tab", "frm"), false)[0];
                    frm.Close();
                }
                catch { }

                tabMain.Controls.RemoveAt(index);
                //if (tabMain.TabCount <= 0)
                //    btnClose.Visible = false;
            }
            TabMain_MouseLeave(null, null);

            FlushMemory();
        }
        #endregion
        #region 双击TabPage页头部关闭
        /// <summary>
        /// 双击TabPage页头部关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabMain.TabCount; i++)
            {
                if (tabMain.GetTabRect(i).Contains(new Point(e.X, e.Y)))
                {
                    if (tabMain.TabPages[i].Name == "tabWelcome" || tabMain.TabPages[i].Name == "tabNotice")
                    {
                        return;
                    }
                    TpClose(i);
                }
            }
        }
        #endregion
        #region 鼠标滑到哪个TabPage，就在附近显示一个叉
        /// <summary>
        /// 鼠标滑到哪个TabPage，就在附近显示一个叉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabMain_MouseMove(object sender, MouseEventArgs e)
        {
            bool bpbClose2 = false;
            for (int i = 0; i < tabMain.TabCount; i++)
            {
                Rectangle rec = tabMain.GetTabRect(i);
                if (rec.Contains(new Point(e.X, e.Y)))
                {
                    if (tabMain.TabPages[i].Name == "tabWelcome" || tabMain.TabPages[i].Name == "tabNotice")
                    {
                        return;
                    }
                    //tabMain.SelectedTab = tabMain.TabPages[i];
                    bpbClose2 = true;
                    pnlClose2.Left = rec.Left + rec.Width - pnlClose2.Width - 3;
                    if (tabMain.SelectedIndex == i)
                        pnlClose2.Top = 29;
                    else
                        pnlClose2.Top = 31;
                    PageIndex = i;
                }
            }
            pnlClose2.Visible = bpbClose2;
        }
        #endregion
        #region 出现在TabPage附近的关闭按钮
        /// <summary>
        /// 出现在TabPage附近的关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbClose2_Click(object sender, EventArgs e)
        {
            TpClose(PageIndex);
            pnlClose2.Visible = false;
        }
        #endregion
        #region 鼠标离开，隐藏关闭按钮
        /// <summary>
        /// 鼠标离开，隐藏关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabMain_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Point pMouse = this.PointToClient(MousePosition);
                Rectangle rec = tabMain.GetTabRect(PageIndex);
                if (pMouse.X <= panel1.Left + rec.Left || pMouse.X >= panel1.Left + rec.Left + rec.Width || pMouse.Y <= panel1.Top + toolStrip.Height + 1 || pMouse.Y >= panel1.Top + toolStrip.Height + rec.Top + rec.Height)
                    pnlClose2.Visible = false;
            }
            catch { pnlClose2.Visible = false; }
        }
        #endregion
        #endregion
        #endregion
        #region 右下角小图标和退出等
        #region 点击窗体关闭，实际执行最小化到托盘  //窗体关闭，tab页中的窗体先关闭
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (frmState)
            {
                case FormState.Logoff:
                    Program.frmLogin.tbPassword.Text = string.Empty;
                    Program.frmLogin.ActiveControl = Program.frmLogin.tbPassword;
                    Program.frmLogin.Show();
                    break;
                case FormState.Normal:
                    frmState = FormState.Minimizel;
                    e.Cancel = true;
                    notifyChint.ShowBalloonTip(100, "提示", "正泰办公平台已最小化到托盘，重新打开请双击图标", ToolTipIcon.Info);
                    this.Hide();
                    //this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
                    break;
            }
        }
        #endregion
        #region 双击任务栏小图标，重新显示窗口
        private void notifyChint_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmState = FormState.Normal;
            this.Activate();
            this.Show();
        }
        #endregion
        #region 任务栏小图标右键退出
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (notifyChint != null)
            {
                notifyChint.Dispose();
            }
            #region 窗体关闭，tab页中的窗体先关闭
            if (tabMain.TabCount > 0)
            {
                foreach (TabPage tp in tabMain.TabPages)
                {
                    if (tp.Name != "tabWelcome" && tp.Name != "tabNotice")
                    {
                        try
                        {
                            Form frm = (Form)tp.Controls.Find(tp.Name.Replace("tab", "frm"), false)[0];
                            frm.Close();
                        }
                        catch { }
                    }
                }
            }
            #endregion
            Environment.Exit(0);
        }
        #endregion
        #region 窗体关闭时，托盘图标消失
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (notifyChint != null)
            {
                notifyChint.Dispose();
            }
        }
        #endregion
        #endregion
        #region 用户信息
        #region 点击用户名显示用户信息
        private void tsslblLoginName_Click(object sender, EventArgs e)
        {
            try
            {
                bpnlLoginInfoRemain = true;
                pnlLoginInfo.Visible = true;
                notifyIcon1.ShowBalloonTip(30, "111", "1111", ToolTipIcon.Info);
            }
            catch //(Exception err)
            { }
        }
        #endregion
        #region 确认修改
        private void btnLoginOK_Click(object sender, EventArgs e)
        {
            if (!ValidateData())
            {
                return;
            }
            XF.BLL.XF_Users bll = new XF.BLL.XF_Users();
            XF.Model.XF_Users model = bll.GetUserModel(Convert.ToInt32(lblLoginId.Text));
            model.UserName = txtLoginName.Text;
            model.RealName = txtRealName.Text;
            model.Email = txtEmail.Text;
            model.Phone = txtPhone.Text;
            model.LastUpdateDate = DateTime.Now;
            model.LastUpdateUser = LoginInfo.LoginName;
            if (bll.UpdateUser(model) >= 1)
            {
                MessageBox.Show("修改用户信息成功!");
                tsslblRealName.Text = LoginInfo.RealName;
                LoginOptioner.SaveLoginInfo((int)Convert.ToDecimal(lblLoginId.Text), txtLoginName.Text, model.RealName, model.LastLoginTime, model.RoleID, (int)LoginInfo.GroupID, model.IsLimit, model.Status, model.Phone, model.Email, model.WarehouseID, model.LGORT, model.MRP);
                btnLoginCancel_Click(null, null);
            }
            else
            {
                MessageBox.Show("更新用户失败!");
            }
        }
        #endregion
        #region 简单校验输入内容
        /// <summary>
        /// 简单校验输入内容
        /// </summary>
        /// <returns></returns>
        private bool ValidateData()
        {
            if (!txtEmail.Text.Trim().Equals(string.Empty))
            {
                if (!ValidateUtil.IsEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("邮箱格式有误！");
                    return false;
                }
            }
            if (!txtPhone.Text.Trim().Equals(string.Empty))
            {
                if (!ValidateUtil.IsValidMobile(txtPhone.Text.Trim()))
                {
                    MessageBox.Show("联系电话格式有误！");
                    return false;
                }
            }
            return true;
        }
        #endregion
        #region 取消修改
        private void btnLoginCancel_Click(object sender, EventArgs e)
        {
            try
            {
                bpnlLoginInfoRemain = false;
                pnlLoginInfo.Visible = false;
                gbLoginInfo.Enabled = false;
                btnLoginOK.Visible = false;
            }
            catch //(Exception err)
            { }
        }
        #endregion
        #region 鼠标放用户名上显示用户信息
        private void tsslblLoginName_MouseEnter(object sender, EventArgs e)
        {
            pnlLoginInfo.Visible = true;
        }
        #endregion
        #region 鼠标离开用户名，看情况消失用户信息
        private void tsslblLoginName_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (!bpnlLoginInfoRemain)
                    pnlLoginInfo.Visible = false;
            }
            catch //(Exception err)
            { }
        }
        #endregion
        #region 启用编辑
        private void btnLoginEdit_Click(object sender, EventArgs e)
        {
            btnLoginOK.Visible = true;
            gbLoginInfo.Enabled = true;
        }
        #endregion
        #region pnlLoginInfo显示的时候加载最新的用户信息
        private void pnlLoginInfo_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlLoginInfo.Visible)
            {
                lblLoginId.Text = LoginInfo.LoginId.ToString();
                txtLoginName.Text = LoginInfo.LoginName;
                txtRealName.Text = LoginInfo.RealName;
                txtPhone.Text = LoginInfo.Phone;
                txtEmail.Text = LoginInfo.Email;
            }
        }
        #endregion
        #endregion
        #region 及时释放内存
        [DllImport("kernel32.dll")]
        private static extern bool SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        private static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
        }
        #endregion
        #region 通知点击事件
        public void notice_LinklblDetailOnClick(string tabName, string tabTag)
        {
            if (tabName != "" && tabTag != "")
            {
                op_MenuClick(tabName, tabTag);
            }
        }
        #endregion
        #region 缩略图里的退出、注销、全屏
        private void FrmMain_Shown(object sender, EventArgs e)
        {
            #region 2018-10-30 xiarw 不能完美匹配win10字体放大效果，暂时注释
            //ThumbnailToolbarButton tbtnExit = new ThumbnailToolbarButton(Properties.Resources.退出, "退出");
            //tbtnExit.Enabled = true;
            //tbtnExit.Click += tbtnExit_Click;
            //ThumbnailToolbarButton tbtnLogOff = new ThumbnailToolbarButton(Properties.Resources.注销, "注销");
            //tbtnLogOff.Enabled = true;
            //tbtnLogOff.Click += tbtnLogOff_Click;
            //ThumbnailToolbarButton tbtnFullScreen = new ThumbnailToolbarButton(Properties.Resources.全屏, "全屏");
            //tbtnFullScreen.Enabled = true;
            //tbtnFullScreen.Click += tbtnFullScreen_Click;


            ////添加按钮
            //TaskbarManager.Instance.ThumbnailToolbars.AddButtons(this.Handle, tbtnFullScreen, tbtnLogOff, tbtnExit);
            #endregion
        }
        private void tbtnExit_Click(object sender, EventArgs e)
        {
            FormClose(null, null);
        }
        private void tbtnLogOff_Click(object sender, EventArgs e)
        {
            LogOff(null, null);
        }
        private void tbtnFullScreen_Click(object sender, EventArgs e)
        {
            FormFullScreen(null, null);
        }
        #endregion
    }

    /// <summary>
    /// 窗体状态
    /// Normal：正常状态
    /// Minimizel：最小化状态
    /// Logoff：注销状态
    /// </summary>
    public enum FormState
    {
        Normal = 0x00,
        Minimizel = 0x01,
        Logoff = 0x02
    }
}
