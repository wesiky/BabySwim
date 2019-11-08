using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XF.IDAL;
using XF.DBUtility;
using System.Collections;//Please add references
namespace XF.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:V_Base_Student
	/// </summary>
	public partial class Base_Student:IBase_Student
	{
        SysManage dalSys = new SysManage();
		public Base_Student()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return SqlServerHelper.GetMaxID("StudentID", "V_Base_Student"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StudentID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from V_Base_Student");
			strSql.Append(" where StudentID=@StudentID");
			SqlParameter[] parameters = {
					new SqlParameter("@StudentID", SqlDbType.Int,4)
			};
			parameters[0].Value = StudentID;

			return SqlServerHelper.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string StudentCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from V_Base_Student");
            strSql.Append(" where StudentCode=@StudentCode");
            SqlParameter[] parameters = {
                    new SqlParameter("@StudentCode", SqlDbType.NVarChar,31)
			};
            parameters[0].Value = StudentCode;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(XF.Model.Base_Student model)
		{
            ArrayList lstSql = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Base_Student(StudentCode,StudentName,StudentType,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser) ");
            strSql.Append("values ('" + model.StudentCode + "','" + model.StudentName + "'," + model.StudentType + ",'" + model.Description + "','" + model.CreateDate + "','" + model.CreateUser +"','" + model.LastUpdateDate +"','" + model.LastUpdateUser + "');");
            lstSql.Add(strSql.ToString());
            strSql.Clear();
            strSql.Append("insert into Base_StudentInfo(StudentID,NickName,Birthdate,TeacherID,AdviserID,Birthday,CourseID,Progress,FamilyID) ");
            strSql.Append("values ((select StudentID from Base_Student where StudentCode = '" + model.StudentCode + "'),'" + model.NickName + "','" + model.Birthdate + "'," + model.TeacherID + "," + model.AdviserID +",'" + model.Birthday + "',");
            if (model.CourseID == null)
            {
                strSql.Append("null");
            }
            else
            {
                strSql.Append(model.CourseID);
            }
            strSql.Append(",");
            if (model.Progress == null)
            {
                strSql.Append("null");
            }
            else
            {
                strSql.Append(model.Progress);
            }
            strSql.Append("," + model.FamilyID + ");");
            lstSql.Add(strSql.ToString());
            if (dalSys.ExecuteSqlTran(lstSql))
            {
                strSql.Clear();
                strSql.Append("select StudentID from Base_Student where StudentCode = '" + model.StudentCode + "';");
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
        public bool Update(XF.Model.Base_Student model)
		{
            ArrayList lstSql = new ArrayList();
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Base_Student set ");
            strSql.Append("StudentCode='" + model.StudentCode + "',");
            strSql.Append("StudentName='" + model.StudentName + "',");
            strSql.Append("StudentType=" + model.StudentType + ",");
            strSql.Append("Description='" + model.Description + "',");
			strSql.Append("CreateDate='" + model.CreateDate + "',");
			strSql.Append("CreateUser='" + model.CreateUser + "',");
			strSql.Append("LastUpdateDate='" + model.LastUpdateDate + "',");
			strSql.Append("LastUpdateUser='" + model.LastUpdateUser + "',");
			strSql.Append("Enable=" + Convert.ToInt32(model.Enable) + " ");
			strSql.Append(" where StudentID=" + model.StudentID + ";");
            lstSql.Add(strSql.ToString());
            strSql.Clear();
            strSql.Append("update Base_StudentInfo set ");
            strSql.Append("NickName='" + model.NickName + "',");
            strSql.Append("Birthdate='" + model.Birthdate + "',");
            strSql.Append("TeacherID=" + model.TeacherID + ",");
            strSql.Append("AdviserID=" + model.AdviserID + ",");
            strSql.Append("Birthday='" + model.Birthday + "',");
            if (model.CourseID == null)
            {
                strSql.Append("CourseID=null,");
            }
            else
            {
                strSql.Append("CourseID=" + model.CourseID + ",");
            }
            if (model.Progress == null)
            {
                strSql.Append("Progress=null,");
            }
            else
            {
                strSql.Append("Progress=" + model.Progress + ",");
            }
            strSql.Append("FamilyID=" + model.FamilyID + " ");
            strSql.Append(" where StudentID=" + model.StudentID + ";");
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
            strSql.Append("delete Base_StudentInfo ");
            strSql.Append(" where StudentID = " + StudentID + ";");
            lstSql.Add(strSql.ToString());
            return dalSys.ExecuteSqlTran(lstSql);
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string StudentIDlist )
		{
            ArrayList lstSql = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Base_Student ");
            strSql.Append(" where StudentID in (" + StudentIDlist + ");");
            lstSql.Add(strSql.ToString());
            strSql.Clear();
            strSql.Append("delete Base_StudentInfo ");
            strSql.Append(" where StudentID in (" + StudentIDlist + ");");
            lstSql.Add(strSql.ToString());
            return dalSys.ExecuteSqlTran(lstSql);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public XF.Model.Base_Student GetModel(int StudentID)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select  top 1 StudentID,StudentCode,StudentName,NickName,Birthdate,TeacherID,AdviserID,Birthday,CourseID,Progress,Description,FamilyID,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable from V_Base_Student ");
			strSql.Append(" where StudentID=@StudentID");
			SqlParameter[] parameters = {
					new SqlParameter("@StudentID", SqlDbType.Int,4)
			};
			parameters[0].Value = StudentID;

            XF.Model.Base_Student model = new XF.Model.Base_Student();
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
        public XF.Model.Base_Student DataRowToModel(DataRow row)
		{
            XF.Model.Base_Student model = new XF.Model.Base_Student();
            if (row != null)
            {
                if (row["StudentID"] != null && row["StudentID"].ToString() != "")
                {
                    model.StudentID = int.Parse(row["StudentID"].ToString());
                }
                if (row["StudentCode"] != null)
                {
                    model.StudentCode = row["StudentCode"].ToString();
                }
                if (row["StudentName"] != null)
                {
                    model.StudentName = row["StudentName"].ToString();
                }
                if (row["NickName"] != null)
                {
                    model.NickName = row["NickName"].ToString();
                }
                if (row["Birthdate"] != null && row["Birthdate"].ToString() != "")
                {
                    model.Birthdate = DateTime.Parse(row["Birthdate"].ToString());
                }
                if (row["TeacherID"] != null && row["TeacherID"].ToString() != "")
                {
                    model.TeacherID = int.Parse(row["TeacherID"].ToString());
                }
                if (row["AdviserID"] != null && row["AdviserID"].ToString() != "")
                {
                    model.AdviserID = int.Parse(row["AdviserID"].ToString());
                }
                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(row["Birthday"].ToString());
                }
                if (row["CourseID"] != null && row["CourseID"].ToString() != "")
                {
                    model.CourseID = int.Parse(row["CourseID"].ToString());
                }
                if (row["Progress"] != null && row["Progress"].ToString() != "")
                {
                    model.Progress = int.Parse(row["Progress"].ToString());
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["CreateDate"] != null && row["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(row["CreateDate"].ToString());
                }
                if (row["CreateUser"] != null)
                {
                    model.CreateUser = row["CreateUser"].ToString();
                }
                if (row["LastUpdateDate"] != null && row["LastUpdateDate"].ToString() != "")
                {
                    model.LastUpdateDate = DateTime.Parse(row["LastUpdateDate"].ToString());
                }
                if (row["LastUpdateUser"] != null)
                {
                    model.LastUpdateUser = row["LastUpdateUser"].ToString();
                }
                if (row["Enable"] != null && row["Enable"].ToString() != "")
                {
                    if ((row["Enable"].ToString() == "1") || (row["Enable"].ToString().ToLower() == "true"))
                    {
                        model.Enable = true;
                    }
                    else
                    {
                        model.Enable = false;
                    }
                }
                if (row["FamilyID"] != null && row["FamilyID"].ToString() != "")
                {
                    model.FamilyID = int.Parse(row["FamilyID"].ToString());
                }
                if (row.Table.Columns.Contains("FamilyCode"))
                {
                    if (row["FamilyCode"] != null)
                    {
                        model.FamilyCode = row["FamilyCode"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("FamilyName"))
                {
                    if (row["FamilyName"] != null)
                    {
                        model.FamilyName = row["FamilyName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("CourseCount"))
                {
                    if (row["CourseCount"] != null && row["CourseCount"].ToString() != "")
                    {
                        model.CourseCount = decimal.Parse(row["CourseCount"].ToString());
                    }
                } 
                if (row.Table.Columns.Contains("Phone"))
                {
                    if (row["Phone"] != null)
                    {
                        model.Phone = row["Phone"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("TeacherCode"))
                {
                    if (row["TeacherCode"] != null)
                    {
                        model.TeacherCode = row["TeacherCode"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("TeacherName"))
                {
                    if (row["TeacherName"] != null)
                    {
                        model.TeacherName = row["TeacherName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("AdviserCode"))
                {
                    if (row["AdviserCode"] != null)
                    {
                        model.AdviserCode = row["AdviserCode"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("AdviserName"))
                {
                    if (row["AdviserName"] != null)
                    {
                        model.AdviserName = row["AdviserName"].ToString();
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
            strSql.Append("select StudentID,StudentCode,StudentName,NickName,Birthdate,TeacherID,AdviserID,Birthday,CourseID,Progress,Description,FamilyID,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM V_Base_Student ");
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
            strSql.Append(" StudentID,StudentCode,StudentName,NickName,Birthdate,TeacherID,AdviserID,Birthday,CourseID,Progress,Description,FamilyID,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM V_Base_Student ");
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
			strSql.Append("select count(1) FROM V_Base_Student ");
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
			strSql.Append(")AS Row, T.*  from V_Base_Student T ");
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
			parameters[0].Value = "V_Base_Student";
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
            strSql.Append("delete Base_StudentInfo ");
            strSql.Append(" where StudentID in (" + IDs + ");");
            lstSql.Add(strSql.ToString());
            return dalSys.ExecuteSqlTran(lstSql);
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
            string tbName = " V_Base_StudentDetail A ";
            string tbGetFields = " A.* ";
            return SqlServerHelper.GetPageList(tbName, tbGetFields, strOrder, pageSize, pageIndex, strWhere, ref count);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDetailList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM V_Base_StudentDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取学员更新SQL
        /// </summary>
        public string GetUpdateStudentSql(int studentID, int courseID,int progress)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Base_StudentInfo set ");
            strSql.Append("CourseID = ");
            strSql.Append(courseID);
            strSql.Append(",Progress = ");
            strSql.Append(progress);
            strSql.Append(" where StudentID = ");
            strSql.Append(studentID);
            strSql.Append(";");
            return strSql.ToString();
        }
		#endregion  ExtensionMethod
	}
}

