using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XF.ExControls;
using Enums;
using XF.Common;

namespace BabySwim
{
    public partial class FrmCourseChoice : XFFormEx
    {
        private XF.BLL.Base_Course bll = new XF.BLL.Base_Course();
        private XF.Model.Course_Selection model;

        public XF.Model.Course_Selection Model
        {
            get { return model; }
            set { model = value; }
        }

        public FrmCourseChoice()
        {
            InitializeComponent();
        }

        private void FrmCourseChoice_Load(object sender, EventArgs e)
        {
            this.TextForeColor = ConfigSetting.TextForeColor;
            this.Icon = ConfigSetting.ProjectIcon;
            List<XF.Model.Base_Course> models = bll.GetModelList(string.Empty);
            if (models.Count > 0)
            {
                tableLayoutPanel1.ColumnStyles.Clear();
                
                for (int i = 0; i < models.Count; i++)
                {
                    QQButton btn = new QQButton();
                    btn.Dock = DockStyle.Fill;
                    btn.Name = "BtnCourse" + models[i].CourseID.ToString();
                    btn.Text = models[i].CourseName;
                    btn.Tag = models[i];
                    btn.Click += new EventHandler(BtnCourse_Click); 
                    ColumnStyle columnStyle = new ColumnStyle();
                    columnStyle.SizeType = SizeType.Percent;
                    columnStyle.Width = 100 / models.Count;
                    tableLayoutPanel1.ColumnCount = models.Count;
                    tableLayoutPanel1.ColumnStyles.Add(columnStyle);
                    tableLayoutPanel1.Controls.Add(btn);
                }
            }
        }

        private void BtnCourse_Click(object sender, EventArgs e)
        {
            this.Hide();
            XF.Model.Base_Course course;
            try
            {
                course = ((sender as Button).Tag) as XF.Model.Base_Course;
                model.CourseID = course.CourseID;
                model.CourseName = course.CourseName;
            }
            catch
            {
                return;
            }
            if (model.CourseID == zDataConverter.ToInt(ConfigSetting.TryOutCourseID))
            {
                FrmTryOutCourseSelectionInfo frmTryOutCourseSelectionInfo = new FrmTryOutCourseSelectionInfo();
                frmTryOutCourseSelectionInfo.Status = CardEnum.ADD;
                frmTryOutCourseSelectionInfo.Model = model;
                frmTryOutCourseSelectionInfo.ShowDialog();
                this.DialogResult = frmTryOutCourseSelectionInfo.DialogResult;
                this.Close();
            }
            else
            {
                FrmCourseSelectionInfo frmCourseSelectionInfo = new FrmCourseSelectionInfo();
                frmCourseSelectionInfo.Status = CardEnum.ADD;
                frmCourseSelectionInfo.Model = model;
                frmCourseSelectionInfo.ShowDialog();
                this.DialogResult = frmCourseSelectionInfo.DialogResult;
                this.Close();
            }
        }
    }
}
