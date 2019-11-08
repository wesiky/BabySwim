namespace BabySwim
{
    partial class FrmCourseSign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCourseSign));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbLesson = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.xfDataGridView1 = new XF.ExControls.XFDataGridView();
            this.ColSelectionStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSignType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColClassRoomID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSectionNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTeacherID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTeacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNormal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColLate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColEarly = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColLeave = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cmbLesson,
            this.toolStripLabel2,
            this.tsBtnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(974, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(24, 25);
            this.toolStripLabel1.Text = "第";
            // 
            // cmbLesson
            // 
            this.cmbLesson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLesson.Name = "cmbLesson";
            this.cmbLesson.Size = new System.Drawing.Size(75, 28);
            this.cmbLesson.SelectedIndexChanged += new System.EventHandler(this.cmbLesson_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(24, 25);
            this.toolStripLabel2.Text = "节";
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSave.Image")));
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(59, 25);
            this.tsBtnSave.Text = "保存";
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // xfDataGridView1
            // 
            this.xfDataGridView1.AllowUserToAddRows = false;
            this.xfDataGridView1.AllowUserToDeleteRows = false;
            this.xfDataGridView1.AllowUserToOrderColumns = true;
            this.xfDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xfDataGridView1.ColumnOrderName = null;
            this.xfDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelectionStudentID,
            this.ColSignType,
            this.ColStudentID,
            this.ColStudentName,
            this.ColNickName,
            this.ColClassRoomID,
            this.ColCourseID,
            this.ColCourse,
            this.ColSectionNO,
            this.ColTeacherID,
            this.ColTeacher,
            this.ColNormal,
            this.ColLate,
            this.ColEarly,
            this.ColLeave});
            this.xfDataGridView1.ContextMenuScriptEnable = true;
            this.xfDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xfDataGridView1.Location = new System.Drawing.Point(0, 28);
            this.xfDataGridView1.Name = "xfDataGridView1";
            this.xfDataGridView1.ReadOnly = true;
            this.xfDataGridView1.RowTemplate.Height = 27;
            this.xfDataGridView1.Size = new System.Drawing.Size(974, 526);
            this.xfDataGridView1.TabIndex = 1;
            this.xfDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.xfDataGridView1_CellClick);
            // 
            // ColSelectionStudentID
            // 
            this.ColSelectionStudentID.HeaderText = "选课ID";
            this.ColSelectionStudentID.Name = "ColSelectionStudentID";
            this.ColSelectionStudentID.ReadOnly = true;
            this.ColSelectionStudentID.Visible = false;
            // 
            // ColSignType
            // 
            this.ColSignType.HeaderText = "旧选课类型";
            this.ColSignType.Name = "ColSignType";
            this.ColSignType.ReadOnly = true;
            this.ColSignType.Visible = false;
            // 
            // ColStudentID
            // 
            this.ColStudentID.HeaderText = "学员ID";
            this.ColStudentID.Name = "ColStudentID";
            this.ColStudentID.ReadOnly = true;
            this.ColStudentID.Visible = false;
            // 
            // ColStudentName
            // 
            this.ColStudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColStudentName.HeaderText = "学员姓名";
            this.ColStudentName.MinimumWidth = 100;
            this.ColStudentName.Name = "ColStudentName";
            this.ColStudentName.ReadOnly = true;
            // 
            // ColNickName
            // 
            this.ColNickName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNickName.HeaderText = "学员昵称";
            this.ColNickName.MinimumWidth = 100;
            this.ColNickName.Name = "ColNickName";
            this.ColNickName.ReadOnly = true;
            // 
            // ColClassRoomID
            // 
            this.ColClassRoomID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColClassRoomID.HeaderText = "教室";
            this.ColClassRoomID.MinimumWidth = 100;
            this.ColClassRoomID.Name = "ColClassRoomID";
            this.ColClassRoomID.ReadOnly = true;
            this.ColClassRoomID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColClassRoomID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColCourseID
            // 
            this.ColCourseID.HeaderText = "课程ID";
            this.ColCourseID.Name = "ColCourseID";
            this.ColCourseID.ReadOnly = true;
            this.ColCourseID.Visible = false;
            // 
            // ColCourse
            // 
            this.ColCourse.HeaderText = "课程";
            this.ColCourse.MinimumWidth = 100;
            this.ColCourse.Name = "ColCourse";
            this.ColCourse.ReadOnly = true;
            // 
            // ColSectionNO
            // 
            this.ColSectionNO.HeaderText = "进度";
            this.ColSectionNO.Name = "ColSectionNO";
            this.ColSectionNO.ReadOnly = true;
            this.ColSectionNO.Width = 60;
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
            this.ColTeacher.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColTeacher.HeaderText = "教师";
            this.ColTeacher.MinimumWidth = 100;
            this.ColTeacher.Name = "ColTeacher";
            this.ColTeacher.ReadOnly = true;
            // 
            // ColNormal
            // 
            this.ColNormal.HeaderText = "正常";
            this.ColNormal.MinimumWidth = 60;
            this.ColNormal.Name = "ColNormal";
            this.ColNormal.ReadOnly = true;
            this.ColNormal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColNormal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColLate
            // 
            this.ColLate.HeaderText = "迟到";
            this.ColLate.MinimumWidth = 60;
            this.ColLate.Name = "ColLate";
            this.ColLate.ReadOnly = true;
            // 
            // ColEarly
            // 
            this.ColEarly.HeaderText = "早退";
            this.ColEarly.MinimumWidth = 60;
            this.ColEarly.Name = "ColEarly";
            this.ColEarly.ReadOnly = true;
            // 
            // ColLeave
            // 
            this.ColLeave.HeaderText = "请假";
            this.ColLeave.MinimumWidth = 60;
            this.ColLeave.Name = "ColLeave";
            this.ColLeave.ReadOnly = true;
            // 
            // FrmCourseSign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 554);
            this.Controls.Add(this.xfDataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCourseSign";
            this.Text = "课程签到";
            this.Load += new System.EventHandler(this.FrmCourseSign_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private XF.ExControls.XFDataGridView xfDataGridView1;
        private System.Windows.Forms.ToolStripComboBox cmbLesson;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSelectionStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSignType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNickName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColClassRoomID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCourseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCourse;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSectionNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTeacherID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTeacher;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColNormal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColLate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColEarly;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColLeave;
    }
}