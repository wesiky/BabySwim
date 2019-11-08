using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using XF.DBUtility;
using XF.IDAL;

namespace XF.SQLServerDAL
{
    /// <summary>
    /// 分组管理数据访问类
    /// </summary>
    public class XF_Groups : IXF_Groups
    {
        public XF_Groups()
        { }
        #region  成员方法
        #region BaseMethod
        /// <summary>
        /// 判断分组是否存在
        /// </summary>
        /// <param name="GroupName">分组名称</param>
        /// <returns></returns>
        public bool Exists(string GroupName, int GroupType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XF_Groups");
            strSql.Append(" where GroupName=@GroupName and GroupType=@GroupType");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupName", SqlDbType.NVarChar,30),
                    new SqlParameter("@GroupType", SqlDbType.Int,4)};
            parameters[0].Value = GroupName;
            parameters[1].Value = GroupType;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一个分组
        /// </summary>
        /// <param name="model">分组实体类</param>
        /// <returns></returns>
        public int CreateGroup(XF.Model.XF_Groups model)
        {
            int ret = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into XF_Groups(");
            strSql.Append("GroupName,GroupOrder,GroupDescription,GroupType,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser)");
            strSql.Append(" values (");
            strSql.Append("@GroupName,@GroupOrder,@GroupDescription,@GroupType,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupName", SqlDbType.NVarChar,30),
					new SqlParameter("@GroupOrder", SqlDbType.Int,4),
					new SqlParameter("@GroupDescription", SqlDbType.NVarChar),
                    new SqlParameter("@GroupType", SqlDbType.Int,4),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@CreateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128)};
            parameters[0].Value = model.GroupName;
            parameters[1].Value = model.GroupOrder;
            parameters[2].Value = model.GroupDescription;
            parameters[3].Value = model.GroupType;
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
        /// 更新一条数据
        /// </summary>
        /// <param name="model">分组实体类</param>
        /// <returns></returns>
        public bool UpdateGroup(XF.Model.XF_Groups model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update XF_Groups set ");
            strSql.Append("GroupName=@GroupName,");
            strSql.Append("GroupOrder=@GroupOrder,");
            strSql.Append("GroupDescription=@GroupDescription,");
            strSql.Append("LastUpdateDate=@LastUpdateDate,");
            strSql.Append("LastUpdateUser=@LastUpdateUser,");
            strSql.Append("Enable=@Enable ");
            strSql.Append(" where GroupID=@GroupID ");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupID", SqlDbType.Int,4),
					new SqlParameter("@GroupName", SqlDbType.NVarChar,30),
					new SqlParameter("@GroupOrder", SqlDbType.Int,4),
					new SqlParameter("@GroupDescription", SqlDbType.NVarChar),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@Enable",SqlDbType.Bit)};
            parameters[0].Value = model.GroupID;
            parameters[1].Value = model.GroupName;
            parameters[2].Value = model.GroupOrder;
            parameters[3].Value = model.GroupDescription;
            parameters[4].Value = model.LastUpdateDate;
            parameters[5].Value = model.LastUpdateUser;
            parameters[6].Value = model.Enable;

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
        /// 删除一条数据
        /// </summary>
        /// <param name="GroupID">分组ID</param>
        /// <returns></returns>
        public int DeleteGroup(int GroupID)
        {
            int ret = 0;

            string strSql1 = "Select RoleID from XF_Roles where RoleGroupID=@GroupID"; //查看应组下是否存在角色
            string strSql2 = "Select UserID from XF_Users where XF_UserGroup=@GroupID";        //查看应组下是否存在用户

            ArrayList SQLList = new ArrayList();

            SqlParameter[] parameters = {
					new SqlParameter("@GroupID", SqlDbType.Int,4)};
            parameters[0].Value = GroupID;

            if (!SqlServerHelper.Exists(strSql1.ToString(), parameters))
            {
                if (!SqlServerHelper.Exists(strSql2.ToString(), parameters))
                {
                    try
                    {
                        SQLList.Add("delete XF_RoleAuthorityList where GroupID=" + parameters[0].Value);
                        SQLList.Add("delete XF_Groups where GroupID=" + parameters[0].Value);
                        SqlServerHelper.ExecuteSqlTran(SQLList);
                        ret = 1;//删除成功
                    }
                    catch
                    {
                        ret = 0;//删除失败
                    }
                }
                else
                {
                    ret = 2;//有用户，不能删除
                }
            }
            else
            {
                ret = 3;//有角色，不能删除
            }
            return ret;
        }

        /// <summary>
        /// 得到一个分组实体
        /// </summary>
        /// <param name="GroupID">分组ID</param>
        /// <returns></returns>
        public XF.Model.XF_Groups GetGroupModel(int GroupID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from XF_Groups ");
            strSql.Append(" where GroupID=@GroupID ");
            SqlParameter[] parameters = {
					new SqlParameter("@GroupID", SqlDbType.Int,4)};
            parameters[0].Value = GroupID;

            XF.Model.XF_Groups model = new XF.Model.XF_Groups();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["GroupID"].ToString() != "")
                {
                    model.GroupID = int.Parse(ds.Tables[0].Rows[0]["GroupID"].ToString());
                }
                model.GroupName = ds.Tables[0].Rows[0]["GroupName"].ToString();
                if (ds.Tables[0].Rows[0]["GroupOrder"].ToString() != "")
                {
                    model.GroupOrder = int.Parse(ds.Tables[0].Rows[0]["GroupOrder"].ToString());
                }
                model.GroupDescription = ds.Tables[0].Rows[0]["GroupDescription"].ToString();

                if (ds.Tables[0].Rows[0]["GroupType"].ToString() != "")
                {
                    model.GroupType = int.Parse(ds.Tables[0].Rows[0]["GroupType"].ToString());
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

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得分组数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetGroupList(string strWhere, string strOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM XF_Groups ");

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
        public DataTable GetGroupListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count)
        {
            string tbName = " XF_Groups ";
            string tbGetFields = " XF_Groups.* ";
            return SqlServerHelper.GetPageList(tbName, tbGetFields, strOrder, pageSize, pageIndex, strWhere, ref count);
        }
        /// <summary>
        /// 删除配置项
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public int DeleteGroups(string IDs)
        {
            int ret = 0;

            string strSql1 = "Select RoleID from XF_Roles where RoleGroupID in (" + IDs + ")"; //查看应组下是否存在角色
            string strSql2 = "Select UserID from XF_Users where UserGroup in (" + IDs + ")";        //查看应组下是否存在用户

            ArrayList SQLList = new ArrayList();

            if (!SqlServerHelper.Exists(strSql1.ToString(), null))
            {
                if (!SqlServerHelper.Exists(strSql2.ToString(), null))
                {
                    try
                    {
                        SQLList.Add("delete XF_RoleAuthorityList where GroupID in (" + IDs + ")");
                        SQLList.Add("delete XF_Groups where GroupID in (" + IDs + ")");
                        SqlServerHelper.ExecuteSqlTran(SQLList);
                        ret = 1;//删除成功
                    }
                    catch
                    {
                        ret = 0;//删除失败
                    }
                }
                else
                {
                    ret = 2;//有用户，不能删除
                }
            }
            else
            {
                ret = 3;//有角色，不能删除
            }
            return ret;
        }
        #endregion
        #endregion  成员方法


    }
}

