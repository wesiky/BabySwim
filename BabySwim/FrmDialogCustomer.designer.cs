namespace BabySwim
{
    partial class FrmDialogCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDialogCustomer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnSure = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsTbCustomer = new System.Windows.Forms.ToolStripTextBox();
            this.tsBtnQuery = new System.Windows.Forms.ToolStripButton();
            this.pagerControl1 = new TActionProject.PagerControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBirthDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(611, 475);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSure,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tsTbCustomer,
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
            this.toolStripLabel1.Text = "客户";
            // 
            // tsTbCustomer
            // 
            this.tsTbCustomer.Name = "tsTbCustomer";
            this.tsTbCustomer.Size = new System.Drawing.Size(76, 25);
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
            this.pagerControl1.Margin = new System.Windows.Forms.Padding(4);
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
            this.ColPhone,
            this.ColBirthDay,
            this.ColAge,
            this.ColDescription});
            this.dataGridView1.Location = new System.Drawing.Point(0, 23);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
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
            this.ColStudentID.HeaderText = "客户ID";
            this.ColStudentID.MinimumWidth = 100;
            this.ColStudentID.Name = "ColStudentID";
            this.ColStudentID.ReadOnly = true;
            this.ColStudentID.Visible = false;
            // 
            // ColStudentCode
            // 
            this.ColStudentCode.DataPropertyName = "StudentCode";
            this.ColStudentCode.HeaderText = "客户编号";
            this.ColStudentCode.MinimumWidth = 100;
            this.ColStudentCode.Name = "ColStudentCode";
            this.ColStudentCode.ReadOnly = true;
            // 
            // ColStudentName
            // 
            this.ColStudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColStudentName.DataPropertyName = "StudentName";
            this.ColStudentName.HeaderText = "客户姓名";
            this.ColStudentName.MinimumWidth = 100;
            this.ColStudentName.Name = "ColStudentName";
            this.ColStudentName.ReadOnly = true;
            // 
            // ColPhone
            // 
            this.ColPhone.DataPropertyName = "Phone";
            this.ColPhone.HeaderText = "联系电话";
            this.ColPhone.MinimumWidth = 100;
            this.ColPhone.Name = "ColPhone";
            this.ColPhone.ReadOnly = true;
            // 
            // ColBirthDay
            // 
            this.ColBirthDay.DataPropertyName = "Birthday";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd";
            dataGridViewCellStyle1.NullValue = null;
            this.ColBirthDay.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColBirthDay.HeaderText = "出生日期";
            this.ColBirthDay.MinimumWidth = 120;
            this.ColBirthDay.Name = "ColBirthDay";
            this.ColBirthDay.ReadOnly = true;
            this.ColBirthDay.Width = 120;
            // 
            // ColAge
            // 
            this.ColAge.DataPropertyName = "Age";
            this.ColAge.HeaderText = "年龄";
            this.ColAge.MinimumWidth = 80;
            this.ColAge.Name = "ColAge";
            this.ColAge.ReadOnly = true;
            // 
            // ColDescription
            // 
            this.ColDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDescription.HeaderText = "备注";
            this.ColDescription.Name = "ColDescription";
            this.ColDescription.ReadOnly = true;
            // 
            // FrmDialogCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(629, 526);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1440, 832);
            this.Name = "FrmDialogCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户查询";
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
        private System.Windows.Forms.ToolStripTextBox tsTbCustomer;
        private System.Windows.Forms.ToolStripButton tsBtnQuery;
        private System.Windows.Forms.DataGridView dataGridView1;
        private TActionProject.PagerControl pagerControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBirthDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
    }
}