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
    public partial class FrmDialogTeacher : XFFormEx
    {
        int teacherid;
        string teachercode;
        string teachername;

        public int TeacherID
        {
            get { return teacherid; }
            set { teacherid = value; }
        }

        public string TeacherCode
        {
            get { return teachercode; }
            set { teachercode = value; }
        }

        public string TeacherName
        {
            get { return teachername; }
            set { teachername = value; }
        }

        XF.BLL.Base_Teacher bll = new XF.BLL.Base_Teacher();

        public FrmDialogTeacher()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        public FrmDialogTeacher(string teacher)
        {
            InitializeComponent();
            tsTbTeacher.Text = teacher;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            SaveDate();
        }

        private void SaveDate()
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                this.teacherid = zDataConverter.ToInt(dataGridView1.SelectedRows[0].Cells[ColID.Name].Value);
                this.teachercode = zDataConverter.ToString(dataGridView1.SelectedRows[0].Cells[ColCode.Name].Value);
                this.teachername = zDataConverter.ToString(dataGridView1.SelectedRows[0].Cells[ColName.Name].Value);
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
            strWhere = zDataConverter.AppendSQL(strWhere, " and A.TeacherType = 0 ");
            if (!tsTbTeacher.Text.Trim().Equals(string.Empty))
            {
                strWhere = zDataConverter.AppendSQL(strWhere, string.Format(" (A.TeacherCode LIKE '%{0}%' or A.TeacherName LIKE '%{1}%')", tsTbTeacher.Text.Trim(), tsTbTeacher.Text.Trim()));
            }
            int count = 0;
            DataTable dt = bll.GetListByPage(strWhere, " A.TeacherCode DESC ", pagerControl1.PageIndex, pagerControl1.PageSize, ref count);

            pagerControl1.DrawControl(count);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SaveDate();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SaveDate();
        }
    }
}
