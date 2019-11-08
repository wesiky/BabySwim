using System;
using System.Collections.Generic;
using System.Linq;
using XF.ExControls;
using Enums;
using XF.Common;
using System.Drawing;
using System.Data;

namespace BabySwim
{
    public partial class FrmTeacherCard : XFFormEx
    {
        private XF.Model.Base_Teacher model;
        private CardEnum status = CardEnum.LOOK;
        DataTable dtTeacherJob = GenerateData.GetTeacherJob(false);
        DataTable dtAdviserJob = GenerateData.GetAdviserJob(false);
        public CardEnum Status
        {
            get { return status; }
            set 
            { 
                status = value;
                SetControlStatus();
            }
        }

        public XF.Model.Base_Teacher Model
        {
            get { return model; }
            set 
            { 
                model = value;
                LoadFormData();
            }
        }

        public FrmTeacherCard()
        {
            InitializeComponent();

            cmbType.DisplayMember = MessageText.LISTITEM_TEXT;
            cmbType.ValueMember = MessageText.LISTITEM_VALUE;
            cmbType.DataSource = GenerateData.GetTeacherType(false);
            cmbJob.DisplayMember = MessageText.LISTITEM_TEXT;
            cmbJob.ValueMember = MessageText.LISTITEM_VALUE;
            cmbJob.DataSource = dtTeacherJob;
            cmbJobLevel.DisplayMember = MessageText.LISTITEM_TEXT;
            cmbJobLevel.ValueMember = MessageText.LISTITEM_VALUE;
            cmbJobLevel.DataSource = GenerateData.GetTeacherJobLevel(false);
        }

        /// <summary>
        /// 取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    tbAge.ReadOnly = true;
                    cmbType.Enabled = false;
                    cmbJob.Enabled = false;
                    cmbJobLevel.Enabled = false;
                    tbSintroduction.ReadOnly = true;
                    break;
                case CardEnum.ADD:
                    tbCode.ReadOnly = false;
                    tbName.ReadOnly = false;
                    tbAge.ReadOnly = false;
                    cmbType.Enabled = true;
                    cmbJob.Enabled = true;
                    cmbJobLevel.Enabled = true;
                    tbSintroduction.ReadOnly = false;
                    break;
                case CardEnum.UPDATE:
                    tbCode.ReadOnly = true;
                    tbName.ReadOnly = false;
                    tbAge.ReadOnly = false;
                    cmbType.Enabled = true;
                    cmbJob.Enabled = true;
                    cmbJobLevel.Enabled = true;
                    tbSintroduction.ReadOnly = false;
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
                tbCode.Text = model.TeacherCode;
                tbName.Text = model.TeacherName;
                tbAge.Text = model.Age.ToString();
                cmbType.SelectedValue = model.TeacherType;
                cmbJob.SelectedValue = model.Job;
                cmbJobLevel.SelectedValue = model.JobLevel;
                tbSintroduction.Text = model.Sintroduction;
            }
        }

        /// <summary>
        /// 设置Model数据
        /// </summary>
        private void SetModelData()
        {
            if (model == null)
            {
                model = new XF.Model.Base_Teacher();
            }
            model.TeacherCode = tbCode.Text.Trim();
            model.TeacherName = tbName.Text;
            model.Age = zDataConverter.ToInt(tbAge.Text.Trim());
            model.TeacherType = zDataConverter.ToInt(cmbType.SelectedValue);
            model.Job = zDataConverter.ToInt(cmbJob.SelectedValue);
            model.JobLevel = zDataConverter.ToInt(cmbJobLevel.SelectedValue);
            model.Sintroduction = tbSintroduction.Text;
        }

        /// <summary>
        /// 数据校验
        /// </summary>
        /// <returns>校验结果信息，为空表示校验通过</returns>
        private string CheckInput()
        {
            int age;
            if (tbCode.Text.Trim().Equals(string.Empty))
            {
                return MessageText.CHECK_ERROR_TEACHER_CODE;
            }
            if (tbName.Text.Equals(string.Empty))
            {
                return MessageText.CHECK_ERROR_TEACHER_NAME;
            }
            if (!int.TryParse(tbAge.Text.Trim(), out age))
            {
                return MessageText.CHECK_ERROR_TEACHER_AGE;
            }
            return string.Empty;
        }

        private void FrmTeacherCard_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            this.TextForeColor = ConfigSetting.TextForeColor;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex == 0)
            {
                cmbJob.DataSource = dtTeacherJob;
            }
            else
            {
                cmbJob.DataSource = dtAdviserJob;
            }
        }
    }
}
