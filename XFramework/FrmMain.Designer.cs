namespace XFramework
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblRealName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiColse = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExitFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tabWelcome = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlClose2 = new System.Windows.Forms.Panel();
            this.notifyChint = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLoginInfo = new System.Windows.Forms.Panel();
            this.gbLoginInfo = new System.Windows.Forms.GroupBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoginCancel = new System.Windows.Forms.Button();
            this.btnLoginOK = new System.Windows.Forms.Button();
            this.btnLoginEdit = new System.Windows.Forms.Button();
            this.lblLoginId = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabWelcome.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.pnlLoginInfo.SuspendLayout();
            this.gbLoginInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.tsslblRealName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(750, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel2.Text = "你好，";
            // 
            // tsslblRealName
            // 
            this.tsslblRealName.IsLink = true;
            this.tsslblRealName.LinkColor = System.Drawing.Color.DarkCyan;
            this.tsslblRealName.Name = "tsslblRealName";
            this.tsslblRealName.Size = new System.Drawing.Size(44, 17);
            this.tsslblRealName.Text = "管理员";
            this.tsslblRealName.VisitedLinkColor = System.Drawing.Color.DarkCyan;
            this.tsslblRealName.Click += new System.EventHandler(this.tsslblLoginName_Click);
            this.tsslblRealName.MouseEnter += new System.EventHandler(this.tsslblLoginName_MouseEnter);
            this.tsslblRealName.MouseLeave += new System.EventHandler(this.tsslblLoginName_MouseLeave);
            // 
            // tabMain
            // 
            this.tabMain.ContextMenuStrip = this.contextMenuStrip1;
            this.tabMain.Controls.Add(this.tabWelcome);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.ItemSize = new System.Drawing.Size(100, 18);
            this.tabMain.Location = new System.Drawing.Point(0, 25);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Drawing.Point(16, 3);
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(750, 515);
            this.tabMain.TabIndex = 4;
            this.tabMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tabMain_KeyPress);
            this.tabMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TabMain_MouseDoubleClick);
            this.tabMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabMain_MouseDown);
            this.tabMain.MouseLeave += new System.EventHandler(this.TabMain_MouseLeave);
            this.tabMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TabMain_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiColse,
            this.tsmiExitFullScreen});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // tsmiColse
            // 
            this.tsmiColse.Name = "tsmiColse";
            this.tsmiColse.Size = new System.Drawing.Size(124, 22);
            this.tsmiColse.Text = "关闭";
            this.tsmiColse.Click += new System.EventHandler(this.TsmiColse_Click);
            // 
            // tsmiExitFullScreen
            // 
            this.tsmiExitFullScreen.Name = "tsmiExitFullScreen";
            this.tsmiExitFullScreen.Size = new System.Drawing.Size(124, 22);
            this.tsmiExitFullScreen.Text = "退出全屏";
            this.tsmiExitFullScreen.Click += new System.EventHandler(this.TsmiExitFullScreen_Click);
            // 
            // tabWelcome
            // 
            this.tabWelcome.BackColor = System.Drawing.Color.White;
            this.tabWelcome.Controls.Add(this.pictureBox1);
            this.tabWelcome.Location = new System.Drawing.Point(4, 22);
            this.tabWelcome.Name = "tabWelcome";
            this.tabWelcome.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabWelcome.Size = new System.Drawing.Size(742, 489);
            this.tabWelcome.TabIndex = 0;
            this.tabWelcome.Text = "首页";
            this.tabWelcome.Resize += new System.EventHandler(this.TabWelcome_Resize);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1192, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.PbClose_Click);
            // 
            // pnlClose2
            // 
            this.pnlClose2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlClose2.BackgroundImage")));
            this.pnlClose2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlClose2.Location = new System.Drawing.Point(58, 29);
            this.pnlClose2.Name = "pnlClose2";
            this.pnlClose2.Size = new System.Drawing.Size(10, 12);
            this.pnlClose2.TabIndex = 8;
            this.pnlClose2.Visible = false;
            this.pnlClose2.Click += new System.EventHandler(this.pbClose2_Click);
            // 
            // notifyChint
            // 
            this.notifyChint.ContextMenuStrip = this.contextMenuStrip2;
            this.notifyChint.Text = "正泰综合办公平台";
            this.notifyChint.Visible = true;
            this.notifyChint.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyChint_MouseDoubleClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem1.Text = "退出";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // pnlLoginInfo
            // 
            this.pnlLoginInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLoginInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            this.pnlLoginInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoginInfo.Controls.Add(this.gbLoginInfo);
            this.pnlLoginInfo.Controls.Add(this.btnLoginCancel);
            this.pnlLoginInfo.Controls.Add(this.btnLoginOK);
            this.pnlLoginInfo.Controls.Add(this.btnLoginEdit);
            this.pnlLoginInfo.Controls.Add(this.lblLoginId);
            this.pnlLoginInfo.Location = new System.Drawing.Point(0, 922);
            this.pnlLoginInfo.Name = "pnlLoginInfo";
            this.pnlLoginInfo.Size = new System.Drawing.Size(225, 242);
            this.pnlLoginInfo.TabIndex = 4;
            this.pnlLoginInfo.Visible = false;
            this.pnlLoginInfo.VisibleChanged += new System.EventHandler(this.pnlLoginInfo_VisibleChanged);
            // 
            // gbLoginInfo
            // 
            this.gbLoginInfo.Controls.Add(this.txtPhone);
            this.gbLoginInfo.Controls.Add(this.txtEmail);
            this.gbLoginInfo.Controls.Add(this.label5);
            this.gbLoginInfo.Controls.Add(this.txtLoginName);
            this.gbLoginInfo.Controls.Add(this.txtRealName);
            this.gbLoginInfo.Controls.Add(this.label4);
            this.gbLoginInfo.Controls.Add(this.label3);
            this.gbLoginInfo.Controls.Add(this.label1);
            this.gbLoginInfo.Enabled = false;
            this.gbLoginInfo.Location = new System.Drawing.Point(8, 40);
            this.gbLoginInfo.Name = "gbLoginInfo";
            this.gbLoginInfo.Size = new System.Drawing.Size(206, 163);
            this.gbLoginInfo.TabIndex = 3;
            this.gbLoginInfo.TabStop = false;
            this.gbLoginInfo.Text = "用户信息";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(52, 113);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(141, 21);
            this.txtPhone.TabIndex = 2;
            this.txtPhone.Text = "13777777777";
            this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(52, 86);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(141, 21);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Text = "admin@chint.com";
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "手机";
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(52, 32);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.ReadOnly = true;
            this.txtLoginName.Size = new System.Drawing.Size(141, 21);
            this.txtLoginName.TabIndex = 2;
            this.txtLoginName.Text = "admin";
            this.txtLoginName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRealName
            // 
            this.txtRealName.Location = new System.Drawing.Point(52, 59);
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(141, 21);
            this.txtRealName.TabIndex = 2;
            this.txtRealName.Text = "管理员";
            this.txtRealName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "邮箱";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "姓名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户";
            // 
            // btnLoginCancel
            // 
            this.btnLoginCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoginCancel.BackgroundImage")));
            this.btnLoginCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLoginCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginCancel.Location = new System.Drawing.Point(189, 8);
            this.btnLoginCancel.Name = "btnLoginCancel";
            this.btnLoginCancel.Size = new System.Drawing.Size(25, 23);
            this.btnLoginCancel.TabIndex = 0;
            this.btnLoginCancel.UseVisualStyleBackColor = true;
            this.btnLoginCancel.Click += new System.EventHandler(this.btnLoginCancel_Click);
            // 
            // btnLoginOK
            // 
            this.btnLoginOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoginOK.BackgroundImage")));
            this.btnLoginOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLoginOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginOK.Location = new System.Drawing.Point(10, 209);
            this.btnLoginOK.Name = "btnLoginOK";
            this.btnLoginOK.Size = new System.Drawing.Size(25, 23);
            this.btnLoginOK.TabIndex = 0;
            this.btnLoginOK.UseVisualStyleBackColor = true;
            this.btnLoginOK.Visible = false;
            this.btnLoginOK.Click += new System.EventHandler(this.btnLoginOK_Click);
            // 
            // btnLoginEdit
            // 
            this.btnLoginEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoginEdit.BackgroundImage")));
            this.btnLoginEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLoginEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginEdit.Location = new System.Drawing.Point(10, 8);
            this.btnLoginEdit.Name = "btnLoginEdit";
            this.btnLoginEdit.Size = new System.Drawing.Size(25, 23);
            this.btnLoginEdit.TabIndex = 0;
            this.btnLoginEdit.UseVisualStyleBackColor = true;
            this.btnLoginEdit.Click += new System.EventHandler(this.btnLoginEdit_Click);
            // 
            // lblLoginId
            // 
            this.lblLoginId.AutoSize = true;
            this.lblLoginId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.lblLoginId.Location = new System.Drawing.Point(82, 13);
            this.lblLoginId.Name = "lblLoginId";
            this.lblLoginId.Size = new System.Drawing.Size(11, 12);
            this.lblLoginId.TabIndex = 1;
            this.lblLoginId.Text = "1";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pnlLoginInfo);
            this.panel1.Controls.Add(this.pnlClose2);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.tabMain);
            this.panel1.Controls.Add(this.toolStrip);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Location = new System.Drawing.Point(9, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 562);
            this.panel1.TabIndex = 10;
            // 
            // toolStrip
            // 
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(750, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(736, 483);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(768, 614);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(99999, 99999);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabWelcome.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.pnlLoginInfo.ResumeLayout(false);
            this.pnlLoginInfo.PerformLayout();
            this.gbLoginInfo.ResumeLayout(false);
            this.gbLoginInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabWelcome;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiColse;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlClose2;
        public System.Windows.Forms.NotifyIcon notifyChint;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblRealName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Panel pnlLoginInfo;
        private System.Windows.Forms.Button btnLoginEdit;
        private System.Windows.Forms.Button btnLoginOK;
        private System.Windows.Forms.Button btnLoginCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbLoginInfo;
        private System.Windows.Forms.Label lblLoginId;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExitFullScreen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}