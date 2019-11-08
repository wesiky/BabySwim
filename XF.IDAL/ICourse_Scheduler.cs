using System;
using System.Data;
namespace XF.IDAL
{
	/// <summary>
	/// 接口层Course_Scheduler
	/// </summary>
	public interface ICourse_Scheduler
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int SchedulerID);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int StoreID, int ClassRoomID, int WeekDay, int LessonNO);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(XF.Model.Course_Scheduler model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(XF.Model.Course_Scheduler model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int SchedulerID);
		bool DeleteList(string SchedulerIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		XF.Model.Course_Scheduler GetModel(int SchedulerID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        XF.Model.Course_Scheduler GetModel(int StoreID, int ClassRoomID, int WeekDay, int LessonNO);

		XF.Model.Course_Scheduler DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
		#region  MethodEx
        /// <summary>
        /// 新增SQL语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        string GetAddSql(Model.Course_Scheduler model, string loginName);
        /// <summary>
        /// 更新SQL语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        string GetUpdateSql(Model.Course_Scheduler model, string loginName);
        /// <summary>
        /// 删除SQL语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        string GetDeleteSql(int StoreID, int ClassRoomID);
		#endregion  MethodEx
	} 
}
