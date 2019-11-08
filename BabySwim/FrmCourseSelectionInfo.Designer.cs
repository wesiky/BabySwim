namespace BabySwim
{
    partial class FrmCourseSelectionInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCourseSelectionInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbCourse = new XF.ExControls.QQTextBox();
            this.tbAdviser = new XF.ExControls.QQTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSectionNO = new XF.ExControls.QQTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCloseCourse = new System.Windows.Forms.ToolStripButton();
            this.tbTeacher = new XF.ExControls.QQTextBox();
            this.tbCourseDate = new XF.ExControls.QQTextBox();
            this.xfDataGridView1 = new XF.ExControls.XFDataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.qqButton3 = new XF.ExControls.QQButton();
            this.qqButton2 = new XF.ExControls.QQButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.qqButton3);
            this.panel1.Controls.Add(this.qqButton2);
            this.panel1.Location = new System.Drawing.Point(9, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(631, 490);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "课程日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "课程名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "授课老师";
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
            this.splitContainer1.Panel1.Controls.Add(this.tbCourse);
            this.splitContainer1.Panel1.Controls.Add(this.tbAdviser);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.tbSectionNO);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.tbTeacher);
            this.splitContainer1.Panel1.Controls.Add(this.tbCourseDate);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.xfDataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Size = new System.Drawing.Size(631, 490);
            this.splitContainer1.SplitterDistance = 107;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 13;
            // 
            // tbCourse
            // 
            this.tbCourse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCourse.EmptyTextTip = null;
            this.tbCourse.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.tbCourse.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbCourse.Location = new System.Drawing.Point(77, 73);
            this.tbCourse.Margin = new System.Windows.Forms.Padding(2);
            this.tbCourse.Name = "tbCourse";
            this.tbCourse.ReadOnly = true;
            this.tbCourse.Size = new System.Drawing.Size(120, 23);
            this.tbCourse.TabIndex = 15;
            // 
            // tbAdviser
            // 
            this.tbAdviser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbAdviser.EmptyTextTip = null;
            this.tbAdviser.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.tbAdviser.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbAdviser.Location = new System.Drawing.Point(485, 34);
            this.tbAdviser.Margin = new System.Windows.Forms.Padding(2);
            this.tbAdviser.Name = "tbAdviser";
            this.tbAdviser.ReadOnly = true;
            this.tbAdviser.Size = new System.Drawing.Size(120, 23);
            this.tbAdviser.TabIndex = 14;
            this.tbAdviser.Click += new System.EventHandler(this.tbAdviser_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(452, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "顾问";
            // 
            // tbSectionNO
            // 
            this.tbSectionNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSectionNO.EmptyTextTip = null;
            this.tbSectionNO.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.tbSectionNO.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbSectionNO.Location = new System.Drawing.Point(280, 74);
            this.tbSectionNO.Margin = new System.Windows.Forms.Padding(2);
            this.tbSectionNO.Name = "tbSectionNO";
            this.tbSectionNO.Size = new System.Drawing.Size(120, 23);
            this.tbSectionNO.TabIndex = 12;
            this.tbSectionNO.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "课程进度";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSave,
            this.tsBtnCancel,
            this.tsBtnCloseCourse});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(631, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
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
            // tsBtnCancel
            // 
            this.tsBtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCancel.Image")));
            this.tsBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCancel.Name = "tsBtnCancel";
            this.tsBtnCancel.Size = new System.Drawing.Size(52, 22);
            this.tsBtnCancel.Text = "取消";
            this.tsBtnCancel.Click += new System.EventHandler(this.tsBtnCancel_Click);
            // 
            // tsBtnCloseCourse
            // 
            this.tsBtnCloseCourse.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCloseCourse.Image")));
            this.tsBtnCloseCourse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCloseCourse.Name = "tsBtnCloseCourse";
            this.tsBtnCloseCourse.Size = new System.Drawing.Size(76, 22);
            this.tsBtnCloseCourse.Text = "关闭课程";
            this.tsBtnCloseCourse.Click += new System.EventHandler(this.tsBtnCloseCourse_Click);
            // 
            // tbTeacher
            // 
            this.tbTeacher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTeacher.EmptyTextTip = null;
            this.tbTeacher.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.tbTeacher.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbTeacher.Location = new System.Drawing.Point(280, 34);
            this.tbTeacher.Margin = new System.Windows.Forms.Padding(2);
            this.tbTeacher.Name = "tbTeacher";
            this.tbTeacher.ReadOnly = true;
            this.tbTeacher.Size = new System.Drawing.Size(120, 23);
            this.tbTeacher.TabIndex = 9;
            this.tbTeacher.Click += new System.EventHandler(this.tbTeacher_Click);
            // 
            // tbCourseDate
            // 
            this.tbCourseDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCourseDate.EmptyTextTip = null;
            this.tbCourseDate.EmptyTextTipColor = System.Drawing.Color.DarkGray;
            this.tbCourseDate.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tbCourseDate.Location = new System.Drawing.Point(77, 34);
            this.tbCourseDate.Margin = new System.Windows.Forms.Padding(2);
            this.tbCourseDate.Name = "tbCourseDate";
            this.tbCourseDate.ReadOnly = true;
            this.tbCourseDate.Size = new System.Drawing.Size(120, 23);
            this.tbCourseDate.TabIndex = 4;
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
            this.ColStudentID,
            this.ColStudentCode,
            this.ColName,
            this.ColType});
            this.xfDataGridView1.ContextMenuScriptEnable = true;
            this.xfDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xfDataGridView1.Location = new System.Drawing.Point(0, 25);
            this.xfDataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.xfDataGridView1.Name = "xfDataGridView1";
            this.xfDataGridView1.RowTemplate.Height = 27;
            this.xfDataGridView1.Size = new System.Drawing.Size(631, 355);
            this.xfDataGridView1.TabIndex = 13;
            this.xfDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.xfDataGridView1_CellClick);
            // 
            // ColID
            // 
            this.ColID.HeaderText = "选课ID";
            this.ColID.Name = "ColID";
            this.ColID.Visible = false;
            // 
            // ColStudentID
            // 
            this.ColStudentID.HeaderText = "学员ID";
            this.ColStudentID.Name = "ColStudentID";
            this.ColStudentID.Visible = false;
            // 
            // ColStudentCode
            // 
            this.ColStudentCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColStudentCode.HeaderText = "学员编号";
            this.ColStudentCode.Name = "ColStudentCode";
            this.ColStudentCode.ReadOnly = true;
            // 
            // ColName
            // 
            this.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColName.HeaderText = "学员名称";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColType
            // 
            this.ColType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColType.HeaderText = "选课类型";
            this.ColType.Name = "ColType";
            this.ColType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAdd,
            this.tsBtnDelete});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(631, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
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
            // tsBtnDelete
            // 
            this.tsBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnDelete.Image")));
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Size = new System.Drawing.Size(52, 22);
            this.tsBtnDelete.Text = "删除";
            this.tsBtnDelete.Click += new System.EventHandler(this.tsBtnDelete_Click);
            // 
            // qqButton3
            // 
            this.qqButton3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.qqButton3.Location = new System.Drawing.Point(377, 160);
            this.qqButton3.Margin = new System.Windows.Forms.Padding(2);
            this.qqButton3.Name = "qqButton3";
            this.qqButton3.Size = new System.Drawing.Size(38, 18);
            this.qqButton3.TabIndex = 10;
            this.qqButton3.Text = "移除";
            this.qqButton3.UseVisualStyleBackColor = true;
            // 
            // qqButton2
            // 
            this.qqButton2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.qqButton2.Location = new System.Drawing.Point(335, 160);
            this.qqButton2.Margin = new System.Windows.Forms.Padding(2);
            this.qqButton2.Name = "qqButton2";
            this.qqButton2.Size = new System.Drawing.Size(38, 18);
            this.qqButton2.TabIndex = 9;
            this.qqButton2.Text = "新增";
            this.qqButton2.UseVisualStyleBackColor = true;
            // 
            // FrmCourseSelectionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(649, 542);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1440, 832);
            this.Name = "FrmCourseSelectionInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选课信息";
            this.Load += new System.EventHandler(this.FrmCourseSelectionInfo_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsBtnAdd;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private XF.ExControls.QQButton qqButton3;
        private XF.ExControls.QQButton qqButton2;
        private XF.ExControls.QQTextBox tbCourseDate;
        private XF.ExControls.QQTextBox tbTeacher;
        private XF.ExControls.XFDataGridView xfDataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.ToolStripButton tsBtnCancel;
        private System.Windows.Forms.ToolStripButton tsBtnCloseCourse;
        private System.Windows.Forms.Label label4;
        private XF.ExControls.QQTextBox tbSectionNO;
        private XF.ExControls.QQTextBox tbAdviser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColType;
        private XF.ExControls.QQTextBox tbCourse;
    }
}