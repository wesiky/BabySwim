﻿using System;
using System.Data;
namespace XF.IDAL
{
	/// <summary>
	/// 接口层Course_Evaluate
	/// </summary>
	public interface ICourse_Evaluate
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int Id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(XF.Model.Course_Evaluate model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(XF.Model.Course_Evaluate model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int Id);
		bool DeleteList(string Idlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		XF.Model.Course_Evaluate GetModel(int Id);
		XF.Model.Course_Evaluate DataRowToModel(DataRow row);
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
		#endregion  MethodEx
	} 
}
