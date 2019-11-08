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
    public partial class FrmModulesCard : Form
    {
        XF.Model.XF_Modules model = new Model.XF_Modules();
        XF.BLL.XF_Modules bll = new BLL.XF_Modules();
        ArrayList authority = new ArrayList();
        public FrmModulesCard(int moduleTypeID,string moduleTypeName)
        {
            InitializeComponent();
            model.ModuleID = -1;
            model.ModuleTypeID = moduleTypeID;
            tbModuleType.Text = moduleTypeName;
            BindShowType();
            BindAuthority();
        }

        public FrmModulesCard(int moduleTypeID, string moduleTypeName, int ModuleID)
        {
            InitializeComponent();
            model.ModuleID = ModuleID;
            tbModuleType.Text = moduleTypeName;
            BindShowType();
            BindAuthority();
            model = bll.GetModuleModel(model.ModuleID);
            tbOrder.Text = model.ModuleOrder.ToString();
            tbName.Text = model.ModuleName;
            if (model.ModuleDisabled)
            {
                rbDisabledNo.Checked = true;
            }
            else
            {
                rbDisabledYes.Checked = true;
            }
            tbTag.Text = model.ModuleTag;
            tbTag.Enabled = false;
            if (model.IsMenu)
            {
                rbDisplayYes.Checked = true;
            }
            else
            {
                rbDisplayNo.Checked = true;
            }
            tbURL.Text = model.ModuleURL;
            tbDecription.Text = model.ModuleDescription;
            cmbShowType.SelectedValue = model.ShowType;
            pbIcon.ImageLocation = model.Icon;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            //校验输入
            if (!CheckInput())
            {
                return;
            } 

            model.ModuleName = tbName.Text.Trim();
            model.ModuleOrder = int.Parse(tbOrder.Text.Trim());
            model.ModuleTag = tbTag.Text.Trim();
            model.ModuleURL = tbURL.Text.Trim();
            model.ShowType = Convert.ToInt32(cmbShowType.SelectedValue);
            model.ModuleDescription = tbDecription.Text;
            if (pbIcon.ImageLocation != null && pbIcon.ImageLocation.Length > 0)
            {
                model.Icon = FileOperater.RelativePath(System.Environment.CurrentDirectory, pbIcon.ImageLocation);
            }
            if (rbDisabledNo.Checked)
            {
                model.ModuleDisabled = true;
            }
            else
            {
                model.ModuleDisabled = false;
            }
            if (rbDisplayYes.Checked)
            {
                model.IsMenu = true;
            }
            else
            {
                model.IsMenu = false;
            }
            //Add
            if (model.ModuleID == -1)
            {
                model.CreateDate = DateTime.Now;
                model.CreateUser = LoginInfo.LoginName;
                model.LastUpdateDate = DateTime.Now;
                model.LastUpdateUser = LoginInfo.LoginName;
                int moduleID = bll.CreateModule(model);
                if (moduleID >= 0)
                {
                    ArrayList list = new ArrayList();//建立事务列表
                    for (int i = 0; i < chkLstAuthority.Items.Count; i++)
                    {
                        if (chkLstAuthority.GetItemChecked(i))
                        {
                            string item = moduleID.ToString() + "|" + (chkLstAuthority.Items[i] as ListItem).Value;
                            list.Add(item);
                        }
                    }
                    //权限加入是否成功！
                    if (bll.CreateAuthorityList(list,LoginInfo.LoginName))
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("权限添加失败！");
                    }
                }
                else if (moduleID == -1)
                {
                    MessageBox.Show("标识" + model.ModuleTag + "已存在，菜单添加失败！");
                }
                else
                {
                    MessageBox.Show("菜单添加失败！");
                }
            }
            //Update
            else
            {
                model.LastUpdateDate = DateTime.Now;
                model.LastUpdateUser = LoginInfo.LoginName;
                int moduleID = bll.UpdateModule(model);
                if (moduleID >= 0)
                {
                    ArrayList list = new ArrayList();//建立事务列表
                    for (int i = 0; i < chkLstAuthority.Items.Count; i++)
                    {
                        ListItem item = chkLstAuthority.Items[i] as ListItem;
                        //初始数据包含，结果未选中，为删除操作
                        if (authority.Contains(item.Value) && !chkLstAuthority.GetItemChecked(i))
                        {
                            string sItem = model.ModuleID.ToString() + "|" + item.Value + "|0";//判断插入增加还是删除
                            list.Add(sItem);
                        }
                        //初始数据不包含，结果选中，为新增操作
                        if (!authority.Contains(item.Value) && chkLstAuthority.GetItemChecked(i))
                        {
                            string sItem = model.ModuleID.ToString() + "|" + item.Value + "|1";//判断插入增加还是删除
                            list.Add(sItem);
                        }
                    }
                    //权限加入是否成功！
                    if (bll.UpdateAuthorityList(list, LoginInfo.LoginName))
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("权限修改失败！");
                    }
                }
                else if (moduleID == -1)
                {
                    MessageBox.Show("标识" + model.ModuleTag + "已存在，菜单修改失败！");
                }
                else
                {
                    MessageBox.Show("菜单添加失败！");
                }
            }
        }

        private void FrmModulesCard_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
        }

        private void BindShowType()
        {
            cmbShowType.DataSource = GenerateData.GetShowType();
        }

        private void BindAuthority()
        {
            DataTable dt = bll.GetAllAuthorityList(model.ModuleID).Tables[0];
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                chkLstAuthority.Items.Add(new ListItem(dt.Rows[i]["AuthorityTag"].ToString(), dt.Rows[i]["AuthorityName"].ToString()));
                if (!string.IsNullOrEmpty(dt.Rows[i]["ModuleID"].ToString()))
                {
                    chkLstAuthority.SetItemChecked(i, true);
                    authority.Add(dt.Rows[i]["AuthorityTag"].ToString());
                }
            }
        }

        private bool CheckInput()
        {
            if (tbTag.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("标识不能为空！");
                return false;
            }
            if (tbName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("名称不能为空！");
                return false;
            }
            if (tbOrder.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("排序不能为空！");
                return false;
            }
            else
            {
                int tmp = 0;
                if (!int.TryParse(tbOrder.Text.Trim(), out tmp))
                {
                    MessageBox.Show("排序必须为数字！");
                    return false;
                }
            }
            if (tbURL.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("调用入口不能为空！");
                return false;
            }
            return true;
        }

        private void chkLstAuthority_Click(object sender, EventArgs e)
        {
            //取反
            chkLstAuthority.SetItemChecked(chkLstAuthority.SelectedIndex, !chkLstAuthority.GetItemChecked(chkLstAuthority.SelectedIndex));
        }

        private void btnChoice_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "图像文件|*.JPG;*.JPEG;*.JPE;*.PNG;";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                pbIcon.ImageLocation = fileDialog.FileName;
                pbIcon.Refresh();
            }
            fileDialog.Dispose();
        }
    }
}
