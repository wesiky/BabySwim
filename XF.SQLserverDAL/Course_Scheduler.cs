using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XF.IDAL;
using XF.DBUtility;//Please add references
namespace XF.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Course_Scheduler
	/// </summary>
	public partial class Course_Scheduler:ICourse_Scheduler
	{
		public Course_Scheduler()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return SqlServerHelper.GetMaxID("SchedulerID", "Course_Scheduler"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SchedulerID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Course_Scheduler");
			strSql.Append(" where SchedulerID=@SchedulerID");
			SqlParameter[] parameters = {
					new SqlParameter("@SchedulerID", SqlDbType.Int,4)
			};
			parameters[0].Value = SchedulerID;

			return SqlServerHelper.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int StoreID, int ClassRoomID, int WeekDay, int LessonNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Course_Scheduler");
            strSql.Append(" where StoreID=@StoreID");
            strSql.Append(" and ClassRoomID=@ClassRoomID");
            strSql.Append(" and WeekDay=@WeekDay");
            strSql.Append(" and LessonNO=@LessonNO");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreID", SqlDbType.Int,4),
                    new SqlParameter("@ClassRoomID", SqlDbType.Int,4),
                    new SqlParameter("@WeekDay", SqlDbType.Int,4),
                    new SqlParameter("@LessonNO", SqlDbType.Int,4),
			};
            parameters[0].Value = StoreID;
            parameters[1].Value = ClassRoomID;
            parameters[2].Value = WeekDay;
            parameters[3].Value = LessonNO;
            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(XF.Model.Course_Scheduler model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Course_Scheduler(");
			strSql.Append("StoreID,ClassRoomID,WeekDay,LessonNO,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable)");
			strSql.Append(" values (");
			strSql.Append("@StoreID,@ClassRoomID,@WeekDay,@LessonNO,@Description,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser,@Enable)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@ClassRoomID", SqlDbType.Int,4),
					new SqlParameter("@WeekDay", SqlDbType.Int,4),
					new SqlParameter("@LessonNO", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@Enable", SqlDbType.Bit,1)};
			parameters[0].Value = model.StoreID;
			parameters[1].Value = model.ClassRoomID;
			parameters[2].Value = model.WeekDay;
			parameters[3].Value = model.LessonNO;
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
		public bool Update(XF.Model.Course_Scheduler model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Course_Scheduler set ");
			strSql.Append("StoreID=@StoreID,");
			strSql.Append("ClassRoomID=@ClassRoomID,");
			strSql.Append("WeekDay=@WeekDay,");
			strSql.Append("LessonNO=@LessonNO,");
			strSql.Append("Description=@Description,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("CreateUser=@CreateUser,");
			strSql.Append("LastUpdateDate=@LastUpdateDate,");
			strSql.Append("LastUpdateUser=@LastUpdateUser,");
			strSql.Append("Enable=@Enable");
			strSql.Append(" where SchedulerID=@SchedulerID");
			SqlParameter[] parameters = {
					new SqlParameter("@StoreID", SqlDbType.Int,4),
					new SqlParameter("@ClassRoomID", SqlDbType.Int,4),
					new SqlParameter("@WeekDay", SqlDbType.Int,4),
					new SqlParameter("@LessonNO", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@Enable", SqlDbType.Bit,1),
					new SqlParameter("@SchedulerID", SqlDbType.Int,4)};
			parameters[0].Value = model.StoreID;
			parameters[1].Value = model.ClassRoomID;
			parameters[2].Value = model.WeekDay;
			parameters[3].Value = model.LessonNO;
			parameters[4].Value = model.Description;
			parameters[5].Value = model.CreateDate;
			parameters[6].Value = model.CreateUser;
			parameters[7].Value = model.LastUpdateDate;
			parameters[8].Value = model.LastUpdateUser;
			parameters[9].Value = model.Enable;
			parameters[10].Value = model.SchedulerID;

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
		public bool Delete(int SchedulerID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Course_Scheduler ");
			strSql.Append(" where SchedulerID=@SchedulerID");
			SqlParameter[] parameters = {
					new SqlParameter("@SchedulerID", SqlDbType.Int,4)
			};
			parameters[0].Value = SchedulerID;

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
		public bool DeleteList(string SchedulerIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Course_Scheduler ");
			strSql.Append(" where SchedulerID in ("+SchedulerIDlist + ")  ");
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
		public XF.Model.Course_Scheduler GetModel(int SchedulerID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SchedulerID,StoreID,ClassRoomID,WeekDay,LessonNO,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable from Course_Scheduler ");
			strSql.Append(" where SchedulerID=@SchedulerID");
			SqlParameter[] parameters = {
					new SqlParameter("@SchedulerID", SqlDbType.Int,4)
			};
			parameters[0].Value = SchedulerID;

			XF.Model.Course_Scheduler model=new XF.Model.Course_Scheduler();
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
        public XF.Model.Course_Scheduler GetModel(int StoreID, int ClassRoomID, int WeekDay, int LessonNO)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SchedulerID,StoreID,ClassRoomID,WeekDay,LessonNO,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable from Course_Scheduler ");
            strSql.Append(" where StoreID=@StoreID");
            strSql.Append(" and ClassRoomID=@ClassRoomID");
            strSql.Append(" and WeekDay=@WeekDay");
            strSql.Append(" and LessonNO=@LessonNO");
            SqlParameter[] parameters = {
					new SqlParameter("@StoreID", SqlDbType.Int,4),
                    new SqlParameter("@ClassRoomID", SqlDbType.Int,4),
                    new SqlParameter("@WeekDay", SqlDbType.Int,4),
                    new SqlParameter("@LessonNO", SqlDbType.Int,4)
			};
            parameters[0].Value = StoreID;
            parameters[1].Value = ClassRoomID;
            parameters[2].Value = WeekDay;
            parameters[3].Value = LessonNO;

            XF.Model.Course_Scheduler model = new XF.Model.Course_Scheduler();
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
		public XF.Model.Course_Scheduler DataRowToModel(DataRow row)
		{
			XF.Model.Course_Scheduler model=new XF.Model.Course_Scheduler();
			if (row != null)
			{
				if(row["SchedulerID"]!=null && row["SchedulerID"].ToString()!="")
				{
					model.SchedulerID=int.Parse(row["SchedulerID"].ToString());
				}
				if(row["StoreID"]!=null && row["StoreID"].ToString()!="")
				{
					model.StoreID=int.Parse(row["StoreID"].ToString());
				}
				if(row["ClassRoomID"]!=null && row["ClassRoomID"].ToString()!="")
				{
					model.ClassRoomID=int.Parse(row["ClassRoomID"].ToString());
				}
				if(row["WeekDay"]!=null && row["WeekDay"].ToString()!="")
				{
					model.WeekDay=int.Parse(row["WeekDay"].ToString());
				}
				if(row["LessonNO"]!=null && row["LessonNO"].ToString()!="")
				{
					model.LessonNO=int.Parse(row["LessonNO"].ToString());
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
			strSql.Append("select SchedulerID,StoreID,ClassRoomID,WeekDay,LessonNO,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM Course_Scheduler ");
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
			strSql.Append(" SchedulerID,StoreID,ClassRoomID,WeekDay,LessonNO,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM Course_Scheduler ");
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
			strSql.Append("select count(1) FROM Course_Scheduler ");
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
				strSql.Append("order by T.SchedulerID desc");
			}
			strSql.Append(")AS Row, T.*  from Course_Scheduler T ");
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
			parameters[0].Value = "Course_Scheduler";
			parameters[1].Value = "SchedulerID";
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
        /// 新增SQL语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetAddSql(Model.Course_Scheduler model, string loginName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Course_Scheduler(")
                .Append("StoreID,ClassRoomID,WeekDay,LessonNO,Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser)")
                .Append(" values (")
                .Append(model.StoreID)
                .Append(",")
                .Append(model.ClassRoomID)
                .Append(",")
                .Append(model.WeekDay)
                .Append(",")
               .Append(model.LessonNO)
               .Append(",'")
               .Append(model.Description)
               .Append("','")
               .Append(DateTime.Now)
               .Append("','")
               .Append(loginName)
               .Append("','")
               .Append(DateTime.Now)
               .Append("','")
               .Append(loginName)
               .Append("');");
            return strSql.ToString();
        }

        /// <summary>
        /// 更新SQL语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetUpdateSql(Model.Course_Scheduler model, string loginName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Course_Scheduler set ");
            strSql.Append("StoreID=" + model.StoreID + ",");
            strSql.Append("ClassRoomID=" + model.ClassRoomID + ",");
            strSql.Append("WeekDay=" + model.WeekDay + ",");
            strSql.Append("LessonNO=" + model.LessonNO + ",");
            strSql.Append("Description='" + model.Description + "',");
            strSql.Append("LastUpdateDate='" + DateTime.Now.ToString() + "',");
            strSql.Append("LastUpdateUser='" + loginName + "'");
            strSql.Append(" where SchedulerID=" + model.SchedulerID);
            return strSql.ToString();
        }

        /// <summary>
        /// 删除SQL语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GetDeleteSql(int StoreID, int ClassRoomID)
        {
            StringBuilder strSql = new StringBuilder(); 
            strSql.Append("delete from Course_Scheduler ");
            strSql.Append(" where StoreID=" + StoreID);
            strSql.Append(" and ClassRoomID=" + ClassRoomID);
            return strSql.ToString();
        }
		#endregion  ExtensionMethod
	}
}

