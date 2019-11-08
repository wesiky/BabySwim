using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using XF.ExControls;
using XF.Common;
using Enums;
using System.Drawing;

namespace BabySwim
{
    public partial class FrmDialogCustomer : XFFormEx
    {
        int studentid;
        string studentcode;
        string studentname;
        string phone;
        DateTime birthday;
        int age;
        string description;

        public int StudentID
        {
            get { return studentid; }
            set { studentid = value; }
        }

        public string StudentCode
        {
            get { return studentcode; }
            set { studentcode = value; }
        }

        public string StudentName
        {
            get { return studentname; }
            set { studentname = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        XF.BLL.Base_Customer bll = new XF.BLL.Base_Customer();

        public FrmDialogCustomer()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        public FrmDialogCustomer(string customerName)
        {
            InitializeComponent();
            tsTbCustomer.Text = customerName;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void tsBtnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void FrmDialogComponent_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            this.TextForeColor = ConfigSetting.TextForeColor;
            BindData();
        }

        private void BindData()
        {
            string strWhere = string.Empty;
            if (!tsTbCustomer.Text.Trim().Equals(string.Empty))
            {
                strWhere += string.Format(" and (StudentCode LIKE '%{0}%' or StudentName LIKE '%{1}%')", tsTbCustomer.Text.Trim(), tsTbCustomer.Text.Trim());
            }
            int count = 0;
            DataTable dt = bll.GetListByPage(strWhere, " CreateDate DESC ", pagerControl1.PageIndex, pagerControl1.PageSize, ref count);

            pagerControl1.DrawControl(count);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                DateTime dt ;
                this.studentid = zDataConverter.ToInt(dataGridView1.SelectedRows[0].Cells[ColStudentID.Name].Value);
                this.studentcode = zDataConverter.ToString(dataGridView1.SelectedRows[0].Cells[ColStudentCode.Name].Value);
                this.studentname = zDataConverter.ToString( dataGridView1.SelectedRows[0].Cells[ColStudentName.Name].Value);
                this.phone = zDataConverter.ToString(dataGridView1.SelectedRows[0].Cells[ColPhone.Name].Value);
                if(DateTime.TryParse(zDataConverter.ToString(dataGridView1.SelectedRows[0].Cells[ColBirthDay.Name].Value),out dt))
                {
                    this.birthday = dt;
                }
                this.age = zDataConverter.ToInt(dataGridView1.SelectedRows[0].Cells[ColAge.Name].Value);
                this.description = zDataConverter.ToString(dataGridView1.SelectedRows[0].Cells[ColDescription.Name].Value);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                QQMessageBox.Show(
                            this,
                            MessageText.TIP_ERROR_SELECTCOUNT_ONE,
                            MessageText.MESSAGEBOX_CAPTION_TIP,
                            QQMessageBoxIcon.Information,
                            QQMessageBoxButtons.OK);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SaveData();
        }
    }
}
