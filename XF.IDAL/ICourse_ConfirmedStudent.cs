using System;
using System.Data;
namespace XF.IDAL
{
	/// <summary>
	/// 接口层Course_ConfirmedStudent
	/// </summary>
	public interface ICourse_ConfirmedStudent
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int ConfirmedID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(XF.Model.Course_ConfirmedStudent model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(XF.Model.Course_ConfirmedStudent model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int ConfirmedID);
		bool DeleteList(string ConfirmedIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		XF.Model.Course_ConfirmedStudent GetModel(int ConfirmedID);
		XF.Model.Course_ConfirmedStudent DataRowToModel(DataRow row);
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
        /// 批量删除
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        bool DeleteMultiple(string IDs);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetDetailList(string strWhere);

        /// <summary>
        /// 获取增加数据SQL
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        string GetAddSql(XF.Model.Course_SelectionStudent model);
		#endregion  MethodEx
	} 
}
