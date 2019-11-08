using System;
using System.Data;
namespace XF.IDAL
{
	/// <summary>
	/// 接口层Assist_Notice
	/// </summary>
	public interface IAssist_Notice
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int NoticeID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(XF.Model.Assist_Notice model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(XF.Model.Assist_Notice model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int NoticeID);
		bool DeleteList(string NoticeIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		XF.Model.Assist_Notice GetModel(int NoticeID);
		XF.Model.Assist_Notice DataRowToModel(DataRow row);
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
        /// 处理消息
        /// </summary>
        bool ConductNotice(int noticeId, int status, string loginName);

        /// <summary>
        /// 获取新增Sql
        /// </summary>
        string GetAddSql(XF.Model.Assist_Notice model);
		#endregion  MethodEx
	} 
}
