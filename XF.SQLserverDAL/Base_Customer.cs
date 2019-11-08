using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XF.IDAL;
using XF.DBUtility;
using XF.Common;
using System.Collections;//Please add references
namespace XF.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:V_Base_Customer
	/// </summary>
	public partial class Base_Customer:IBase_Customer
	{
        SysManage dalSys = new SysManage();
		public Base_Customer()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return SqlServerHelper.GetMaxID("StudentID", "V_Base_Customer"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CustomerID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from V_Base_Customer");
			strSql.Append(" where StudentID=@StudentID");
			SqlParameter[] parameters = {
					new SqlParameter("@StudentID", SqlDbType.Int,4)
			};
            parameters[0].Value = CustomerID;

			return SqlServerHelper.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CustomerCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from V_Base_Customer");
            strSql.Append(" where StudentCode=@StudentCode");
            SqlParameter[] parameters = {
					new SqlParameter("@StudentCode", SqlDbType.NVarChar,31)
			};
            parameters[0].Value = CustomerCode;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(XF.Model.Base_Customer model)
		{
            ArrayList lstSql = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_Student(");
            strSql.Append("StudentCode,StudentName,StudentType,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser)");
            strSql.Append(" values ('");
            strSql.Append(model.CustomerCode);
            strSql.Append("','");
            strSql.Append(model.CustomerName);
            strSql.Append("',");
            strSql.Append(model.StudentType);
            strSql.Append(",'");
            strSql.Append(model.Description);
            strSql.Append("','");
            strSql.Append(DateTime.Now);
            strSql.Append("','");
            strSql.Append(model.CreateUser);
            strSql.Append("','");
            strSql.Append(DateTime.Now);
            strSql.Append("','");
            strSql.Append(model.LastUpdateUser);
            strSql.Append("');");
            lstSql.Add(strSql.ToString());
            strSql.Clear();
            strSql.Append("insert into Base_CustomerInfo(");
            strSql.Append("StudentID,Phone,Birthday,CoursePrice,InfoSource,FollowInfo,FollowUser,IsVisit,VisitDate,Age)");
            strSql.Append(" values ((select StudentID from Base_Student where StudentCode = '" + model.CustomerCode + "')");
            strSql.Append(",'");
            strSql.Append(model.Phone);
            strSql.Append("',");
            if (model.Birthday == null)
            {
                strSql.Append("null");
            }
            else
            {
                strSql.Append("'" + model.Birthday.Value.ToString() + "'");
            }
            strSql.Append(",");
            if (model.CoursePrice == null)
            {
                strSql.Append("null");
            }
            else
            {
                strSql.Append(model.CoursePrice.ToString());
            }
            strSql.Append(",'");
            strSql.Append(model.InfoSource);
            strSql.Append("','");
            strSql.Append(model.FollowInfo);
            strSql.Append("','");
            strSql.Append(model.FollowUser);
            strSql.Append("',");
            strSql.Append(Convert.ToInt32(model.IsVisit));
            strSql.Append(",");
            if (model.VisitDate == null)
            {
                strSql.Append("null");
            }
            else
            {
                strSql.Append("'" + model.VisitDate.Value.ToString() + "'");
            }
            strSql.Append(",");
            strSql.Append(model.Age);
            strSql.Append(");");
            lstSql.Add(strSql.ToString());
            if (dalSys.ExecuteSqlTran(lstSql))
            {
                strSql.Clear();
                strSql.Append("select StudentID from Base_Student where StudentCode = '" + model.CustomerCode + "';");
                object obj = SqlServerHelper.GetSingle(strSql.ToString());
                return Convert.ToInt32(obj);
            }
            else
            {
                return -1;
            }
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(XF.Model.Base_Customer model)
		{
            ArrayList lstSql = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_Student set ");
            strSql.Append("StudentCode='" + model.CustomerCode + "',");
            strSql.Append("StudentName='" + model.CustomerName + "',");
            strSql.Append("StudentType=" + model.StudentType + ",");
            strSql.Append("Description='" + model.Description + "',");
            strSql.Append("LastUpdateDate='" + model.LastUpdateDate + "',");
            strSql.Append("LastUpdateUser='" + model.LastUpdateUser + "' ");
            strSql.Append(" where StudentID=" + model.CustomerID.ToString() + ";");
            lstSql.Add(strSql.ToString());
            strSql.Clear();
            strSql.Append("update Base_CustomerInfo set ");
            strSql.Append("Phone='" + model.Phone + "',");
            if (model.Birthday == null)
            {
                strSql.Append("Birthday=null,");
            }
            else
            {
                strSql.Append("Birthday='" + model.Birthday.Value.ToString() + "',");
            }
            if (model.CoursePrice == null)
            {
                strSql.Append("CoursePrice=null,");
            }
            else
            {
                strSql.Append("CoursePrice=" + model.CoursePrice + ",");
            }
            strSql.Append("InfoSource='" + model.InfoSource + "',");
            strSql.Append("FollowInfo='" + model.FollowInfo + "',");
            strSql.Append("FollowUser='" + model.FollowUser + "',");
            if (model.IsVisit)
            {
                strSql.Append("IsVisit=1,");
            }
            else
            {
                strSql.Append("IsVisit=0,");
            }
            if (model.VisitDate == null)
            {
                strSql.Append("VisitDate=null,");
            }
            else
            {
                strSql.Append("VisitDate='" + model.VisitDate.Value.ToString() + "',");
            }
            strSql.Append("Age=" + model.Age + " ");
            strSql.Append(" where StudentID=" + model.CustomerID.ToString() + ";");
            lstSql.Add(strSql.ToString());
            return dalSys.ExecuteSqlTran(lstSql);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int StudentID)
		{
            ArrayList lstSql = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Base_Student ");
            strSql.Append(" where StudentID = " + StudentID + ";");
            lstSql.Add(strSql.ToString());
            strSql.Clear();
            strSql.Append("delete Base_CustomerInfo ");
            strSql.Append(" where StudentID = " + StudentID + ";");
            lstSql.Add(strSql.ToString());
            return dalSys.ExecuteSqlTran(lstSql);
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string CustomerIDlist )
		{
            ArrayList lstSql = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Base_Student ");
            strSql.Append(" where StudentID in (" + CustomerIDlist + ");");
            lstSql.Add(strSql.ToString());
            strSql.Clear();
            strSql.Append("delete Base_CustomerInfo ");
            strSql.Append(" where StudentID in (" + CustomerIDlist + ");");
            lstSql.Add(strSql.ToString());
            return dalSys.ExecuteSqlTran(lstSql);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public XF.Model.Base_Customer GetModel(int CustomerID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 StudentID,StudentCode,StudentName,Phone,Birthday,CoursePrice,InfoSource,FollowInfo,FollowUser,IsVisit,VisitDate,Age,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable from V_Base_Customer ");
			strSql.Append(" where StudentID=@StudentID");
			SqlParameter[] parameters = {
					new SqlParameter("@StudentID", SqlDbType.Int,4)
			};
			parameters[0].Value = CustomerID;

			XF.Model.Base_Customer model=new XF.Model.Base_Customer();
			DataSet ds=SqlServerHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XF.Model.Base_Customer GetModel(string CustomerCode)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 StudentID,StudentCode,StudentName,Phone,Birthday,CoursePrice,InfoSource,FollowInfo,FollowUser,IsVisit,VisitDate,Age,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable from V_Base_Customer ");
            strSql.Append(" where StudentCode=@StudentCode");
            SqlParameter[] parameters = {
					new SqlParameter("@StudentCode", SqlDbType.NVarChar,31)
			};
            parameters[0].Value = CustomerCode;

            XF.Model.Base_Customer model = new XF.Model.Base_Customer();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public XF.Model.Base_Customer DataRowToModel(DataRow row)
		{
			XF.Model.Base_Customer model=new XF.Model.Base_Customer();
			if (row != null)
			{
				if(row["StudentID"]!=null && row["StudentID"].ToString()!="")
				{
					model.CustomerID=int.Parse(row["StudentID"].ToString());
				}
                if (row["StudentCode"] != null)
                {
                    model.CustomerCode = row["StudentCode"].ToString();
                }
                if (row["StudentName"] != null)
				{
                    model.CustomerName = row["StudentName"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["Birthday"]!=null && row["Birthday"].ToString()!="")
				{
					model.Birthday=DateTime.Parse(row["Birthday"].ToString());
				}
				if(row["CoursePrice"]!=null && row["CoursePrice"].ToString()!="")
				{
					model.CoursePrice=decimal.Parse(row["CoursePrice"].ToString());
				}
				if(row["InfoSource"]!=null)
				{
					model.InfoSource=row["InfoSource"].ToString();
				}
				if(row["FollowInfo"]!=null)
				{
					model.FollowInfo=row["FollowInfo"].ToString();
				}
				if(row["FollowUser"]!=null)
				{
					model.FollowUser=row["FollowUser"].ToString();
				}
                if (row["IsVisit"] != null && row["IsVisit"].ToString() != "")
                {
                    if ((row["IsVisit"].ToString() == "1") || (row["IsVisit"].ToString().ToLower() == "true"))
                    {
                        model.IsVisit = true;
                    }
                    else
                    {
                        model.IsVisit = false;
                    }
                }
                if (row["VisitDate"] != null && row["VisitDate"].ToString() != "")
                {
                    model.VisitDate = DateTime.Parse(row["VisitDate"].ToString());
                }
                if (row["Age"] != null && row["Age"].ToString() != "")
                {
                    model.Age = int.Parse(row["Age"].ToString());
                }
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=DateTime.Parse(row["CreateDate"].ToString());
				}
				if(row["CreateUser"]!=null)
				{
					model.CreateUser=row["CreateUser"].ToString();
				}
				if(row["LastUpdateDate"]!=null && row["LastUpdateDate"].ToString()!="")
				{
					model.LastUpdateDate=DateTime.Parse(row["LastUpdateDate"].ToString());
				}
				if(row["LastUpdateUser"]!=null)
				{
					model.LastUpdateUser=row["LastUpdateUser"].ToString();
				}
				if(row["Enable"]!=null && row["Enable"].ToString()!="")
				{
					if((row["Enable"].ToString()=="1")||(row["Enable"].ToString().ToLower()=="true"))
					{
						model.Enable=true;
					}
					else
					{
						model.Enable=false;
					}
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select StudentID,StudentCode,StudentName,Phone,Birthday,CoursePrice,InfoSource,FollowInfo,FollowUser,IsVisit,VisitDate,Age,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM V_Base_Customer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return SqlServerHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
            strSql.Append(" StudentID,StudentCode,StudentName,Phone,Birthday,CoursePrice,InfoSource,FollowInfo,FollowUser,IsVisit,VisitDate,Age,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM V_Base_Customer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return SqlServerHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM V_Base_Customer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            object obj = SqlServerHelper.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.StudentID desc");
			}
			strSql.Append(")AS Row, T.*  from V_Base_Customer T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return SqlServerHelper.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "V_Base_Customer";
			parameters[1].Value = "StudentID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return SqlServerHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        public bool DeleteMultiple(string IDs)
        {
            ArrayList lstSql = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Base_Student ");
            strSql.Append(" where StudentID in (" + IDs + ");");
            lstSql.Add(strSql.ToString());
            strSql.Clear();
            strSql.Append("delete Base_CustomerInfo ");
            strSql.Append(" where StudentID in (" + IDs + ");");
            lstSql.Add(strSql.ToString());
            return dalSys.ExecuteSqlTran(lstSql);
        }

        /// <summary>
        /// 新增SQL语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAddSql(Model.Base_Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_Student(");
            strSql.Append("StudentCode,StudentName,StudentType,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser)");
            strSql.Append(" values ('");
            strSql.Append(model.CustomerCode);
            strSql.Append("','");
            strSql.Append(model.CustomerName);
            strSql.Append("',");
            strSql.Append(model.StudentType);
            strSql.Append(",'");
            strSql.Append(model.Description);
            strSql.Append("','");
            strSql.Append(DateTime.Now);
            strSql.Append("','");
            strSql.Append(model.CreateUser);
            strSql.Append("','");
            strSql.Append(DateTime.Now);
            strSql.Append("','");
            strSql.Append(model.LastUpdateUser);
            strSql.Append("');");
            strSql.Append("insert into Base_CustomerInfo(");
            strSql.Append("StudentID,Phone,Birthday,CoursePrice,InfoSource,FollowInfo,FollowUser,IsVisit,VisitDate,Age)");
            strSql.Append(" values ((select StudentID from Base_Student where StudentCode = '" + model.CustomerCode + "')");
            strSql.Append(",'");
            strSql.Append(model.Phone);
            strSql.Append("',");
            if (model.Birthday == null)
            {
                strSql.Append("null");
            }
            else
            {
                strSql.Append("'" + model.Birthday.Value.ToString() + "'");
            }
            strSql.Append(",");
            if (model.CoursePrice == null)
            {
                strSql.Append("null");
            }
            else
            {
                strSql.Append(model.CoursePrice.ToString());
            }
            strSql.Append(",'");
            strSql.Append(model.InfoSource);
            strSql.Append("','");
            strSql.Append(model.FollowInfo);
            strSql.Append("','");
            strSql.Append(model.FollowUser);
            strSql.Append("',");
            strSql.Append(Convert.ToInt32(model.IsVisit));
            strSql.Append(",");
            if (model.VisitDate == null)
            {
                strSql.Append("null");
            }
            else
            {
                strSql.Append("'" + model.VisitDate.Value.ToString() + "'");
            }
            strSql.Append(",");
            strSql.Append(model.Age);
            strSql.Append(");");
            return strSql.ToString();
        }

        /// <summary>
        /// 更新SQL语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetUpdateSql(Model.Base_Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_Student set ");
            strSql.Append("StudentCode='" + model.CustomerCode + "',");
            strSql.Append("StudentName='" + model.CustomerName + "',");
            strSql.Append("StudentType='" + model.StudentType + "',");
            strSql.Append("Description='" + model.Description + "',");
            strSql.Append("LastUpdateDate='" + model.LastUpdateDate + "',");
            strSql.Append("LastUpdateUser='" + model.LastUpdateUser + "' ");
            strSql.Append(" where StudentID=" + model.CustomerID.ToString() + ";");
            strSql.Append("update Base_CustomerInfo set ");
            strSql.Append("Phone='" + model.Phone + "',");
            if (model.Birthday == null)
            {
                strSql.Append("Birthday=null,");
            }
            else
            {
                strSql.Append("Birthday='" + model.Birthday.Value.ToString() + "',");
            }
            if (model.CoursePrice == null)
            {
                strSql.Append("CoursePrice=null,");
            }
            else
            {
                strSql.Append("CoursePrice=" + model.CoursePrice + ",");
            }
            strSql.Append("InfoSource='" + model.InfoSource + "',");
            strSql.Append("FollowInfo='" + model.FollowInfo + "',");
            strSql.Append("FollowUser='" + model.FollowUser + "',");
            if (model.IsVisit)
            {
                strSql.Append("IsVisit=1,");
            }
            else
            {
                strSql.Append("IsVisit=0,");
            }
            if (model.VisitDate == null)
            {
                strSql.Append("VisitDate=null,");
            }
            else
            {
                strSql.Append("VisitDate='" + model.VisitDate.Value.ToString() + "',");
            }
            strSql.Append("Age=" + model.Age + " ");
            strSql.Append(" where StudentID=" + model.CustomerID.ToString() + ";");
            return strSql.ToString();
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
            string tbName = " V_Base_Customer ";
            string tbGetFields = " V_Base_Customer.* ";
            return SqlServerHelper.GetPageList(tbName, tbGetFields, strOrder, pageSize, pageIndex, strWhere, ref count);
        }
		#endregion  ExtensionMethod
	}
}

