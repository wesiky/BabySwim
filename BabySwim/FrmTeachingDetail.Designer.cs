namespace BabySwim
{
    partial class FrmTeachingDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTeachingDetail));
            this.xfDataGridView1 = new XF.ExControls.XFDataGridView();
            this.ColSelectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCourseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColClassRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLessonNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCourseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.xfDataGridView1);
            this.panel1.Location = new System.Drawing.Point(9, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Size = new System.Drawing.Size(830, 538);
            // 
            // xfDataGridView1
            // 
            this.xfDataGridView1.AllowUserToAddRows = false;
            this.xfDataGridView1.AllowUserToDeleteRows = false;
            this.xfDataGridView1.AllowUserToOrderColumns = true;
            this.xfDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xfDataGridView1.ColumnOrderName = null;
            this.xfDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSelectionID,
            this.ColCourseDate,
            this.ColClassRoom,
            this.ColLessonNO,
            this.ColCourseName,
            this.ColProgress,
            this.ColStudentCode,
            this.ColStudentName});
            this.xfDataGridView1.ContextMenuScriptEnable = true;
            this.xfDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xfDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.xfDataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.xfDataGridView1.Name = "xfDataGridView1";
            this.xfDataGridView1.ReadOnly = true;
            this.xfDataGridView1.RowTemplate.Height = 27;
            this.xfDataGridView1.Size = new System.Drawing.Size(830, 538);
            this.xfDataGridView1.TabIndex = 1;
            // 
            // ColSelectionID
            // 
            this.ColSelectionID.HeaderText = "选课ID";
            this.ColSelectionID.Name = "ColSelectionID";
            this.ColSelectionID.ReadOnly = true;
            this.ColSelectionID.Visible = false;
            // 
            // ColCourseDate
            // 
            dataGridViewCellStyle1.Format = "yyyy-MM-dd";
            this.ColCourseDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColCourseDate.HeaderText = "课程日期";
            this.ColCourseDate.MinimumWidth = 120;
            this.ColCourseDate.Name = "ColCourseDate";
            this.ColCourseDate.ReadOnly = true;
            this.ColCourseDate.Width = 160;
            // 
            // ColClassRoom
            // 
            this.ColClassRoom.HeaderText = "教室";
            this.ColClassRoom.MinimumWidth = 100;
            this.ColClassRoom.Name = "ColClassRoom";
            this.ColClassRoom.ReadOnly = true;
            this.ColClassRoom.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColClassRoom.Width = 120;
            // 
            // ColLessonNO
            // 
            this.ColLessonNO.HeaderText = "课堂";
            this.ColLessonNO.MinimumWidth = 100;
            this.ColLessonNO.Name = "ColLessonNO";
            this.ColLessonNO.ReadOnly = true;
            // 
            // ColCourseName
            // 
            this.ColCourseName.HeaderText = "课程名称";
            this.ColCourseName.MinimumWidth = 100;
            this.ColCourseName.Name = "ColCourseName";
            this.ColCourseName.ReadOnly = true;
            this.ColCourseName.Width = 120;
            // 
            // ColProgress
            // 
            this.ColProgress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColProgress.HeaderText = "课程进度";
            this.ColProgress.Name = "ColProgress";
            this.ColProgress.ReadOnly = true;
            // 
            // ColStudentCode
            // 
            this.ColStudentCode.HeaderText = "学员编码";
            this.ColStudentCode.MinimumWidth = 100;
            this.ColStudentCode.Name = "ColStudentCode";
            this.ColStudentCode.ReadOnly = true;
            // 
            // ColStudentName
            // 
            this.ColStudentName.HeaderText = "学员姓名";
            this.ColStudentName.MinimumWidth = 100;
            this.ColStudentName.Name = "ColStudentName";
            this.ColStudentName.ReadOnly = true;
            // 
            // FrmTeachingDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(848, 589);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(1440, 832);
            this.Name = "FrmTeachingDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "授课明细";
            this.Load += new System.EventHandler(this.FrmCourseEvaluateSearch_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XF.ExControls.XFDataGridView xfDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSelectionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCourseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColClassRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLessonNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCourseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentName;
    }
}