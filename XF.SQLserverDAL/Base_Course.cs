using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XF.IDAL;
using XF.DBUtility;//Please add references
namespace XF.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Base_Course
	/// </summary>
	public partial class Base_Course:IBase_Course
	{
		public Base_Course()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return SqlServerHelper.GetMaxID("CourseID", "Base_Course"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CourseID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Base_Course");
			strSql.Append(" where CourseID=@CourseID");
			SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4)
			};
			parameters[0].Value = CourseID;

			return SqlServerHelper.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CourseName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_Course");
            strSql.Append(" where CourseName=@CourseName");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseName", SqlDbType.NVarChar,63)
			};
            parameters[0].Value = CourseName;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(XF.Model.Base_Course model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Base_Course(");
			strSql.Append("CourseName,MaxCount,MaxSection,Description,Color,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable)");
			strSql.Append(" values (");
            strSql.Append("@CourseName,@MaxCount,@MaxSection,@Description,@Color,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser,@Enable)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CourseName", SqlDbType.NVarChar,63),
					new SqlParameter("@MaxCount", SqlDbType.Int,4),
					new SqlParameter("@MaxSection", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@Enable", SqlDbType.Bit,1),
                    new SqlParameter("@Color",SqlDbType.NVarChar,10)};
			parameters[0].Value = model.CourseName;
			parameters[1].Value = model.MaxCount;
			parameters[2].Value = model.MaxSection;
			parameters[3].Value = model.Description;
			parameters[4].Value = model.CreateDate;
			parameters[5].Value = model.CreateUser;
			parameters[6].Value = model.LastUpdateDate;
			parameters[7].Value = model.LastUpdateUser;
			parameters[8].Value = model.Enable;
            parameters[9].Value = model.Color;

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
		public bool Update(XF.Model.Base_Course model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Base_Course set ");
			strSql.Append("CourseName=@CourseName,");
			strSql.Append("MaxCount=@MaxCount,");
			strSql.Append("MaxSection=@MaxSection,");
			strSql.Append("Description=@Description,");
            strSql.Append("Color=@Color,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("CreateUser=@CreateUser,");
			strSql.Append("LastUpdateDate=@LastUpdateDate,");
			strSql.Append("LastUpdateUser=@LastUpdateUser,");
			strSql.Append("Enable=@Enable");
			strSql.Append(" where CourseID=@CourseID");
			SqlParameter[] parameters = {
					new SqlParameter("@CourseName", SqlDbType.NVarChar,63),
					new SqlParameter("@MaxCount", SqlDbType.Int,4),
					new SqlParameter("@MaxSection", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@Enable", SqlDbType.Bit,1),
					new SqlParameter("@CourseID", SqlDbType.Int,4),
                    new SqlParameter("@Color",SqlDbType.NVarChar,10)};
			parameters[0].Value = model.CourseName;
			parameters[1].Value = model.MaxCount;
			parameters[2].Value = model.MaxSection;
			parameters[3].Value = model.Description;
			parameters[4].Value = model.CreateDate;
			parameters[5].Value = model.CreateUser;
			parameters[6].Value = model.LastUpdateDate;
			parameters[7].Value = model.LastUpdateUser;
			parameters[8].Value = model.Enable;
			parameters[9].Value = model.CourseID;
            parameters[10].Value = model.Color;

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
		public bool Delete(int CourseID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Base_Course ");
			strSql.Append(" where CourseID=@CourseID");
			SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4)
			};
			parameters[0].Value = CourseID;

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
		public bool DeleteList(string CourseIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Base_Course ");
			strSql.Append(" where CourseID in ("+CourseIDlist + ")  ");
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
		public XF.Model.Base_Course GetModel(int CourseID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CourseID,CourseName,MaxCount,MaxSection,Description,Color,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable from Base_Course ");
			strSql.Append(" where CourseID=@CourseID");
			SqlParameter[] parameters = {
					new SqlParameter("@CourseID", SqlDbType.Int,4)
			};
			parameters[0].Value = CourseID;

			XF.Model.Base_Course model =new XF.Model.Base_Course();
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
		public XF.Model.Base_Course DataRowToModel(DataRow row)
		{
			XF.Model.Base_Course model =new XF.Model.Base_Course();
			if (row != null)
			{
				if(row["CourseID"]!=null && row["CourseID"].ToString()!="")
				{
					model.CourseID=int.Parse(row["CourseID"].ToString());
				}
				if(row["CourseName"]!=null)
				{
					model.CourseName=row["CourseName"].ToString();
				}
				if(row["MaxCount"]!=null && row["MaxCount"].ToString()!="")
				{
					model.MaxCount=int.Parse(row["MaxCount"].ToString());
				}
				if(row["MaxSection"]!=null && row["MaxSection"].ToString()!="")
				{
					model.MaxSection=int.Parse(row["MaxSection"].ToString());
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
                if (row["Color"] != null)
                {
                    model.Color = row["Color"].ToString();
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
            strSql.Append("select CourseID,CourseName,MaxCount,MaxSection,Description,Color,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM Base_Course ");
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
            strSql.Append(" CourseID,CourseName,MaxCount,MaxSection,Description,Color,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM Base_Course ");
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
			strSql.Append("select count(1) FROM Base_Course ");
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
				strSql.Append("order by T.CourseID desc");
			}
			strSql.Append(")AS Row, T.*  from Base_Course T ");
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
			parameters[0].Value = "Base_Course";
			parameters[1].Value = "CourseID";
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
            strSql.Append("delete Base_Course ");
            strSql.Append(" where CourseID in (" + IDs + ")");
            if (SqlServerHelper.ExecuteSql(strSql.ToString()) >= 1)
                return true;
            else
                return false;
        }
		#endregion  ExtensionMethod
	}
}

