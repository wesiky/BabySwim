using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Enums;
using XF.ExControls;
using XF.Common;

namespace BabySwim
{
    public partial class FrmCourseSelection : Form
    {
        XF.BLL.Course_Selection bll = new XF.BLL.Course_Selection();
        XF.BLL.Course_Scheduler bllScheduler = new XF.BLL.Course_Scheduler();
        XF.BLL.XF_Configuration bllConfiguration = new XF.BLL.XF_Configuration();
        DataTable dtScheduler;//排课信息
        DataTable dtSelection;//选课信息
        int StoreID = -1;//门店ID
        int ClassRoomID = -1; //教室ID
        DateTimePicker dtpDate = new DateTimePicker();
        XFClassScheduler xfClassScheduler;
        public FrmCourseSelection()
        {
            InitializeComponent();
            dtpDate.Width = 120;
            dtpDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            ToolStripControlHost item = new ToolStripControlHost(dtpDate);
            toolStrip1.Items.Insert(3, item);
        }

        private void xfClassScheduler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender.GetType().Equals(typeof(XFClassScheduler)))
            {
                XFClassScheduler xfClassScheduler = sender as XFClassScheduler;
                //判断是否可选
                if (!zDataConverter.ToString(xfClassScheduler.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag).Equals(string.Empty))
                {
                    XF.Model.Course_Selection model;
                    int selectionID = zDataConverter.ToInt(xfClassScheduler.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag);
                    if (selectionID == -1)
                    {
                        //未选课处理
                        model = new XF.Model.Course_Selection();
                        try
                        {
                            model.CourseDate = (DateTime)xfClassScheduler.Tag;
                        }
                        catch (Exception ex)
                        {
                            QQMessageBox.Show(
                                this,
                                string.Format(MessageText.PROGRAM_ERROR_SCHEDULER_DATE, ex.Message),
                                MessageText.MESSAGEBOX_CAPTION_ERROR,
                                QQMessageBoxIcon.Error,
                                QQMessageBoxButtons.OK);
                        }
                        model.SelectionID = selectionID;
                        model.StoreID = StoreID;
                        model.ClassRoomID = e.ColumnIndex;
                        model.LessonNO = e.RowIndex;

                        //弹出课程选择框
                        FrmCourseChoice frmCourseChoice = new FrmCourseChoice();
                        frmCourseChoice.Model = model;
                        frmCourseChoice.ShowDialog();
                        if (frmCourseChoice.DialogResult == System.Windows.Forms.DialogResult.OK)
                        {
                            //新增数据
                            string msg = bll.SaveSelection(frmCourseChoice.Model);
                            if (msg.Equals(string.Empty))
                            {
                                BindData();
                            }
                            else
                            {
                                QQMessageBox.Show(
                                    this,
                                    "选课保存出错，错误原因：" + msg,
                                    MessageText.MESSAGEBOX_CAPTION_ERROR,
                                    QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                            }
                        }
                    }
                    else
                    {
                        //已选课处理
                        model = bll.GetDetailModel(selectionID);
                        if (model.CourseID == zDataConverter.ToInt(ConfigSetting.TryOutCourseID))
                        {
                            //试听课处理
                            FrmTryOutCourseSelectionInfo frmTryOutCourseSelectionInfo = new FrmTryOutCourseSelectionInfo();
                            frmTryOutCourseSelectionInfo.Model = model;
                            frmTryOutCourseSelectionInfo.Status = CardEnum.UPDATE;
                            frmTryOutCourseSelectionInfo.ShowDialog();
                            if (frmTryOutCourseSelectionInfo.DialogResult == System.Windows.Forms.DialogResult.OK)
                            {
                                //更新数据
                                //更新试听课数据----
                                string msg = bll.SaveSelection(frmTryOutCourseSelectionInfo.Model);
                                if (msg.Equals(string.Empty))
                                {
                                    BindData();
                                }
                                else
                                {
                                    QQMessageBox.Show(
                                        this,
                                        "选课保存出错，错误原因：" + msg,
                                        MessageText.MESSAGEBOX_CAPTION_ERROR,
                                        QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                                }
                            }
                            else if (frmTryOutCourseSelectionInfo.DialogResult == System.Windows.Forms.DialogResult.No)
                            {
                                //关闭课程
                                string msg = bll.CloseCourse(frmTryOutCourseSelectionInfo.Model.SelectionID, frmTryOutCourseSelectionInfo.Model.CourseID, frmTryOutCourseSelectionInfo.Model.CourseDate);
                                if (msg.Equals(string.Empty))
                                {
                                    QQMessageBox.Show(
                                        this,
                                        MessageText.SUCCESS_SELECTION_CLOSE,
                                        MessageText.MESSAGEBOX_CAPTION_TIP,
                                        QQMessageBoxIcon.OK, QQMessageBoxButtons.OK);
                                    BindData();
                                }
                                else
                                {
                                    QQMessageBox.Show(
                                        this,
                                        msg,
                                        MessageText.MESSAGEBOX_CAPTION_ERROR,
                                        QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                                }
                            }
                        }
                        else
                        {
                            //非试听课处理
                            FrmCourseSelectionInfo frmCourseSelectionInfo = new FrmCourseSelectionInfo();
                            frmCourseSelectionInfo.Model = model;
                            frmCourseSelectionInfo.Status = CardEnum.UPDATE;
                            frmCourseSelectionInfo.ShowDialog();
                            if (frmCourseSelectionInfo.DialogResult == System.Windows.Forms.DialogResult.OK)
                            {
                                //更新数据
                                //更新非试听课数据----
                                string msg = bll.SaveSelection(frmCourseSelectionInfo.Model);
                                if (msg.Equals(string.Empty))
                                {
                                    BindData();
                                }
                                else
                                {
                                    QQMessageBox.Show(
                                        this,
                                        "选课保存出错，错误原因：" + msg,
                                        MessageText.MESSAGEBOX_CAPTION_ERROR,
                                        QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                                }
                            }
                            else if (frmCourseSelectionInfo.DialogResult == System.Windows.Forms.DialogResult.No)
                            {
                                //关闭课程
                                string msg = bll.CloseCourse(frmCourseSelectionInfo.Model.SelectionID, frmCourseSelectionInfo.Model.CourseID, frmCourseSelectionInfo.Model.CourseDate);
                                if (msg.Equals(string.Empty))
                                {
                                    QQMessageBox.Show(
                                        this,
                                        MessageText.SUCCESS_SELECTION_CLOSE,
                                        MessageText.MESSAGEBOX_CAPTION_TIP,
                                        QQMessageBoxIcon.OK, QQMessageBoxButtons.OK);
                                    BindData();
                                }
                                else
                                {
                                    QQMessageBox.Show(
                                        this,
                                        msg,
                                        MessageText.MESSAGEBOX_CAPTION_ERROR,
                                        QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void FrmCourseSelection_Load(object sender, EventArgs e)
        {
            this.Icon = ConfigSetting.ProjectIcon;
            BindData();
        }

        /// <summary>
        /// 绑定选课信息
        /// </summary>
        private void BindData()
        {
            dtScheduler = bllScheduler.GetList(StoreID, ClassRoomID).Tables[0];
            dtSelection = bll.GetWeekDetailList(dtpDate.Value, StoreID, ClassRoomID).Tables[0];
            for (int i = 0; i < 7; i++)
            {
                SetSelectionInfo(i);
            }
        }
        private void SetSelectionInfo(int index)
        {
            //设置显示日期文本
            DateTime dt = dtpDate.Value.AddDays(index);
            int roomCount = zDataConverter.ToInt(bllConfiguration.GetItemValueByCache("RoomCount"));
            int dayCount = zDataConverter.ToInt(bllConfiguration.GetItemValueByCache("DayCount"));
            string[] roomNames = zDataConverter.ToString(bllConfiguration.GetItemValueByCache("RoomNames")).Split(',');
            string[] dayNames = zDataConverter.ToString(bllConfiguration.GetItemValueByCache("DayNames")).Split(',');
            tabControl1.TabPages[index].Text = string.Format(MessageText.FORMAT_DATE_WEEK, dt.ToString(MessageText.FORMAT_DATE), dt.ToString("dddd", new System.Globalization.CultureInfo("zh-CN")));
            //清除表格重绘
            Control[] controls = tabControl1.TabPages[index].Controls.Find(zDataConverter.ToString(typeof(XFClassScheduler)) + index, false);
            if (controls.Length > 0)
            {
                for (int i = 0; i < controls.Length; i++)
                {
                    tabControl1.TabPages[index].Controls.Remove(controls[i]);
                    controls[i].Dispose();
                }
            }
            xfClassScheduler = new XFClassScheduler(dayCount,roomCount,roomNames,dayNames);
            xfClassScheduler.Name = zDataConverter.ToString(typeof(XFClassScheduler)) + index;
            xfClassScheduler.Tag = dt;
            xfClassScheduler.Dock = DockStyle.Fill;
            xfClassScheduler.Size = new Size(tabControl1.TabPages[index].Width - 6, tabControl1.TabPages[index].Height - 6);
            tabControl1.TabPages[index].Controls.Add(xfClassScheduler);
            //设置已选课数据
            foreach (DataRow dr in dtSelection.Select(string.Format("CourseDate ='{0}' and StoreID = {1}", dt, StoreID)))
            {
                XF.Model.Course_Selection model = bll.DataRowToModel(dr);
                xfClassScheduler.Rows[model.LessonNO].Cells[model.ClassRoomID].Style.BackColor = ColorTranslator.FromHtml(model.Color);
                xfClassScheduler.Rows[model.LessonNO].Cells[model.ClassRoomID].Value = string.Format("{0}第{1}节{2}选课人数：{3}{2}授课老师：{4}{2}学员：{5}", model.CourseName, model.SectionNO, MessageText.KEY_ENTER, zDataConverter.ToString(model.SelectionCount), model.TeacherName,model.StudentNames);
                xfClassScheduler.Rows[model.LessonNO].Cells[model.ClassRoomID].Tag = model.SelectionID;
            }
            //设置已排课数据,目前不区分教室排课
            int weekDay = ((int)dt.DayOfWeek + 6) % 7;
            foreach (DataRow dr in dtScheduler.Select(string.Format("StoreID = {0} and WeekDay = {1}", StoreID, weekDay)))
            {
                XF.Model.Course_Scheduler model = bllScheduler.DataRowToModel(dr);
                for (int i = 0; i < roomCount; i++)
                {
                    if (zDataConverter.ToString(xfClassScheduler.Rows[model.LessonNO].Cells[i].Tag).Equals(string.Empty))
                    {
                        xfClassScheduler.Rows[model.LessonNO].Cells[i].Style.BackColor = Color.Lavender;
                        xfClassScheduler.Rows[model.LessonNO].Cells[i].Tag = -1;
                        xfClassScheduler.Rows[model.LessonNO].Cells[i].Value = "未排课";
                    }
                }
            }
            //设置点击事件
            xfClassScheduler.CellClick += new DataGridViewCellEventHandler(xfClassScheduler_CellClick);
        }

        private void tsBtnLook_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void tsBtnConfirmedStudent_Click(object sender, EventArgs e)
        {
            FrmConfirmedStudentList frmConfirmedStudentList = new FrmConfirmedStudentList();
            frmConfirmedStudentList.ShowDialog();
        }
    }
}
