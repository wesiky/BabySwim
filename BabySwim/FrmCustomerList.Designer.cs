namespace BabySwim
{
    partial class FrmCustomerList
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsBtnLook = new System.Windows.Forms.ToolStripButton();
            this.tsBtnImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
            this.tsTbInfoSource = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsTbFollowInfo = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsTbFollowUser = new System.Windows.Forms.ToolStripTextBox();
            this.tsBtnSearch = new System.Windows.Forms.ToolStripButton();
            this.pagerControl1 = new TActionProject.PagerControl();
            this.dataGridView1 = new XF.ExControls.XFDataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCoursePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInfoSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFollowInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFollowUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVisitInfo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColVisitDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAdd,
            this.tsBtnUpdate,
            this.tsBtnDelete,
            this.tsBtnLook,
            this.tsBtnImport,
            this.toolStripSeparator1,
            this.toolStripLabel3,
            this.toolStripLabel4,
            this.toolStripLabel7,
            this.toolStripLabel5,
            this.toolStripLabel6,
            this.toolStripLabel8,
            this.tsTbInfoSource,
            this.toolStripLabel1,
            this.tsTbFollowInfo,
            this.toolStripLabel2,
            this.tsTbFollowUser,
            this.tsBtnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(888, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnAdd
            // 
            this.tsBtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAdd.Image")));
            this.tsBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAdd.Name = "tsBtnAdd";
            this.tsBtnAdd.Size = new System.Drawing.Size(52, 22);
            this.tsBtnAdd.Text = "新增";
            this.tsBtnAdd.Click += new System.EventHandler(this.tsBtnAdd_Click);
            // 
            // tsBtnUpdate
            // 
            this.tsBtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnUpdate.Image")));
            this.tsBtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnUpdate.Name = "tsBtnUpdate";
            this.tsBtnUpdate.Size = new System.Drawing.Size(52, 22);
            this.tsBtnUpdate.Text = "修改";
            this.tsBtnUpdate.Click += new System.EventHandler(this.tsBtnUpdate_Click);
            // 
            // tsBtnDelete
            // 
            this.tsBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDelete.Image")));
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Size = new System.Drawing.Size(52, 22);
            this.tsBtnDelete.Text = "删除";
            this.tsBtnDelete.Click += new System.EventHandler(this.tsBtnDelete_Click);
            // 
            // tsBtnLook
            // 
            this.tsBtnLook.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnLook.Image")));
            this.tsBtnLook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnLook.Name = "tsBtnLook";
            this.tsBtnLook.Size = new System.Drawing.Size(52, 22);
            this.tsBtnLook.Text = "查看";
            this.tsBtnLook.Click += new System.EventHandler(this.tsBtnLook_Click);
            // 
            // tsBtnImport
            // 
            this.tsBtnImport.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnImport.Image")));
            this.tsBtnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnImport.Name = "tsBtnImport";
            this.tsBtnImport.Size = new System.Drawing.Size(52, 22);
            this.tsBtnImport.Text = "导入";
            this.tsBtnImport.Click += new System.EventHandler(this.tsBtnImport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel3.Text = "创建日期";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel4.Text = "至";
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(12, 22);
            this.toolStripLabel7.Text = " ";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel5.Text = "更新日期";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel6.Text = "-";
            // 
            // toolStripLabel8
            // 
            this.toolStripLabel8.Name = "toolStripLabel8";
            this.toolStripLabel8.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel8.Text = "名单来源";
            // 
            // tsTbInfoSource
            // 
            this.tsTbInfoSource.Name = "tsTbInfoSource";
            this.tsTbInfoSource.Size = new System.Drawing.Size(76, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel1.Text = "跟单情况";
            // 
            // tsTbFollowInfo
            // 
            this.tsTbFollowInfo.Name = "tsTbFollowInfo";
            this.tsTbFollowInfo.Size = new System.Drawing.Size(91, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel2.Text = "跟单人员";
            // 
            // tsTbFollowUser
            // 
            this.tsTbFollowUser.Name = "tsTbFollowUser";
            this.tsTbFollowUser.Size = new System.Drawing.Size(91, 25);
            // 
            // tsBtnSearch
            // 
            this.tsBtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSearch.Image")));
            this.tsBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSearch.Name = "tsBtnSearch";
            this.tsBtnSearch.Size = new System.Drawing.Size(52, 24);
            this.tsBtnSearch.Text = "搜索";
            this.tsBtnSearch.Click += new System.EventHandler(this.tsBtnSearch_Click);
            // 
            // pagerControl1
            // 
            this.pagerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pagerControl1.BackColor = System.Drawing.Color.Transparent;
            this.pagerControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(78)))), ((int)(((byte)(151)))));
            this.pagerControl1.JumpText = "Go";
            this.pagerControl1.Location = new System.Drawing.Point(288, 442);
            this.pagerControl1.MaximumSize = new System.Drawing.Size(600, 29);
            this.pagerControl1.MinimumSize = new System.Drawing.Size(600, 29);
            this.pagerControl1.Name = "pagerControl1";
            this.pagerControl1.PageIndex = 1;
            this.pagerControl1.PageSize = 100;
            this.pagerControl1.RecordCount = 0;
            this.pagerControl1.Size = new System.Drawing.Size(600, 29);
            this.pagerControl1.TabIndex = 2;
            this.pagerControl1.OnPageChanged += new System.EventHandler(this.pagerControl1_OnPageChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnOrderName = null;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColCode,
            this.ColName,
            this.ColPhone,
            this.ColAge,
            this.ColBirthday,
            this.ColCoursePrice,
            this.ColInfoSource,
            this.ColFollowInfo,
            this.ColFollowUser,
            this.ColVisitInfo,
            this.ColVisitDate,
            this.ColDescription});
            this.dataGridView1.ContextMenuScriptEnable = true;
            this.dataGridView1.Location = new System.Drawing.Point(0, 22);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(888, 414);
            this.dataGridView1.TabIndex = 1;
            // 
            // ColID
            // 
            this.ColID.HeaderText = "客户ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColCode
            // 
            this.ColCode.HeaderText = "客户编号";
            this.ColCode.MinimumWidth = 100;
            this.ColCode.Name = "ColCode";
            this.ColCode.ReadOnly = true;
            // 
            // ColName
            // 
            this.ColName.HeaderText = "客户姓名";
            this.ColName.MinimumWidth = 100;
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColPhone
            // 
            this.ColPhone.HeaderText = "联系号码";
            this.ColPhone.MinimumWidth = 100;
            this.ColPhone.Name = "ColPhone";
            this.ColPhone.ReadOnly = true;
            // 
            // ColAge
            // 
            this.ColAge.HeaderText = "年龄";
            this.ColAge.MinimumWidth = 100;
            this.ColAge.Name = "ColAge";
            this.ColAge.ReadOnly = true;
            // 
            // ColBirthday
            // 
            dataGridViewCellStyle1.Format = "yyyy-MM-dd";
            dataGridViewCellStyle1.NullValue = null;
            this.ColBirthday.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColBirthday.HeaderText = "出生日期";
            this.ColBirthday.Name = "ColBirthday";
            this.ColBirthday.ReadOnly = true;
            this.ColBirthday.Visible = false;
            // 
            // ColCoursePrice
            // 
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.ColCoursePrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColCoursePrice.HeaderText = "售课价格";
            this.ColCoursePrice.MinimumWidth = 100;
            this.ColCoursePrice.Name = "ColCoursePrice";
            this.ColCoursePrice.ReadOnly = true;
            // 
            // ColInfoSource
            // 
            this.ColInfoSource.HeaderText = "名单来源";
            this.ColInfoSource.MinimumWidth = 100;
            this.ColInfoSource.Name = "ColInfoSource";
            this.ColInfoSource.ReadOnly = true;
            // 
            // ColFollowInfo
            // 
            this.ColFollowInfo.HeaderText = "跟单情况";
            this.ColFollowInfo.MinimumWidth = 100;
            this.ColFollowInfo.Name = "ColFollowInfo";
            this.ColFollowInfo.ReadOnly = true;
            // 
            // ColFollowUser
            // 
            this.ColFollowUser.HeaderText = "跟单人员";
            this.ColFollowUser.MinimumWidth = 100;
            this.ColFollowUser.Name = "ColFollowUser";
            this.ColFollowUser.ReadOnly = true;
            // 
            // ColVisitInfo
            // 
            this.ColVisitInfo.HeaderText = "到访情况";
            this.ColVisitInfo.MinimumWidth = 100;
            this.ColVisitInfo.Name = "ColVisitInfo";
            this.ColVisitInfo.ReadOnly = true;
            this.ColVisitInfo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColVisitInfo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColVisitDate
            // 
            dataGridViewCellStyle3.Format = "yyyy-MM-dd";
            dataGridViewCellStyle3.NullValue = null;
            this.ColVisitDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColVisitDate.HeaderText = "到访日期";
            this.ColVisitDate.MinimumWidth = 100;
            this.ColVisitDate.Name = "ColVisitDate";
            this.ColVisitDate.ReadOnly = true;
            // 
            // ColDescription
            // 
            this.ColDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDescription.HeaderText = "备注";
            this.ColDescription.MinimumWidth = 100;
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.ReadOnly = true;
            // 
            // FrmCustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 471);
            this.Controls.Add(this.pagerControl1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmCustomerList";
            this.Text = "客户信息管理";
            this.Load += new System.EventHandler(this.FrmCustomerList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private XF.ExControls.XFDataGridView dataGridView1;
        private TActionProject.PagerControl pagerControl1;
        private System.Windows.Forms.ToolStripButton tsBtnAdd;
        private System.Windows.Forms.ToolStripButton tsBtnUpdate;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.ToolStripButton tsBtnImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tsTbFollowUser;
        private System.Windows.Forms.ToolStripButton tsBtnSearch;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.ToolStripButton tsBtnLook;
        private System.Windows.Forms.ToolStripTextBox tsTbFollowInfo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel8;
        private System.Windows.Forms.ToolStripTextBox tsTbInfoSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBirthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCoursePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInfoSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFollowInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFollowUser;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColVisitInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVisitDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
    }
}

