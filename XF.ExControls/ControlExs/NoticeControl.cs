using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XF.ExControls
{
    public partial class NoticeControl : UserControl
    {
        public delegate void ClickHandler(string tabName,string tabTag);
        public event ClickHandler LinklblDetailOnClick;
        string m_sTabName = "";
        string m_sTabTag = "";
        
        public NoticeControl()
        {
            InitializeComponent();
        }
        public NoticeControl(List<object> listParams)
        {
            InitializeComponent();
            if (listParams != null && listParams.Count > 0)
            {
                switch (listParams[0].ToString())
                { 
                    case "0":
                        /// 普通首页提醒
                        /// 参数1：通知类型 【0：普通首页通知】
                        /// 参数2：TabName
                        /// 参数3：TabTag
                        /// 参数4：标题内容
                        /// 参数5：显示的文本内容
                        if (listParams.Count == 5)
                        {
                            m_sTabName = listParams[1].ToString();
                            m_sTabTag = listParams[2].ToString();
                            gbNotice.Text = listParams[3].ToString();
                            txtNoticeContent.Text = listParams[4].ToString();
                        }
                        break;
                }
            }
        }

        private void linklblDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinklblDetailOnClick(m_sTabName, m_sTabTag);
        }
    }
}
