using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XF.IDAL;
using XF.DBUtility;//Please add references
namespace XF.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Base_Teacher
	/// </summary>
	public partial class Base_Teacher:IBase_Teacher
	{
		public Base_Teacher()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return SqlServerHelper.GetMaxID("TeacherID", "Base_Teacher"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TeacherID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Base_Teacher");
			strSql.Append(" where TeacherID=@TeacherID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TeacherID", SqlDbType.Int,4)			};
			parameters[0].Value = TeacherID;

			return SqlServerHelper.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TeacherCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Base_Teacher");
            strSql.Append(" where TeacherCode=@TeacherCode ");
            SqlParameter[] parameters = {
					new SqlParameter("@TeacherCode", SqlDbType.NVarChar,31)			};
            parameters[0].Value = TeacherCode;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(XF.Model.Base_Teacher model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Base_Teacher(");
			strSql.Append("TeacherCode,TeacherName,Age,Sintroduction,TeacherType,Job,JobLevel,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable)");
			strSql.Append(" values (");
            strSql.Append("@TeacherCode,@TeacherName,@Age,@Sintroduction,@TeacherType,@Job,@JobLevel,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser,@Enable)");
			SqlParameter[] parameters = {
					new SqlParameter("@TeacherCode", SqlDbType.NVarChar,31),
					new SqlParameter("@TeacherName", SqlDbType.NVarChar,7),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@Sintroduction", SqlDbType.NVarChar,511),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@Enable", SqlDbType.Bit,1),
                    new SqlParameter("@Job", SqlDbType.Int,4),
                    new SqlParameter("@JobLevel", SqlDbType.Int,4),
                    new SqlParameter("@TeacherType", SqlDbType.Int,4)};
			parameters[0].Value = model.TeacherCode;
			parameters[1].Value = model.TeacherName;
			parameters[2].Value = model.Age;
			parameters[3].Value = model.Sintroduction;
			parameters[4].Value = model.CreateDate;
			parameters[5].Value = model.CreateUser;
			parameters[6].Value = model.LastUpdateDate;
			parameters[7].Value = model.LastUpdateUser;
			parameters[8].Value = model.Enable;
            parameters[9].Value = model.Job;
            parameters[10].Value = model.JobLevel;
            parameters[11].Value = model.TeacherType;

			return SqlServerHelper.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(XF.Model.Base_Teacher model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Base_Teacher set ");
			strSql.Append("TeacherCode=@TeacherCode,");
			strSql.Append("TeacherName=@TeacherName,");
			strSql.Append("Age=@Age,");
			strSql.Append("Sintroduction=@Sintroduction,");
            strSql.Append("TeacherType=@TeacherType,");
            strSql.Append("Job=@Job,");
            strSql.Append("JobLevel=@JobLevel,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("CreateUser=@CreateUser,");
			strSql.Append("LastUpdateDate=@LastUpdateDate,");
			strSql.Append("LastUpdateUser=@LastUpdateUser,");
			strSql.Append("Enable=@Enable");
			strSql.Append(" where TeacherID=@TeacherID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TeacherCode", SqlDbType.NVarChar,31),
					new SqlParameter("@TeacherName", SqlDbType.NVarChar,7),
					new SqlParameter("@Age", SqlDbType.Int,4),
					new SqlParameter("@Sintroduction", SqlDbType.NVarChar,511),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@Enable", SqlDbType.Bit,1),
					new SqlParameter("@TeacherID", SqlDbType.Int,4),
                    new SqlParameter("@Job", SqlDbType.Int,4),
                    new SqlParameter("@JobLevel", SqlDbType.Int,4),
                    new SqlParameter("@TeacherType", SqlDbType.Int,4)};
			parameters[0].Value = model.TeacherCode;
			parameters[1].Value = model.TeacherName;
			parameters[2].Value = model.Age;
			parameters[3].Value = model.Sintroduction;
			parameters[4].Value = model.CreateDate;
			parameters[5].Value = model.CreateUser;
			parameters[6].Value = model.LastUpdateDate;
			parameters[7].Value = model.LastUpdateUser;
			parameters[8].Value = model.Enable;
			parameters[9].Value = model.TeacherID;
            parameters[10].Value = model.Job;
            parameters[11].Value = model.JobLevel;
            parameters[12].Value = model.TeacherType;

			int rows=SqlServerHelper.ExecuteSql(strSql.ToString(),parameters);
			if (rows > -1)
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
		public bool Delete(int TeacherID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Base_Teacher ");
			strSql.Append(" where TeacherID=@TeacherID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TeacherID", SqlDbType.Int,4)			};
			parameters[0].Value = TeacherID;

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
		public bool DeleteList(string TeacherIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Base_Teacher ");
			strSql.Append(" where TeacherID in ("+TeacherIDlist + ")  ");
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
		public XF.Model.Base_Teacher GetModel(int TeacherID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TeacherID,TeacherCode,TeacherName,Age,Sintroduction,TeacherType,Job,JobLevel,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable from Base_Teacher ");
			strSql.Append(" where TeacherID=@TeacherID ");
			SqlParameter[] parameters = {
					new SqlParameter("@TeacherID", SqlDbType.Int,4)			};
			parameters[0].Value = TeacherID;

			XF.Model.Base_Teacher model=new XF.Model.Base_Teacher();
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
		public XF.Model.Base_Teacher DataRowToModel(DataRow row)
		{
			XF.Model.Base_Teacher model=new XF.Model.Base_Teacher();
			if (row != null)
			{
				if(row["TeacherID"]!=null && row["TeacherID"].ToString()!="")
				{
					model.TeacherID=int.Parse(row["TeacherID"].ToString());
				}
				if(row["TeacherCode"]!=null)
				{
					model.TeacherCode=row["TeacherCode"].ToString();
				}
				if(row["TeacherName"]!=null)
				{
					model.TeacherName=row["TeacherName"].ToString();
				}
				if(row["Age"]!=null && row["Age"].ToString()!="")
				{
					model.Age=int.Parse(row["Age"].ToString());
				}
				if(row["Sintroduction"]!=null)
				{
					model.Sintroduction=row["Sintroduction"].ToString();
				}
                if (row["TeacherType"] != null && row["TeacherType"].ToString() != "")
                {
                    model.TeacherType = int.Parse(row["TeacherType"].ToString());
                }
                if(row["Job"]!=null && row["Job"].ToString()!="")
				{
					model.Job=int.Parse(row["Job"].ToString());
				}
                if(row["JobLevel"]!=null && row["JobLevel"].ToString()!="")
				{
					model.JobLevel=int.Parse(row["JobLevel"].ToString());
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
            strSql.Append("select TeacherID,TeacherCode,TeacherName,Age,Sintroduction,TeacherType,Job,JobLevel,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM Base_Teacher ");
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
            strSql.Append(" TeacherID,TeacherCode,TeacherName,Age,Sintroduction,TeacherType,Job,JobLevel,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM Base_Teacher ");
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
			strSql.Append("select count(1) FROM Base_Teacher ");
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
				strSql.Append("order by T.TeacherID desc");
			}
			strSql.Append(")AS Row, T.*  from Base_Teacher T ");
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
			parameters[0].Value = "Base_Teacher";
			parameters[1].Value = "TeacherID";
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
            strSql.Append("delete Base_Teacher ");
            strSql.Append(" where TeacherID in (" + IDs + ")");
            if (SqlServerHelper.ExecuteSql(strSql.ToString()) >= 1)
                return true;
            else
                return false;
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
            const string tbName = " Base_Teacher A ";
            const string tbGetFields = " A.* ";
            return SqlServerHelper.GetPageList(tbName, tbGetFields, strOrder, pageSize, pageIndex, strWhere, ref count);
        }

        /// <summary>
        /// 获取教师授课统计报表
        /// </summary>
        /// <param name="courseIDs"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetTeacherReport(int[] courseIDs, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            if (courseIDs.Length > 0)
            {
                string courseStatistics = string.Empty;
                string courseField = string.Empty;
                foreach (int courseID in courseIDs)
                {
                    courseField += ",isnull(B.Course" + courseID + ",0) as Course" + courseID;
                    courseStatistics += ",Sum(case when CourseID = " + courseID + " then 1 else 0 end) as Course" + courseID;
                }
                strSql.Append("select A.*,isnull(B.Totle,0) as Totle");
                strSql.Append(courseField);
                strSql.Append(" from Base_Teacher A left join");
                strSql.Append("(select RealTeacherID,COUNT(1) as Totle");
                strSql.Append(courseStatistics);
                strSql.Append(" from V_Course_SelectionStudentDetail");
                if (!strWhere.Equals(string.Empty))
                {
                    strSql.Append(" where " + strWhere);
                }
                strSql.Append(" group by RealTeacherID) B");
                strSql.Append(" on A.TeacherID = B.RealTeacherID where A.TeacherType = 0");
                return SqlServerHelper.Query(strSql.ToString()).Tables[0];
            }
            else
            {
                return null;
            }
        }
		#endregion  ExtensionMethod
	}
}

