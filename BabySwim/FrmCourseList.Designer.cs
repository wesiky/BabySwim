namespace BabySwim
{
    partial class FrmCourseList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCourseList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.xfDataGridView1 = new XF.ExControls.XFDataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMaxCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMaxSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAdd,
            this.tsBtnSave,
            this.tsBtnDelete,
            this.tsBtnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(834, 27);
            this.toolStrip1.TabIndex = 1;
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
            // tsBtnRefresh
            // 
            this.tsBtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRefresh.Image")));
            this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefresh.Name = "tsBtnRefresh";
            this.tsBtnRefresh.Size = new System.Drawing.Size(59, 24);
            this.tsBtnRefresh.Text = "刷新";
            this.tsBtnRefresh.Click += new System.EventHandler(this.tsBtnRefresh_Click);
            // 
            // xfDataGridView1
            // 
            this.xfDataGridView1.AllowUserToAddRows = false;
            this.xfDataGridView1.AllowUserToDeleteRows = false;
            this.xfDataGridView1.AllowUserToOrderColumns = true;
            this.xfDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xfDataGridView1.ColumnOrderName = null;
            this.xfDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColName,
            this.ColMaxCount,
            this.ColMaxSection,
            this.ColColor,
            this.ColDescription});
            this.xfDataGridView1.ContextMenuScriptEnable = true;
            this.xfDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xfDataGridView1.Location = new System.Drawing.Point(0, 27);
            this.xfDataGridView1.Name = "xfDataGridView1";
            this.xfDataGridView1.RowTemplate.Height = 27;
            this.xfDataGridView1.Size = new System.Drawing.Size(834, 461);
            this.xfDataGridView1.TabIndex = 2;
            this.xfDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.xfDataGridView1_CellClick);
            this.xfDataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.xfDataGridView1_CellEndEdit);
            // 
            // ColID
            // 
            this.ColID.HeaderText = "课程ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColName
            // 
            this.ColName.HeaderText = "课程名称";
            this.ColName.Name = "ColName";
            // 
            // ColMaxCount
            // 
            this.ColMaxCount.HeaderText = "最大上课人数";
            this.ColMaxCount.Name = "ColMaxCount";
            this.ColMaxCount.Width = 120;
            // 
            // ColMaxSection
            // 
            this.ColMaxSection.HeaderText = "最大节数";
            this.ColMaxSection.Name = "ColMaxSection";
            // 
            // ColColor
            // 
            this.ColColor.HeaderText = "标识色";
            this.ColColor.Name = "ColColor";
            this.ColColor.Width = 75;
            // 
            // ColDescription
            // 
            this.ColDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDescription.HeaderText = "备注";
            this.ColDescription.Name = "ColDescription";
            // 
            // FrmCourseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 488);
            this.Controls.Add(this.xfDataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCourseList";
            this.Text = "课程管理";
            this.Load += new System.EventHandler(this.FrmCourseList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnAdd;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private XF.ExControls.XFDataGridView xfDataGridView1;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMaxCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMaxSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
    }
}