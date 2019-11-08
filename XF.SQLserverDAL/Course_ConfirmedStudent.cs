using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XF.IDAL;
using XF.DBUtility;//Please add references
namespace XF.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Course_ConfirmedStudent
    /// </summary>
    public partial class Course_ConfirmedStudent : ICourse_ConfirmedStudent
    {
        public Course_ConfirmedStudent()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return SqlServerHelper.GetMaxID("ConfirmedID", "Course_ConfirmedStudent");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ConfirmedID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Course_ConfirmedStudent");
            strSql.Append(" where ConfirmedID=@ConfirmedID");
            SqlParameter[] parameters = {
					new SqlParameter("@ConfirmedID", SqlDbType.Int,4)
			};
            parameters[0].Value = ConfirmedID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(XF.Model.Course_ConfirmedStudent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Course_ConfirmedStudent(");
            strSql.Append("StudentID,DayOfWeek,LessonNO,ClassRoomID,StoreID,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable)");
            strSql.Append(" values (");
            strSql.Append("@StudentID,@DayOfWeek,@LessonNO,@ClassRoomID,@StoreID,@Description,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser,@Enable)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StudentID", SqlDbType.Int,4),
					new SqlParameter("@DayOfWeek", SqlDbType.Int,4),
					new SqlParameter("@LessonNO", SqlDbType.Int,4),
					new SqlParameter("@ClassRoomID", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@Enable", SqlDbType.Bit,1),
                    new SqlParameter("@StoreID", SqlDbType.Int,4)};
            parameters[0].Value = model.StudentID;
            parameters[1].Value = model.DayOfWeek;
            parameters[2].Value = model.LessonNO;
            parameters[3].Value = model.ClassRoomID;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.CreateUser;
            parameters[7].Value = model.LastUpdateDate;
            parameters[8].Value = model.LastUpdateUser;
            parameters[9].Value = model.Enable;
            parameters[10].Value = model.StoreID;

            object obj = SqlServerHelper.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(XF.Model.Course_ConfirmedStudent model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Course_ConfirmedStudent set ");
            strSql.Append("StudentID=@StudentID,");
            strSql.Append("DayOfWeek=@DayOfWeek,");
            strSql.Append("LessonNO=@LessonNO,");
            strSql.Append("ClassRoomID=@ClassRoomID,");
            strSql.Append("StoreID=@StoreID,");
            strSql.Append("Description=@Description,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("CreateUser=@CreateUser,");
            strSql.Append("LastUpdateDate=@LastUpdateDate,");
            strSql.Append("LastUpdateUser=@LastUpdateUser,");
            strSql.Append("Enable=@Enable");
            strSql.Append(" where ConfirmedID=@ConfirmedID");
            SqlParameter[] parameters = {
					new SqlParameter("@StudentID", SqlDbType.Int,4),
					new SqlParameter("@DayOfWeek", SqlDbType.Int,4),
					new SqlParameter("@LessonNO", SqlDbType.Int,4),
					new SqlParameter("@ClassRoomID", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@Enable", SqlDbType.Bit,1),
					new SqlParameter("@ConfirmedID", SqlDbType.Int,4),
                    new SqlParameter("@StoreID", SqlDbType.Int,4)};
            parameters[0].Value = model.StudentID;
            parameters[1].Value = model.DayOfWeek;
            parameters[2].Value = model.LessonNO;
            parameters[3].Value = model.ClassRoomID;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.CreateUser;
            parameters[7].Value = model.LastUpdateDate;
            parameters[8].Value = model.LastUpdateUser;
            parameters[9].Value = model.Enable;
            parameters[10].Value = model.ConfirmedID;
            parameters[11].Value = model.StoreID;

            int rows = SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int ConfirmedID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Course_ConfirmedStudent ");
            strSql.Append(" where ConfirmedID=@ConfirmedID");
            SqlParameter[] parameters = {
					new SqlParameter("@ConfirmedID", SqlDbType.Int,4)
			};
            parameters[0].Value = ConfirmedID;

            int rows = SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string ConfirmedIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Course_ConfirmedStudent ");
            strSql.Append(" where ConfirmedID in (" + ConfirmedIDlist + ")  ");
            int rows = SqlServerHelper.ExecuteSql(strSql.ToString());
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
        public XF.Model.Course_ConfirmedStudent GetModel(int ConfirmedID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ConfirmedID,StudentID,DayOfWeek,LessonNO,ClassRoomID,StoreID,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable from Course_ConfirmedStudent ");
            strSql.Append(" where ConfirmedID=@ConfirmedID");
            SqlParameter[] parameters = {
					new SqlParameter("@ConfirmedID", SqlDbType.Int,4)
			};
            parameters[0].Value = ConfirmedID;

            XF.Model.Course_ConfirmedStudent model = new XF.Model.Course_ConfirmedStudent();
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
        public XF.Model.Course_ConfirmedStudent DataRowToModel(DataRow row)
        {
            XF.Model.Course_ConfirmedStudent model = new XF.Model.Course_ConfirmedStudent();
            if (row != null)
            {
                if (row["ConfirmedID"] != null && row["ConfirmedID"].ToString() != "")
                {
                    model.ConfirmedID = int.Parse(row["ConfirmedID"].ToString());
                }
                if (row["StudentID"] != null && row["StudentID"].ToString() != "")
                {
                    model.StudentID = int.Parse(row["StudentID"].ToString());
                }
                if (row["DayOfWeek"] != null && row["DayOfWeek"].ToString() != "")
                {
                    model.DayOfWeek = int.Parse(row["DayOfWeek"].ToString());
                }
                if (row["LessonNO"] != null && row["LessonNO"].ToString() != "")
                {
                    model.LessonNO = int.Parse(row["LessonNO"].ToString());
                }
                if (row["ClassRoomID"] != null && row["ClassRoomID"].ToString() != "")
                {
                    model.ClassRoomID = int.Parse(row["ClassRoomID"].ToString());
                }
                if (row["StoreID"] != null && row["StoreID"].ToString() != "")
                {
                    model.StoreID = int.Parse(row["StoreID"].ToString());
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
                #region 扩展属性
                if (row.Table.Columns.Contains("StudentName"))
                {
                    if (row["StudentName"] != null)
                    {
                        model.StudentName = row["StudentName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("NickName"))
                {
                    if (row["NickName"] != null)
                    {
                        model.NickName = row["NickName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("FamilyID"))
                {
                    if (row["FamilyID"] != null && row["FamilyID"].ToString() != "")
                    {
                        model.FamilyID = int.Parse(row["FamilyID"].ToString());
                    }
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
                if (row.Table.Columns.Contains("TeacherID"))
                {
                    if (row["TeacherID"] != null && row["TeacherID"].ToString() != "")
                    {
                        model.TeacherID = int.Parse(row["TeacherID"].ToString());
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
                if (row.Table.Columns.Contains("CourseID"))
                {
                    if (row["CourseID"] != null && row["CourseID"].ToString() != "")
                    {
                        model.CourseID = int.Parse(row["CourseID"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("CourseName"))
                {
                    if (row["CourseName"] != null)
                    {
                        model.CourseName = row["CourseName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("SectionNO"))
                {
                    if (row["SectionNO"] != null && row["SectionNO"].ToString() != "")
                    {
                        model.SectionNO = int.Parse(row["SectionNO"].ToString());
                    }
                }
                #endregion
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ConfirmedID,StudentID,DayOfWeek,LessonNO,ClassRoomID,StoreID,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
            strSql.Append(" FROM Course_ConfirmedStudent ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ConfirmedID,StudentID,DayOfWeek,LessonNO,ClassRoomID,StoreID,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
            strSql.Append(" FROM Course_ConfirmedStudent ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Course_ConfirmedStudent ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ConfirmedID desc");
            }
            strSql.Append(")AS Row, T.*  from Course_ConfirmedStudent T ");
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
            parameters[0].Value = "Course_ConfirmedStudent";
            parameters[1].Value = "ConfirmedID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public bool DeleteMultiple(string IDs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Course_ConfirmedStudent ");
            strSql.Append(" where ConfirmedID in (" + IDs + ")");
            if (SqlServerHelper.ExecuteSql(strSql.ToString()) >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDetailList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM V_Course_ConfirmedStudentDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取增加数据SQL
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAddSql(XF.Model.Course_SelectionStudent model)
        {
            StringBuilder strSql = new StringBuilder();
            //新增固定选课学员记录
            if (model.SelectionType == 1 && model.CourseDate != null)
            {
                strSql.Append("insert into Course_ConfirmedStudent(");
                strSql.Append("StudentID,DayOfWeek,LessonNO,ClassRoomID,StoreID,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser)");
                strSql.Append(" values (");
                strSql.Append(model.StudentID);
                strSql.Append(",");
                strSql.Append("(datepart(weekday,'" + ((DateTime)model.CourseDate).ToShortDateString() + "') + 5)%7");
                strSql.Append(",");
                strSql.Append(model.LessonNO);
                strSql.Append(",");
                strSql.Append(model.ClassroomID);
                strSql.Append(",");
                strSql.Append(model.StoreID);
                strSql.Append(",'");
                strSql.Append(model.CreateDate);
                strSql.Append("','");
                strSql.Append(model.CreateUser);
                strSql.Append("','");
                strSql.Append(model.LastUpdateDate);
                strSql.Append("','");
                strSql.Append(model.LastUpdateUser);
                strSql.Append("');");
            }
            return strSql.ToString();
        }
        #endregion  ExtensionMethod
    }
}

