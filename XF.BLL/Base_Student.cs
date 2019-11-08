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
	/// Base_Student
	/// </summary>
	public partial class Base_Student
	{
		private readonly IBase_Student dal=DataAccess.CreateBase_Student();
		public Base_Student()
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
		public bool Exists(int StudentID)
		{
			return dal.Exists(StudentID);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string StudentCode)
        {
            return dal.Exists(StudentCode);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(XF.Model.Base_Student model)
		{
            if (Exists(model.StudentCode))
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
		public bool Update(XF.Model.Base_Student model)
		{
            model.LastUpdateUser = LoginInfo.LoginName;
            model.LastUpdateDate = DateTime.Now;
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StudentID)
		{
			
			return dal.Delete(StudentID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string StudentIDlist )
		{
			return dal.DeleteList(StudentIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public XF.Model.Base_Student GetModel(int StudentID)
		{
			
			return dal.GetModel(StudentID);
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
		public List<XF.Model.Base_Student> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<XF.Model.Base_Student> DataTableToList(DataTable dt)
		{
			List<XF.Model.Base_Student> modelList = new List<XF.Model.Base_Student>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				XF.Model.Base_Student model;
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
        /// 获得生日学员列表
        /// </summary>
        public List<XF.Model.Base_Student> GetBirthdayStudentDetailList(DateTime dtStart, DateTime dtEnd)
        {
            string strWhere = string.Empty;
            strWhere = zDataConverter.AppendSQL(strWhere, " CONVERT(datetime,'" + PhysicalConstants.DEFAULT_YEAR + "' + '-' + cast(month(birthday) as nvarchar(2)) + '-' + cast(day(birthday) as nvarchar(2)) ,101) between '" + dtStart.ToShortDateString() + "' and '" + dtEnd.ToShortDateString() +"'");
            DataSet ds = dal.GetDetailList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDetailList(string strWhere)
        {
            return dal.GetDetailList(strWhere);
        }

        /// <summary>
        /// 获取学员更新SQL
        /// </summary>
        public string GetUpdateStudentSql(int studentID, int courseID, int progress)
        {
            return dal.GetUpdateStudentSql(studentID, courseID, progress);
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
        public List<Model.Base_Student> GetModelListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count)
        {
            DataTable dt = dal.GetListByPage(strWhere, strOrder, pageIndex, pageSize, ref count);
            return DataTableToList(dt);
        }
        #endregion  ExtensionMethod
    }
}

