namespace BabySwim
{
    partial class FrmDialogStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDialogStudent));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnSure = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsTbStudent = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsTbFamily = new System.Windows.Forms.ToolStripTextBox();
            this.tsBtnQuery = new System.Windows.Forms.ToolStripButton();
            this.pagerControl1 = new TActionProject.PagerControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFamilyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFamilyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFamilyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCourseCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTeacherID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAdviserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTeacherCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTeacherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAdviserCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAdviserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.pagerControl1);
            this.panel1.Location = new System.Drawing.Point(9, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Size = new System.Drawing.Size(611, 475);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSure,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tsTbStudent,
            this.toolStripLabel2,
            this.tsTbFamily,
            this.tsBtnQuery});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(611, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnSure
            // 
            this.tsBtnSure.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSure.Image")));
            this.tsBtnSure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSure.Name = "tsBtnSure";
            this.tsBtnSure.Size = new System.Drawing.Size(52, 22);
            this.tsBtnSure.Text = "确定";
            this.tsBtnSure.Click += new System.EventHandler(this.tsBtnSave_Click);
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
            this.toolStripLabel1.Text = "学员";
            // 
            // tsTbStudent
            // 
            this.tsTbStudent.Name = "tsTbStudent";
            this.tsTbStudent.Size = new System.Drawing.Size(76, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel2.Text = "家长";
            // 
            // tsTbFamily
            // 
            this.tsTbFamily.Name = "tsTbFamily";
            this.tsTbFamily.Size = new System.Drawing.Size(76, 25);
            // 
            // tsBtnQuery
            // 
            this.tsBtnQuery.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnQuery.Image")));
            this.tsBtnQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnQuery.Name = "tsBtnQuery";
            this.tsBtnQuery.Size = new System.Drawing.Size(52, 22);
            this.tsBtnQuery.Text = "查询";
            this.tsBtnQuery.Click += new System.EventHandler(this.tsBtnQuery_Click);
            // 
            // pagerControl1
            // 
            this.pagerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pagerControl1.BackColor = System.Drawing.Color.Transparent;
            this.pagerControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(78)))), ((int)(((byte)(151)))));
            this.pagerControl1.JumpText = "Go";
            this.pagerControl1.Location = new System.Drawing.Point(8, 442);
            this.pagerControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pagerControl1.MaximumSize = new System.Drawing.Size(600, 29);
            this.pagerControl1.MinimumSize = new System.Drawing.Size(600, 29);
            this.pagerControl1.Name = "pagerControl1";
            this.pagerControl1.PageIndex = 1;
            this.pagerControl1.PageSize = 100;
            this.pagerControl1.RecordCount = 0;
            this.pagerControl1.Size = new System.Drawing.Size(600, 29);
            this.pagerControl1.TabIndex = 1;
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
            this.ColStudentID,
            this.ColStudentCode,
            this.ColStudentName,
            this.ColNickName,
            this.ColFamilyID,
            this.ColFamilyCode,
            this.ColFamilyName,
            this.ColCourseCount,
            this.ColBirthDate,
            this.ColTeacherID,
            this.ColAdviserID,
            this.ColCourseID,
            this.ColProgress,
            this.ColBirthday,
            this.ColTeacherCode,
            this.ColTeacherName,
            this.ColAdviserCode,
            this.ColAdviserName});
            this.dataGridView1.Location = new System.Drawing.Point(0, 23);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(611, 414);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // ColStudentID
            // 
            this.ColStudentID.DataPropertyName = "StudentID";
            this.ColStudentID.HeaderText = "学员ID";
            this.ColStudentID.MinimumWidth = 100;
            this.ColStudentID.Name = "ColStudentID";
            this.ColStudentID.ReadOnly = true;
            this.ColStudentID.Visible = false;
            // 
            // ColStudentCode
            // 
            this.ColStudentCode.DataPropertyName = "StudentCode";
            this.ColStudentCode.HeaderText = "学员编号";
            this.ColStudentCode.Name = "ColStudentCode";
            this.ColStudentCode.ReadOnly = true;
            // 
            // ColStudentName
            // 
            this.ColStudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColStudentName.DataPropertyName = "StudentName";
            this.ColStudentName.HeaderText = "学员姓名";
            this.ColStudentName.MinimumWidth = 100;
            this.ColStudentName.Name = "ColStudentName";
            this.ColStudentName.ReadOnly = true;
            // 
            // ColNickName
            // 
            this.ColNickName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNickName.DataPropertyName = "NickName";
            this.ColNickName.HeaderText = "学员昵称";
            this.ColNickName.MinimumWidth = 100;
            this.ColNickName.Name = "ColNickName";
            this.ColNickName.ReadOnly = true;
            // 
            // ColFamilyID
            // 
            this.ColFamilyID.DataPropertyName = "FamilyID";
            this.ColFamilyID.HeaderText = "家长ID";
            this.ColFamilyID.Name = "ColFamilyID";
            this.ColFamilyID.ReadOnly = true;
            this.ColFamilyID.Visible = false;
            // 
            // ColFamilyCode
            // 
            this.ColFamilyCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColFamilyCode.DataPropertyName = "FamilyCode";
            this.ColFamilyCode.HeaderText = "家长编号";
            this.ColFamilyCode.MinimumWidth = 100;
            this.ColFamilyCode.Name = "ColFamilyCode";
            this.ColFamilyCode.ReadOnly = true;
            // 
            // ColFamilyName
            // 
            this.ColFamilyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColFamilyName.DataPropertyName = "FamilyName";
            this.ColFamilyName.HeaderText = "家长姓名";
            this.ColFamilyName.MinimumWidth = 100;
            this.ColFamilyName.Name = "ColFamilyName";
            this.ColFamilyName.ReadOnly = true;
            // 
            // ColCourseCount
            // 
            this.ColCourseCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColCourseCount.DataPropertyName = "CourseCount";
            this.ColCourseCount.HeaderText = "剩余课时";
            this.ColCourseCount.MinimumWidth = 100;
            this.ColCourseCount.Name = "ColCourseCount";
            this.ColCourseCount.ReadOnly = true;
            // 
            // ColBirthDate
            // 
            this.ColBirthDate.DataPropertyName = "Birthdate";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd";
            dataGridViewCellStyle1.NullValue = null;
            this.ColBirthDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColBirthDate.HeaderText = "出生日期";
            this.ColBirthDate.MinimumWidth = 120;
            this.ColBirthDate.Name = "ColBirthDate";
            this.ColBirthDate.ReadOnly = true;
            this.ColBirthDate.Width = 120;
            // 
            // ColTeacherID
            // 
            this.ColTeacherID.DataPropertyName = "TeacherID";
            this.ColTeacherID.HeaderText = "执教老师ID";
            this.ColTeacherID.Name = "ColTeacherID";
            this.ColTeacherID.ReadOnly = true;
            this.ColTeacherID.Visible = false;
            // 
            // ColAdviserID
            // 
            this.ColAdviserID.DataPropertyName = "AdviserID";
            this.ColAdviserID.HeaderText = "顾问ID";
            this.ColAdviserID.Name = "ColAdviserID";
            this.ColAdviserID.ReadOnly = true;
            this.ColAdviserID.Visible = false;
            // 
            // ColCourseID
            // 
            this.ColCourseID.DataPropertyName = "CourseID";
            this.ColCourseID.HeaderText = "当前课程ID";
            this.ColCourseID.MinimumWidth = 100;
            this.ColCourseID.Name = "ColCourseID";
            this.ColCourseID.ReadOnly = true;
            this.ColCourseID.Visible = false;
            // 
            // ColProgress
            // 
            this.ColProgress.DataPropertyName = "Progress";
            this.ColProgress.HeaderText = "授课进度";
            this.ColProgress.MinimumWidth = 100;
            this.ColProgress.Name = "ColProgress";
            this.ColProgress.ReadOnly = true;
            // 
            // ColBirthday
            // 
            this.ColBirthday.DataPropertyName = "Birthday";
            dataGridViewCellStyle2.Format = "yyyy-MM-dd";
            dataGridViewCellStyle2.NullValue = null;
            this.ColBirthday.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColBirthday.HeaderText = "农历生日";
            this.ColBirthday.MinimumWidth = 120;
            this.ColBirthday.Name = "ColBirthday";
            this.ColBirthday.ReadOnly = true;
            this.ColBirthday.Width = 120;
            // 
            // ColTeacherCode
            // 
            this.ColTeacherCode.DataPropertyName = "TeacherCode";
            this.ColTeacherCode.HeaderText = "执教老师编码";
            this.ColTeacherCode.MinimumWidth = 120;
            this.ColTeacherCode.Name = "ColTeacherCode";
            this.ColTeacherCode.ReadOnly = true;
            this.ColTeacherCode.Width = 120;
            // 
            // ColTeacherName
            // 
            this.ColTeacherName.DataPropertyName = "TeacherName";
            this.ColTeacherName.HeaderText = "执教老师姓名";
            this.ColTeacherName.MinimumWidth = 120;
            this.ColTeacherName.Name = "ColTeacherName";
            this.ColTeacherName.ReadOnly = true;
            this.ColTeacherName.Width = 120;
            // 
            // ColAdviserCode
            // 
            this.ColAdviserCode.DataPropertyName = "AdviserCode";
            this.ColAdviserCode.HeaderText = "顾问编码";
            this.ColAdviserCode.Name = "ColAdviserCode";
            this.ColAdviserCode.ReadOnly = true;
            // 
            // ColAdviserName
            // 
            this.ColAdviserName.DataPropertyName = "AdviserName";
            this.ColAdviserName.HeaderText = "顾问姓名";
            this.ColAdviserName.Name = "ColAdviserName";
            this.ColAdviserName.ReadOnly = true;
            // 
            // FrmDialogStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(629, 526);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(1440, 832);
            this.Name = "FrmDialogStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学员查询";
            this.Load += new System.EventHandler(this.FrmDialogComponent_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnSure;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tsTbStudent;
        private System.Windows.Forms.ToolStripButton tsBtnQuery;
        private System.Windows.Forms.DataGridView dataGridView1;
        private TActionProject.PagerControl pagerControl1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tsTbFamily;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNickName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFamilyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFamilyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFamilyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCourseCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTeacherID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAdviserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCourseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBirthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTeacherCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTeacherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAdviserCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAdviserName;
    }
}