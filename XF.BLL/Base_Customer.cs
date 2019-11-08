using System;
using System.Data;
using System.Collections.Generic;
using XF.Model;
using XF.DALFactory;
using XF.IDAL;
using Enums;
namespace XF.BLL
{
	/// <summary>
	/// Base_Customer
	/// </summary>
	public partial class Base_Customer
	{
		private readonly IBase_Customer dal=DataAccess.CreateBase_Customer();
		public Base_Customer()
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
		public bool Exists(int CustomerID)
		{
			return dal.Exists(CustomerID);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CustomerCode)
        {
            return dal.Exists(CustomerCode);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(XF.Model.Base_Customer model)
		{
            if (Exists(model.CustomerCode))
            {
                return PhysicalConstants.SQL_Existed;
            }
            else
            {
                model.CreateUser = LoginInfo.LoginName;
                model.CreateDate = DateTime.Now;
                model.LastUpdateUser = LoginInfo.LoginName;
                model.LastUpdateDate = DateTime.Now;
                model.Enable = true;
                return dal.Add(model);
            }
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(XF.Model.Base_Customer model)
		{
            model.LastUpdateUser = LoginInfo.LoginName;
            model.LastUpdateDate = DateTime.Now;
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CustomerID)
		{
			
			return dal.Delete(CustomerID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string CustomerIDlist )
		{
			return dal.DeleteList(CustomerIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public XF.Model.Base_Customer GetModel(int CustomerID)
		{
			
			return dal.GetModel(CustomerID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XF.Model.Base_Customer GetModel(string CustomerCode)
        {
            return dal.GetModel(CustomerCode);
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
		public List<XF.Model.Base_Customer> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XF.Model.Base_Customer> DataTableToList(DataTable dt)
		{
			List<XF.Model.Base_Customer> modelList = new List<XF.Model.Base_Customer>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				XF.Model.Base_Customer model;
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
        public bool DeleteMultiple(string IDs)
        {
            return dal.DeleteMultiple(IDs);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetEnableList()
        {
            return GetList(" Enable = 1 ");
        }

        /// <summary>
        /// 新增SQL语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAddSql(Model.Base_Customer model)
        {
            model.CreateDate = DateTime.Now;
            model.CreateUser = LoginInfo.LoginName;
            model.LastUpdateDate = DateTime.Now;
            model.LastUpdateUser = LoginInfo.LoginName;
            return dal.GetAddSql(model);
        }

        /// <summary>
        /// 更新SQL语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetUpdateSql(Model.Base_Customer model)
        {
            model.LastUpdateDate = DateTime.Now;
            model.LastUpdateUser = LoginInfo.LoginName;
            return dal.GetUpdateSql(model);
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
        public List<Model.Base_Customer> GetModelListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count)
        {
            if (!strWhere.Equals(string.Empty))
            {
                strWhere = " and " + strWhere;
            }
            DataTable dt = dal.GetListByPage(strWhere, strOrder, pageIndex, pageSize, ref count);
            return DataTableToList(dt);
        }
		#endregion  ExtensionMethod
	}
}

