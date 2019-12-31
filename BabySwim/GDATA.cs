using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Enums;
using System.Threading.Tasks;
using XF.ExControls;
using System.Windows.Forms;
using System.Globalization;
using XF.Common;
using XF.BLL;

namespace BabySwim
{
    public class GDATA
    {
        XF.BLL.SysManage bllSys = new XF.BLL.SysManage();
        XF.BLL.XF_Configuration bllConfiguration = new XF.BLL.XF_Configuration();
        XF.BLL.Base_Student bllStudent = new XF.BLL.Base_Student();
        XF.BLL.Course_SelectionStudent bllSelectionStudent = new XF.BLL.Course_SelectionStudent();
        XF.BLL.Course_Selection bllSelection = new XF.BLL.Course_Selection();
        XF.BLL.Course_ConfirmedStudent bllConfirmedStudent = new XF.BLL.Course_ConfirmedStudent();
        XF.BLL.Assist_Notice bllNotice = new XF.BLL.Assist_Notice();

        /// <summary>
        /// 生成通知
        /// </summary>
        public void GenerateNotice(Form owner)
        {
            string msg = string.Empty;
            try
            {
                msg = GenerateCourseNotice();
                if (msg.Equals(MessageText.SQL_ERROR_COURSENOTICE_GENERATE))
                {
                    QQMessageBox.Show(owner, msg, MessageText.MESSAGEBOX_CAPTION_ERROR, QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                }
            }
            catch
            {
            }
            try
            {
                msg = GenerateBirthdayNotice();
                if (msg.Equals(MessageText.SQL_ERROR_BIRTHDAYNOTICE_GENERATE))
                {
                    QQMessageBox.Show(owner, msg, MessageText.MESSAGEBOX_CAPTION_ERROR, QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                }
            }
            catch
            {
            }
            try
            {
                msg = GenerateStudentScheduler();
                if (!(msg.Equals(MessageText.TIP_SCHEDULER_ISGENERATED) || msg.Equals(MessageText.TIP_SUCCESS_GENERATE)))
                {
                    QQMessageBox.Show(owner, msg, MessageText.MESSAGEBOX_CAPTION_ERROR, QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 生成上课通知
        /// </summary>
        /// <returns></returns>
        public string GenerateCourseNotice()
        {
            DateTime dtCourseNotice;
            DateTime dt = DateTime.Now.AddDays(1);
            string courseNoticeDate = bllConfiguration.GetItemValueByCache(SystemSetting.CourseNoticeDate);
            if (!DateTime.TryParse(courseNoticeDate, out dtCourseNotice))
            {
                dtCourseNotice = DateTime.Now;
            }
            if (!dtCourseNotice.ToString("yyyy-MM-dd").Equals(dt.ToString("yyyy-MM-dd")))
            {
                ArrayList lstSql = new ArrayList();
                List<XF.Model.Course_SelectionStudent> models = bllSelectionStudent.GetDetailModelListByDateLessonNO(dt, -1);
                XF.Model.Assist_Notice notice = new XF.Model.Assist_Notice();
                notice.CreateDate = DateTime.Now;
                notice.CreateUser = XF.BLL.LoginInfo.LoginName;
                notice.LastUpdateDate = DateTime.Now;
                notice.LastUpdateUser = XF.BLL.LoginInfo.LoginName;
                foreach (XF.Model.Course_SelectionStudent model in models)
                {
                    notice.ContentMsg = "学员" + model.StudentName + "于" + dt.ToShortDateString() + "上课";
                    notice.AttachMsg = model.Phone;
                    notice.ObjectName = model.FamilyCode + "-" + model.FamilyName;
                    lstSql.Add(bllNotice.GetAddSql(notice));
                }
                if (!bllSys.ExecuteSqlTran(lstSql))
                {
                    return MessageText.SQL_ERROR_COURSENOTICE_GENERATE;
                }
                bllConfiguration.UpdateItem(SystemSetting.CourseNoticeDate, dt.ToShortDateString(), XF.BLL.LoginInfo.LoginName);
                return MessageText.TIP_SUCCESS_GENERATE;
            }
            else
            {
                return MessageText.TIP_COURSENOTICE_ISGENERATED;
            }
        }

        /// <summary>
        /// 生成生日通知
        /// </summary>
        /// <returns></returns>
        public string GenerateBirthdayNotice()
        {
            ChineseLunisolarCalendar cls = new ChineseLunisolarCalendar();
            DateTime dtBirthdayNotice;
            //生成未来一周的通知
            DateTime dt = DateTime.Now.AddDays(7);
            string courseNoticeDate = bllConfiguration.GetItemValueByCache(SystemSetting.BirthdayNoticeDate);
            if (!DateTime.TryParse(courseNoticeDate, out dtBirthdayNotice))
            {
                dtBirthdayNotice = DateTime.Now;
            }
            //公历转农历
            dtBirthdayNotice = new DateTime(PhysicalConstants.DEFAULT_YEAR, cls.GetMonth(dtBirthdayNotice), cls.GetDayOfMonth(dtBirthdayNotice));
            DateTime dtCls = new DateTime(PhysicalConstants.DEFAULT_YEAR, cls.GetMonth(dt), cls.GetDayOfMonth(dt));
            //防止年末变换导致开始日期大于结束日期
            if (dtBirthdayNotice.CompareTo(dtCls) > 0)
            {
                dtCls.AddYears(1);
            }
            ArrayList lstSql = new ArrayList();
            List<XF.Model.Base_Student> models = bllStudent.GetBirthdayStudentDetailList(dtBirthdayNotice, dtCls);
            XF.Model.Assist_Notice notice = new XF.Model.Assist_Notice();
            notice.CreateDate = DateTime.Now;
            notice.CreateUser = XF.BLL.LoginInfo.LoginName;
            notice.LastUpdateDate = DateTime.Now;
            notice.LastUpdateUser = XF.BLL.LoginInfo.LoginName;
            foreach (XF.Model.Base_Student model in models)
            {
                notice.ContentMsg = "学员" + model.StudentName + "于农历" + model.Birthday.ToShortDateString() + "生日";
                notice.AttachMsg = model.Phone;
                notice.ObjectName = model.FamilyCode + "-" + model.FamilyName;
                lstSql.Add(bllNotice.GetAddSql(notice));
            }
            if (!bllSys.ExecuteSqlTran(lstSql))
            {
                return MessageText.SQL_ERROR_BIRTHDAYNOTICE_GENERATE;
            }
            bllConfiguration.UpdateItem(SystemSetting.BirthdayNoticeDate, dt.ToShortDateString(), XF.BLL.LoginInfo.LoginName);
            return MessageText.TIP_SUCCESS_GENERATE;
        }

        /// <summary>
        /// 生成固定选课数据
        /// </summary>
        /// <returns></returns>
        public string GenerateStudentScheduler()
        {
            string msg = string.Empty;
            DateTime dtStudentScheduler;
            string studentSchedulerDate = bllConfiguration.GetItemValueByCache(SystemSetting.StudentSchedulerDate);
            int studentSchedulerWeeks = zDataConverter.ToInt( bllConfiguration.GetItemValueByCache(SystemSetting.StudentSchedulerWeeks));
            DateTime dt = new DateTime(DateTime.Now.AddDays(7 * studentSchedulerWeeks).Year, DateTime.Now.AddDays(7 * studentSchedulerWeeks).Month, DateTime.Now.AddDays(7 * studentSchedulerWeeks).Day);
            if (!DateTime.TryParse(studentSchedulerDate, out dtStudentScheduler))
            {
                dtStudentScheduler = dt;
            }
            if (dtStudentScheduler.CompareTo(dt)<0)
            {
                ArrayList lstSql = new ArrayList();
                List<XF.Model.Course_ConfirmedStudent> models = bllConfirmedStudent.GetModelDetailList(string.Empty);
                foreach (XF.Model.Course_ConfirmedStudent model in models)
                {
                    //向后计算出最近的固定排课日期
                    DateTime courseDate = dtStudentScheduler.AddDays(1);
                    int day = (model.DayOfWeek - Convert.ToInt32(courseDate.DayOfWeek) + 7) % 7 + 1;
                    courseDate = courseDate.AddDays(day);
                    //新建学员对象
                    XF.Model.Course_SelectionStudent student = new XF.Model.Course_SelectionStudent();
                    student.StoreID = model.StoreID;
                    student.ClassroomID = model.ClassRoomID;
                    student.LessonNO = model.LessonNO;
                    student.StudentID = model.StudentID;
                    student.SelectionType = 1;

                    while (courseDate.CompareTo(dt) <= 0)
                    {
                        //固定学员循环生成选课
                        model.SectionNO++;
                        XF.Model.Course_Selection selection = bllSelection.GetDetailModel(courseDate, model.StoreID, model.ClassRoomID, model.LessonNO);
                        if (selection == null)
                        {
                            selection = new XF.Model.Course_Selection();
                            selection.CourseDate = courseDate;
                            selection.ClassRoomID = model.ClassRoomID;
                            selection.LessonNO = model.LessonNO;
                            selection.CourseID = model.CourseID;
                            selection.SectionNO = model.SectionNO;
                            selection.TeacherID = (int)model.TeacherID;
                            selection.StoreID = model.StoreID;
                            selection.CreateDate = DateTime.Now;
                            selection.CreateUser = LoginInfo.LoginName;
                            selection.LastUpdateDate = DateTime.Now;
                            selection.LastUpdateUser = LoginInfo.LoginName;
                            //新增选课
                            lstSql.Add(bllSelection.GetAddSql(selection));
                            //新增固定学员选课记录
                            student.CourseDate = courseDate;
                            if (bllSelectionStudent.GetDetailModel((DateTime)student.CourseDate, student.StoreID, student.ClassroomID, student.LessonNO, student.StudentID) == null)
                            {
                                lstSql.Add(bllSelectionStudent.GetAddSql(student));
                            }
                        }
                        else
                        {
                            if (selection.TeacherID == model.TeacherID && selection.SectionNO == model.SectionNO && selection.CourseID == model.CourseID)
                            {
                                //新增固定学员选课记录
                                student.CourseDate = courseDate;
                                if (bllSelectionStudent.GetDetailModel((DateTime)student.CourseDate, student.StoreID, student.ClassroomID, student.LessonNO, student.StudentID) == null)
                                {
                                    lstSql.Add(bllSelectionStudent.GetAddSql(student));
                                }
                            }
                            else
                            {
                                //提示日期排课出错
                                msg += "学员" + student.StudentID + string.Format(MessageText.PROGTAM_ERROR_CONFIRMEDSTUDENT_SAVE, courseDate.ToString(MessageText.FORMAT_DATE), MessageText.LIST_NUMBER_CHINESE[model.ClassRoomID], model.LessonNO + 1) + MessageText.KEY_ENTER;

                            }
                        }
                        courseDate = courseDate.AddDays(7);
                    }
                }
                //执行存储过程
                if (!bllSys.ExecuteSqlTran(lstSql))
                {
                    return MessageText.SQL_ERROR_GENERATESTUDENTSCHEDULER;
                }
                bllConfiguration.UpdateItem(SystemSetting.StudentSchedulerDate, dt.ToShortDateString(), XF.BLL.LoginInfo.LoginName);
                if (msg.Equals(string.Empty))
                {
                    return MessageText.TIP_SUCCESS_GENERATE;
                }
                else
                {
                    return msg;
                }
            }
            else
            {
                return MessageText.TIP_SCHEDULER_ISGENERATED;
            }
        }
    }
}
