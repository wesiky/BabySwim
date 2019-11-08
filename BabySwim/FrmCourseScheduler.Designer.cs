namespace BabySwim
{
    partial class FrmCourseScheduler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCourseScheduler));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.xfCourseScheduler1 = new XF.ExControls.XFCourseScheduler();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfCourseScheduler1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(859, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSave.Image")));
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(59, 24);
            this.tsBtnSave.Text = "保存";
            this.tsBtnSave.Click += new System.EventHandler(this.tsBtnSave_Click);
            // 
            // xfCourseScheduler1
            // 
            this.xfCourseScheduler1.AllowUserToAddRows = false;
            this.xfCourseScheduler1.AllowUserToDeleteRows = false;
            this.xfCourseScheduler1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xfCourseScheduler1.ContextMenuScriptEnable = true;
            this.xfCourseScheduler1.CrossRowColor = System.Drawing.Color.Lavender;
            this.xfCourseScheduler1.CrossRowFlag = true;
            this.xfCourseScheduler1.DayCount = 7;
            this.xfCourseScheduler1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xfCourseScheduler1.Location = new System.Drawing.Point(0, 27);
            this.xfCourseScheduler1.Name = "xfCourseScheduler1";
            this.xfCourseScheduler1.ReadOnly = true;
            this.xfCourseScheduler1.RowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.xfCourseScheduler1.RowDescription = ((System.Collections.Generic.List<string>)(resources.GetObject("xfCourseScheduler1.RowDescription")));
            this.xfCourseScheduler1.RowHeadersWidth = 120;
            this.xfCourseScheduler1.RowTemplate.Height = 27;
            this.xfCourseScheduler1.Size = new System.Drawing.Size(859, 538);
            this.xfCourseScheduler1.TabIndex = 2;
            this.xfCourseScheduler1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.xfCourseScheduler1_CellClick);
            // 
            // FrmCourseScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 565);
            this.Controls.Add(this.xfCourseScheduler1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCourseScheduler";
            this.Text = "排课管理";
            this.Load += new System.EventHandler(this.FrmCourseScheduler_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xfCourseScheduler1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private XF.ExControls.XFCourseScheduler xfCourseScheduler1;
    }
}