namespace XF.BaseFunction
{
    partial class FrmUserGrantRel
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
            this.lstBoxUserRole = new System.Windows.Forms.ListBox();
            this.lstBoxAllRole = new System.Windows.Forms.ListBox();
            this.btnMoveRightAll = new System.Windows.Forms.Button();
            this.btnMoveRight = new System.Windows.Forms.Button();
            this.btnMoveLeft = new System.Windows.Forms.Button();
            this.btnMoveLeftAll = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstBoxUserRole
            // 
            this.lstBoxUserRole.FormattingEnabled = true;
            this.lstBoxUserRole.ItemHeight = 15;
            this.lstBoxUserRole.Location = new System.Drawing.Point(33, 60);
            this.lstBoxUserRole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstBoxUserRole.Name = "lstBoxUserRole";
            this.lstBoxUserRole.Size = new System.Drawing.Size(180, 319);
            this.lstBoxUserRole.TabIndex = 0;
            // 
            // lstBoxAllRole
            // 
            this.lstBoxAllRole.FormattingEnabled = true;
            this.lstBoxAllRole.ItemHeight = 15;
            this.lstBoxAllRole.Location = new System.Drawing.Point(261, 60);
            this.lstBoxAllRole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstBoxAllRole.Name = "lstBoxAllRole";
            this.lstBoxAllRole.Size = new System.Drawing.Size(180, 319);
            this.lstBoxAllRole.TabIndex = 1;
            // 
            // btnMoveRightAll
            // 
            this.btnMoveRightAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveRightAll.Location = new System.Drawing.Point(219, 70);
            this.btnMoveRightAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMoveRightAll.Name = "btnMoveRightAll";
            this.btnMoveRightAll.Size = new System.Drawing.Size(36, 36);
            this.btnMoveRightAll.TabIndex = 2;
            this.btnMoveRightAll.Text = ">>";
            this.btnMoveRightAll.UseVisualStyleBackColor = true;
            this.btnMoveRightAll.Click += new System.EventHandler(this.btnMoveRightAll_Click);
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveRight.Location = new System.Drawing.Point(219, 108);
            this.btnMoveRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(36, 36);
            this.btnMoveRight.TabIndex = 3;
            this.btnMoveRight.Text = ">";
            this.btnMoveRight.UseVisualStyleBackColor = true;
            this.btnMoveRight.Click += new System.EventHandler(this.btnMoveRight_Click);
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveLeft.Location = new System.Drawing.Point(219, 145);
            this.btnMoveLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(36, 36);
            this.btnMoveLeft.TabIndex = 4;
            this.btnMoveLeft.Text = "<";
            this.btnMoveLeft.UseVisualStyleBackColor = true;
            this.btnMoveLeft.Click += new System.EventHandler(this.btnMoveLeft_Click);
            // 
            // btnMoveLeftAll
            // 
            this.btnMoveLeftAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveLeftAll.Location = new System.Drawing.Point(219, 182);
            this.btnMoveLeftAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMoveLeftAll.Name = "btnMoveLeftAll";
            this.btnMoveLeftAll.Size = new System.Drawing.Size(36, 36);
            this.btnMoveLeftAll.TabIndex = 5;
            this.btnMoveLeftAll.Text = "<<";
            this.btnMoveLeftAll.UseVisualStyleBackColor = true;
            this.btnMoveLeftAll.Click += new System.EventHandler(this.btnMoveLeftAll_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(92, 402);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(261, 402);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "用户角色";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "系统角色";
            // 
            // FrmUserGrantRel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(472, 435);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnMoveLeftAll);
            this.Controls.Add(this.btnMoveLeft);
            this.Controls.Add(this.btnMoveRight);
            this.Controls.Add(this.btnMoveRightAll);
            this.Controls.Add(this.lstBoxAllRole);
            this.Controls.Add(this.lstBoxUserRole);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(490, 482);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(490, 482);
            this.Name = "FrmUserGrantRel";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色分配";
            this.Load += new System.EventHandler(this.FrmUserGrantRel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxUserRole;
        private System.Windows.Forms.ListBox lstBoxAllRole;
        private System.Windows.Forms.Button btnMoveRightAll;
        private System.Windows.Forms.Button btnMoveRight;
        private System.Windows.Forms.Button btnMoveLeft;
        private System.Windows.Forms.Button btnMoveLeftAll;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}