using System;
using System.Data;
using System.Collections.Generic;
using XF.Model;
using XF.DALFactory;
using XF.IDAL;
using System.Collections;
using Enums;
using XF.Common;
namespace XF.BLL
{
	/// <summary>
	/// Course_Selection
	/// </summary>
    public partial class Course_Selection
    {
        private readonly ICourse_Selection dal = DataAccess.CreateCourse_Selection();
        private DateTime dtStudentScheduler;//最后次排课日期
        private Course_SelectionStudent bllSelectionStudent = new Course_SelectionStudent();
        private Course_ConfirmedStudent bllConfirmedStudent = new Course_ConfirmedStudent();
        XF.BLL.XF_Configuration bllConfiguration = new XF.BLL.XF_Configuration();
        private SysManage bllSys = new SysManage();
        public Course_Selection()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SelectionID)
        {
            return dal.Exists(SelectionID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(XF.Model.Course_Selection model)
        {
            model.CreateUser = LoginInfo.LoginName;
            model.CreateDate = DateTime.Now;
            model.LastUpdateUser = LoginInfo.LoginName;
            model.LastUpdateDate = DateTime.Now;
            model.Enable = true;
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(XF.Model.Course_Selection model)
        {
            model.LastUpdateUser = LoginInfo.LoginName;
            model.LastUpdateDate = DateTime.Now;
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int SelectionID)
        {
            return dal.Delete(SelectionID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string SelectionIDlist)
        {
            return dal.DeleteList(SelectionIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XF.Model.Course_Selection GetModel(int SelectionID)
        {
            return dal.GetModel(SelectionID);
        }

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
        public XF.Model.Course_Selection DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XF.Model.Course_Selection> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XF.Model.Course_Selection> DataTableToList(DataTable dt)
        {
            List<XF.Model.Course_Selection> modelList = new List<XF.Model.Course_Selection>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XF.Model.Course_Selection model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 获得指定日期起一周数据列表
        /// </summary>
        public DataSet GetWeekList(DateTime dt)
        {
            return dal.GetWeekList(dt, -1, -1);
        }

        public DataSet GetWeekList(DateTime dt, int StoreID)
        {
            return dal.GetWeekList(dt, StoreID, -1);
        }
        /// <summary>
        /// 获取一周选课记录
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="StoreID"></param>
        /// <param name="ClassRoomID"></param>
        /// <returns></returns>
        public DataSet GetWeekList(DateTime dt, int StoreID, int ClassRoomID)
        {
            return dal.GetWeekList(dt, StoreID, ClassRoomID);
        }
        /// <summary>
        /// 获取选课详细信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDetailList(string strWhere)
        {
            return dal.GetDetailList(strWhere);
        }

        /// <summary>
        /// 获取一周选课详细信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetWeekDetailList(DateTime dt, int StoreID, int ClassRoomID)
        {
            return dal.GetWeekDetailList(dt, StoreID, ClassRoomID);
        }

        /// <summary>
        /// 获得指定日期的详细数据列表
        /// </summary>
        public DataSet GetDayDetailList(DateTime dt, int storeID, int classRoomID)
        {
            return dal.GetDayDetailList(dt, storeID, classRoomID);
        }

        public XF.Model.Course_Selection GetDetailModel(int SelectionID)
        {
            XF.Model.Course_Selection model = dal.GetDetailModel(SelectionID);
            if (model != null)
            {
                model.SelectionStudents = bllSelectionStudent.GetDetailModelListBySelectionID(model.SelectionID,model.CourseID);
            }
            return model;
        }

        public List<XF.Model.Course_Selection> GetDetailModelList(string strWhere)
        {
            DataTable dt = GetDetailList(strWhere).Tables[0];
            return DataTableToList(dt);
        }

        public List<XF.Model.Course_Selection> GetDetailModelList(DateTime dtStart, DateTime dtEnd, int teacherID, int courseID)
        {
            string strWhere = string.Empty;
            strWhere = zDataConverter.AppendSQL(strWhere, " CourseDate between '" + dtStart.ToShortDateString() + "' and '" + dtEnd.AddDays(1).ToShortDateString() + "'");
            if (teacherID >= 0)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " TeacherID = " + teacherID);
            }
            if (courseID >= 0)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " CourseID = " + courseID);
            }
            return GetDetailModelList(strWhere);
        }

        /// <summary>
        /// 保存选课数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string SaveSelection(XF.Model.Course_Selection model)
        {
            bool hasConfirmed = false;
            ArrayList lstSql = new ArrayList();
            //保存选课学生数据
            //保存逻辑
            //1、删除选课学员记录
            //3、增加选课学员记录
            //4、增加固定选课学员记录
            lstSql.Add(bllSelectionStudent.GetDeleteSql(model.SelectionID, model.CourseID, model.CourseDate));
            //保存选课数据
            if (model.SelectionID == -1)
            {
                lstSql.Add(this.GetAddSql(model));
            }
            else
            {
                lstSql.Add(this.GetUpdateSql(model));
            }
            foreach (XF.Model.Course_SelectionStudent student in model.SelectionStudents)
            {
                if (!hasConfirmed && student.SelectionType == 1)
                {
                    hasConfirmed = true;
                }
                student.CourseDate = model.CourseDate;
                student.LessonNO = model.LessonNO;
                student.ClassroomID = model.ClassRoomID;
                student.StoreID = model.StoreID;
                student.CreateDate = model.CreateDate;
                student.CreateUser = model.CreateUser;
                student.LastUpdateDate = model.LastUpdateDate;
                student.LastUpdateUser = model.LastUpdateUser;
                lstSql.Add(bllSelectionStudent.GetAddSql(student));
                if (student.SelectionType == 1)
                {
                    lstSql.Add(bllConfirmedStudent.GetAddSql(student));
                }
            }
            if (model.CourseID != zDataConverter.ToInt(ConfigSetting.TryOutCourseID))
            {
                lstSql.Add(this.CloseInvalidCourse());
            }
            if (!bllSys.ExecuteSqlTran(lstSql))
            {
                return MessageText.SQL_ERROR_SELECTIONSTUDENT_SAVE;
            }
            if (hasConfirmed)
            {
                string msg = string.Empty;
                lstSql.Clear();
                DateTime dtStudentScheduler = GetStudentSchedulerDate();
                model.CourseDate = model.CourseDate.AddDays(7);
                model.SectionNO++;
                while (model.CourseDate <= dtStudentScheduler)
                {
                    //固定学员循环生成选课
                    Model.Course_Selection selection = GetModel(model.CourseDate,model.StoreID,model.ClassRoomID, model.LessonNO);
                    //若对应时间地点没有课程安排，则新增
                    if (selection == null)
                    {
                        //新增选课课程
                        lstSql.Add(this.GetAddSql(model));
                        //新增固定学员选课记录
                        foreach (XF.Model.Course_SelectionStudent student in model.SelectionStudents)
                        {
                            if (student.SelectionType == 1)
                            {
                                student.CourseDate = model.CourseDate;
                                if (bllSelectionStudent.GetDetailModel((DateTime)student.CourseDate, student.StoreID, student.ClassroomID, student.LessonNO, student.StudentID) == null)
                                {
                                    lstSql.Add(bllSelectionStudent.GetAddSql(student));
                                }
                            }
                        }
                    }
                    //若对应时间地点有课程，则判断课程信息是否一致，课程信息一致，则新增学员选课记录，若不一致，给出提示
                    else
                    {
                        if (selection.TeacherID == model.TeacherID && selection.SectionNO == model.SectionNO && selection.CourseID == model.CourseID)
                        {
                            //新增固定学员选课记录
                            foreach (XF.Model.Course_SelectionStudent student in model.SelectionStudents)
                            {
                                if (student.SelectionType == 1)
                                {
                                    student.CourseDate = model.CourseDate;
                                    if (bllSelectionStudent.GetDetailModel((DateTime)student.CourseDate, student.StoreID, student.ClassroomID, student.LessonNO, student.StudentID) == null)
                                    {
                                        lstSql.Add(bllSelectionStudent.GetAddSql(student));
                                    }
                                }
                            }
                        }
                        else
                        {
                            //提示日期排课出错
                            msg += string.Format(MessageText.PROGTAM_ERROR_CONFIRMEDSTUDENT_SAVE, model.CourseDate.ToString(MessageText.FORMAT_DATE), MessageText.LIST_NUMBER_CHINESE[model.ClassRoomID], model.LessonNO + 1) + MessageText.KEY_ENTER;
                            
                        }
                    }
                    model.CourseDate = model.CourseDate.AddDays(7);
                    model.SectionNO++;
                }
                if (!bllSys.ExecuteSqlTran(lstSql))
                {
                    return MessageText.SQL_ERROR_GENERATESTUDENTSCHEDULER;
                }
                if (!msg.Equals(string.Empty))
                {
                    return msg;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取最后次排课日期
        /// </summary>
        /// <returns></returns>
        private DateTime GetStudentSchedulerDate()
        {
            if (dtStudentScheduler == DateTime.MinValue)
            {
                string studentSchedulerDate = bllConfiguration.GetItemValueByCache(SystemSetting.StudentSchedulerDate);
                if (!DateTime.TryParse(studentSchedulerDate, out dtStudentScheduler))
                {
                    dtStudentScheduler = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                }
            }
            return dtStudentScheduler;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XF.Model.Course_Selection GetDetailModel(DateTime courseDate,int storeID, int classroomID, int lessonNO)
        {
            return dal.GetDetailModel(courseDate,storeID, classroomID, lessonNO);
        }

        /// <summary>
        /// 获取删除SQL
        /// </summary>
        public string CloseCourse(int SelectionID, int courseID, DateTime courseDate)
        {
            ArrayList lstSql = new ArrayList();
            lstSql.Add(bllSelectionStudent.GetDeleteSql(SelectionID, courseID, courseDate));
            lstSql.Add(this.GetDeleteSql(SelectionID));
            if (courseID != zDataConverter.ToInt(ConfigSetting.TryOutCourseID))
            {
                lstSql.Add(this.CloseInvalidCourse());
            }
            if (!bllSys.ExecuteSqlTran(lstSql))
            {
                return MessageText.SQL_ERROR_SELECTION_CLOSE;
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取增加SQL
        /// </summary>
        public string GetAddSql(XF.Model.Course_Selection model)
        {
            model.CreateUser = LoginInfo.LoginName;
            model.CreateDate = DateTime.Now;
            model.LastUpdateUser = LoginInfo.LoginName;
            model.LastUpdateDate = DateTime.Now;
            return dal.GetAddSql(model);
        }

        /// <summary>
        /// 获取更新SQL
        /// </summary>
        public string GetUpdateSql(XF.Model.Course_Selection model)
        {
            model.LastUpdateUser = LoginInfo.LoginName;
            model.LastUpdateDate = DateTime.Now;
            return dal.GetUpdateSql(model);
        }

        public string GetDeleteSql(int selectionID)
        {
            return dal.GetDeleteSql(selectionID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XF.Model.Course_Selection GetModel(DateTime CourseDate, int StoreID, int ClassRoomID, int LessonNO)
        {
            return dal.GetModel(CourseDate, StoreID, ClassRoomID, LessonNO);
        }

        /// <summary>
        /// 关闭空课程
        /// </summary>
        /// <returns></returns>
        public string CloseInvalidCourse()
        {
            return dal.CloseInvalidCourse();
        }
        #endregion  ExtensionMethod
    }
}

