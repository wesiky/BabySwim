using System;
using System.Data;
using System.Collections.Generic;
using XF.Model;
using XF.DALFactory;
using XF.IDAL;
using Enums;
using XF.Common;
namespace XF.BLL
{
	/// <summary>
	/// Base_Teacher
	/// </summary>
	public partial class Base_Teacher
	{
		private readonly IBase_Teacher dal=DataAccess.CreateBase_Teacher();
		public Base_Teacher()
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
		public bool Exists(int TeacherID)
		{
			return dal.Exists(TeacherID);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TeacherCode)
        {
            return dal.Exists(TeacherCode);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(XF.Model.Base_Teacher model)
		{
            if (Exists(model.TeacherCode))
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
		public bool Update(XF.Model.Base_Teacher model)
		{
            model.LastUpdateUser = LoginInfo.LoginName;
            model.LastUpdateDate = DateTime.Now;
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int TeacherID)
		{
			
			return dal.Delete(TeacherID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string TeacherIDlist )
		{
			return dal.DeleteList(TeacherIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public XF.Model.Base_Teacher GetModel(int TeacherID)
		{
			
			return dal.GetModel(TeacherID);
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
		public List<XF.Model.Base_Teacher> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XF.Model.Base_Teacher> DataTableToList(DataTable dt)
		{
			List<XF.Model.Base_Teacher> modelList = new List<XF.Model.Base_Teacher>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				XF.Model.Base_Teacher model;
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

        // <summary>
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
        /// 获取教师授课统计报表
        /// </summary>
        /// <param name="courseIDs"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetTeacherReport(int[] courseIDs, string strWhere)
        {
            return dal.GetTeacherReport(courseIDs,strWhere);
        }

        /// <summary>
        /// 根据时间区间获取所有教师授课统计报表
        /// </summary>
        /// <param name="courseIDs"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetTeacherReport(DateTime dtStart,DateTime dtEnd,int[] courseIDs)
        {
            string strWhere = string.Empty;
            strWhere = zDataConverter.AppendSQL(strWhere," CourseDate between '" + dtStart.ToShortDateString() + "' and '" + dtEnd.AddDays(1).ToShortDateString() + "'");
            return dal.GetTeacherReport(courseIDs, strWhere);
        }
		#endregion  ExtensionMethod
	}
}

