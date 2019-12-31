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
	/// Base_Course
	/// </summary>
	public partial class Base_Course
	{
		private readonly IBase_Course dal=DataAccess.CreateBase_Course();
		public Base_Course()
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
		public bool Exists(int CourseID)
		{
			return dal.Exists(CourseID);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CourseName)
        {
            return dal.Exists(CourseName);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(XF.Model.BaseCourse model)
		{
            if (Exists(model.CourseName))
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
		public bool Update(XF.Model.BaseCourse model)
		{
            model.LastUpdateUser = LoginInfo.LoginName;
            model.LastUpdateDate = DateTime.Now;
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int CourseID)
		{
			
			return dal.Delete(CourseID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string CourseIDlist )
		{
			return dal.DeleteList(CourseIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public XF.Model.BaseCourse GetModel(int CourseID)
		{
			
			return dal.GetModel(CourseID);
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
		public List<XF.Model.BaseCourse> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XF.Model.BaseCourse> DataTableToList(DataTable dt)
		{
			List<XF.Model.BaseCourse> modelList = new List<XF.Model.BaseCourse>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				XF.Model.BaseCourse model;
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
		#endregion  ExtensionMethod
	}
}

