using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XF.IDAL;
using XF.DBUtility;
using XF.Common;
using Enums;//Please add references
namespace XF.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Course_SelectionStudent
	/// </summary>
	public partial class Course_SelectionStudent:ICourse_SelectionStudent
	{
		public Course_SelectionStudent()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return SqlServerHelper.GetMaxID("SelectionStudentID", "Course_SelectionStudent"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SelectionStudentID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Course_SelectionStudent");
			strSql.Append(" where SelectionStudentID=@SelectionStudentID");
			SqlParameter[] parameters = {
					new SqlParameter("@SelectionStudentID", SqlDbType.Int,4)
			};
			parameters[0].Value = SelectionStudentID;

			return SqlServerHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(XF.Model.Course_SelectionStudent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Course_SelectionStudent(");
			strSql.Append("SelectionID,StudentID,SelectionType,SignType,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable)");
			strSql.Append(" values (");
			strSql.Append("@SelectionID,@StudentID,@SelectionType,@SignType,@Description,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser,@Enable)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SelectionID", SqlDbType.Int,4),
					new SqlParameter("@StudentID", SqlDbType.Int,4),
					new SqlParameter("@SelectionType", SqlDbType.Int,4),
					new SqlParameter("@SignType", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@Enable", SqlDbType.Bit,1)};
			parameters[0].Value = model.SelectionID;
			parameters[1].Value = model.StudentID;
			parameters[2].Value = model.SelectionType;
			parameters[3].Value = model.SignType;
			parameters[4].Value = model.Description;
			parameters[5].Value = model.CreateDate;
			parameters[6].Value = model.CreateUser;
			parameters[7].Value = model.LastUpdateDate;
			parameters[8].Value = model.LastUpdateUser;
			parameters[9].Value = model.Enable;

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
		public bool Update(XF.Model.Course_SelectionStudent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Course_SelectionStudent set ");
			strSql.Append("SelectionID=@SelectionID,");
			strSql.Append("StudentID=@StudentID,");
			strSql.Append("SelectionType=@SelectionType,");
			strSql.Append("SignType=@SignType,");
			strSql.Append("Description=@Description,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("CreateUser=@CreateUser,");
			strSql.Append("LastUpdateDate=@LastUpdateDate,");
			strSql.Append("LastUpdateUser=@LastUpdateUser,");
			strSql.Append("Enable=@Enable");
			strSql.Append(" where SelectionStudentID=@SelectionStudentID");
			SqlParameter[] parameters = {
					new SqlParameter("@SelectionID", SqlDbType.Int,4),
					new SqlParameter("@StudentID", SqlDbType.Int,4),
					new SqlParameter("@SelectionType", SqlDbType.Int,4),
					new SqlParameter("@SignType", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@Enable", SqlDbType.Bit,1),
					new SqlParameter("@SelectionStudentID", SqlDbType.Int,4)};
			parameters[0].Value = model.SelectionID;
			parameters[1].Value = model.StudentID;
			parameters[2].Value = model.SelectionType;
			parameters[3].Value = model.SignType;
			parameters[4].Value = model.Description;
			parameters[5].Value = model.CreateDate;
			parameters[6].Value = model.CreateUser;
			parameters[7].Value = model.LastUpdateDate;
			parameters[8].Value = model.LastUpdateUser;
			parameters[9].Value = model.Enable;
			parameters[10].Value = model.SelectionStudentID;

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
		public bool Delete(int SelectionStudentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Course_SelectionStudent ");
			strSql.Append(" where SelectionStudentID=@SelectionStudentID");
			SqlParameter[] parameters = {
					new SqlParameter("@SelectionStudentID", SqlDbType.Int,4)
			};
			parameters[0].Value = SelectionStudentID;

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
		public bool DeleteList(string SelectionStudentIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Course_SelectionStudent ");
			strSql.Append(" where SelectionStudentID in ("+SelectionStudentIDlist + ")  ");
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
		public XF.Model.Course_SelectionStudent GetModel(int SelectionStudentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SelectionStudentID,SelectionID,StudentID,SelectionType,SignType,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable from Course_SelectionStudent ");
			strSql.Append(" where SelectionStudentID=@SelectionStudentID");
			SqlParameter[] parameters = {
					new SqlParameter("@SelectionStudentID", SqlDbType.Int,4)
			};
			parameters[0].Value = SelectionStudentID;

			XF.Model.Course_SelectionStudent model=new XF.Model.Course_SelectionStudent();
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
		public XF.Model.Course_SelectionStudent DataRowToModel(DataRow row)
		{
			XF.Model.Course_SelectionStudent model=new XF.Model.Course_SelectionStudent();
			if (row != null)
			{
				if(row["SelectionStudentID"]!=null && row["SelectionStudentID"].ToString()!="")
				{
					model.SelectionStudentID=int.Parse(row["SelectionStudentID"].ToString());
				}
				if(row["SelectionID"]!=null && row["SelectionID"].ToString()!="")
				{
					model.SelectionID=int.Parse(row["SelectionID"].ToString());
				}
				if(row["StudentID"]!=null && row["StudentID"].ToString()!="")
				{
					model.StudentID=int.Parse(row["StudentID"].ToString());
				}
				if(row["SelectionType"]!=null && row["SelectionType"].ToString()!="")
				{
					model.SelectionType=int.Parse(row["SelectionType"].ToString());
				}
				if(row["SignType"]!=null && row["SignType"].ToString()!="")
				{
					model.SignType=int.Parse(row["SignType"].ToString());
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
                if (row["Evaluation"] != null)
                {
                    model.Evaluation = row["Evaluation"].ToString();
                }
                if (row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
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
                if (row.Table.Columns.Contains("StudentCode"))
                {
                    if (row["StudentCode"] != null)
                    {
                        model.StudentCode = row["StudentCode"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("NickName"))
                {
                    if (row["NickName"] != null)
                    {
                        model.NickName = row["NickName"].ToString();
                    }
                }
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
                if (row.Table.Columns.Contains("OpenId"))
                {
                    if (row["OpenId"] != null)
                    {
                        model.OpenId = row["OpenId"].ToString();
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
                if (row.Table.Columns.Contains("StoreID"))
                {
                    if (row["StoreID"] != null && row["StoreID"].ToString() != "")
                    {
                        model.StoreID = int.Parse(row["StoreID"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("ClassRoomID"))
                {
                    if (row["ClassRoomID"] != null && row["ClassRoomID"].ToString() != "")
                    {
                        model.ClassroomID = int.Parse(row["ClassRoomID"].ToString());
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
                if (row.Table.Columns.Contains("LessonNO"))
                {
                    if (row["LessonNO"] != null && row["LessonNO"].ToString() != "")
                    {
                        model.LessonNO = int.Parse(row["LessonNO"].ToString());
                    }
                }
                if (row.Table.Columns.Contains("CourseDate"))
                {
                    if (row["CourseDate"] != null && row["CourseDate"].ToString() != "")
                    {
                        model.CourseDate = DateTime.Parse(row["CourseDate"].ToString());
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
			strSql.Append("select SelectionStudentID,SelectionID,StudentID,SelectionType,SignType,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM Course_SelectionStudent ");
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
			strSql.Append(" SelectionStudentID,SelectionID,StudentID,SelectionType,SignType,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM Course_SelectionStudent ");
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
			strSql.Append("select count(1) FROM Course_SelectionStudent ");
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
				strSql.Append("order by T.SelectionStudentID desc");
			}
			strSql.Append(")AS Row, T.*  from Course_SelectionStudent T ");
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
			parameters[0].Value = "Course_SelectionStudent";
			parameters[1].Value = "SelectionStudentID";
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
        /// 获得选课学员数据列表
        /// </summary>
        public DataSet GetStudentDetailList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM V_Course_SelectionStudentDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得选课客户数据列表
        /// </summary>
        public DataSet GetCustomerDetailList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM V_Course_SelectionCustomerDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得选课数据列表
        /// </summary>
        public DataSet GetDetailList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM V_Course_SelectionCustomerDetail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取删除选课SQL
        /// </summary>
        /// <param name="selectionID"></param>
        /// <returns></returns>
        public string GetDeleteSql(int selectionID,int courseID,DateTime courseDate)
        {
            StringBuilder strSql = new StringBuilder();
            if (courseID == zDataConverter.ToInt(ConfigSetting.TryOutCourseID))
            {
                //删除学员选课记录
                strSql.Append("delete from Course_SelectionStudent where SelectionID = "+ selectionID + ";");
                //关闭课程
                strSql.Append("delete from Course_Selection where SelectionID = " + selectionID + ";");
            }
            else
            {
                //返还家长剩余课时
                strSql.Append("update Base_Family set CourseCount = A.CourseCount + B.ConsumeCount from Base_Family A,");
                strSql.Append("(select FamilyID,COUNT(1) as ConsumeCount from V_Course_SelectionStudentDetail where SignType = 4 and StudentID in (select StudentID from Course_SelectionStudent where SelectionID = " + selectionID + ") and CourseDate >= '" + courseDate.ToString(MessageText.FORMAT_DATE) + "'");
                strSql.Append(" group by FamilyID) B where A.FamilyID = B.FamilyID;");
                //删除固定选课学员记录
                strSql.Append("delete from Course_ConfirmedStudent where convert(nvarchar(32),StudentID)+'|'+convert(nvarchar(1),DayOfWeek)+'|'+convert(nvarchar(2),LessonNO)+'|'+convert(nvarchar(2) ,ClassRoomID) in (select convert(nvarchar(32),StudentID)+'|'+convert(nvarchar(1),(datepart(weekday,CourseDate) + 5)%7)+'|'+convert(nvarchar(2),LessonNO)+'|'+convert(nvarchar(2) ,ClassRoomID) from V_Course_SelectionStudentDetail  where SelectionID = " + selectionID + ");");
                //删除学员当前和后续选课记录
                strSql.Append("delete from Course_SelectionStudent where SelectionStudentID in (");
                strSql.Append("select SelectionStudentID from V_Course_SelectionStudentDetail ");
                strSql.Append("where CourseDate >= '" + courseDate.ToString(MessageText.FORMAT_DATE) + "' ");
                strSql.Append("and StudentID in (select StudentID from Course_SelectionStudent where SelectionID = " + selectionID + "));");
            }
            
            return strSql.ToString();
        }

        /// <summary>
        /// 获取增加数据SQL
        /// </summary>
        public string GetAddSql(XF.Model.Course_SelectionStudent model)
        {
            StringBuilder strSql = new StringBuilder();
            //新增学员选课记录
            strSql.Append("insert into Course_SelectionStudent(");
            strSql.Append("SelectionID,StudentID,SelectionType,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser)");
            strSql.Append(" values (");
            strSql.Append("(select top 1 SelectionID from Course_Selection where CONVERT(varchar(100), CourseDate, 112) = '" + model.CourseDate.Value.ToString("yyyyMMdd") + "' and StoreID = " + model.StoreID + " and ClassRoomID = " + model.ClassroomID + " and LessonNO = " + model.LessonNO + " )");
            strSql.Append(",");
            strSql.Append(model.StudentID);
            strSql.Append(",");
            strSql.Append(model.SelectionType);
            strSql.Append(",'");
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
        /// 获取更新签到数据SQL
        /// </summary>
        public string GetUpdateSignTypeSql(int selectionStudentID,int signTypeOld, int signType,int courseID,int sectionNO,int teacherID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Course_SelectionStudent set ");
            strSql.Append("SignType = ");
            strSql.Append(signType);
            strSql.Append(" where SelectionStudentID = ");
            strSql.Append(selectionStudentID);
            strSql.Append(";");
            //首次签到且未请假时扣除课时
            if(signTypeOld == 0&& signType <4)
            {
                strSql.Append("update Base_Family set CourseCount = CourseCount - 1 ");
                strSql.Append(" where FamilyID = (select top 1 FamilyID from V_Course_SelectionStudentDetail where SelectionStudentID = " + selectionStudentID + ");");
            }
            //首次签到且请假时不扣除课时
            else if(signType ==0&& signType ==4)
            {
                
            }
            //非首次签到时，签到类型由正常改为请假时还原课时
            else if (signTypeOld < 4 && signType == 4)
            {
                strSql.Append("update Base_Family set CourseCount = CourseCount + 1 ");
                strSql.Append(" where FamilyID = (select top 1 FamilyID from V_Course_SelectionStudentDetail where SelectionStudentID = " + selectionStudentID + ");");
            }
            //非首次签到时，签到类型由请假改为正常时扣除课时
            else if (signTypeOld ==4 && signType <4)
            {
                strSql.Append("update Base_Family set CourseCount = CourseCount - 1 ");
                strSql.Append(" where FamilyID = (select top 1 FamilyID from V_Course_SelectionStudentDetail where SelectionStudentID = " + selectionStudentID + ");");
            }
            if (signType < 4)
            {
                strSql.Append("update Base_StudentInfo set ");
                strSql.Append(" CourseID = " + courseID);
                strSql.Append(",Progress = " + sectionNO);
                strSql.Append(",TeacherID = " + teacherID);
                strSql.Append(" where StudentID = (select top 1 StudentID from Course_SelectionStudent where SelectionStudentID = -1);");
            }
            return strSql.ToString();
        }

        /// <summary>
        /// 获取更新评价数据SQL
        /// </summary>
        public string GetUpdateEvaluateSql(XF.Model.Course_SelectionStudent selectionStudent)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Course_SelectionStudent set ");
            strSql.Append("Evaluation = '");
            strSql.Append(selectionStudent.Evaluation);
            strSql.Append("' where SelectionStudentID = ");
            strSql.Append(selectionStudent.SelectionStudentID);
            strSql.Append(";");
            strSql.Append("delete from Course_Evaluate where SelectionStudentId = ");
            strSql.Append(selectionStudent.SelectionStudentID);
            strSql.Append(";");
            foreach(XF.Model.Course_Evaluate evaluate in selectionStudent.Evaluates)
            {
                strSql.Append("insert into Course_Evaluate(SelectionStudentId, Item, Score, MaxScore) values(");
                strSql.Append(selectionStudent.SelectionStudentID);
                strSql.Append(",'");
                strSql.Append(evaluate.Item);
                strSql.Append("',");
                strSql.Append(evaluate.Score);
                strSql.Append(",");
                strSql.Append(evaluate.MaxScore);
                strSql.Append("); ");
            }
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
            string tbName = " V_Course_SelectionStudentDetail ";
            string tbGetFields = " V_Course_SelectionStudentDetail.* ";
            return SqlServerHelper.GetPageList(tbName, tbGetFields, strOrder, pageSize, pageIndex, strWhere, ref count);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XF.Model.Course_SelectionStudent GetDetailModel(int SelectionStudentID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from V_Course_SelectionStudentDetail ");
            strSql.Append(" where SelectionStudentID=@SelectionStudentID");
            SqlParameter[] parameters = {
					new SqlParameter("@SelectionStudentID", SqlDbType.Int,4)
			};
            parameters[0].Value = SelectionStudentID;

            XF.Model.Course_SelectionStudent model = new XF.Model.Course_SelectionStudent();
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
        public XF.Model.Course_SelectionStudent GetDetailModel(DateTime CourseDate, int StoreID, int ClassRoomID, int LessonNO,int StudentID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from V_Course_SelectionStudentDetail ");
            strSql.Append(" where CourseDate=@CourseDate");
            strSql.Append(" and LessonNO=@LessonNO");
            strSql.Append(" and ClassRoomID=@ClassRoomID");
            strSql.Append(" and StoreID=@StoreID");
            strSql.Append(" and StudentID=@StudentID");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseDate", SqlDbType.DateTime),
                    new SqlParameter("@LessonNO", SqlDbType.Int,4),
                    new SqlParameter("@ClassRoomID", SqlDbType.Int,4),
                    new SqlParameter("@StoreID", SqlDbType.Int,4),
                    new SqlParameter("@StudentID", SqlDbType.Int,4)
            };

            parameters[0].Value = CourseDate;
            parameters[1].Value = LessonNO;
            parameters[2].Value = ClassRoomID;
            parameters[3].Value = StoreID;
            parameters[4].Value = StudentID;
            XF.Model.Course_SelectionStudent model = new XF.Model.Course_SelectionStudent();
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
		#endregion  ExtensionMethod
	}
}

