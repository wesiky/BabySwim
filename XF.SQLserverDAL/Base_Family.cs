using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XF.IDAL;
using XF.DBUtility;//Please add references
namespace XF.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Base_Family
	/// </summary>
	public partial class Base_Family:IBase_Family
	{
		public Base_Family()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return SqlServerHelper.GetMaxID("FamilyID", "Base_Family"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FamilyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Base_Family");
			strSql.Append(" where FamilyID=@FamilyID");
			SqlParameter[] parameters = {
					new SqlParameter("@FamilyID", SqlDbType.Int,4)
			};
			parameters[0].Value = FamilyID;

			return SqlServerHelper.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string FamilyCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_Family");
            strSql.Append(" where FamilyCode=@FamilyCode");
            SqlParameter[] parameters = {
					new SqlParameter("@FamilyCode", SqlDbType.NVarChar,31)
			};
            parameters[0].Value = FamilyCode;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(XF.Model.Base_Family model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Base_Family(");
			strSql.Append("FamilyCode,FamilyName,CourseCount,Phone,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable)");
			strSql.Append(" values (");
			strSql.Append("@FamilyCode,@FamilyName,@CourseCount,@Phone,@Description,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser,@Enable)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FamilyCode", SqlDbType.NVarChar,31),
					new SqlParameter("@FamilyName", SqlDbType.NVarChar,7),
					new SqlParameter("@CourseCount", SqlDbType.Decimal,9),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@Enable", SqlDbType.Bit,1),
                    new SqlParameter("@Phone",SqlDbType.NVarChar,18)};
			parameters[0].Value = model.FamilyCode;
			parameters[1].Value = model.FamilyName;
			parameters[2].Value = model.CourseCount;
			parameters[3].Value = model.Description;
			parameters[4].Value = model.CreateDate;
			parameters[5].Value = model.CreateUser;
			parameters[6].Value = model.LastUpdateDate;
			parameters[7].Value = model.LastUpdateUser;
			parameters[8].Value = model.Enable;
            parameters[9].Value = model.Phone;

			object obj = SqlServerHelper.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return -1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(XF.Model.Base_Family model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Base_Family set ");
			strSql.Append("FamilyCode=@FamilyCode,");
			strSql.Append("FamilyName=@FamilyName,");
			strSql.Append("CourseCount=@CourseCount,");
            strSql.Append("Phone=@Phone,");
			strSql.Append("Description=@Description,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("CreateUser=@CreateUser,");
			strSql.Append("LastUpdateDate=@LastUpdateDate,");
			strSql.Append("LastUpdateUser=@LastUpdateUser,");
			strSql.Append("Enable=@Enable");
			strSql.Append(" where FamilyID=@FamilyID");
			SqlParameter[] parameters = {
					new SqlParameter("@FamilyCode", SqlDbType.NVarChar,31),
					new SqlParameter("@FamilyName", SqlDbType.NVarChar,7),
					new SqlParameter("@CourseCount", SqlDbType.Decimal,9),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@Enable", SqlDbType.Bit,1),
					new SqlParameter("@FamilyID", SqlDbType.Int,4),
                    new SqlParameter("@Phone",SqlDbType.NVarChar,18)};
			parameters[0].Value = model.FamilyCode;
			parameters[1].Value = model.FamilyName;
			parameters[2].Value = model.CourseCount;
			parameters[3].Value = model.Description;
			parameters[4].Value = model.CreateDate;
			parameters[5].Value = model.CreateUser;
			parameters[6].Value = model.LastUpdateDate;
			parameters[7].Value = model.LastUpdateUser;
			parameters[8].Value = model.Enable;
			parameters[9].Value = model.FamilyID;
            parameters[10].Value = model.Phone;

			int rows=SqlServerHelper.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int FamilyID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Base_Family ");
			strSql.Append(" where FamilyID=@FamilyID;");
            strSql.Append("delete from Base_Student");
            strSql.Append(" where FamilyID=@FamilyID;");
			SqlParameter[] parameters = {
					new SqlParameter("@FamilyID", SqlDbType.Int,4)
			};
			parameters[0].Value = FamilyID;

			int rows=SqlServerHelper.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string FamilyIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Base_Family ");
			strSql.Append(" where FamilyID in ("+FamilyIDlist + ")  ");
			int rows=SqlServerHelper.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public XF.Model.Base_Family GetModel(int FamilyID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FamilyID,FamilyCode,FamilyName,CourseCount,Phone,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable from Base_Family ");
			strSql.Append(" where FamilyID=@FamilyID");
			SqlParameter[] parameters = {
					new SqlParameter("@FamilyID", SqlDbType.Int,4)
			};
			parameters[0].Value = FamilyID;

			XF.Model.Base_Family model=new XF.Model.Base_Family();
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
		public XF.Model.Base_Family DataRowToModel(DataRow row)
		{
			XF.Model.Base_Family model=new XF.Model.Base_Family();
			if (row != null)
			{
				if(row["FamilyID"]!=null && row["FamilyID"].ToString()!="")
				{
					model.FamilyID=int.Parse(row["FamilyID"].ToString());
				}
				if(row["FamilyCode"]!=null)
				{
					model.FamilyCode=row["FamilyCode"].ToString();
				}
				if(row["FamilyName"]!=null)
				{
					model.FamilyName=row["FamilyName"].ToString();
				}
				if(row["CourseCount"]!=null && row["CourseCount"].ToString()!="")
				{
					model.CourseCount=decimal.Parse(row["CourseCount"].ToString());
				}
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
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
			strSql.Append("select FamilyID,FamilyCode,FamilyName,CourseCount,Phone,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM Base_Family ");
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
			strSql.Append(" FamilyID,FamilyCode,FamilyName,CourseCount,Phone,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM Base_Family ");
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
			strSql.Append("select count(1) FROM Base_Family ");
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
				strSql.Append("order by T.FamilyID desc");
			}
			strSql.Append(")AS Row, T.*  from Base_Family T ");
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
			parameters[0].Value = "Base_Family";
			parameters[1].Value = "FamilyID";
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Base_Family ");
            strSql.Append(" where FamilyID in (" + IDs + ");");
            strSql.Append("delete from Base_Student ");
            strSql.Append(" where StudentID in (select StudentID from Base_StudentInfo where FamilyID in (" + IDs + "));");
            strSql.Append("delete Base_StudentInfo ");
            strSql.Append(" where FamilyID in (" + IDs + ");");
            if (SqlServerHelper.ExecuteSql(strSql.ToString()) >= 1)
                return true;
            else
                return false;
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
            string tbName = " Base_Family ";
            string tbGetFields = " Base_Family.* ";
            return SqlServerHelper.GetPageList(tbName, tbGetFields, strOrder, pageSize, pageIndex, strWhere, ref count);
        }
		#endregion  ExtensionMethod
	}
}

