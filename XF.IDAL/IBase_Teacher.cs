using System;
using System.Data;
namespace XF.IDAL
{
	/// <summary>
	/// 接口层Base_Teacher
	/// </summary>
	public interface IBase_Teacher
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int TeacherID);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string TeacherCode);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(XF.Model.Base_Teacher model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(XF.Model.Base_Teacher model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int TeacherID);
		bool DeleteList(string TeacherIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		XF.Model.Base_Teacher GetModel(int TeacherID);
		XF.Model.Base_Teacher DataRowToModel(DataRow row);
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
        bool DeleteMultiple(string IDs);

        // <summary>
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
        /// 获取教师授课统计报表
        /// </summary>
        /// <param name="courseIDs"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataTable GetTeacherReport(int[] courseIDs, string strWhere);
		#endregion  MethodEx
	} 
}
