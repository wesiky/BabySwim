namespace XF.ExControls.ControlExs
{
    partial class NoticeRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoticeRecord));
            this.lbObjectName = new System.Windows.Forms.Label();
            this.lbAdditional = new System.Windows.Forms.Label();
            this.imgBtnSure = new XF.ExControls.ImageButton();
            this.imgBtnCancel = new XF.ExControls.ImageButton();
            this.lbContent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBtnSure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBtnCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // lbObjectName
            // 
            this.lbObjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbObjectName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbObjectName.Location = new System.Drawing.Point(3, 38);
            this.lbObjectName.Name = "lbObjectName";
            this.lbObjectName.Size = new System.Drawing.Size(187, 15);
            this.lbObjectName.TabIndex = 0;
            this.lbObjectName.Text = "通知对象";
            // 
            // lbAdditional
            // 
            this.lbAdditional.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAdditional.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAdditional.Location = new System.Drawing.Point(196, 38);
            this.lbAdditional.Name = "lbAdditional";
            this.lbAdditional.Size = new System.Drawing.Size(317, 15);
            this.lbAdditional.TabIndex = 1;
            this.lbAdditional.Text = "附加消息";
            // 
            // imgBtnSure
            // 
            this.imgBtnSure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBtnSure.BackColor = System.Drawing.Color.Transparent;
            this.imgBtnSure.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imgBtnSure.DownImage = null;
            this.imgBtnSure.HoverImage = null;
            this.imgBtnSure.Location = new System.Drawing.Point(549, 33);
            this.imgBtnSure.Name = "imgBtnSure";
            this.imgBtnSure.NormalImage = ((System.Drawing.Image)(resources.GetObject("imgBtnSure.NormalImage")));
            this.imgBtnSure.Size = new System.Drawing.Size(24, 24);
            this.imgBtnSure.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBtnSure.TabIndex = 2;
            this.imgBtnSure.TabStop = false;
            this.imgBtnSure.ToolTipText = null;
            this.imgBtnSure.Click += new System.EventHandler(this.imgBtnSure_Click);
            // 
            // imgBtnCancel
            // 
            this.imgBtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.imgBtnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imgBtnCancel.DownImage = null;
            this.imgBtnCancel.HoverImage = null;
            this.imgBtnCancel.Location = new System.Drawing.Point(519, 33);
            this.imgBtnCancel.Name = "imgBtnCancel";
            this.imgBtnCancel.NormalImage = ((System.Drawing.Image)(resources.GetObject("imgBtnCancel.NormalImage")));
            this.imgBtnCancel.Size = new System.Drawing.Size(24, 24);
            this.imgBtnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBtnCancel.TabIndex = 3;
            this.imgBtnCancel.TabStop = false;
            this.imgBtnCancel.ToolTipText = null;
            this.imgBtnCancel.Click += new System.EventHandler(this.imgBtnCancel_Click);
            // 
            // lbContent
            // 
            this.lbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbContent.Location = new System.Drawing.Point(3, 8);
            this.lbContent.Name = "lbContent";
            this.lbContent.Size = new System.Drawing.Size(570, 15);
            this.lbContent.TabIndex = 4;
            this.lbContent.Text = "通知内容";
            // 
            // NoticeRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imgBtnCancel);
            this.Controls.Add(this.imgBtnSure);
            this.Controls.Add(this.lbAdditional);
            this.Controls.Add(this.lbObjectName);
            this.Controls.Add(this.lbContent);
            this.Name = "NoticeRecord";
            this.Size = new System.Drawing.Size(584, 60);
            ((System.ComponentModel.ISupportInitialize)(this.imgBtnSure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBtnCancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbObjectName;
        private System.Windows.Forms.Label lbAdditional;
        private ImageButton imgBtnSure;
        private ImageButton imgBtnCancel;
        private System.Windows.Forms.Label lbContent;
    }
}
