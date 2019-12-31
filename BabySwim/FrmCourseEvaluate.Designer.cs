namespace BabySwim
{
    partial class FrmCourseEvaluate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCourseEvaluate));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbTeacher = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSectionNO = new System.Windows.Forms.TextBox();
            this.tbCourse = new System.Windows.Forms.TextBox();
            this.tbCourseDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtcEvaluate = new XF.ExControls.RichTextControl();
            this.xfDataGridView1 = new XF.ExControls.XFDataGridView();
            this.ColSelectionStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSignType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColEvaluate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnSure = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCancel = new System.Windows.Forms.ToolStripButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.domainUpDown2 = new System.Windows.Forms.DomainUpDown();
            this.domainUpDown3 = new System.Windows.Forms.DomainUpDown();
            this.domainUpDown4 = new System.Windows.Forms.DomainUpDown();
            this.domainUpDown5 = new System.Windows.Forms.DomainUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(9, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(815, 480);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbTeacher);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.tbSectionNO);
            this.splitContainer1.Panel1.Controls.Add(this.tbCourse);
            this.splitContainer1.Panel1.Controls.Add(this.tbCourseDate);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.domainUpDown5);
            this.splitContainer1.Panel2.Controls.Add(this.domainUpDown4);
            this.splitContainer1.Panel2.Controls.Add(this.domainUpDown3);
            this.splitContainer1.Panel2.Controls.Add(this.domainUpDown2);
            this.splitContainer1.Panel2.Controls.Add(this.domainUpDown1);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.rtcEvaluate);
            this.splitContainer1.Panel2.Controls.Add(this.xfDataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(815, 480);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // tbTeacher
            // 
            this.tbTeacher.Location = new System.Drawing.Point(685, 16);
            this.tbTeacher.Margin = new System.Windows.Forms.Padding(2);
            this.tbTeacher.Name = "tbTeacher";
            this.tbTeacher.ReadOnly = true;
            this.tbTeacher.Size = new System.Drawing.Size(121, 21);
            this.tbTeacher.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(630, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "授课教师";
            // 
            // tbSectionNO
            // 
            this.tbSectionNO.Location = new System.Drawing.Point(482, 16);
            this.tbSectionNO.Margin = new System.Windows.Forms.Padding(2);
            this.tbSectionNO.Name = "tbSectionNO";
            this.tbSectionNO.ReadOnly = true;
            this.tbSectionNO.Size = new System.Drawing.Size(121, 21);
            this.tbSectionNO.TabIndex = 5;
            // 
            // tbCourse
            // 
            this.tbCourse.Location = new System.Drawing.Point(280, 16);
            this.tbCourse.Margin = new System.Windows.Forms.Padding(2);
            this.tbCourse.Name = "tbCourse";
            this.tbCourse.ReadOnly = true;
            this.tbCourse.Size = new System.Drawing.Size(121, 21);
            this.tbCourse.TabIndex = 4;
            // 
            // tbCourseDate
            // 
            this.tbCourseDate.Location = new System.Drawing.Point(77, 16);
            this.tbCourseDate.Margin = new System.Windows.Forms.Padding(2);
            this.tbCourseDate.Name = "tbCourseDate";
            this.tbCourseDate.ReadOnly = true;
            this.tbCourseDate.Size = new System.Drawing.Size(121, 21);
            this.tbCourseDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(428, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "课程进度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "课程名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "上课日期";
            // 
            // rtcEvaluate
            // 
            this.rtcEvaluate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtcEvaluate.ContentRtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\nouicompat\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fn" +
    "il\\fcharset134 \\\'cb\\\'ce\\\'cc\\\'e5;}}\r\n{\\*\\generator Riched20 10.0.17134}\\viewkind4" +
    "\\uc1 \r\n\\pard\\f0\\fs18\\lang2052\\par\r\n}\r\n";
            this.rtcEvaluate.ContentText = "";
            this.rtcEvaluate.Location = new System.Drawing.Point(280, 55);
            this.rtcEvaluate.Name = "rtcEvaluate";
            this.rtcEvaluate.Size = new System.Drawing.Size(535, 365);
            this.rtcEvaluate.TabIndex = 4;
            // 
            // xfDataGridView1
            // 
            this.xfDataGridView1.AllowUserToAddRows = false;
            this.xfDataGridView1.AllowUserToDeleteRows = false;
            this.xfDataGridView1.AllowUserToOrderColumns = true;
            this.xfDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.xfDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xfDataGridView1.ColumnOrderName = null;
            this.xfDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelectionStudentID,
            this.ColStudentID,
            this.ColStudentCode,
            this.ColStudentName,
            this.ColSignType,
            this.ColEvaluate});
            this.xfDataGridView1.ContextMenuScriptEnable = true;
            this.xfDataGridView1.Location = new System.Drawing.Point(0, 22);
            this.xfDataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.xfDataGridView1.Name = "xfDataGridView1";
            this.xfDataGridView1.ReadOnly = true;
            this.xfDataGridView1.RowTemplate.Height = 27;
            this.xfDataGridView1.Size = new System.Drawing.Size(275, 398);
            this.xfDataGridView1.TabIndex = 1;
            this.xfDataGridView1.CurrentCellChanged += new System.EventHandler(this.xfDataGridView1_CurrentCellChanged);
            // 
            // ColSelectionStudentID
            // 
            this.ColSelectionStudentID.HeaderText = "学员选课ID";
            this.ColSelectionStudentID.Name = "ColSelectionStudentID";
            this.ColSelectionStudentID.ReadOnly = true;
            this.ColSelectionStudentID.Visible = false;
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
            this.ColStudentCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColStudentCode.HeaderText = "学员编号";
            this.ColStudentCode.Name = "ColStudentCode";
            this.ColStudentCode.ReadOnly = true;
            // 
            // ColStudentName
            // 
            this.ColStudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColStudentName.HeaderText = "学员名称";
            this.ColStudentName.Name = "ColStudentName";
            this.ColStudentName.ReadOnly = true;
            // 
            // ColSignType
            // 
            this.ColSignType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColSignType.HeaderText = "签到类型";
            this.ColSignType.Name = "ColSignType";
            this.ColSignType.ReadOnly = true;
            this.ColSignType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColSignType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColEvaluate
            // 
            this.ColEvaluate.HeaderText = "评价";
            this.ColEvaluate.Name = "ColEvaluate";
            this.ColEvaluate.ReadOnly = true;
            this.ColEvaluate.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSure,
            this.tsBtnCancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(815, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnSure
            // 
            this.tsBtnSure.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSure.Image")));
            this.tsBtnSure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSure.Name = "tsBtnSure";
            this.tsBtnSure.Size = new System.Drawing.Size(52, 22);
            this.tsBtnSure.Text = "保存";
            this.tsBtnSure.Click += new System.EventHandler(this.tsBtnSure_Click);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "课堂纪律";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(379, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "动手能力";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(478, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "专注力";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(565, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "逻辑思维能力";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(688, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "表达沟通能力";
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Location = new System.Drawing.Point(774, 28);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(32, 21);
            this.domainUpDown1.TabIndex = 10;
            this.domainUpDown1.Text = "10";
            // 
            // domainUpDown2
            // 
            this.domainUpDown2.Location = new System.Drawing.Point(339, 28);
            this.domainUpDown2.Name = "domainUpDown2";
            this.domainUpDown2.Size = new System.Drawing.Size(32, 21);
            this.domainUpDown2.TabIndex = 11;
            this.domainUpDown2.Text = "10";
            // 
            // domainUpDown3
            // 
            this.domainUpDown3.Location = new System.Drawing.Point(438, 28);
            this.domainUpDown3.Name = "domainUpDown3";
            this.domainUpDown3.Size = new System.Drawing.Size(32, 21);
            this.domainUpDown3.TabIndex = 12;
            this.domainUpDown3.Text = "10";
            // 
            // domainUpDown4
            // 
            this.domainUpDown4.Location = new System.Drawing.Point(525, 28);
            this.domainUpDown4.Name = "domainUpDown4";
            this.domainUpDown4.Size = new System.Drawing.Size(32, 21);
            this.domainUpDown4.TabIndex = 13;
            this.domainUpDown4.Text = "10";
            // 
            // domainUpDown5
            // 
            this.domainUpDown5.Location = new System.Drawing.Point(648, 28);
            this.domainUpDown5.Name = "domainUpDown5";
            this.domainUpDown5.Size = new System.Drawing.Size(32, 21);
            this.domainUpDown5.TabIndex = 14;
            this.domainUpDown5.Text = "10";
            // 
            // FrmCourseEvaluate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(833, 531);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1440, 832);
            this.Name = "FrmCourseEvaluate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "课程评价";
            this.Load += new System.EventHandler(this.FrmCourseEvaluate_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private XF.ExControls.XFDataGridView xfDataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSectionNO;
        private System.Windows.Forms.TextBox tbCourse;
        private System.Windows.Forms.TextBox tbCourseDate;
        private System.Windows.Forms.ToolStripButton tsBtnSure;
        private System.Windows.Forms.ToolStripButton tsBtnCancel;
        private System.Windows.Forms.TextBox tbTeacher;
        private System.Windows.Forms.Label label4;
        private XF.ExControls.RichTextControl rtcEvaluate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSelectionStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColSignType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEvaluate;
        private System.Windows.Forms.DomainUpDown domainUpDown5;
        private System.Windows.Forms.DomainUpDown domainUpDown4;
        private System.Windows.Forms.DomainUpDown domainUpDown3;
        private System.Windows.Forms.DomainUpDown domainUpDown2;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}