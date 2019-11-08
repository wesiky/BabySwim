using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Enums;
using XF.Common;
using XF.ExControls;
using System.Drawing;

namespace BabySwim
{
    public partial class FrmSelectionStudentCard : XFFormEx
    {
        private XF.Model.Course_SelectionStudent model;

        public XF.Model.Course_SelectionStudent Model
        {
            get { return model; }
            set
            {
                model = value;
                LoadFormData();
            }
        }

        public FrmSelectionStudentCard()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 设置Model数据
        /// </summary>
        private void SetModelData()
        {
            if (rdoNormal.Checked)
            {
                model.SignType = 1;
            }
            else if (rdoLate.Checked)
            {
                model.SignType = 2;
            }
            else if(rdoEarly.Checked)
            {
                model.SignType = 3;
            }
            else if (rdoLeave.Checked)
            {
                model.SignType = 4;
            }
            else
            {
                model.SignType = 0;
            }
            model.Evaluate = rtcEvaluate.ContentRtf;
        }

        /// <summary>
        /// 设置界面数据
        /// </summary>
        private void LoadFormData()
        {
            if (model != null)
            {
                tbCourseDate.Text = model.CourseDate.Value.ToString(MessageText.FORMAT_DATE);
                tbClassRoom.Text = "教室" + MessageText.LIST_NUMBER_CHINESE[model.ClassroomID]; ;
                tbLessonNO.Text = model.LessonNO.ToString();
                tbCourseName.Text = model.CourseName;
                tbProgress.Text = model.SectionNO.ToString();
                tbTeacher.Text = model.TeacherCode + "-" + model.TeacherName;
                tbStudentName.Text = model.StudentName;
                tbNickName.Text = model.NickName;
                if (model.SelectionType == 0)
                {
                    tbSelectionType.Text = "临时";
                }
                else
                {
                    tbSelectionType.Text = "固定";
                }
                switch (model.SignType)
                {
                    case 0:
                        rdoUnSign.Checked = true;
                        break;
                    case 1:
                        rdoNormal.Checked = true;
                        break;
                    case 2:
                        rdoLate.Checked = true;
                        break;
                    case 3:
                        rdoEarly.Checked = true;
                        break;
                    case 4:
                        rdoLeave.Checked = true;
                        break;
                    default:
                        rdoNormal.Checked = true;
                        break;
                }
                rtcEvaluate.ContentRtf = model.Evaluate;
            }
        }

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            SetModelData();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void FrmSelectionStudentCard_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            this.TextForeColor = ConfigSetting.TextForeColor;
        }
    }
}
