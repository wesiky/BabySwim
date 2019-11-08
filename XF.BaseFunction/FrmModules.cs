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
    public partial class FrmModules : Form
    {
        XF.BLL.XF_Modules bll = new XF.BLL.XF_Modules();
        int ModuleTypeID = -1;
        private DataTable ModuleTable;

        public FrmModules()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            ColIsMenu.DisplayMember = "Text";
            ColIsMenu.ValueMember = "Value";
            ColIsMenu.DataSource = GenerateData.GetYesNo();
            ColDisabled.DisplayMember = "Text";
            ColDisabled.ValueMember = "Value";
            ColDisabled.DataSource = GenerateData.GetOpenClose();
            ColShowType.DisplayMember = "Text";
            ColShowType.ValueMember = "Value";
            ColShowType.DataSource = GenerateData.GetShowType();
        }

        private void FrmModules_Load(object sender, EventArgs e)
        {
            LoginHandler.InitModule("admin_ModulesPage");
            if (LoginHandler.ValidationHandle(XF_Tag.Browse))//是否有浏览权限
            {
                Logger.Info(LoginInfo.LoginName + "浏览admin_ModulesPage页面");
                this.Icon = ConfigSetting.ProjectIcon;
                BindModuleType();
            }
            else
            {
                MessageBox.Show("您没有对应的权限！");
                this.Close();
            }
            if (!LoginHandler.ValidationHandle(XF_Tag.Add))
            {
                tsBtnAdd.Visible = false;
                tsBtnModuleAdd.Visible = false;
            }
            if (!LoginHandler.ValidationHandle(XF_Tag.Edit))
            {
                tbName.ReadOnly = true;
                tbOrder.ReadOnly = true;
                tbDescription.ReadOnly = true;
                tsBtnModuleUpdate.Visible = false;
            }
            if (!LoginHandler.ValidationHandle(XF_Tag.Add)&&!LoginHandler.ValidationHandle(XF_Tag.Edit))
            {
                tsBtnSave.Visible = false;
            }
            if (!LoginHandler.ValidationHandle(XF_Tag.Delete))
            {
                tsBtnDelete.Visible = false;
                tsBtnModuleDelete.Visible = false;
            }
        }

        private void BindModuleType()
        {
            ModuleTable = bll.GetModuleTypeList("").Tables[0];  //取得所有数据得到DataTable 
            DataTable dt = ModuleTable.Copy();
            DataRow dr = dt.NewRow();
            dr["ModuleTypeID"] = 0;
            dr["ModuleTypeName"] = "无";
            dt.Rows.InsertAt(dr, 0);
            cmbSuperior.DataSource = dt;
            tvModulesType.Nodes.Clear();
            LoadNode(tvModulesType.Nodes, "0"); //建立节点 
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataRowView dr = e.Node.Tag as DataRowView;
            ModuleTypeID = int.Parse(dr["ModuleTypeID"].ToString());
            cmbSuperior.SelectedValue = int.Parse(dr["ModuleTypeSuperiorID"].ToString());
            tbName.Enabled = false;
            tbName.Text = dr["ModuleTypeName"].ToString();
            tbOrder.Text = dr["ModuleTypeOrder"].ToString();
            tbDescription.Text = dr["ModuleTypeDescription"].ToString();
            pbIcon.ImageLocation = dr["Icon"].ToString();
            pbIcon.Refresh();
            BindModules();
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (tvModulesType.SelectedNode == null)
            {
                MessageBox.Show("请选择目录！");
            }
            else
            {
                DataRowView dr = tvModulesType.SelectedNode.Tag as DataRowView;
                int ret = bll.DeleteModuleType(int.Parse(dr["ModuleTypeID"].ToString()));
                if (ret == -1)
                {
                    MessageBox.Show("删除目录失败，请先删除子菜单！");
                    return;
                }
                else if (ret == -2)
                {
                    MessageBox.Show("删除目录失败，请先删除子目录！");
                    return;
                }
                BindModuleType();
            }
        }

        private void tsBtnAdd_Click(object sender, EventArgs e)
        {
            tbName.Enabled = true;
            ClearInput();
        }

        /// <summary>
        /// 清楚输入
        /// </summary>
        private void ClearInput()
        {
            cmbSuperior.SelectedIndex = 0;
            ModuleTypeID = -1;
            tbName.Text = string.Empty;
            tbOrder.Text = string.Empty;
            tbDescription.Text = string.Empty;
            dataGridView1.DataSource = null;
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }
            XF.Model.XF_ModuleType model = new Model.XF_ModuleType();
            model.ModuleTypeID = ModuleTypeID;
            model.ModuleTypeSuperiorID = int.Parse(cmbSuperior.SelectedValue.ToString());
            model.ModuleTypeName = tbName.Text.Trim();
            model.ModuleTypeOrder = int.Parse(tbOrder.Text.Trim());
            model.ModuleTypeDescription = tbDescription.Text;
            if (pbIcon.ImageLocation.Length > 0)
            {
                model.Icon = FileOperater.RelativePath(System.Environment.CurrentDirectory, pbIcon.ImageLocation);
            }
            //新增
            if (ModuleTypeID == -1)
            {
                model.ModuleTypeDepth = 1;
                model.ModuleTypeCount = 0;
                model.CreateDate = DateTime.Now;
                model.CreateUser = LoginInfo.LoginName;
                model.LastUpdateDate = DateTime.Now;
                model.LastUpdateUser = LoginInfo.LoginName;
                int ret = bll.CreateModuleType(model);
                if (ret >= 0)
                {
                    BindModuleType();
                }
                else if (ret == -1)
                {
                    MessageBox.Show("目录"+ model.ModuleTypeName + "已存在，新增目录失败！");
                }
                else
                {
                    MessageBox.Show("新增目录失败！");
                }
            }
            //修改
            else
            {
                DataRowView dr = tvModulesType.SelectedNode.Tag as DataRowView;
                model.ModuleTypeDepth = int.Parse(dr["ModuleTypeDepth"].ToString());
                model.ModuleTypeCount = int.Parse(dr["ModuleTypeCount"].ToString());
                model.LastUpdateDate = DateTime.Now;
                model.LastUpdateUser = LoginInfo.LoginName;
                if (bll.UpdateModuleType(model))
                {
                    BindModuleType();
                }
                else
                {
                    MessageBox.Show("修改目录失败！");
                }
            }
            MessageBox.Show("保存成功");
        }

        /// <summary>
        /// 检查输入项
        /// </summary>
        /// <param name="index"></param>
        private bool CheckInput()
        {
            if (ModuleTypeID != -1)
            {
                if (tvModulesType.SelectedNode == null)
                {
                    MessageBox.Show("请先选择目录");
                    return false;
                }
            }
            if (ModuleTypeID == int.Parse(cmbSuperior.SelectedValue.ToString()))
            {
                MessageBox.Show("上级目录不能为自身！");
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
            return true;
        }

        /// <summary>
        /// 加载菜单
        /// </summary>
        /// <param name="ModuleTypeID"></param>
        private void BindModules()
        {
            dataGridView1.DataSource = bll.GetModuleList(" and ModuleTypeID = " + ModuleTypeID.ToString()).Tables[0];
        }

        private void tsBtnModuleAdd_Click(object sender, EventArgs e)
        {
            DataRowView dr = tvModulesType.SelectedNode.Tag as DataRowView;
            FrmModulesCard frmModulesCard = new FrmModulesCard(int.Parse(dr["ModuleTypeID"].ToString()), dr["ModuleTypeName"].ToString());
            frmModulesCard.StartPosition = FormStartPosition.CenterScreen;
            if (frmModulesCard.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BindModules();
            }
        }

        private void tsBtnModuleUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行记录进行修改！");
                return;
            }
            DataRowView dr = tvModulesType.SelectedNode.Tag as DataRowView;
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells["ColID"].Value.ToString());
            FrmModulesCard frmModulesCard = new FrmModulesCard(int.Parse(dr["ModuleTypeID"].ToString()), dr["ModuleTypeName"].ToString(),id);
            frmModulesCard.StartPosition = FormStartPosition.CenterScreen;
            if (frmModulesCard.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BindModules();
            }
        }

        private void tsBtnModuleDelete_Click(object sender, EventArgs e)
        {
            string IDs = "";
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                IDs += "," + r.Cells["ColID"].Value.ToString();
            }
            if (bll.DeleteModules(IDs.Substring(1)))
            {
                BindModules();
            }
            else
            {
                MessageBox.Show("删除操作失败!");
            }
        }

        private void FrmModules_Activated(object sender, EventArgs e)
        {
            BindModuleType();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            System.Drawing.Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Y, this.dataGridView1.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), this.dataGridView1.RowHeadersDefaultCellStyle.Font, rectangle, this.dataGridView1.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
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

        private void pbIcon_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
