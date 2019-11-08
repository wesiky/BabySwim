namespace BabySwim
{
    partial class FrmConfirmedStudentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfirmedStudentList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.xfDataGridView1 = new XF.ExControls.XFDataGridView();
            this.ColConfirmedID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFamilyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFamilyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFamilyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDayOfWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColClassRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLessonNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTeacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.xfDataGridView1);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Size = new System.Drawing.Size(954, 633);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(954, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
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
            // xfDataGridView1
            // 
            this.xfDataGridView1.AllowUserToAddRows = false;
            this.xfDataGridView1.AllowUserToDeleteRows = false;
            this.xfDataGridView1.AllowUserToOrderColumns = true;
            this.xfDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xfDataGridView1.ColumnOrderName = null;
            this.xfDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColConfirmedID,
            this.ColStudentName,
            this.ColNickName,
            this.ColFamilyID,
            this.ColFamilyCode,
            this.ColFamilyName,
            this.ColDayOfWeek,
            this.ColClassRoom,
            this.ColLessonNO,
            this.ColCourseName,
            this.ColTeacher,
            this.ColDescription});
            this.xfDataGridView1.ContextMenuScriptEnable = true;
            this.xfDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xfDataGridView1.Location = new System.Drawing.Point(0, 27);
            this.xfDataGridView1.Name = "xfDataGridView1";
            this.xfDataGridView1.ReadOnly = true;
            this.xfDataGridView1.RowTemplate.Height = 27;
            this.xfDataGridView1.Size = new System.Drawing.Size(954, 606);
            this.xfDataGridView1.TabIndex = 1;
            // 
            // ColConfirmedID
            // 
            this.ColConfirmedID.HeaderText = "排课ID";
            this.ColConfirmedID.Name = "ColConfirmedID";
            this.ColConfirmedID.ReadOnly = true;
            this.ColConfirmedID.Visible = false;
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
            this.ColFamilyCode.ReadOnly = true;
            // 
            // ColFamilyName
            // 
            this.ColFamilyName.HeaderText = "家长姓名";
            this.ColFamilyName.Name = "ColFamilyName";
            this.ColFamilyName.ReadOnly = true;
            // 
            // ColDayOfWeek
            // 
            this.ColDayOfWeek.HeaderText = "排课日期";
            this.ColDayOfWeek.Name = "ColDayOfWeek";
            this.ColDayOfWeek.ReadOnly = true;
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
            // ColCourseName
            // 
            this.ColCourseName.HeaderText = "课程名称";
            this.ColCourseName.Name = "ColCourseName";
            this.ColCourseName.ReadOnly = true;
            // 
            // ColTeacher
            // 
            this.ColTeacher.HeaderText = "授课教师";
            this.ColTeacher.Name = "ColTeacher";
            this.ColTeacher.ReadOnly = true;
            this.ColTeacher.Width = 140;
            // 
            // ColDescription
            // 
            this.ColDescription.HeaderText = "备注";
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.ReadOnly = true;
            // 
            // FrmConfirmedStudentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(978, 697);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmConfirmedStudentList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "固定选课学员清单";
            this.TextForeColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FrmCourseEvaluateSearch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private XF.ExControls.XFDataGridView xfDataGridView1;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColConfirmedID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNickName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFamilyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFamilyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFamilyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDayOfWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColClassRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLessonNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTeacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
    }
}