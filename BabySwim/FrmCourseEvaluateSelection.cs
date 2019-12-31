using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XF.Common;
using Enums;
using XF.ExControls;
using System.Collections;
using System.IO;

namespace BabySwim
{
    public partial class FrmCourseEvaluateSelection : Form
    {
        XF.BLL.Course_Selection bll = new XF.BLL.Course_Selection();
        XF.BLL.Course_SelectionStudent bllStudent = new XF.BLL.Course_SelectionStudent();
        XF.BLL.XF_Configuration bllConfiguration = new XF.BLL.XF_Configuration();
        XF.BLL.SysManage bllSys = new XF.BLL.SysManage();
        DateTime dt = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
        private XF.ExControls.XFClassScheduler xfClassScheduler1;
        int StoreID = -1;//门店ID
        int ClassRoomID = -1; //教室ID
        public FrmCourseEvaluateSelection()
        {
            InitializeComponent();
        }

        private void FrmCourseEvaluateSelection_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            BindData();
        }

        private void xfClassScheduler1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //判断是否可选
            if (!zDataConverter.ToString(xfClassScheduler1.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag).Equals(string.Empty))
            {
                XF.Model.Course_Selection model;
                int selectionID = zDataConverter.ToInt(xfClassScheduler1.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag);
                model = bll.GetDetailModel(selectionID);
                FrmCourseEvaluate frmCourseEvaluate = new FrmCourseEvaluate();
                frmCourseEvaluate.Model = model;
                frmCourseEvaluate.ShowDialog();
                if (frmCourseEvaluate.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    //更新评价
                    ArrayList lstSql = new ArrayList();
                    foreach (XF.Model.Course_SelectionStudent student in model.SelectionStudents)
                    {
                        string evaluateFilePath = ConfigSetting.EvaluateFilePath + student.SelectionStudentID.ToString() + ".txt";
                        lstSql.Add(bllStudent.GetUpdateEvaluateSql(student.SelectionStudentID, evaluateFilePath));
                    }
                    if (!bllSys.ExecuteSqlTran(lstSql))
                    {
                        QQMessageBox.Show(this, MessageText.SQL_ERROR_SELECTIONSTUDENT_EVALUATE_SAVE, MessageText.MESSAGEBOX_CAPTION_ERROR, QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                        return;
                    }
                    //保存评价内容文件
                    //创建评价文件
                    foreach (XF.Model.Course_SelectionStudent student in model.SelectionStudents)
                    {
                        FileStream fs;
                        string evaluateFilePath = ConfigSetting.EvaluateFilePath + student.SelectionStudentID.ToString() + ".txt";
                        if (File.Exists(evaluateFilePath))
                        {
                            fs = new FileStream(evaluateFilePath, FileMode.Truncate);
                            fs.Close();
                        }
                        fs = new FileStream(evaluateFilePath, FileMode.OpenOrCreate);
                        StreamWriter sw = new StreamWriter(fs);
                        //开始写入
                        sw.Write(student.Evaluate);
                        //清空缓冲区
                        sw.Flush();
                        //关闭流
                        sw.Close();
                        fs.Close();
                    }
                    QQMessageBox.Show(this, MessageText.TIP_SUCCESS_SAVE, MessageText.MESSAGEBOX_CAPTION_TIP, QQMessageBoxIcon.Information, QQMessageBoxButtons.OK);
                }
            }
        }

        private void BindData()
        {
            if(xfClassScheduler1 == null)
            {
                int roomCount = zDataConverter.ToInt(bllConfiguration.GetItemValueByCache("RoomCount"));
                int dayCount = zDataConverter.ToInt(bllConfiguration.GetItemValueByCache("DayCount"));
                string[] roomNames = zDataConverter.ToString(bllConfiguration.GetItemValueByCache("RoomNames")).Split(',');
                string[] dayNames = zDataConverter.ToString(bllConfiguration.GetItemValueByCache("DayNames")).Split(',');
                xfClassScheduler1 = new XFClassScheduler(dayCount, roomCount, roomNames, dayNames);
                xfClassScheduler1.Dock = DockStyle.Fill;
                xfClassScheduler1.CellClick += xfClassScheduler1_CellClick;
                this.Controls.Add(xfClassScheduler1);
            }
            DataTable dtSelection = bll.GetDayDetailList(dt, StoreID, ClassRoomID).Tables[0];
            //设置已选课数据
            foreach (DataRow dr in dtSelection.Rows)
            {
                XF.Model.Course_Selection model = bll.DataRowToModel(dr);
                xfClassScheduler1.Rows[model.LessonNO].Cells[model.ClassRoomID].Style.BackColor = ColorTranslator.FromHtml(model.Color);
                xfClassScheduler1.Rows[model.LessonNO].Cells[model.ClassRoomID].Value = string.Format("{0}第{1}节{2}选课人数：{3}{2}授课老师：{4}", model.CourseName, model.SectionNO, MessageText.KEY_ENTER, zDataConverter.ToString(model.SelectionCount), model.TeacherName);
                if (model.CourseID != zDataConverter.ToInt(ConfigSetting.TryOutCourseID))
                {
                    xfClassScheduler1.Rows[model.LessonNO].Cells[model.ClassRoomID].Tag = model.SelectionID;
                }
            }
        }

        private void XfClassScheduler1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
