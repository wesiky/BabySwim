namespace XF.BaseFunction
{
    partial class FrmConfigList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfigList));
            this.pagerControl1 = new TActionProject.PagerControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCreateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLastUpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLastUpdateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsTbItemName = new System.Windows.Forms.ToolStripTextBox();
            this.tsBtnQuery = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pagerControl1
            // 
            this.pagerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pagerControl1.BackColor = System.Drawing.Color.Transparent;
            this.pagerControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(78)))), ((int)(((byte)(151)))));
            this.pagerControl1.JumpText = "Go";
            this.pagerControl1.Location = new System.Drawing.Point(441, 396);
            this.pagerControl1.Margin = new System.Windows.Forms.Padding(5);
            this.pagerControl1.MaximumSize = new System.Drawing.Size(800, 36);
            this.pagerControl1.MinimumSize = new System.Drawing.Size(800, 36);
            this.pagerControl1.Name = "pagerControl1";
            this.pagerControl1.PageIndex = 1;
            this.pagerControl1.PageSize = 100;
            this.pagerControl1.RecordCount = 0;
            this.pagerControl1.Size = new System.Drawing.Size(800, 36);
            this.pagerControl1.TabIndex = 0;
            this.pagerControl1.OnPageChanged += new System.EventHandler(this.pagerControl1_OnPageChanged);
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
            this.ColItemName,
            this.ColValue,
            this.ColCreateDate,
            this.ColCreateUser,
            this.ColLastUpdateDate,
            this.ColLastUpdateUser,
            this.ColDescription});
            this.dataGridView1.Location = new System.Drawing.Point(0, 30);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1241, 359);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // ColID
            // 
            this.ColID.DataPropertyName = "ItemID";
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColItemName
            // 
            this.ColItemName.DataPropertyName = "ItemName";
            this.ColItemName.HeaderText = "配置项";
            this.ColItemName.Name = "ColItemName";
            this.ColItemName.Width = 180;
            // 
            // ColValue
            // 
            this.ColValue.DataPropertyName = "ItemValue";
            this.ColValue.HeaderText = "配置值";
            this.ColValue.Name = "ColValue";
            this.ColValue.Width = 180;
            // 
            // ColCreateDate
            // 
            this.ColCreateDate.DataPropertyName = "CreateDate";
            this.ColCreateDate.HeaderText = "创建时间";
            this.ColCreateDate.Name = "ColCreateDate";
            this.ColCreateDate.Width = 180;
            // 
            // ColCreateUser
            // 
            this.ColCreateUser.DataPropertyName = "CreateUser";
            this.ColCreateUser.HeaderText = "创建人";
            this.ColCreateUser.Name = "ColCreateUser";
            this.ColCreateUser.Width = 120;
            // 
            // ColLastUpdateDate
            // 
            this.ColLastUpdateDate.DataPropertyName = "LastUpdateDate";
            this.ColLastUpdateDate.HeaderText = "最近修改时间";
            this.ColLastUpdateDate.Name = "ColLastUpdateDate";
            this.ColLastUpdateDate.Width = 180;
            // 
            // ColLastUpdateUser
            // 
            this.ColLastUpdateUser.DataPropertyName = "LastUpdateUser";
            this.ColLastUpdateUser.HeaderText = "修改人";
            this.ColLastUpdateUser.Name = "ColLastUpdateUser";
            this.ColLastUpdateUser.Width = 120;
            // 
            // ColDescription
            // 
            this.ColDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDescription.DataPropertyName = "ItemDescription";
            this.ColDescription.HeaderText = "描述";
            this.ColDescription.Name = "ColDescription";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAdd,
            this.tsBtnSave,
            this.tsBtnDelete,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tsTbItemName,
            this.tsBtnQuery});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1243, 27);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(54, 24);
            this.toolStripLabel1.Text = "配置项";
            // 
            // tsTbItemName
            // 
            this.tsTbItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsTbItemName.Name = "tsTbItemName";
            this.tsTbItemName.Size = new System.Drawing.Size(141, 27);
            // 
            // tsBtnQuery
            // 
            this.tsBtnQuery.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnQuery.Image")));
            this.tsBtnQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnQuery.Name = "tsBtnQuery";
            this.tsBtnQuery.Size = new System.Drawing.Size(59, 24);
            this.tsBtnQuery.Text = "查询";
            this.tsBtnQuery.Click += new System.EventHandler(this.tsBtnQuery_Click);
            // 
            // FrmConfigList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1243, 435);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pagerControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmConfigList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统配置";
            this.Activated += new System.EventHandler(this.FrmConfigList_Activated);
            this.Load += new System.EventHandler(this.FrmConfigList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TActionProject.PagerControl pagerControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tsTbItemName;
        private System.Windows.Forms.ToolStripButton tsBtnQuery;
        private System.Windows.Forms.ToolStripButton tsBtnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCreateUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLastUpdateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLastUpdateUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
    }
}