using System;
using System.Data;
namespace XF.IDAL
{
	/// <summary>
	/// 接口层Course_SelectionStudent
	/// </summary>
	public interface ICourse_SelectionStudent
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int SelectionStudentID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(XF.Model.Course_SelectionStudent model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(XF.Model.Course_SelectionStudent model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int SelectionStudentID);
		bool DeleteList(string SelectionStudentIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		XF.Model.Course_SelectionStudent GetModel(int SelectionStudentID);
		XF.Model.Course_SelectionStudent DataRowToModel(DataRow row);
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
        /// 获得数据列表
        /// </summary>
        DataSet GetStudentDetailList(string strWhere);
        /// <summary>
        /// 获得选课客户数据列表
        /// </summary>
        DataSet GetCustomerDetailList(string strWhere);
        /// <summary>
        /// 获取删除选课SQL
        /// </summary>
        /// <param name="selectionID"></param>
        /// <returns></returns>
        string GetDeleteSql(int selectionID, int courseID, DateTime courseDate);

        /// <summary>
        /// 获取增加数据SQL
        /// </summary>
        string GetAddSql(XF.Model.Course_SelectionStudent model);

        /// <summary>
        /// 获取增加数据SQL
        /// </summary>
        string GetUpdateSignTypeSql(int selectionStudentID, int signTypeOld, int signType, int courseID, int sectionNO, int teacherID);

        /// <summary>
        /// 获取增加数据SQL
        /// </summary>
        string GetUpdateEvaluateSql(int selectionStudentID, string evaluateFilePath);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strOrder"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        DataTable GetListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        XF.Model.Course_SelectionStudent GetDetailModel(int SelectionStudentID);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        XF.Model.Course_SelectionStudent GetDetailModel(DateTime CourseDate, int StoreID, int ClassRoomID, int LessonNO,int StudentID);
		#endregion  MethodEx
	} 
}
