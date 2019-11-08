using System;
using System.Data;
namespace XF.IDAL
{
	/// <summary>
	/// 接口层Course_Selection
	/// </summary>
	public interface ICourse_Selection
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int SelectionID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(XF.Model.Course_Selection model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(XF.Model.Course_Selection model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int SelectionID);
		bool DeleteList(string SelectionIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		XF.Model.Course_Selection GetModel(int SelectionID);
		XF.Model.Course_Selection DataRowToModel(DataRow row);
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
        /// 获得指定日期起一周数据列表
        /// </summary>
        DataSet GetWeekList(DateTime dt, int StoreID, int ClassRoomID);
        /// <summary>
        /// 获取选课详细信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataSet GetDetailList(string strWhere);
        /// <summary>
        /// 获得指定日期起一周详细数据列表
        /// </summary>
        DataSet GetWeekDetailList(DateTime dt, int StoreID, int ClassRoomID);
        /// <summary>
        /// 获得指定日期的详细数据列表
        /// </summary>
        DataSet GetDayDetailList(DateTime dt, int storeID, int classRoomID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        XF.Model.Course_Selection GetDetailModel(int SelectionID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        XF.Model.Course_Selection GetDetailModel(DateTime courseDate, int storeID, int classroomID, int lessonNO);

        /// <summary>
        /// 获取删除SQL
        /// </summary>
        string GetDeleteSql(int SelectionID);

        /// <summary>
        /// 获取增加SQL
        /// </summary>
        string GetAddSql(XF.Model.Course_Selection model);

        /// <summary>
        /// 获取更新SQL
        /// </summary>
        string GetUpdateSql(XF.Model.Course_Selection model);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        XF.Model.Course_Selection GetModel(DateTime CourseDate, int StoreID, int ClassRoomID, int LessonNO);

        /// <summary>
        /// 关闭空课程
        /// </summary>
        /// <returns></returns>
        string CloseInvalidCourse();
		#endregion  MethodEx
	} 
}
