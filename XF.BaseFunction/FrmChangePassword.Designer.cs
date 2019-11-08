namespace XF.BaseFunction
{
    partial class FrmChangePassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbPasswordOld = new System.Windows.Forms.TextBox();
            this.tbPasswordNew = new System.Windows.Forms.TextBox();
            this.tbPasswordSure = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "原密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "新密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "确认新密码";
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(107, 179);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 30);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(227, 179);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbPasswordOld
            // 
            this.tbPasswordOld.Location = new System.Drawing.Point(148, 30);
            this.tbPasswordOld.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPasswordOld.Name = "tbPasswordOld";
            this.tbPasswordOld.PasswordChar = '*';
            this.tbPasswordOld.Size = new System.Drawing.Size(180, 25);
            this.tbPasswordOld.TabIndex = 5;
            this.tbPasswordOld.UseSystemPasswordChar = true;
            // 
            // tbPasswordNew
            // 
            this.tbPasswordNew.Location = new System.Drawing.Point(148, 80);
            this.tbPasswordNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPasswordNew.Name = "tbPasswordNew";
            this.tbPasswordNew.PasswordChar = '*';
            this.tbPasswordNew.Size = new System.Drawing.Size(180, 25);
            this.tbPasswordNew.TabIndex = 6;
            this.tbPasswordNew.UseSystemPasswordChar = true;
            // 
            // tbPasswordSure
            // 
            this.tbPasswordSure.Location = new System.Drawing.Point(148, 130);
            this.tbPasswordSure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPasswordSure.Name = "tbPasswordSure";
            this.tbPasswordSure.PasswordChar = '*';
            this.tbPasswordSure.Size = new System.Drawing.Size(180, 25);
            this.tbPasswordSure.TabIndex = 7;
            this.tbPasswordSure.UseSystemPasswordChar = true;
            // 
            // FrmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(397, 236);
            this.Controls.Add(this.tbPasswordSure);
            this.Controls.Add(this.tbPasswordNew);
            this.Controls.Add(this.tbPasswordOld);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmChangePassword";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.FrmChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbPasswordOld;
        private System.Windows.Forms.TextBox tbPasswordNew;
        private System.Windows.Forms.TextBox tbPasswordSure;
    }
}