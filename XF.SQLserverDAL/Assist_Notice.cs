using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XF.IDAL;
using XF.DBUtility;//Please add references
namespace XF.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Assist_Notice
	/// </summary>
	public partial class Assist_Notice:IAssist_Notice
	{
		public Assist_Notice()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return SqlServerHelper.GetMaxID("NoticeID", "Assist_Notice"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int NoticeID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Assist_Notice");
			strSql.Append(" where NoticeID=@NoticeID");
			SqlParameter[] parameters = {
					new SqlParameter("@NoticeID", SqlDbType.Int,4)
			};
			parameters[0].Value = NoticeID;

			return SqlServerHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(XF.Model.Assist_Notice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Assist_Notice(");
			strSql.Append("ObjectName,ContentMsg,AttachMsg,Status,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable)");
			strSql.Append(" values (");
			strSql.Append("@ObjectName,@ContentMsg,@AttachMsg,@Status,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser,@Enable)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ObjectName", SqlDbType.NVarChar,31),
					new SqlParameter("@ContentMsg", SqlDbType.NVarChar,500),
					new SqlParameter("@AttachMsg", SqlDbType.NVarChar,255),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@Enable", SqlDbType.Bit,1)};
			parameters[0].Value = model.ObjectName;
			parameters[1].Value = model.ContentMsg;
			parameters[2].Value = model.AttachMsg;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.CreateDate;
			parameters[5].Value = model.CreateUser;
			parameters[6].Value = model.LastUpdateDate;
			parameters[7].Value = model.LastUpdateUser;
			parameters[8].Value = model.Enable;

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
		public bool Update(XF.Model.Assist_Notice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Assist_Notice set ");
			strSql.Append("ObjectName=@ObjectName,");
			strSql.Append("ContentMsg=@ContentMsg,");
			strSql.Append("AttachMsg=@AttachMsg,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("CreateUser=@CreateUser,");
			strSql.Append("LastUpdateDate=@LastUpdateDate,");
			strSql.Append("LastUpdateUser=@LastUpdateUser,");
			strSql.Append("Enable=@Enable");
			strSql.Append(" where NoticeID=@NoticeID");
			SqlParameter[] parameters = {
					new SqlParameter("@ObjectName", SqlDbType.NVarChar,31),
					new SqlParameter("@ContentMsg", SqlDbType.NVarChar,500),
					new SqlParameter("@AttachMsg", SqlDbType.NVarChar,255),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@CreateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@Enable", SqlDbType.Bit,1),
					new SqlParameter("@NoticeID", SqlDbType.Int,4)};
			parameters[0].Value = model.ObjectName;
			parameters[1].Value = model.ContentMsg;
			parameters[2].Value = model.AttachMsg;
			parameters[3].Value = model.Status;
			parameters[4].Value = model.CreateDate;
			parameters[5].Value = model.CreateUser;
			parameters[6].Value = model.LastUpdateDate;
			parameters[7].Value = model.LastUpdateUser;
			parameters[8].Value = model.Enable;
			parameters[9].Value = model.NoticeID;

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
		public bool Delete(int NoticeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Assist_Notice ");
			strSql.Append(" where NoticeID=@NoticeID");
			SqlParameter[] parameters = {
					new SqlParameter("@NoticeID", SqlDbType.Int,4)
			};
			parameters[0].Value = NoticeID;

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
		public bool DeleteList(string NoticeIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Assist_Notice ");
			strSql.Append(" where NoticeID in ("+NoticeIDlist + ")  ");
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
		public XF.Model.Assist_Notice GetModel(int NoticeID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 NoticeID,ObjectName,ContentMsg,AttachMsg,Status,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable from Assist_Notice ");
			strSql.Append(" where NoticeID=@NoticeID");
			SqlParameter[] parameters = {
					new SqlParameter("@NoticeID", SqlDbType.Int,4)
			};
			parameters[0].Value = NoticeID;

			XF.Model.Assist_Notice model=new XF.Model.Assist_Notice();
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
		public XF.Model.Assist_Notice DataRowToModel(DataRow row)
		{
			XF.Model.Assist_Notice model=new XF.Model.Assist_Notice();
			if (row != null)
			{
				if(row["NoticeID"]!=null && row["NoticeID"].ToString()!="")
				{
					model.NoticeID=int.Parse(row["NoticeID"].ToString());
				}
				if(row["ObjectName"]!=null)
				{
					model.ObjectName=row["ObjectName"].ToString();
				}
				if(row["ContentMsg"]!=null)
				{
					model.ContentMsg=row["ContentMsg"].ToString();
				}
				if(row["AttachMsg"]!=null)
				{
					model.AttachMsg=row["AttachMsg"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
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
			strSql.Append("select NoticeID,ObjectName,ContentMsg,AttachMsg,Status,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM Assist_Notice ");
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
			strSql.Append(" NoticeID,ObjectName,ContentMsg,AttachMsg,Status,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Enable ");
			strSql.Append(" FROM Assist_Notice ");
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
			strSql.Append("select count(1) FROM Assist_Notice ");
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
				strSql.Append("order by T.NoticeID desc");
			}
			strSql.Append(")AS Row, T.*  from Assist_Notice T ");
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
			parameters[0].Value = "Assist_Notice";
			parameters[1].Value = "NoticeID";
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
        /// 处理消息
        /// </summary>
        public bool ConductNotice(int noticeId,int status,string loginName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Assist_Notice set ");
            strSql.Append("Status=@Status,");
            strSql.Append("LastUpdateDate=@LastUpdateDate,");
            strSql.Append("LastUpdateUser=@LastUpdateUser ");
            strSql.Append(" where NoticeID=@NoticeID");
            SqlParameter[] parameters = {
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
					new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,127),
					new SqlParameter("@NoticeID", SqlDbType.Int,4)};
            parameters[0].Value = status;
            parameters[1].Value = DateTime.Now;
            parameters[2].Value = loginName;
            parameters[3].Value = noticeId;

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
        /// 获取新增Sql
        /// </summary>
        public string GetAddSql(XF.Model.Assist_Notice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Assist_Notice(");
            strSql.Append("ObjectName,ContentMsg,AttachMsg,Status,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser)");
            strSql.Append(" values ('");
            strSql.Append(model.ObjectName);
            strSql.Append("','");
            strSql.Append(model.ContentMsg);
            strSql.Append("','");
            strSql.Append(model.AttachMsg);
            strSql.Append("',");
            strSql.Append(model.Status);
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
		#endregion  ExtensionMethod
	}
}

