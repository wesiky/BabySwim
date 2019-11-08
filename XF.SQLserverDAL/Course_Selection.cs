using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XF.IDAL;
using XF.DBUtility;
using XF.Common;//Please add references
namespace XF.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Course_Selection
	/// </summary>
	public partial class Course_Selection:ICourse_Selection
	{
		public Course_Selection()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return SqlServerHelper.GetMaxID("SelectionID", "Course_Selection"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SelectionID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Course_Selection");
			strSql.Append(" where SelectionID=@SelectionID");
			SqlParameter[] parameters = {
					new SqlParameter("@SelectionID", SqlDbType.Int,4)
			};
			parameters[0].Value = SelectionID;

			return SqlServerHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(XF.Model.Course_Selection model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Course_Selection(");
			strSql.Append("CourseDate,LessonNO,CourseID,SectionNO,TeacherID,AdviserID,ClassRoomID,StoreID,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable)");
			strSql.Append(" values (");
            strSql.Append("@CourseDate,@LessonNO,@CourseID,@SectionNO,@TeacherID,@AdviserID,@ClassRoomID,@StoreID,@Description,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser,@Enable)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CourseDate", SqlDbType.DateTime),
					new SqlParameter("@LessonNO", SqlDbType.Int,4),
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@SectionNO", SqlDbType.Int,4),
					new SqlParameter("@TeacherID", SqlDbType.Int,4),
					new SqlParameter("@ClassRoomID", SqlDbType.Int,4),
					new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@Enable", SqlDbType.Bit,1),
					new SqlParameter("@AdviserID", SqlDbType.Int,4)};
			parameters[0].Value = model.CourseDate;
			parameters[1].Value = model.LessonNO;
			parameters[2].Value = model.CourseID;
			parameters[3].Value = model.SectionNO;
			parameters[4].Value = model.TeacherID;
			parameters[5].Value = model.ClassRoomID;
			parameters[6].Value = model.StoreID;
			parameters[7].Value = model.Description;
			parameters[8].Value = model.CreateDate;
			parameters[9].Value = model.CreateUser;
			parameters[10].Value = model.LastUpdateDate;
			parameters[11].Value = model.LastUpdateUser;
			parameters[12].Value = model.Enable;
            parameters[13].Value = model.AdviserID;

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
		public bool Update(XF.Model.Course_Selection model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Course_Selection set ");
			strSql.Append("CourseDate=@CourseDate,");
			strSql.Append("LessonNO=@LessonNO,");
			strSql.Append("CourseID=@CourseID,");
			strSql.Append("SectionNO=@SectionNO,");
			strSql.Append("TeacherID=@TeacherID,");
            strSql.Append("AdviserID=@AdviserID,");
			strSql.Append("ClassRoomID=@ClassRoomID,");
			strSql.Append("StoreID=@StoreID,");
			strSql.Append("Description=@Description,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("CreateUser=@CreateUser,");
			strSql.Append("LastUpdateDate=@LastUpdateDate,");
			strSql.Append("LastUpdateUser=@LastUpdateUser,");
			strSql.Append("Enable=@Enable");
			strSql.Append(" where SelectionID=@SelectionID");
			SqlParameter[] parameters = {
					new SqlParameter("@CourseDate", SqlDbType.DateTime),
					new SqlParameter("@LessonNO", SqlDbType.Int,4),
					new SqlParameter("@CourseID", SqlDbType.Int,4),
					new SqlParameter("@SectionNO", SqlDbType.Int,4),
					new SqlParameter("@TeacherID", SqlDbType.Int,4),
					new SqlParameter("@ClassRoomID", SqlDbType.Int,4),
					new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@Enable", SqlDbType.Bit,1),
					new SqlParameter("@SelectionID", SqlDbType.Int,4),
					new SqlParameter("@AdviserID", SqlDbType.Int,4)};
			parameters[0].Value = model.CourseDate;
			parameters[1].Value = model.LessonNO;
			parameters[2].Value = model.CourseID;
			parameters[3].Value = model.SectionNO;
			parameters[4].Value = model.TeacherID;
			parameters[5].Value = model.ClassRoomID;
			parameters[6].Value = model.StoreID;
			parameters[7].Value = model.Description;
			parameters[8].Value = model.CreateDate;
			parameters[9].Value = model.CreateUser;
			parameters[10].Value = model.LastUpdateDate;
			parameters[11].Value = model.LastUpdateUser;
			parameters[12].Value = model.Enable;
			parameters[13].Value = model.SelectionID;
            parameters[14].Value = model.AdviserID;

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
		public bool Delete(int SelectionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Course_Selection ");
			strSql.Append(" where SelectionID=@SelectionID;");
            strSql.Append("delete from Course_SelectionStudent ");
            strSql.Append(" where SelectionID=@SelectionID;");
			SqlParameter[] parameters = {
					new SqlParameter("@SelectionID", SqlDbType.Int,4)
			};
			parameters[0].Value = SelectionID;

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
		public bool DeleteList(string SelectionIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Course_Selection ");
			strSql.Append(" where SelectionID in ("+SelectionIDlist + ")  ");
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
		public XF.Model.Course_Selection GetModel(int SelectionID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SelectionID,CourseDate,LessonNO,CourseID,SectionNO,TeacherID,AdviserID,ClassRoomID,StoreID,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable from Course_Selection ");
			strSql.Append(" where SelectionID=@SelectionID");
			SqlParameter[] parameters = {
					new SqlParameter("@SelectionID", SqlDbType.Int,4)
			};
			parameters[0].Value = SelectionID;

			XF.Model.Course_Selection model=new XF.Model.Course_Selection();
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
		public XF.Model.Course_Selection DataRowToModel(DataRow row)
		{
			XF.Model.Course_Selection model=new XF.Model.Course_Selection();
			if (row != null)
			{
				if(row["SelectionID"]!=null && row["SelectionID"].ToString()!="")
				{
					model.SelectionID=int.Parse(row["SelectionID"].ToString());
				}
				if(row["CourseDate"]!=null && row["CourseDate"].ToString()!="")
				{
					model.CourseDate=DateTime.Parse(row["CourseDate"].ToString());
				}
				if(row["LessonNO"]!=null && row["LessonNO"].ToString()!="")
				{
					model.LessonNO=int.Parse(row["LessonNO"].ToString());
				}
				if(row["CourseID"]!=null && row["CourseID"].ToString()!="")
				{
					model.CourseID=int.Parse(row["CourseID"].ToString());
				}
				if(row["SectionNO"]!=null && row["SectionNO"].ToString()!="")
				{
					model.SectionNO=int.Parse(row["SectionNO"].ToString());
				}
				if(row["TeacherID"]!=null && row["TeacherID"].ToString()!="")
				{
					model.TeacherID=int.Parse(row["TeacherID"].ToString());
				}
                if (row["AdviserID"] != null && row["AdviserID"].ToString() != "")
                {
                    model.AdviserID = int.Parse(row["AdviserID"].ToString());
                }
				if(row["ClassRoomID"]!=null && row["ClassRoomID"].ToString()!="")
				{
					model.ClassRoomID=int.Parse(row["ClassRoomID"].ToString());
				}
				if(row["StoreID"]!=null && row["StoreID"].ToString()!="")
				{
					model.StoreID=int.Parse(row["StoreID"].ToString());
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
                #region 扩展属性
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
                if (row.Table.Columns.Contains("CourseName"))
                {
                    if (row["CourseName"] != null)
                    {
                        model.CourseName = row["CourseName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("Color"))
                {
                    if (row["Color"] != null)
                    {
                        model.Color = row["Color"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("SelectionCount"))
                {
                    if (row["SelectionCount"] != null && row["SelectionCount"].ToString() != "")
                    {
                        model.SelectionCount = int.Parse(row["SelectionCount"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("StudentNames"))
                {
                    if (row["StudentNames"] != null)
                    {
                        model.StudentNames = row["StudentNames"].ToString();
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
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select SelectionID,CourseDate,LessonNO,CourseID,SectionNO,TeacherID,AdviserID,ClassRoomID,StoreID,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM Course_Selection ");
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
            strSql.Append(" SelectionID,CourseDate,LessonNO,CourseID,SectionNO,TeacherID,AdviserID,ClassRoomID,StoreID,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM Course_Selection ");
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
			strSql.Append("select count(1) FROM Course_Selection ");
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
				strSql.Append("order by T.SelectionID desc");
			}
			strSql.Append(")AS Row, T.*  from Course_Selection T ");
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
			parameters[0].Value = "Course_Selection";
			parameters[1].Value = "SelectionID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return SqlServerHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 获得指定日期起一周数据列表
        /// </summary>
        public DataSet GetWeekList(DateTime dt, int StoreID, int ClassRoomID)
        {
            string strWhere = string.Empty;
            strWhere = zDataConverter.AppendSQL(strWhere, " CourseDate Between '" + dt.ToShortDateString() + "' and '" + dt.AddDays(7).ToShortDateString() + "'");
            if (StoreID >= 0)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " StoreID = " + StoreID);
            }
            if (ClassRoomID >= 0)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " ClassRoomID = " + ClassRoomID);
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SelectionID,CourseDate,LessonNO,CourseID,SectionNO,TeacherID,AdviserID,ClassRoomID,StoreID,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
            strSql.Append(" FROM Course_Selection ");
            strSql.Append(" where " + strWhere);
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取选课详细信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetDetailList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM V_Course_SelectionDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得指定日期起一周详细数据列表
        /// </summary>
        public DataSet GetWeekDetailList(DateTime dt, int StoreID, int ClassRoomID)
        {
            string strWhere = string.Empty;
            strWhere = zDataConverter.AppendSQL(strWhere, " CourseDate Between '" + dt.ToShortDateString() + "' and '" + dt.AddDays(7).ToShortDateString() + "'");
            if (StoreID >= 0)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " StoreID = " + StoreID);
            }
            if (ClassRoomID >= 0)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " ClassRoomID = " + ClassRoomID);
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM V_Course_SelectionDetail ");
            if (!strWhere.Equals(string.Empty))
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得指定日期的详细数据列表
        /// </summary>
        public DataSet GetDayDetailList(DateTime dt, int storeID, int classRoomID)
        {
            string strWhere = string.Empty;
            strWhere = zDataConverter.AppendSQL(strWhere, " CourseDate = '" + dt.ToShortDateString() + "'");
            if (storeID >= 0)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " StoreID = " + storeID);
            }
            if (classRoomID >= 0)
            {
                strWhere = zDataConverter.AppendSQL(strWhere, " ClassRoomID = " + classRoomID);
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM V_Course_SelectionDetail ");
            if (!strWhere.Equals(string.Empty))
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XF.Model.Course_Selection GetDetailModel(int SelectionID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from V_Course_SelectionDetail ");
            strSql.Append(" where SelectionID=@SelectionID;");
            SqlParameter[] parameters = {
					new SqlParameter("@SelectionID", SqlDbType.Int,4)
			};
            parameters[0].Value = SelectionID;

            XF.Model.Course_Selection model = new XF.Model.Course_Selection();
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
        public XF.Model.Course_Selection GetDetailModel(DateTime courseDate, int storeID, int classroomID, int lessonNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from V_Course_SelectionDetail ");
            strSql.Append(" where CourseDate=@CourseDate ");
            strSql.Append(" and StoreID=@StoreID");
            strSql.Append(" and ClassRoomID=@ClassRoomID");
            strSql.Append(" and LessonNO=@LessonNO;");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseDate", SqlDbType.DateTime),
                    new SqlParameter("@StoreID", SqlDbType.Int,4),
                    new SqlParameter("@ClassRoomID", SqlDbType.Int,4),
                    new SqlParameter("@LessonNO", SqlDbType.Int,4)
			};
            parameters[0].Value = courseDate;
            parameters[1].Value = storeID;
            parameters[2].Value = classroomID;
            parameters[3].Value = lessonNO;

            XF.Model.Course_Selection model = new XF.Model.Course_Selection();
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
        /// 获取删除SQL
        /// </summary>
        public string GetDeleteSql(int SelectionID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Course_Selection ");
            strSql.Append(" where SelectionID=" + SelectionID + ";");
            return strSql.ToString();
        }

        /// <summary>
        /// 获取增加SQL
        /// </summary>
        public string GetAddSql(XF.Model.Course_Selection model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Course_Selection(");
            strSql.Append("CourseDate,LessonNO,CourseID,SectionNO,TeacherID,AdviserID,ClassRoomID,StoreID,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser)");
            strSql.Append(" values ('");
            strSql.Append(model.CourseDate);
            strSql.Append("',");
            strSql.Append(model.LessonNO);
            strSql.Append(",");
            strSql.Append(model.CourseID); 
            strSql.Append(",");
            strSql.Append(model.SectionNO);
            strSql.Append(",");
            strSql.Append(model.TeacherID);
            strSql.Append(",");
            strSql.Append(model.AdviserID);
            strSql.Append(",");
            strSql.Append(model.ClassRoomID);
            strSql.Append(",");
            strSql.Append(model.StoreID);
            strSql.Append(",'");
            strSql.Append(model.Description);
            strSql.Append("','");
            strSql.Append(model.CreateDate);
            strSql.Append("','");
            strSql.Append(model.CreateUser);
            strSql.Append("','");
            strSql.Append(model.LastUpdateDate);
            strSql.Append("','");
            strSql.Append(model.LastUpdateUser);
            strSql.Append("');");
            return strSql.ToString();
        }
        /// <summary>
        /// 获取更新SQL
        /// </summary>
        public string GetUpdateSql(XF.Model.Course_Selection model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Course_Selection set ");
            strSql.Append("CourseDate='");
            strSql.Append(model.CourseDate);
            strSql.Append("',");
            strSql.Append("LessonNO=");
            strSql.Append(model.LessonNO);
            strSql.Append(",");
            strSql.Append("CourseID=");
            strSql.Append(model.CourseID);
            strSql.Append(",");
            strSql.Append("SectionNO=");
            strSql.Append(model.SectionNO);
            strSql.Append(",");
            strSql.Append("TeacherID=");
            strSql.Append(model.TeacherID);
            strSql.Append(",");
            strSql.Append("AdviserID=");
            strSql.Append(model.AdviserID);
            strSql.Append(",");
            strSql.Append("ClassRoomID=");
            strSql.Append(model.ClassRoomID);
            strSql.Append(",");
            strSql.Append("StoreID=");
            strSql.Append(model.StoreID);
            strSql.Append(",");
            strSql.Append("Description='");
            strSql.Append(model.Description);
            strSql.Append("',");
            strSql.Append("LastUpdateDate='");
            strSql.Append(model.LastUpdateDate);
            strSql.Append("',");
            strSql.Append("LastUpdateUser='");
            strSql.Append(model.LastUpdateUser);
            strSql.Append("' ");
            strSql.Append(" where SelectionID=");
            strSql.Append(model.SelectionID);
            strSql.Append(";");
            return strSql.ToString();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XF.Model.Course_Selection GetModel(DateTime CourseDate, int StoreID, int ClassRoomID, int LessonNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SelectionID,CourseDate,LessonNO,CourseID,SectionNO,TeacherID,AdviserID,ClassRoomID,StoreID,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable from Course_Selection ");
            strSql.Append(" where CourseDate=@CourseDate");
            strSql.Append(" and LessonNO=@LessonNO");
            strSql.Append(" and ClassRoomID=@ClassRoomID");
            strSql.Append(" and StoreID=@StoreID");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseDate", SqlDbType.DateTime),
                    new SqlParameter("@LessonNO", SqlDbType.Int,4),
                    new SqlParameter("@ClassRoomID", SqlDbType.Int,4),
                    new SqlParameter("@StoreID", SqlDbType.Int,4)
			};
            parameters[0].Value = CourseDate;
            parameters[1].Value = LessonNO;
            parameters[2].Value = ClassRoomID;
            parameters[3].Value = StoreID;

            XF.Model.Course_Selection model = new XF.Model.Course_Selection();
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
        /// 关闭空课程
        /// </summary>
        /// <returns></returns>
        public string CloseInvalidCourse()
        {
            string sql = "delete from Course_Selection where SelectionID in (select SelectionID from V_Course_SelectionDetail where SelectionCount = 0);";
            return sql;
        }
		#endregion  ExtensionMethod
	}
}

