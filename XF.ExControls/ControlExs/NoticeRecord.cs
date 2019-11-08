using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XF.ExControls.ControlExs
{
    public partial class NoticeRecord : UserControl
    {
        int noticeid;

        public delegate void NoticeClick(object sender, EventArgs e);
        public event NoticeClick SureClick;
        public event NoticeClick CancelClick;

        public int NoticeID
        {
            get { return noticeid; }
            set { noticeid = value; }
        }

        public string Additional
        {
            get { return lbAdditional.Text; }
            set { lbAdditional.Text = value; }
        }

        public string ObjectName
        {
            get { return lbObjectName.Text; }
            set { lbObjectName.Text = value; }
        }

        public string Content
        {
            get { return lbContent.Text; }
            set { lbContent.Text = value; }
        }
        public NoticeRecord()
        {
            InitializeComponent();
        }

        public NoticeRecord(string objName,string additional,string content)
        {
            InitializeComponent();
            lbObjectName.Text = objName;
            lbAdditional.Text = additional;
            lbContent.Text = content;
        }

        private void imgBtnCancel_Click(object sender, EventArgs e)
        {
            CancelClick(this, e);
        }

        private void imgBtnSure_Click(object sender, EventArgs e)
        {
            SureClick(this, e);
        }
    }
}
