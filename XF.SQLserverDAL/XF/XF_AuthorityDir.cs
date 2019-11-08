using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using XF.DBUtility;
using XF.IDAL;

namespace XF.SQLServerDAL
{
    /// <summary>
    /// 权限管理数据访问类
    /// </summary>
    public class XF_AuthorityDir : IXF_AuthorityDir
    {
        public XF_AuthorityDir()
        { }

        #region BaseMethod
        /// <summary>
        /// 判断权限标识否存在
        /// </summary>
        /// <param name="AuthorityTag">权限标识</param>
        /// <returns></returns>
        public bool Exists(string AuthorityTag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XF_AuthorityDir");
            strSql.Append(" where AuthorityTag=@AuthorityTag ");
            SqlParameter[] parameters = {
					new SqlParameter("@AuthorityTag", SqlDbType.NVarChar,50)};
            parameters[0].Value = AuthorityTag;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一个权限
        /// </summary>
        /// <param name="model">权限实体类</param>
        /// <returns></returns>
        public int CreateAuthority(XF.Model.XF_AuthorityDir model)
        {
            int ret = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into XF_AuthorityDir(");
            strSql.Append("AuthorityName,AuthorityTag,AuthorityDescription,AuthorityOrder,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser)");
            strSql.Append(" values (");
            strSql.Append("@AuthorityName,@AuthorityTag,@AuthorityDescription,@AuthorityOrder,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AuthorityName", SqlDbType.NVarChar,30),
					new SqlParameter("@AuthorityTag", SqlDbType.NVarChar,50),
					new SqlParameter("@AuthorityDescription", SqlDbType.NVarChar,50),
                    new SqlParameter("@AuthorityOrder", SqlDbType.Int,4),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@CreateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128)};
            parameters[0].Value = model.AuthorityName;
            parameters[1].Value = model.AuthorityTag;
            parameters[2].Value = model.AuthorityDescription;
            parameters[3].Value = model.AuthorityOrder;
            parameters[4].Value = model.CreateDate;
            parameters[5].Value = model.CreateUser;
            parameters[6].Value = model.LastUpdateDate;
            parameters[7].Value = model.LastUpdateUser;

            object obj = SqlServerHelper.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                ret = int.Parse(obj.ToString());
            }
            return ret;
        }

        /// <summary>
        /// 更新指定的权限
        /// </summary>
        /// <param name="model">权限实体类</param>
        /// <returns></returns>
        public bool UpdateAuthority(XF.Model.XF_AuthorityDir model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update XF_AuthorityDir set ");
            strSql.Append("AuthorityName=@AuthorityName,");
            strSql.Append("AuthorityTag=@AuthorityTag,");
            strSql.Append("AuthorityDescription=@AuthorityDescription,");
            strSql.Append("AuthorityOrder=@AuthorityOrder,");
            strSql.Append("LastUpdateDate=@LastUpdateDate,");
            strSql.Append("LastUpdateUser=@LastUpdateUser,");
            strSql.Append("Enable=@Enable ");
            strSql.Append(" where AuthorityID=@AuthorityID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AuthorityID", SqlDbType.Int,4),
					new SqlParameter("@AuthorityName", SqlDbType.NVarChar,30),
					new SqlParameter("@AuthorityTag", SqlDbType.NVarChar,50),
					new SqlParameter("@AuthorityDescription", SqlDbType.NVarChar,50),
					new SqlParameter("@AuthorityOrder", SqlDbType.Int,4),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@Enable",SqlDbType.Bit)};
            parameters[0].Value = model.AuthorityID;
            parameters[1].Value = model.AuthorityName;
            parameters[2].Value = model.AuthorityTag;
            parameters[3].Value = model.AuthorityDescription;
            parameters[4].Value = model.AuthorityOrder;
            parameters[5].Value = model.LastUpdateDate;
            parameters[6].Value = model.LastUpdateUser;
            parameters[7].Value = model.Enable;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 删除一个权限
        /// </summary>
        /// <param name="AuthorityID">权限ID</param>
        /// <returns></returns>
        public bool DeleteAuthority(int AuthorityID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete XF_AuthorityDir ");
            strSql.Append(" where AuthorityID=@AuthorityID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AuthorityID", SqlDbType.Int,4)};
            parameters[0].Value = AuthorityID;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 得到一个权限实体
        /// </summary>
        /// <param name="AuthorityID">权限ID</param>
        /// <returns></returns>
        public XF.Model.XF_AuthorityDir GetAuthorityModel(int AuthorityID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from XF_AuthorityDir ");
            strSql.Append(" where AuthorityID=@AuthorityID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AuthorityID", SqlDbType.Int,4)};
            parameters[0].Value = AuthorityID;

            XF.Model.XF_AuthorityDir model = new XF.Model.XF_AuthorityDir();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AuthorityID"].ToString() != "")
                {
                    model.AuthorityID = int.Parse(ds.Tables[0].Rows[0]["AuthorityID"].ToString());
                }
                model.AuthorityName = ds.Tables[0].Rows[0]["AuthorityName"].ToString();
                model.AuthorityTag = ds.Tables[0].Rows[0]["AuthorityTag"].ToString();
                model.AuthorityDescription = ds.Tables[0].Rows[0]["AuthorityDescription"].ToString();
                if (ds.Tables[0].Rows[0]["AuthorityOrder"].ToString() != "")
                {
                    model.AuthorityOrder = int.Parse(ds.Tables[0].Rows[0]["AuthorityOrder"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                model.CreateUser = ds.Tables[0].Rows[0]["CreateUser"].ToString();
                if (ds.Tables[0].Rows[0]["LastUpdateDate"].ToString() != "")
                {
                    model.CreateDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["LastUpdateDate"].ToString());
                }
                model.LastUpdateUser = ds.Tables[0].Rows[0]["LastUpdateUser"].ToString();
                if (ds.Tables[0].Rows[0]["Enable"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Enable"].ToString() == "1") || (ds.Tables[0].Rows[0]["Enable"].ToString().ToLower() == "true"))
                    {
                        model.Enable = true;
                    }
                    else
                    {
                        model.Enable = false;
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得权限数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetAuthorityList(string strWhere, string strOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM XF_AuthorityDir ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            if (strOrder.Trim() != "")
            {
                strSql.Append(" " + strOrder);
            }

            return SqlServerHelper.Query(strSql.ToString());
        }
        #endregion

        #region ExtendMethod
        public DataTable GetAuthorityListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count)
        {
            string tbName = " XF_AuthorityDir ";
            string tbGetFields = " XF_AuthorityDir.* ";
            return SqlServerHelper.GetPageList(tbName, tbGetFields, strOrder, pageSize, pageIndex, strWhere, ref count);
        }
        /// <summary>
        /// 删除配置项
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool DeleteAuthority(string Tags)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete XF_AuthorityDir ");
            strSql.Append(" where AuthorityTag in (" + Tags + ")");
            if (SqlServerHelper.ExecuteSql(strSql.ToString()) >= 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 权限是否在使用
        /// </summary>
        /// <param name="Tags"></param>
        /// <returns></returns>
        public DataTable IsUsedAuthority(string Tags)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AuthorityTag,COUNT(1) as Count from XF_ModuleAuthorityList where AuthorityTag in (")
            .Append(Tags)
            .Append(") group by AuthorityTag");

            return SqlServerHelper.Query(strSql.ToString()).Tables[0];
        }
        #endregion
    }
}

