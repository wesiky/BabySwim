using System;
using System.Data;
using System.Collections.Generic;
using XF.Model;
using XF.DALFactory;
using XF.IDAL;
using XF.Common;
namespace XF.BLL
{
	/// <summary>
	/// Course_Scheduler
	/// </summary>
	public partial class Course_Scheduler
	{
		private readonly ICourse_Scheduler dal=DataAccess.CreateCourse_Scheduler();
		public Course_Scheduler()
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
		public bool Exists(int SchedulerID)
		{
			return dal.Exists(SchedulerID);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int StoreID, int ClassRoomID, int WeekDay, int LessonNO)
        {
            return dal.Exists(StoreID, ClassRoomID, WeekDay, LessonNO);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(XF.Model.Course_Scheduler model)
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
		public bool Update(XF.Model.Course_Scheduler model)
		{
            model.LastUpdateUser = LoginInfo.LoginName;
            model.LastUpdateDate = DateTime.Now;
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SchedulerID)
		{
			
			return dal.Delete(SchedulerID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string SchedulerIDlist )
		{
			return dal.DeleteList(SchedulerIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public XF.Model.Course_Scheduler GetModel(int SchedulerID)
		{
			
			return dal.GetModel(SchedulerID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XF.Model.Course_Scheduler GetModel(int StoreID, int ClassRoomID, int WeekDay, int LessonNO)
        {
            return dal.GetModel(StoreID, ClassRoomID, WeekDay, LessonNO);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
        public XF.Model.Course_Scheduler DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int storeID, int classRoomID)
        {
            string strWhere = string.Empty;
            if (storeID >= 0)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " StoreID = " + storeID);
            }
            if (classRoomID >= 0)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " ClassRoomID = " + classRoomID);
            }
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
		public List<XF.Model.Course_Scheduler> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XF.Model.Course_Scheduler> GetModelList(int storeID,int classRoomID)
        {
            string strWhere = string.Empty;
            if (storeID >= 0)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " StoreID = " + storeID);
            }
            if (classRoomID >= 0)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " ClassRoomID = " + classRoomID);
            }
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XF.Model.Course_Scheduler> DataTableToList(DataTable dt)
		{
			List<XF.Model.Course_Scheduler> modelList = new List<XF.Model.Course_Scheduler>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				XF.Model.Course_Scheduler model;
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
        /// 新增SQL语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAddSql(Model.Course_Scheduler model)
        {
            return dal.GetAddSql(model, LoginInfo.LoginName);
        }

        /// <summary>
        /// 更新SQL语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetUpdateSql(Model.Course_Scheduler model)
        {
            return dal.GetUpdateSql(model, LoginInfo.LoginName);
        }
        /// <summary>
        /// 删除SQL语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetDeleteSql(int StoreID, int ClassRoomID)
        {
            return dal.GetDeleteSql(StoreID, ClassRoomID);
        }
		#endregion  ExtensionMethod
	}
}

