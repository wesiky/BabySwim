namespace XF.ExControls
{
    partial class NoticeControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gbNotice = new System.Windows.Forms.GroupBox();
            this.txtNoticeContent = new System.Windows.Forms.TextBox();
            this.linklblDetail = new System.Windows.Forms.LinkLabel();
            this.gbNotice.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNotice
            // 
            this.gbNotice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNotice.Controls.Add(this.txtNoticeContent);
            this.gbNotice.Controls.Add(this.linklblDetail);
            this.gbNotice.Location = new System.Drawing.Point(3, 3);
            this.gbNotice.Name = "gbNotice";
            this.gbNotice.Size = new System.Drawing.Size(494, 144);
            this.gbNotice.TabIndex = 0;
            this.gbNotice.TabStop = false;
            this.gbNotice.Text = "通知";
            // 
            // txtNoticeContent
            // 
            this.txtNoticeContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoticeContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNoticeContent.Location = new System.Drawing.Point(12, 28);
            this.txtNoticeContent.Multiline = true;
            this.txtNoticeContent.Name = "txtNoticeContent";
            this.txtNoticeContent.Size = new System.Drawing.Size(472, 93);
            this.txtNoticeContent.TabIndex = 2;
            // 
            // linklblDetail
            // 
            this.linklblDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linklblDetail.AutoSize = true;
            this.linklblDetail.Location = new System.Drawing.Point(434, 124);
            this.linklblDetail.Name = "linklblDetail";
            this.linklblDetail.Size = new System.Drawing.Size(53, 12);
            this.linklblDetail.TabIndex = 1;
            this.linklblDetail.TabStop = true;
            this.linklblDetail.Text = "查看详情";
            this.linklblDetail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblDetail_LinkClicked);
            // 
            // NoticeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbNotice);
            this.Name = "NoticeControl";
            this.Size = new System.Drawing.Size(500, 150);
            this.gbNotice.ResumeLayout(false);
            this.gbNotice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNotice;
        private System.Windows.Forms.LinkLabel linklblDetail;
        private System.Windows.Forms.TextBox txtNoticeContent;
    }
}
