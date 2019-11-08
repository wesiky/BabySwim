using System;
using System.Data;
using System.Collections.Generic;
using XF.Model;
using XF.DALFactory;
using XF.IDAL;
using XF.Common;
using Enums;
namespace XF.BLL
{
	/// <summary>
	/// Assist_Notice
	/// </summary>
	public partial class Assist_Notice
	{
		private readonly IAssist_Notice dal=DataAccess.CreateAssist_Notice();
		public Assist_Notice()
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
		public bool Exists(int NoticeID)
		{
			return dal.Exists(NoticeID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(XF.Model.Assist_Notice model)
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
		public bool Update(XF.Model.Assist_Notice model)
		{
            model.LastUpdateUser = LoginInfo.LoginName;
            model.LastUpdateDate = DateTime.Now;
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int NoticeID)
		{
			
			return dal.Delete(NoticeID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string NoticeIDlist )
		{
			return dal.DeleteList(NoticeIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public XF.Model.Assist_Notice GetModel(int NoticeID)
		{
			
			return dal.GetModel(NoticeID);
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
		public List<XF.Model.Assist_Notice> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XF.Model.Assist_Notice> DataTableToList(DataTable dt)
		{
			List<XF.Model.Assist_Notice> modelList = new List<XF.Model.Assist_Notice>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				XF.Model.Assist_Notice model;
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
        /// 获取未处理通知清单
        /// </summary>
        /// <returns></returns>
        public DataSet GetUndoList()
        {
            string strWhere = string.Empty;
            strWhere = zDataConverter.AppendSQL(strWhere, " Status = 0 ");
            return GetList(strWhere);
        }

        /// <summary>
        /// 获取未处理通知对象数组
        /// </summary>
        /// <returns></returns>
        public List<XF.Model.Assist_Notice> GetUndoModelList()
        {
            DataSet ds = GetUndoList();
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 处理通知
        /// </summary>
        /// <param name="noticeId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool ConductNotice(int noticeId,NoticeStatusEnum status)
        {
            return dal.ConductNotice(noticeId,Convert.ToInt32( status),LoginInfo.LoginName);
        }

        /// <summary>
        /// 获取新增Sql
        /// </summary>
        public string GetAddSql(XF.Model.Assist_Notice model)
        {
            return dal.GetAddSql(model);
        }
		#endregion  ExtensionMethod
	}
}

