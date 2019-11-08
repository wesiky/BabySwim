namespace BabySwim
{
    partial class FrmFamilyList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFamilyList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pagerControl1 = new TActionProject.PagerControl();
            this.xfDataGridView1 = new XF.ExControls.XFDataGridView();
            this.ColFamilyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFamilyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFamilyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCourseCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsTbFamily = new System.Windows.Forms.ToolStripTextBox();
            this.tsBtnSearch = new System.Windows.Forms.ToolStripButton();
            this.xfDataGridView2 = new XF.ExControls.XFDataGridView();
            this.ColStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBirthdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTeacher = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColAdviser = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCourse = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsBtnStudentAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnStudentSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnStudentDelete = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRefresh = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView2)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pagerControl1);
            this.splitContainer1.Panel1.Controls.Add(this.xfDataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.xfDataGridView2);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Size = new System.Drawing.Size(690, 449);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // pagerControl1
            // 
            this.pagerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pagerControl1.BackColor = System.Drawing.Color.Transparent;
            this.pagerControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(78)))), ((int)(((byte)(151)))));
            this.pagerControl1.JumpText = "Go";
            this.pagerControl1.Location = new System.Drawing.Point(90, 193);
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
            // xfDataGridView1
            // 
            this.xfDataGridView1.AllowUserToAddRows = false;
            this.xfDataGridView1.AllowUserToDeleteRows = false;
            this.xfDataGridView1.AllowUserToOrderColumns = true;
            this.xfDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xfDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xfDataGridView1.ColumnOrderName = null;
            this.xfDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColFamilyID,
            this.ColFamilyCode,
            this.ColFamilyName,
            this.ColCourseCount,
            this.ColPhone,
            this.ColDescription});
            this.xfDataGridView1.ContextMenuScriptEnable = true;
            this.xfDataGridView1.Location = new System.Drawing.Point(0, 24);
            this.xfDataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.xfDataGridView1.Name = "xfDataGridView1";
            this.xfDataGridView1.RowTemplate.Height = 27;
            this.xfDataGridView1.Size = new System.Drawing.Size(690, 163);
            this.xfDataGridView1.TabIndex = 1;
            this.xfDataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.xfDataGridView1_CellEndEdit);
            this.xfDataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.xfDataGridView1_CellValueChanged);
            this.xfDataGridView1.CurrentCellChanged += new System.EventHandler(this.xfDataGridView1_CurrentCellChanged);
            // 
            // ColFamilyID
            // 
            this.ColFamilyID.HeaderText = "家长ID";
            this.ColFamilyID.Name = "ColFamilyID";
            this.ColFamilyID.ReadOnly = true;
            this.ColFamilyID.Visible = false;
            // 
            // ColFamilyCode
            // 
            this.ColFamilyCode.HeaderText = "家长编号";
            this.ColFamilyCode.Name = "ColFamilyCode";
            // 
            // ColFamilyName
            // 
            this.ColFamilyName.HeaderText = "家长姓名";
            this.ColFamilyName.Name = "ColFamilyName";
            // 
            // ColCourseCount
            // 
            this.ColCourseCount.HeaderText = "剩余课时";
            this.ColCourseCount.Name = "ColCourseCount";
            // 
            // ColPhone
            // 
            this.ColPhone.HeaderText = "联系方式";
            this.ColPhone.Name = "ColPhone";
            this.ColPhone.Width = 120;
            // 
            // ColDescription
            // 
            this.ColDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDescription.HeaderText = "备注";
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
            this.tsTbFamily,
            this.tsBtnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(690, 25);
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
            // tsBtnSave
            // 
            this.tsBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSave.Image")));
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(52, 22);
            this.tsBtnSave.Text = "保存";
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel1.Text = "家长";
            // 
            // tsTbFamily
            // 
            this.tsTbFamily.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tsTbFamily.Name = "tsTbFamily";
            this.tsTbFamily.Size = new System.Drawing.Size(91, 25);
            // 
            // tsBtnSearch
            // 
            this.tsBtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSearch.Image")));
            this.tsBtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSearch.Name = "tsBtnSearch";
            this.tsBtnSearch.Size = new System.Drawing.Size(52, 22);
            this.tsBtnSearch.Text = "搜索";
            this.tsBtnSearch.Click += new System.EventHandler(this.tsBtnSearch_Click);
            // 
            // xfDataGridView2
            // 
            this.xfDataGridView2.AllowUserToAddRows = false;
            this.xfDataGridView2.AllowUserToDeleteRows = false;
            this.xfDataGridView2.AllowUserToOrderColumns = true;
            this.xfDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xfDataGridView2.ColumnOrderName = null;
            this.xfDataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColStudentID,
            this.ColStudentCode,
            this.ColStudentName,
            this.ColNickName,
            this.ColBirthdate,
            this.ColTeacher,
            this.ColAdviser,
            this.ColBirthday,
            this.ColCourse,
            this.ColProgress,
            this.ColStudentDescription});
            this.xfDataGridView2.ContextMenuScriptEnable = true;
            this.xfDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xfDataGridView2.Location = new System.Drawing.Point(0, 25);
            this.xfDataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.xfDataGridView2.Name = "xfDataGridView2";
            this.xfDataGridView2.RowTemplate.Height = 27;
            this.xfDataGridView2.Size = new System.Drawing.Size(690, 196);
            this.xfDataGridView2.TabIndex = 1;
            this.xfDataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.xfDataGridView2_CellClick);
            this.xfDataGridView2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.xfDataGridView2_CellEndEdit);
            this.xfDataGridView2.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.xfDataGridView2_ColumnWidthChanged);
            this.xfDataGridView2.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.xfDataGridView2_DataError);
            this.xfDataGridView2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.xfDataGridView2_Scroll);
            // 
            // ColStudentID
            // 
            this.ColStudentID.HeaderText = "学员ID";
            this.ColStudentID.Name = "ColStudentID";
            this.ColStudentID.ReadOnly = true;
            this.ColStudentID.Visible = false;
            // 
            // ColStudentCode
            // 
            this.ColStudentCode.HeaderText = "学员编号";
            this.ColStudentCode.Name = "ColStudentCode";
            // 
            // ColStudentName
            // 
            this.ColStudentName.HeaderText = "学员姓名";
            this.ColStudentName.Name = "ColStudentName";
            // 
            // ColNickName
            // 
            this.ColNickName.HeaderText = "昵称";
            this.ColNickName.Name = "ColNickName";
            // 
            // ColBirthdate
            // 
            dataGridViewCellStyle1.Format = "yyyy-MM-dd";
            this.ColBirthdate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColBirthdate.HeaderText = "出生日期";
            this.ColBirthdate.Name = "ColBirthdate";
            // 
            // ColTeacher
            // 
            this.ColTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColTeacher.HeaderText = "执教老师";
            this.ColTeacher.Name = "ColTeacher";
            this.ColTeacher.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColTeacher.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColAdviser
            // 
            this.ColAdviser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColAdviser.HeaderText = "顾问老师";
            this.ColAdviser.Name = "ColAdviser";
            this.ColAdviser.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColAdviser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColBirthday
            // 
            dataGridViewCellStyle2.Format = "MM-dd";
            this.ColBirthday.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColBirthday.HeaderText = "农历生日";
            this.ColBirthday.Name = "ColBirthday";
            this.ColBirthday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColCourse
            // 
            this.ColCourse.HeaderText = "课程名称";
            this.ColCourse.Name = "ColCourse";
            // 
            // ColProgress
            // 
            this.ColProgress.HeaderText = "进度";
            this.ColProgress.Name = "ColProgress";
            this.ColProgress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColProgress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColStudentDescription
            // 
            this.ColStudentDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColStudentDescription.HeaderText = "备注";
            this.ColStudentDescription.MinimumWidth = 100;
            this.ColStudentDescription.Name = "ColStudentDescription";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnStudentAdd,
            this.tsBtnStudentSave,
            this.tsBtnStudentDelete,
            this.tsBtnRefresh});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(690, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsBtnStudentAdd
            // 
            this.tsBtnStudentAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnStudentAdd.Image")));
            this.tsBtnStudentAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnStudentAdd.Name = "tsBtnStudentAdd";
            this.tsBtnStudentAdd.Size = new System.Drawing.Size(52, 22);
            this.tsBtnStudentAdd.Text = "新增";
            this.tsBtnStudentAdd.Click += new System.EventHandler(this.tsBtnStudentAdd_Click);
            // 
            // tsBtnStudentSave
            // 
            this.tsBtnStudentSave.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnStudentSave.Image")));
            this.tsBtnStudentSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnStudentSave.Name = "tsBtnStudentSave";
            this.tsBtnStudentSave.Size = new System.Drawing.Size(52, 22);
            this.tsBtnStudentSave.Text = "保存";
            this.tsBtnStudentSave.Click += new System.EventHandler(this.tsBtnStudentSave_Click);
            // 
            // tsBtnStudentDelete
            // 
            this.tsBtnStudentDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnStudentDelete.Image")));
            this.tsBtnStudentDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnStudentDelete.Name = "tsBtnStudentDelete";
            this.tsBtnStudentDelete.Size = new System.Drawing.Size(52, 22);
            this.tsBtnStudentDelete.Text = "删除";
            this.tsBtnStudentDelete.Click += new System.EventHandler(this.tsBtnStudentDelete_Click);
            // 
            // tsBtnRefresh
            // 
            this.tsBtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRefresh.Image")));
            this.tsBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRefresh.Name = "tsBtnRefresh";
            this.tsBtnRefresh.Size = new System.Drawing.Size(52, 22);
            this.tsBtnRefresh.Text = "刷新";
            this.tsBtnRefresh.Click += new System.EventHandler(this.tsBtnRefresh_Click);
            // 
            // FrmFamilyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 449);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmFamilyList";
            this.Text = "学员家长信息管理";
            this.Load += new System.EventHandler(this.FrmFamilyList_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView2)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnAdd;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tsTbFamily;
        private System.Windows.Forms.ToolStripButton tsBtnSearch;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsBtnStudentAdd;
        private System.Windows.Forms.ToolStripButton tsBtnStudentSave;
        private System.Windows.Forms.ToolStripButton tsBtnStudentDelete;
        private System.Windows.Forms.ToolStripButton tsBtnRefresh;
        private TActionProject.PagerControl pagerControl1;
        private XF.ExControls.XFDataGridView xfDataGridView1;
        private XF.ExControls.XFDataGridView xfDataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFamilyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFamilyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFamilyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCourseCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNickName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBirthdate;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColTeacher;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColAdviser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBirthday;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentDescription;
    }
}