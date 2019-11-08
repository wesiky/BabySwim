namespace BabySwim
{
    partial class FrmTeacherList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTeacherList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsBtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsBtnLook = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsTbTeacher = new System.Windows.Forms.ToolStripTextBox();
            this.tsBtnSearch = new System.Windows.Forms.ToolStripButton();
            this.xfDataGridView1 = new XF.ExControls.XFDataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTeacherType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColJobLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSintroduction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAdd,
            this.tsBtnUpdate,
            this.tsBtnDelete,
            this.tsBtnLook,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tsTbTeacher,
            this.tsBtnSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(641, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
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
            // tsBtnUpdate
            // 
            this.tsBtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnUpdate.Image")));
            this.tsBtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnUpdate.Name = "tsBtnUpdate";
            this.tsBtnUpdate.Size = new System.Drawing.Size(52, 22);
            this.tsBtnUpdate.Text = "修改";
            this.tsBtnUpdate.Click += new System.EventHandler(this.tsBtnUpdate_Click);
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
            this.toolStripLabel1.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel1.Text = "教师";
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
            this.xfDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xfDataGridView1.ColumnOrderName = null;
            this.xfDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.ColCode,
            this.ColName,
            this.ColAge,
            this.ColTeacherType,
            this.ColJob,
            this.ColJobLevel,
            this.ColSintroduction});
            this.xfDataGridView1.ContextMenuScriptEnable = true;
            this.xfDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xfDataGridView1.Location = new System.Drawing.Point(0, 25);
            this.xfDataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.xfDataGridView1.Name = "xfDataGridView1";
            this.xfDataGridView1.ReadOnly = true;
            this.xfDataGridView1.RowTemplate.Height = 27;
            this.xfDataGridView1.Size = new System.Drawing.Size(641, 420);
            this.xfDataGridView1.TabIndex = 1;
            // 
            // ColID
            // 
            this.ColID.HeaderText = "员工ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // ColCode
            // 
            this.ColCode.HeaderText = "员工编码";
            this.ColCode.Name = "ColCode";
            this.ColCode.ReadOnly = true;
            // 
            // ColName
            // 
            this.ColName.HeaderText = "员工姓名";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColAge
            // 
            this.ColAge.HeaderText = "年龄";
            this.ColAge.Name = "ColAge";
            this.ColAge.ReadOnly = true;
            // 
            // ColTeacherType
            // 
            this.ColTeacherType.HeaderText = "岗位";
            this.ColTeacherType.MinimumWidth = 100;
            this.ColTeacherType.Name = "ColTeacherType";
            this.ColTeacherType.ReadOnly = true;
            this.ColTeacherType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColTeacherType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColJob
            // 
            this.ColJob.HeaderText = "职位";
            this.ColJob.Name = "ColJob";
            this.ColJob.ReadOnly = true;
            this.ColJob.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColJobLevel
            // 
            this.ColJobLevel.HeaderText = "级别";
            this.ColJobLevel.Name = "ColJobLevel";
            this.ColJobLevel.ReadOnly = true;
            this.ColJobLevel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColSintroduction
            // 
            this.ColSintroduction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColSintroduction.HeaderText = "简介";
            this.ColSintroduction.MinimumWidth = 100;
            this.ColSintroduction.Name = "ColSintroduction";
            this.ColSintroduction.ReadOnly = true;
            // 
            // FrmTeacherList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 445);
            this.Controls.Add(this.xfDataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmTeacherList";
            this.Text = "员工信息管理";
            this.Load += new System.EventHandler(this.FrmTeacherList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private XF.ExControls.XFDataGridView xfDataGridView1;
        private System.Windows.Forms.ToolStripButton tsBtnAdd;
        private System.Windows.Forms.ToolStripButton tsBtnUpdate;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Windows.Forms.ToolStripButton tsBtnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tsTbTeacher;
        private System.Windows.Forms.ToolStripButton tsBtnLook;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTeacherType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColJob;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColJobLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSintroduction;
    }
}