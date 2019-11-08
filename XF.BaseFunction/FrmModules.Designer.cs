namespace XF.BaseFunction
{
    partial class FrmModules
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModules));
            this.tvModulesType = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnChoice = new XF.ExControls.QQButton();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDisabled = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColIsMenu = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColShowType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsBtnModuleAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnModuleUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsBtnModuleDelete = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbOrder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSuperior = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.generateDataBindingSource = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generateDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tvModulesType
            // 
            this.tvModulesType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvModulesType.Location = new System.Drawing.Point(11, 10);
            this.tvModulesType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tvModulesType.Name = "tvModulesType";
            this.tvModulesType.Size = new System.Drawing.Size(214, 423);
            this.tvModulesType.TabIndex = 0;
            this.tvModulesType.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvModulesType);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnChoice);
            this.splitContainer1.Panel2.Controls.Add(this.pbIcon);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.tbDescription);
            this.splitContainer1.Panel2.Controls.Add(this.tbOrder);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.tbName);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.cmbSuperior);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Size = new System.Drawing.Size(1461, 445);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnChoice
            // 
            this.btnChoice.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnChoice.Location = new System.Drawing.Point(391, 6);
            this.btnChoice.Name = "btnChoice";
            this.btnChoice.Size = new System.Drawing.Size(50, 25);
            this.btnChoice.TabIndex = 14;
            this.btnChoice.Text = "选择";
            this.btnChoice.UseVisualStyleBackColor = true;
            this.btnChoice.Click += new System.EventHandler(this.btnChoice_Click);
            // 
            // pbIcon
            // 
            this.pbIcon.Location = new System.Drawing.Point(360, 6);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(25, 25);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIcon.TabIndex = 13;
            this.pbIcon.TabStop = false;
            this.pbIcon.Click += new System.EventHandler(this.pbIcon_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(317, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "图标";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColName,
            this.ColTag,
            this.ColDisabled,
            this.ColIsMenu,
            this.ColOrder,
            this.ColShowType,
            this.ColURL,
            this.ColDescription});
            this.dataGridView1.Location = new System.Drawing.Point(3, 169);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1209, 264);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "ModuleID";
            this.ColID.HeaderText = "编号";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColName
            // 
            this.ColName.DataPropertyName = "ModuleName";
            this.ColName.HeaderText = "菜单名";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            this.ColName.Width = 180;
            // 
            // ColTag
            // 
            this.ColTag.DataPropertyName = "ModuleTag";
            this.ColTag.HeaderText = "标识";
            this.ColTag.Name = "ColTag";
            this.ColTag.ReadOnly = true;
            this.ColTag.Width = 180;
            // 
            // ColDisabled
            // 
            this.ColDisabled.DataPropertyName = "ModuleDisabled";
            this.ColDisabled.HeaderText = "状态";
            this.ColDisabled.Name = "ColDisabled";
            this.ColDisabled.ReadOnly = true;
            this.ColDisabled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColDisabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColIsMenu
            // 
            this.ColIsMenu.DataPropertyName = "IsMenu";
            this.ColIsMenu.HeaderText = "是否显示";
            this.ColIsMenu.Name = "ColIsMenu";
            this.ColIsMenu.ReadOnly = true;
            this.ColIsMenu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColIsMenu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColOrder
            // 
            this.ColOrder.DataPropertyName = "ModuleOrder";
            this.ColOrder.HeaderText = "排序";
            this.ColOrder.Name = "ColOrder";
            this.ColOrder.ReadOnly = true;
            this.ColOrder.Width = 80;
            // 
            // ColShowType
            // 
            this.ColShowType.DataPropertyName = "ShowType";
            this.ColShowType.HeaderText = "显示方式";
            this.ColShowType.Name = "ColShowType";
            this.ColShowType.ReadOnly = true;
            this.ColShowType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColShowType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColShowType.Width = 140;
            // 
            // ColURL
            // 
            this.ColURL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColURL.DataPropertyName = "ModuleURL";
            this.ColURL.HeaderText = "调用入口";
            this.ColURL.Name = "ColURL";
            this.ColURL.ReadOnly = true;
            // 
            // ColDescription
            // 
            this.ColDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDescription.DataPropertyName = "ModuleDescription";
            this.ColDescription.HeaderText = "说明";
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.ReadOnly = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnModuleAdd,
            this.tsBtnModuleUpdate,
            this.tsBtnModuleDelete});
            this.toolStrip2.Location = new System.Drawing.Point(0, 141);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1223, 27);
            this.toolStrip2.TabIndex = 9;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsBtnModuleAdd
            // 
            this.tsBtnModuleAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnModuleAdd.Image")));
            this.tsBtnModuleAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnModuleAdd.Name = "tsBtnModuleAdd";
            this.tsBtnModuleAdd.Size = new System.Drawing.Size(59, 24);
            this.tsBtnModuleAdd.Text = "新增";
            this.tsBtnModuleAdd.Click += new System.EventHandler(this.tsBtnModuleAdd_Click);
            // 
            // tsBtnModuleUpdate
            // 
            this.tsBtnModuleUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnModuleUpdate.Image")));
            this.tsBtnModuleUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnModuleUpdate.Name = "tsBtnModuleUpdate";
            this.tsBtnModuleUpdate.Size = new System.Drawing.Size(59, 24);
            this.tsBtnModuleUpdate.Text = "修改";
            this.tsBtnModuleUpdate.Click += new System.EventHandler(this.tsBtnModuleUpdate_Click);
            // 
            // tsBtnModuleDelete
            // 
            this.tsBtnModuleDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnModuleDelete.Image")));
            this.tsBtnModuleDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnModuleDelete.Name = "tsBtnModuleDelete";
            this.tsBtnModuleDelete.Size = new System.Drawing.Size(59, 24);
            this.tsBtnModuleDelete.Text = "删除";
            this.tsBtnModuleDelete.Click += new System.EventHandler(this.tsBtnModuleDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "说明";
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(360, 58);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(852, 75);
            this.tbDescription.TabIndex = 7;
            // 
            // tbOrder
            // 
            this.tbOrder.Location = new System.Drawing.Point(88, 108);
            this.tbOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbOrder.Name = "tbOrder";
            this.tbOrder.Size = new System.Drawing.Size(180, 25);
            this.tbOrder.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "排序";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(88, 58);
            this.tbName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(180, 25);
            this.tbName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "类型名称";
            // 
            // cmbSuperior
            // 
            this.cmbSuperior.DisplayMember = "ModuleTypeName";
            this.cmbSuperior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuperior.FormattingEnabled = true;
            this.cmbSuperior.Location = new System.Drawing.Point(88, 8);
            this.cmbSuperior.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSuperior.Name = "cmbSuperior";
            this.cmbSuperior.Size = new System.Drawing.Size(180, 23);
            this.cmbSuperior.TabIndex = 2;
            this.cmbSuperior.ValueMember = "ModuleTypeID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "上级目录";
            // 
            // splitter1
            // 
            this.splitter1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1223, 141);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAdd,
            this.tsBtnSave,
            this.tsBtnDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1461, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnAdd
            // 
            this.tsBtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAdd.Image")));
            this.tsBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAdd.Name = "tsBtnAdd";
            this.tsBtnAdd.Size = new System.Drawing.Size(59, 24);
            this.tsBtnAdd.Text = "新增";
            this.tsBtnAdd.Click += new System.EventHandler(this.tsBtnAdd_Click);
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSave.Image")));
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(59, 24);
            this.tsBtnSave.Text = "保存";
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // tsBtnDelete
            // 
            this.tsBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDelete.Image")));
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Size = new System.Drawing.Size(59, 24);
            this.tsBtnDelete.Text = "删除";
            this.tsBtnDelete.Click += new System.EventHandler(this.tsBtnDelete_Click);
            // 
            // generateDataBindingSource
            // 
            this.generateDataBindingSource.DataSource = typeof(XF.Common.GenerateData);
            // 
            // FrmModules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1461, 475);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmModules";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "菜单目录管理";
            this.Activated += new System.EventHandler(this.FrmModules_Activated);
            this.Load += new System.EventHandler(this.FrmModules_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generateDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvModulesType;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnAdd;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSuperior;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsBtnModuleAdd;
        private System.Windows.Forms.ToolStripButton tsBtnModuleUpdate;
        private System.Windows.Forms.ToolStripButton tsBtnModuleDelete;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.BindingSource generateDataBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTag;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColDisabled;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColIsMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOrder;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColShowType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbIcon;
        private ExControls.QQButton btnChoice;
    }
}