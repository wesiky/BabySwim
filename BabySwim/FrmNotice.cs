using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XF.ExControls.ControlExs;
using XF.ExControls;
using Enums;

namespace BabySwim
{
    public partial class FrmNotice : Form
    {
        XF.BLL.Assist_Notice bll = new XF.BLL.Assist_Notice();
        List<NoticeRecord> noticeRecords;

        public List<NoticeRecord> GetNotices()
        {
            if (noticeRecords == null)
            {
                noticeRecords = new List<NoticeRecord>();
            }
            return noticeRecords;
        }

        public FrmNotice()
        {
            InitializeComponent();
            List<XF.Model.Assist_Notice> notices = bll.GetUndoModelList();
            foreach (XF.Model.Assist_Notice notice in notices)
            {
                NoticeRecord noticeRecord = new NoticeRecord();
                noticeRecord.NoticeID = notice.NoticeID;
                noticeRecord.Width = this.flowLayoutPanel1.Width / 3;
                noticeRecord.Content = notice.ContentMsg;
                noticeRecord.ObjectName = notice.ObjectName;
                noticeRecord.Additional = notice.AttachMsg;
                noticeRecord.SureClick += new NoticeRecord.NoticeClick(noticeRecord_SureClick);
                noticeRecord.CancelClick += new NoticeRecord.NoticeClick(noticeRecord_CancelClick);
                this.flowLayoutPanel1.Controls.Add(noticeRecord);
                noticeRecords.Add(noticeRecord);
            }
        }

        private void noticeRecord_SureClick(object sender, EventArgs e)
        {
            try
            {
                NoticeRecord noticeRecord = (sender as NoticeRecord);
                ConductNotice(noticeRecord, Enums.NoticeStatusEnum.Done);
            }
            catch (Exception ex)
            {
                QQMessageBox.Show(this, "消息处理失败，请联系管理员！错误信息：" + ex.Message, MessageText.MESSAGEBOX_CAPTION_ERROR, QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="noticeRecord"></param>
        /// <param name="status"></param>
        private void ConductNotice(NoticeRecord noticeRecord,Enums.NoticeStatusEnum status)
        {
            if (bll.ConductNotice(noticeRecord.NoticeID, status))
            {
                this.flowLayoutPanel1.Controls.Remove(noticeRecord);
                noticeRecord.Dispose();
            }
            else
            {
                throw new Exception("更新数据库失败");
            }
        }

        private void noticeRecord_CancelClick(object sender, EventArgs e)
        {
            try
            {
                NoticeRecord noticeRecord = (sender as NoticeRecord);
                ConductNotice(noticeRecord, Enums.NoticeStatusEnum.Ignore);
            }
            catch (Exception ex)
            {
                QQMessageBox.Show(this, "消息处理失败，请联系管理员！错误信息：" + ex.Message, MessageText.MESSAGEBOX_CAPTION_ERROR, QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
            }
        }

        private void FrmNotice_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (NoticeRecord noticeRecord in GetNotices())
            {
                noticeRecord.Width = this.flowLayoutPanel1.Width / 3 - 5;
            }
        }
    }
}
