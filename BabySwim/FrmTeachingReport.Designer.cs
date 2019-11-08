namespace BabySwim
{
    partial class FrmTeachingReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTeachingReport));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnLook = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnSearch = new System.Windows.Forms.ToolStripButton();
            this.xfDataGridView1 = new XF.ExControls.DataGridViewSummary();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColJob = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColJobLevel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColTotle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnLook,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.tsBtnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(641, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnLook
            // 
            this.tsBtnLook.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnLook.Image")));
            this.tsBtnLook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnLook.Name = "tsBtnLook";
            this.tsBtnLook.Size = new System.Drawing.Size(52, 22);
            this.tsBtnLook.Text = "查看";
            this.tsBtnLook.Click += new System.EventHandler(this.tsBtnLook_Click);
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
            this.toolStripLabel1.Text = "授课日期";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel2.Text = "至";
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
            this.xfDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xfDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColCode,
            this.ColName,
            this.ColJob,
            this.ColJobLevel,
            this.ColTotle});
            this.xfDataGridView1.DisplaySumRowHeader = true;
            this.xfDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xfDataGridView1.Location = new System.Drawing.Point(0, 25);
            this.xfDataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.xfDataGridView1.Name = "xfDataGridView1";
            this.xfDataGridView1.ReadOnly = true;
            this.xfDataGridView1.RowTemplate.Height = 27;
            this.xfDataGridView1.Size = new System.Drawing.Size(641, 420);
            this.xfDataGridView1.SummaryColumns = new string[] {
        "Freight"};
            this.xfDataGridView1.SummaryRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.xfDataGridView1.SummaryRowSpace = 10;
            this.xfDataGridView1.SummaryRowVisible = false;
            this.xfDataGridView1.SumRowHeaderText = "SUM";
            this.xfDataGridView1.SumRowHeaderTextBold = true;
            this.xfDataGridView1.TabIndex = 1;
            // 
            // ColID
            // 
            this.ColID.HeaderText = "教师ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColCode
            // 
            this.ColCode.HeaderText = "教师编码";
            this.ColCode.Name = "ColCode";
            this.ColCode.ReadOnly = true;
            // 
            // ColName
            // 
            this.ColName.HeaderText = "教师姓名";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColJob
            // 
            this.ColJob.HeaderText = "职位";
            this.ColJob.Name = "ColJob";
            this.ColJob.ReadOnly = true;
            // 
            // ColJobLevel
            // 
            this.ColJobLevel.HeaderText = "级别";
            this.ColJobLevel.Name = "ColJobLevel";
            this.ColJobLevel.ReadOnly = true;
            // 
            // ColTotle
            // 
            this.ColTotle.HeaderText = "总授课人数";
            this.ColTotle.Name = "ColTotle";
            this.ColTotle.ReadOnly = true;
            // 
            // FrmTeachingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 445);
            this.Controls.Add(this.xfDataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmTeachingReport";
            this.Text = "教师授课统计报表";
            this.Load += new System.EventHandler(this.FrmTeacherList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private XF.ExControls.DataGridViewSummary xfDataGridView1;
        private System.Windows.Forms.ToolStripButton tsBtnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsBtnLook;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColJob;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColJobLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotle;
    }
}