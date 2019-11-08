using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using XF.Common;
using Enums;
using XF.ExControls;
using System.Collections;
using XF.BLL;
using System.Drawing;

namespace BabySwim
{
    public partial class FrmImportCustomer : XFFormEx
    {
        Base_Customer bll = new Base_Customer();
        SysManage bllSys = new SysManage();
        OpenFileDialog fileDialog = new OpenFileDialog();
        public FrmImportCustomer()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "Excel 97-2003 文件|*.xls";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                tbFilePath.Text = fileDialog.FileName;
            }  
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (File.Exists(tbFilePath.Text))
            {
                try
                {
                    dataGridView1.DataSource = ExcelOptioner.Import(tbFilePath.Text);
                }
                catch
                {
                    QQMessageBox.Show(
                        this,
                        MessageText.TIP_FILE_INVALID,
                        MessageText.MESSAGEBOX_CAPTION_TIP,
                        QQMessageBoxIcon.Information,
                        QQMessageBoxButtons.OK);
                }
            }
            else
            {
                QQMessageBox.Show(
                        this,
                        MessageText.TIP_FILE_NON_EXIST,
                        MessageText.MESSAGEBOX_CAPTION_TIP,
                        QQMessageBoxIcon.Information,
                        QQMessageBoxButtons.OK);
            }
        }

        private void tsBtnImport_Click(object sender, EventArgs e)
        {
            tsBtnImport.Enabled = false;
            try
            {
                string msg = string.Empty;
                if (dataGridView1.Rows.Count > 0)
                {
                    //数据格式验证
                    foreach (DataGridViewRow dgvr in dataGridView1.Rows)
                    {
                        if (zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_CUSTOMERCODE].Value).Equals(string.Empty))
                        {
                            msg += string.Format(MessageText.CHECK_ERROR_CUSTOMER_IMPORT_CODE, dgvr.Index + 1) + MessageText.KEY_ENTER;
                        }
                        if (zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_CUSTOMERNAME].Value).Equals(string.Empty))
                        {
                            msg += string.Format(MessageText.CHECK_ERROR_CUSTOMER_IMPORT_NAME, dgvr.Index + 1) + MessageText.KEY_ENTER;
                        }
                        string isVisit = zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_ISVISIT].Value).Trim();
                        if (!(isVisit.Equals("是") || isVisit.Equals("否")))
                        {
                            msg += string.Format(MessageText.CHECK_ERROR_CUSTOMER_IMPORT_ISVISIT, dgvr.Index + 1) + MessageText.KEY_ENTER;
                        }
                        if (isVisit.Equals("是"))
                        {
                            DateTime tempDateTime;
                            if (!DateTime.TryParse(zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_VISITDATE].Value).Trim(), out tempDateTime))
                            {
                                msg += string.Format(MessageText.CHECK_ERROR_CUSTOMER_IMPORT_VISITDATE, dgvr.Index + 1) + MessageText.KEY_ENTER;
                            }
                        }
                    }
                    //数据导入
                    if (msg.Equals(string.Empty))
                    {
                        ArrayList lstSql = new ArrayList();
                        XF.Model.Base_Customer model;
                        foreach (DataGridViewRow dgvr in dataGridView1.Rows)
                        {
                            model = bll.GetModel(zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_CUSTOMERCODE].Value));
                            if (model == null)
                            {
                                model = new XF.Model.Base_Customer();
                                model.CustomerCode = zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_CUSTOMERCODE].Value);
                                model.CustomerName = zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_CUSTOMERNAME].Value);
                                model.Phone = zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_PHONE].Value);
                                //if (zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_BIRTHDAY].Value).Equals(string.Empty))
                                //{
                                //    model.Birthday = null;
                                //}
                                //else
                                //{
                                //    model.Birthday = Convert.ToDateTime(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_BIRTHDAY].Value);
                                //}
                                model.Age = zDataConverter.ToInt(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_AGE].Value);
                                model.CoursePrice = zDataConverter.ToDecimal(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_COURSEPRICE].Value);
                                model.InfoSource = zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_INFOSOURCE].Value);
                                model.FollowInfo = zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_FOLLOWINFO].Value);
                                model.FollowUser = zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_FOLLOWUSER].Value);
                                if (zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_ISVISIT].Value).Trim().Equals("是"))
                                {
                                    model.IsVisit = true;
                                }
                                else
                                {
                                    model.IsVisit = false;
                                }
                                if (model.IsVisit)
                                {
                                    model.VisitDate = Convert.ToDateTime(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_VISITDATE].Value);
                                }
                                else
                                {
                                    model.VisitDate = null;
                                }
                                model.Description = zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_DESCRIPTION].Value);
                                lstSql.Add(bll.GetAddSql(model));
                            }
                            else
                            {
                                model.CustomerName = zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_CUSTOMERNAME].Value);
                                model.Phone = zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_PHONE].Value);
                                //if (zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_BIRTHDAY].Value).Equals(string.Empty))
                                //{
                                //    model.Birthday = null;
                                //}
                                //else
                                //{
                                //    model.Birthday = Convert.ToDateTime(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_BIRTHDAY].Value);
                                //}
                                model.Age = zDataConverter.ToInt(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_AGE].Value);
                                model.CoursePrice = zDataConverter.ToDecimal(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_COURSEPRICE].Value);
                                model.InfoSource = zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_INFOSOURCE].Value);
                                model.FollowInfo = zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_FOLLOWINFO].Value);
                                model.FollowUser = zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_FOLLOWUSER].Value);
                                if (zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_ISVISIT].Value).Trim().Equals("是"))
                                {
                                    model.IsVisit = true;
                                }
                                else
                                {
                                    model.IsVisit = false;
                                }
                                if (model.IsVisit)
                                {
                                    model.VisitDate = Convert.ToDateTime(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_VISITDATE].Value);
                                }
                                else
                                {
                                    model.VisitDate = null;
                                }
                                model.Description = zDataConverter.ToString(dgvr.Cells[MessageText.IMPORT_TEMPLATES_CUSTOMER_DESCRIPTION].Value);
                                lstSql.Add(bll.GetUpdateSql(model));
                            }
                        }
                        if (bllSys.ExecuteSqlTran(lstSql))
                        {
                            QQMessageBox.Show(
                                this,
                                MessageText.TIP_SUCCESS_IMPORT,
                                MessageText.MESSAGEBOX_CAPTION_ERROR,
                                QQMessageBoxIcon.OK,
                                QQMessageBoxButtons.OK);
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            QQMessageBox.Show(
                                this,
                                MessageText.SQL_ERROR_CUSTOMER_IMPORT,
                                MessageText.MESSAGEBOX_CAPTION_ERROR,
                                QQMessageBoxIcon.Error,
                                QQMessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        QQMessageBox.Show(
                        this,
                        msg,
                        MessageText.MESSAGEBOX_CAPTION_WARN,
                        QQMessageBoxIcon.Warning,
                        QQMessageBoxButtons.OK);
                    }
                }
                else
                {
                    QQMessageBox.Show(
                        this,
                        MessageText.TIP_WARN_DATA_NONE,
                        MessageText.MESSAGEBOX_CAPTION_WARN,
                        QQMessageBoxIcon.Warning,
                        QQMessageBoxButtons.OK);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                tsBtnImport.Enabled = true;
            }
        }

        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void FrmImportCustomer_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            this.TextForeColor = ConfigSetting.TextForeColor;
        }
    }
}
