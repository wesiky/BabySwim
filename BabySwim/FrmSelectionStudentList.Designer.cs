namespace BabySwim
{
    partial class FrmSelectionStudentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectionStudentList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tsCmbCourse = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tsTbStudent = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.tsTbTeacher = new System.Windows.Forms.ToolStripTextBox();
            this.tsBtnSearch = new System.Windows.Forms.ToolStripButton();
            this.xfDataGridView1 = new XF.ExControls.XFDataGridView();
            this.pagerControl1 = new TActionProject.PagerControl();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCourseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColClassRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLessonNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSelectionType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColTeacherID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTeacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSignType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnUpdate,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.toolStripLabel3,
            this.tsCmbCourse,
            this.toolStripLabel4,
            this.tsTbStudent,
            this.toolStripLabel5,
            this.tsTbTeacher,
            this.tsBtnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(734, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel1.Text = "上课日期";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel2.Text = "至";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel3.Text = "课程名称";
            // 
            // tsCmbCourse
            // 
            this.tsCmbCourse.Name = "tsCmbCourse";
            this.tsCmbCourse.Size = new System.Drawing.Size(92, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel4.Text = "学员";
            // 
            // tsTbStudent
            // 
            this.tsTbStudent.Name = "tsTbStudent";
            this.tsTbStudent.Size = new System.Drawing.Size(91, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel5.Text = "授课教师";
            // 
            // tsTbTeacher
            // 
            this.tsTbTeacher.Name = "tsTbTeacher";
            this.tsTbTeacher.Size = new System.Drawing.Size(91, 25);
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
            this.ColID,
            this.ColCourseDate,
            this.ColClassRoom,
            this.ColLessonNO,
            this.ColCourseID,
            this.ColCourseName,
            this.ColProgress,
            this.ColStudentName,
            this.ColNickName,
            this.ColSelectionType,
            this.ColTeacherID,
            this.ColTeacher,
            this.ColSignType,
            this.ColDescription});
            this.xfDataGridView1.ContextMenuScriptEnable = true;
            this.xfDataGridView1.Location = new System.Drawing.Point(0, 22);
            this.xfDataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.xfDataGridView1.Name = "xfDataGridView1";
            this.xfDataGridView1.ReadOnly = true;
            this.xfDataGridView1.RowTemplate.Height = 27;
            this.xfDataGridView1.Size = new System.Drawing.Size(734, 410);
            this.xfDataGridView1.TabIndex = 1;
            // 
            // pagerControl1
            // 
            this.pagerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pagerControl1.BackColor = System.Drawing.Color.Transparent;
            this.pagerControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(78)))), ((int)(((byte)(151)))));
            this.pagerControl1.JumpText = "Go";
            this.pagerControl1.Location = new System.Drawing.Point(134, 438);
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
            // ColID
            // 
            this.ColID.HeaderText = "学员选课ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColCourseDate
            // 
            dataGridViewCellStyle1.Format = "yyyy-MM-dd";
            dataGridViewCellStyle1.NullValue = null;
            this.ColCourseDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColCourseDate.HeaderText = "课程日期";
            this.ColCourseDate.Name = "ColCourseDate";
            this.ColCourseDate.ReadOnly = true;
            // 
            // ColClassRoom
            // 
            this.ColClassRoom.HeaderText = "教室";
            this.ColClassRoom.Name = "ColClassRoom";
            this.ColClassRoom.ReadOnly = true;
            this.ColClassRoom.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColLessonNO
            // 
            this.ColLessonNO.HeaderText = "课堂";
            this.ColLessonNO.Name = "ColLessonNO";
            this.ColLessonNO.ReadOnly = true;
            // 
            // ColCourseID
            // 
            this.ColCourseID.HeaderText = "课程ID";
            this.ColCourseID.Name = "ColCourseID";
            this.ColCourseID.ReadOnly = true;
            this.ColCourseID.Visible = false;
            // 
            // ColCourseName
            // 
            this.ColCourseName.HeaderText = "课程名称";
            this.ColCourseName.Name = "ColCourseName";
            this.ColCourseName.ReadOnly = true;
            // 
            // ColProgress
            // 
            this.ColProgress.HeaderText = "课程进度";
            this.ColProgress.Name = "ColProgress";
            this.ColProgress.ReadOnly = true;
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
            // ColSelectionType
            // 
            this.ColSelectionType.HeaderText = "选课类型";
            this.ColSelectionType.Name = "ColSelectionType";
            this.ColSelectionType.ReadOnly = true;
            this.ColSelectionType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColSelectionType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColTeacherID
            // 
            this.ColTeacherID.HeaderText = "教师ID";
            this.ColTeacherID.Name = "ColTeacherID";
            this.ColTeacherID.ReadOnly = true;
            this.ColTeacherID.Visible = false;
            // 
            // ColTeacher
            // 
            this.ColTeacher.HeaderText = "授课教师";
            this.ColTeacher.Name = "ColTeacher";
            this.ColTeacher.ReadOnly = true;
            this.ColTeacher.Width = 140;
            // 
            // ColSignType
            // 
            this.ColSignType.HeaderText = "签到类型";
            this.ColSignType.Name = "ColSignType";
            this.ColSignType.ReadOnly = true;
            this.ColSignType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColSignType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColDescription
            // 
            this.ColDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDescription.HeaderText = "上课表现";
            this.ColDescription.MinimumWidth = 160;
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.ReadOnly = true;
            // 
            // FrmSelectionStudentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 468);
            this.Controls.Add(this.pagerControl1);
            this.Controls.Add(this.xfDataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmSelectionStudentList";
            this.Text = "课程情况管理";
            this.Load += new System.EventHandler(this.FrmCourseEvaluateSearch_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private XF.ExControls.XFDataGridView xfDataGridView1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox tsCmbCourse;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox tsTbStudent;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox tsTbTeacher;
        private System.Windows.Forms.ToolStripButton tsBtnSearch;
        private System.Windows.Forms.ToolStripButton tsBtnUpdate;
        private TActionProject.PagerControl pagerControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCourseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColClassRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLessonNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCourseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNickName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColSelectionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTeacherID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTeacher;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColSignType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
    }
}