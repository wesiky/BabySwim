namespace BabySwim
{
    partial class FrmStudentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStudentList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbStudent = new System.Windows.Forms.ToolStripTextBox();
            this.tsBtnSearch = new System.Windows.Forms.ToolStripButton();
            this.xfDataGridView1 = new XF.ExControls.XFDataGridView();
            this.ColStudentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBirthdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTeacher = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColAdviser = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCourse = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFamilyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFamilyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCourseCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagerControl1 = new TActionProject.PagerControl();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tbFamily = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tbStudent,
            this.toolStripLabel2,
            this.tbFamily,
            this.tsBtnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1173, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel1.Text = "学员";
            // 
            // tbStudent
            // 
            this.tbStudent.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tbStudent.Name = "tbStudent";
            this.tbStudent.Size = new System.Drawing.Size(100, 25);
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
            this.ColStudentId,
            this.ColStudentCode,
            this.ColStudentName,
            this.ColNickName,
            this.ColBirthdate,
            this.ColTeacher,
            this.ColAdviser,
            this.ColBirthday,
            this.ColCourse,
            this.ColProgress,
            this.ColFamilyCode,
            this.ColFamilyName,
            this.ColCourseCount,
            this.ColPhone,
            this.ColStudentDescription});
            this.xfDataGridView1.ContextMenuScriptEnable = true;
            this.xfDataGridView1.Location = new System.Drawing.Point(0, 28);
            this.xfDataGridView1.Name = "xfDataGridView1";
            this.xfDataGridView1.ReadOnly = true;
            this.xfDataGridView1.RowTemplate.Height = 27;
            this.xfDataGridView1.Size = new System.Drawing.Size(1173, 452);
            this.xfDataGridView1.TabIndex = 1;
            this.xfDataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.xfDataGridView1_DataError);
            // 
            // ColStudentId
            // 
            this.ColStudentId.HeaderText = "学员ID";
            this.ColStudentId.Name = "ColStudentId";
            this.ColStudentId.ReadOnly = true;
            this.ColStudentId.Visible = false;
            // 
            // ColStudentCode
            // 
            this.ColStudentCode.HeaderText = "学员编号";
            this.ColStudentCode.Name = "ColStudentCode";
            this.ColStudentCode.ReadOnly = true;
            // 
            // ColStudentName
            // 
            this.ColStudentName.HeaderText = "学员姓名";
            this.ColStudentName.Name = "ColStudentName";
            this.ColStudentName.ReadOnly = true;
            // 
            // ColNickName
            // 
            this.ColNickName.HeaderText = "昵称";
            this.ColNickName.Name = "ColNickName";
            this.ColNickName.ReadOnly = true;
            // 
            // ColBirthdate
            // 
            dataGridViewCellStyle1.Format = "yyyy-MM-dd";
            dataGridViewCellStyle1.NullValue = null;
            this.ColBirthdate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColBirthdate.HeaderText = "出生日期";
            this.ColBirthdate.Name = "ColBirthdate";
            this.ColBirthdate.ReadOnly = true;
            // 
            // ColTeacher
            // 
            this.ColTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColTeacher.HeaderText = "执教老师";
            this.ColTeacher.Name = "ColTeacher";
            this.ColTeacher.ReadOnly = true;
            this.ColTeacher.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColTeacher.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColAdviser
            // 
            this.ColAdviser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ColAdviser.HeaderText = "顾问老师";
            this.ColAdviser.Name = "ColAdviser";
            this.ColAdviser.ReadOnly = true;
            this.ColAdviser.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColAdviser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColBirthday
            // 
            dataGridViewCellStyle2.Format = "MM-dd";
            dataGridViewCellStyle2.NullValue = null;
            this.ColBirthday.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColBirthday.HeaderText = "农历生日";
            this.ColBirthday.Name = "ColBirthday";
            this.ColBirthday.ReadOnly = true;
            this.ColBirthday.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColCourse
            // 
            dataGridViewCellStyle3.NullValue = null;
            this.ColCourse.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColCourse.HeaderText = "课程名称";
            this.ColCourse.Name = "ColCourse";
            this.ColCourse.ReadOnly = true;
            // 
            // ColProgress
            // 
            this.ColProgress.HeaderText = "进度";
            this.ColProgress.Name = "ColProgress";
            this.ColProgress.ReadOnly = true;
            this.ColProgress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColProgress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColFamilyCode
            // 
            this.ColFamilyCode.HeaderText = "家长编号";
            this.ColFamilyCode.Name = "ColFamilyCode";
            this.ColFamilyCode.ReadOnly = true;
            // 
            // ColFamilyName
            // 
            this.ColFamilyName.HeaderText = "家长名称";
            this.ColFamilyName.Name = "ColFamilyName";
            this.ColFamilyName.ReadOnly = true;
            // 
            // ColCourseCount
            // 
            this.ColCourseCount.HeaderText = "剩余课时";
            this.ColCourseCount.Name = "ColCourseCount";
            this.ColCourseCount.ReadOnly = true;
            // 
            // ColPhone
            // 
            this.ColPhone.HeaderText = "家长电话";
            this.ColPhone.Name = "ColPhone";
            this.ColPhone.ReadOnly = true;
            // 
            // ColStudentDescription
            // 
            this.ColStudentDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColStudentDescription.HeaderText = "备注";
            this.ColStudentDescription.MinimumWidth = 100;
            this.ColStudentDescription.Name = "ColStudentDescription";
            this.ColStudentDescription.ReadOnly = true;
            // 
            // pagerControl1
            // 
            this.pagerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pagerControl1.BackColor = System.Drawing.Color.Transparent;
            this.pagerControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(78)))), ((int)(((byte)(151)))));
            this.pagerControl1.JumpText = "Go";
            this.pagerControl1.Location = new System.Drawing.Point(573, 486);
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
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel2.Text = "家长";
            // 
            // tbFamily
            // 
            this.tbFamily.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tbFamily.Name = "tbFamily";
            this.tbFamily.Size = new System.Drawing.Size(100, 25);
            // 
            // FrmStudentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 517);
            this.Controls.Add(this.pagerControl1);
            this.Controls.Add(this.xfDataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmStudentList";
            this.Text = "学员信息查询";
            this.Load += new System.EventHandler(this.FrmStudentList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbStudent;
        private System.Windows.Forms.ToolStripButton tsBtnSearch;
        private XF.ExControls.XFDataGridView xfDataGridView1;
        private TActionProject.PagerControl pagerControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNickName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBirthdate;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColTeacher;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColAdviser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBirthday;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFamilyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFamilyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCourseCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentDescription;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tbFamily;
    }
}