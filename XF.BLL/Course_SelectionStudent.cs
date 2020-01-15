using System;
using System.Data;
using System.Collections.Generic;
using XF.Model;
using XF.DALFactory;
using XF.IDAL;
using XF.Common;
using Enums;
using System.IO;
namespace XF.BLL
{
	/// <summary>
	/// Course_SelectionStudent
	/// </summary>
	public partial class Course_SelectionStudent
	{
		private readonly ICourse_SelectionStudent dal=DataAccess.CreateCourse_SelectionStudent();
		public Course_SelectionStudent()
		{}
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
		public bool Exists(int SelectionStudentID)
		{
			return dal.Exists(SelectionStudentID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(XF.Model.Course_SelectionStudent model)
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
		public bool Update(XF.Model.Course_SelectionStudent model)
		{
            model.LastUpdateUser = LoginInfo.LoginName;
            model.LastUpdateDate = DateTime.Now;
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SelectionStudentID)
		{
			
			return dal.Delete(SelectionStudentID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SelectionStudentIDlist )
		{
			return dal.DeleteList(SelectionStudentIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public XF.Model.Course_SelectionStudent GetModel(int SelectionStudentID)
		{
			XF.Model.Course_SelectionStudent model = dal.GetModel(SelectionStudentID);
            return model;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XF.Model.Course_SelectionStudent> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XF.Model.Course_SelectionStudent> DataTableToList(DataTable dt)
		{
			List<XF.Model.Course_SelectionStudent> modelList = new List<XF.Model.Course_SelectionStudent>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				XF.Model.Course_SelectionStudent model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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
        /// 获得数据列表
        /// </summary>
        public List<XF.Model.Course_SelectionStudent> GetModelListBySelectionID(int selectionID)
        {
            string strWhere = string.Empty;
            strWhere = zDataConverter.AppendSQL(strWhere, " SelectionID = " + selectionID);
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XF.Model.Course_SelectionStudent> GetDetailModelListBySelectionID(int selectionID,int courseID)
        {
            string strWhere = string.Empty;
            strWhere = zDataConverter.AppendSQL(strWhere, " SelectionID = " + selectionID);
            DataSet ds;
            if (courseID == zDataConverter.ToInt(ConfigSetting.TryOutCourseID))
            {
                ds = dal.GetCustomerDetailList(strWhere);
            }
            else
            {
                ds = dal.GetStudentDetailList(strWhere);
            }
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XF.Model.Course_SelectionStudent> GetDetailModelListByDateLessonNO(DateTime courseDate,int lessonNO)
        {
            string strWhere = string.Empty;
            strWhere = zDataConverter.AppendSQL(strWhere, " CourseDate = '" + courseDate.ToShortDateString() + "'");
            strWhere = zDataConverter.AppendSQL(strWhere, " CourseID <> " + ConfigSetting.TryOutCourseID );
            if (lessonNO >= 0)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " lessonNO = " + lessonNO);
            }
            strWhere = zDataConverter.AppendSQL(strWhere, " SignType = 0");
            DataSet ds = dal.GetStudentDetailList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetStudentDetailList(string strWhere)
        {
            return dal.GetStudentDetailList(strWhere);
        }

        /// <summary>
        /// 获得选课客户数据列表
        /// </summary>
        public DataSet GetCustomerDetailList(string strWhere)
        {
            return dal.GetCustomerDetailList(strWhere);
        }

        /// <summary>
        /// 获取删除选课SQL
        /// </summary>
        /// <param name="selectionID"></param>
        /// <returns></returns>
        public string GetDeleteSql(int selectionID, int courseID, DateTime courseDate)
        {
            return dal.GetDeleteSql(selectionID,courseID,courseDate);
        }

        /// <summary>
        /// 获取增加数据SQL
        /// </summary>
        public string GetAddSql(XF.Model.Course_SelectionStudent model)
        {
            return dal.GetAddSql(model);
        }

        /// <summary>
        /// 获取增加数据SQL
        /// </summary>
        public string GetUpdateSignTypeSql(int selectionStudentID, int signTypeOld, int signType, int courseID, int sectionNO, int teacherID)
        {
            return dal.GetUpdateSignTypeSql(selectionStudentID, signTypeOld, signType, courseID, sectionNO, teacherID);
        }

        /// <summary>
        /// 获取增加数据SQL
        /// </summary>
        public string GetUpdateEvaluateSql(XF.Model.Course_SelectionStudent selectionStudent)
        {
            return dal.GetUpdateEvaluateSql(selectionStudent);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strOrder"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public DataTable GetListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count)
        {
            return dal.GetListByPage(strWhere, strOrder, pageIndex, pageSize, ref count);
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strOrder"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<XF.Model.Course_SelectionStudent> GetModelListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count)
        {
            DataTable dt = dal.GetListByPage(strWhere, strOrder, pageIndex, pageSize, ref count);
            return DataTableToList(dt);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XF.Model.Course_SelectionStudent GetDetailModel(int SelectionStudentID)
        {
            XF.Model.Course_SelectionStudent model = dal.GetDetailModel(SelectionStudentID);
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XF.Model.Course_SelectionStudent GetDetailModel(DateTime CourseDate, int StoreID, int ClassRoomID, int LessonNO,int StudentID)
        {
            XF.Model.Course_SelectionStudent model = dal.GetDetailModel(CourseDate, StoreID, ClassRoomID, LessonNO,StudentID);
            return model;
        }

        public List<XF.Model.Course_SelectionStudent> GetDetailModelList(DateTime dtStart, DateTime dtEnd, int teacherID, int courseID)
        {
            string strWhere = string.Empty;
            strWhere = zDataConverter.AppendSQL(strWhere, " CourseDate between '" + dtStart.ToShortDateString() + "' and '" + dtEnd.AddDays(1).ToShortDateString() + "'");
            if (teacherID >= 0)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " RealTeacherID = " + teacherID);
            }
            if (courseID >= 0)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " CourseID = " + courseID);
            }
            DataSet ds = dal.GetStudentDetailList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
		#endregion  ExtensionMethod
	}
}

