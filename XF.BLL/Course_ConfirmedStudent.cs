using System;
using System.Data;
using System.Collections.Generic;
using XF.Model;
using XF.DALFactory;
using XF.IDAL;
namespace XF.BLL
{
	/// <summary>
	/// Course_ConfirmedStudent
	/// </summary>
	public partial class Course_ConfirmedStudent
	{
		private readonly ICourse_ConfirmedStudent dal=DataAccess.CreateCourse_ConfirmedStudent();
		public Course_ConfirmedStudent()
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
		public bool Exists(int ConfirmedID)
		{
			return dal.Exists(ConfirmedID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(XF.Model.Course_ConfirmedStudent model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(XF.Model.Course_ConfirmedStudent model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ConfirmedID)
		{
			
			return dal.Delete(ConfirmedID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ConfirmedIDlist )
		{
			return dal.DeleteList(ConfirmedIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public XF.Model.Course_ConfirmedStudent GetModel(int ConfirmedID)
		{
			
			return dal.GetModel(ConfirmedID);
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
		public List<XF.Model.Course_ConfirmedStudent> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XF.Model.Course_ConfirmedStudent> DataTableToList(DataTable dt)
		{
			List<XF.Model.Course_ConfirmedStudent> modelList = new List<XF.Model.Course_ConfirmedStudent>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				XF.Model.Course_ConfirmedStudent model;
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
        /// 批量删除
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public bool DeleteMultiple(string IDs)
        {
            return dal.DeleteMultiple(IDs);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDetailList(string strWhere)
        {
            return dal.GetDetailList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XF.Model.Course_ConfirmedStudent> GetModelDetailList(string strWhere)
        {
            DataTable dt =  dal.GetDetailList(strWhere).Tables[0];
            return DataTableToList(dt);
        }

        /// <summary>
        /// 获取增加数据SQL
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAddSql(XF.Model.Course_SelectionStudent model)
        {
            return dal.GetAddSql(model);
        }
		#endregion  ExtensionMethod
	}
}

