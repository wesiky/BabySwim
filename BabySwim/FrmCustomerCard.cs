using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using XF.ExControls;
using XF.Common;
using System.Drawing;

namespace BabySwim
{
    public partial class FrmCustomerCard : XFFormEx
    {
        private XF.Model.Base_Customer model;
        private CardEnum status = CardEnum.LOOK;

        public CardEnum Status
        {
            get { return status; }
            set
            {
                status = value;
                SetControlStatus();
            }
        }

        public XF.Model.Base_Customer Model
        {
            get { return model; }
            set
            {
                model = value;
                LoadFormData();
            }
        }
        public FrmCustomerCard()
        {
            InitializeComponent();
            cmbIsVisit.DisplayMember = MessageText.LISTITEM_TEXT;
            cmbIsVisit.ValueMember = MessageText.LISTITEM_VALUE;
            cmbIsVisit.DataSource = GenerateData.GetYesNo();
        }

        private void tsBtnSure_Click(object sender, EventArgs e)
        {
            string msg = CheckInput();
            if (msg.Equals(string.Empty))
            {
                SetModelData();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                QQMessageBox.Show(
                this,
                msg,
                MessageText.MESSAGEBOX_CAPTION_TIP,
                QQMessageBoxIcon.Information,
                QQMessageBoxButtons.OK);
            }
        }

        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 设置界面控件状态
        /// </summary>
        private void SetControlStatus()
        {
            switch (status)
            {
                case CardEnum.LOOK:
                    tbCode.ReadOnly = true;
                    tbName.ReadOnly = true;
                    tbPhone.ReadOnly = true;
                    nudAge.Enabled = false;
                    tbCoursePrice.ReadOnly = true;
                    tbInfoSource.ReadOnly = true;
                    tbFollowUser.ReadOnly = true;
                    tbFollowInfo.ReadOnly = true;
                    cmbIsVisit.Enabled = false;
                    dtpVisitedDate.Enabled = false;
                    tbDescription.ReadOnly = true;
                    break;
                case CardEnum.ADD:
                    tbCode.ReadOnly = false;
                    tbName.ReadOnly = false;
                    tbPhone.ReadOnly = false;
                    nudAge.Enabled = true;
                    tbCoursePrice.ReadOnly = false;
                    tbInfoSource.ReadOnly = false;
                    tbFollowUser.ReadOnly = false;
                    tbFollowInfo.ReadOnly = false;
                    cmbIsVisit.Enabled = true;
                    dtpVisitedDate.Enabled = true;
                    tbDescription.ReadOnly = false;
                    break;
                case CardEnum.UPDATE:
                    tbCode.ReadOnly = true;
                    tbName.ReadOnly = true;
                    tbPhone.ReadOnly = false;
                    nudAge.Enabled = true;
                    tbCoursePrice.ReadOnly = false;
                    tbInfoSource.ReadOnly = false;
                    tbFollowUser.ReadOnly = false;
                    tbFollowInfo.ReadOnly = false;
                    cmbIsVisit.Enabled = true;
                    dtpVisitedDate.Enabled = true;
                    tbDescription.ReadOnly = false;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 设置界面数据
        /// </summary>
        private void LoadFormData()
        {
            if (model != null)
            {
                tbCode.Text = model.CustomerCode;
                tbName.Text = model.CustomerName;
                tbPhone.Text = model.Phone;
                //if (model.Birthday != null)
                //{
                //    dtpBirthdate.Value = (DateTime)model.Birthday;
                //}
                nudAge.Value = model.Age;
                tbCoursePrice.Text = model.CoursePrice.ToString();
                tbInfoSource.Text = model.InfoSource;
                tbFollowUser.Text = model.FollowUser;
                tbFollowInfo.Text = model.FollowInfo;
                if (model.IsVisit)
                {
                    cmbIsVisit.SelectedIndex = 0;
                }
                else
                {
                    cmbIsVisit.SelectedIndex = 1;
                }
                if (model.VisitDate != null)
                {
                    dtpVisitedDate.Value = (DateTime)model.VisitDate;
                }
                tbDescription.Text = model.Description;
            }
        }

        /// <summary>
        /// 设置Model数据
        /// </summary>
        private void SetModelData()
        {
            if (model == null)
            {
                model = new XF.Model.Base_Customer();
            }
            model.CustomerCode = tbCode.Text;
            model.CustomerName = tbName.Text;
            model.Phone = tbPhone.Text;
            //model.Birthday = dtpBirthdate.Value;
            model.Age = (int)nudAge.Value;
            model.CoursePrice = zDataConverter.ToDecimal(tbCoursePrice.Text.Trim());
            model.InfoSource = tbInfoSource.Text;
            model.FollowUser = tbFollowUser.Text;
            model.FollowInfo = tbFollowInfo.Text;
            model.IsVisit =Convert.ToBoolean(cmbIsVisit.SelectedValue);
            if (model.IsVisit)
            {
                model.VisitDate = dtpVisitedDate.Value;
            }
            else
            {
                model.VisitDate = null;
            }
            model.Description = tbDescription.Text;
        }

        /// <summary>
        /// 数据校验
        /// </summary>
        /// <returns>校验结果信息，为空表示校验通过</returns>
        private string CheckInput()
        {
            decimal price;
            if (tbCode.Text.Trim().Equals(string.Empty))
            {
                return MessageText.CHECK_ERROR_CUSTOMER_CODE;
            }
            if (tbName.Text.Trim().Equals(string.Empty))
            {
                return MessageText.CHECK_ERROR_CUSTOMER_NAME;
            }
            if (!decimal.TryParse(tbCoursePrice.Text.Trim(), out price))
            {
                return MessageText.CHECK_ERROR_CUSTOMER_COURSEPRICE;
            }
            return string.Empty;
        }

        private void FrmCustomerCard_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            this.TextForeColor = ConfigSetting.TextForeColor;
        }
    }
}
