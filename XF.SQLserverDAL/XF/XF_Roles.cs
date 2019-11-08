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
    /// 角色管理数据访问类
    /// </summary>
    public class XF_Roles : IXF_Roles
    {
        public XF_Roles()
        { }

        #region 角色管理
        #region BaseMethod
        /// <summary>
        /// 判断角色是否存在
        /// </summary>
        /// <param name="RoleName">角色名称</param>
        /// <param name="RoleGroupID">角色分组ID</param>
        /// <returns></returns>
        public bool RoleExists(string RoleName, int RoleGroupID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XF_Roles");
            strSql.Append(" where RoleName=@RoleName and RoleGroupID=@RoleGroupID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.NVarChar,30),
                    new SqlParameter("@RoleGroupID", SqlDbType.Int,4)};
            parameters[0].Value = RoleName;
            parameters[1].Value = RoleGroupID;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加角色
        /// </summary>
        /// <param name="model">角色实体类</param>
        /// <returns></returns>
        public int CreateRole(XF.Model.XF_Roles model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into XF_Roles(");
            strSql.Append("RoleGroupID,RoleName,RoleDescription,RoleOrder,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser)");
            strSql.Append(" values (");
            strSql.Append("@RoleGroupID,@RoleName,@RoleDescription,@RoleOrder,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser)");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleGroupID", SqlDbType.Int,4),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,30),
					new SqlParameter("@RoleDescription", SqlDbType.NVarChar,50),
                    new SqlParameter("@RoleOrder", SqlDbType.Int,4),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@CreateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128)};
            parameters[0].Value = model.RoleGroupID;
            parameters[1].Value = model.RoleName;
            parameters[2].Value = model.RoleDescription;
            parameters[3].Value = model.RoleOrder;
            parameters[4].Value = model.CreateDate;
            parameters[5].Value = model.CreateUser;
            parameters[6].Value = model.LastUpdateDate;
            parameters[7].Value = model.LastUpdateUser;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1)

                return 1;
            else
                return 0;

        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="model">角色实体类</param>
        /// <returns></returns>
        public bool UpdateRole(XF.Model.XF_Roles model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update XF_Roles set ");
            strSql.Append("RoleGroupID=@RoleGroupID,");
            strSql.Append("RoleName=@RoleName,");
            strSql.Append("RoleDescription=@RoleDescription,");
            strSql.Append("RoleOrder=@RoleOrder,");
            strSql.Append("LastUpdateDate=@LastUpdateDate,");
            strSql.Append("LastUpdateUser=@LastUpdateUser,");
            strSql.Append("Enable=@Enable ");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4),
					new SqlParameter("@RoleGroupID", SqlDbType.Int,4),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,30),
					new SqlParameter("@RoleDescription", SqlDbType.NVarChar,50),
                    new SqlParameter("@RoleOrder", SqlDbType.Int,4),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@Enable",SqlDbType.Bit)};
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.RoleGroupID;
            parameters[2].Value = model.RoleName;
            parameters[3].Value = model.RoleDescription;
            parameters[4].Value = model.RoleOrder;
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
        /// 删除角色
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public int DeleteRole(int RoleID)
        {
            int ret = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = RoleID;


            string strSql1 = "Select userid from XF_Users where RoleID=@RoleID";

            //删除角色的同时删除相关的权限
            ArrayList list = new ArrayList();
            list.Add("delete XF_RoleAuthorityList where RoleID=" + RoleID.ToString());
            list.Add("delete XF_Roles where RoleID=" + RoleID.ToString());

            if (!SqlServerHelper.Exists(strSql1, parameters))
            {
                try
                {
                    SqlServerHelper.ExecuteSqlTran(list);
                    ret = 1;
                }
                catch
                {
                    ret = 0;
                }
            }
            else
            {
                ret = 2;
            }
            return ret;
        }

        /// <summary>
        /// 获取角色实体
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public XF.Model.XF_Roles GetRoleModel(int RoleID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from XF_Roles ");
            strSql.Append(" where RoleID=@RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = RoleID;

            XF.Model.XF_Roles model = new XF.Model.XF_Roles();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RoleRoleID"].ToString() != "")
                {
                    model.RoleGroupID = int.Parse(ds.Tables[0].Rows[0]["RoleGroupID"].ToString());
                }
                model.RoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();
                model.RoleDescription = ds.Tables[0].Rows[0]["RoleDescription"].ToString();

                if (ds.Tables[0].Rows[0]["RoleOrder"].ToString() != "")
                {
                    model.RoleOrder = int.Parse(ds.Tables[0].Rows[0]["RoleOrder"].ToString());
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
        /// 获得角色数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <returns></returns>
        public DataSet GetRoleList(string strWhere, string strOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM XF_Roles ");

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
        public DataTable GetRoleListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count)
        {
            string tbName = " XF_Roles ";
            string tbGetFields = " XF_Roles.* ";
            return SqlServerHelper.GetPageList(tbName, tbGetFields, strOrder, pageSize, pageIndex, strWhere, ref count);
        }
        public int DeleteRoles(string IDs)
        {
            int ret = 0;

            string strSql1 = "Select userid from XF_UserRoles where RoleID in (" + IDs + ")";


            if (!SqlServerHelper.Exists(strSql1))
            {
                try
                {
                    //删除角色的同时删除相关的权限
                    ArrayList list = new ArrayList();
                    list.Add("delete XF_RoleAuthorityList where RoleID in (" + IDs + ")");
                    list.Add("delete XF_Roles where RoleID in (" + IDs + ")");
                    SqlServerHelper.ExecuteSqlTran(list);
                    ret = 1;
                }
                catch
                {
                    ret = 0;
                }
            }
            else
            {
                ret = 2;
            }
            return ret;
        }

        #endregion
        #endregion

        #region 授权


        

        #region 用户授权

        /// <summary>
        /// 判断记录是否存在
        /// </summary>
        public bool RoleAuthorityExists(XF.Model.XF_RoleAuthorityList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XF_RoleAuthorityList where ");
            if (model.UserID != 0)//判断是角色权限还是用户权限
            { strSql.Append("UserID=@UserID"); }
            else if (model.RoleID != 0)
            { strSql.Append("RoleID=@RoleID"); }
            else
            { strSql.Append("GroupID=@GroupID"); }
            strSql.Append(" and ModuleID=@ModuleID and AuthorityTag=@AuthorityTag");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@RoleID", SqlDbType.Int,4),
                    new SqlParameter("@GroupID", SqlDbType.Int,4),
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@AuthorityTag", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.RoleID;
            parameters[2].Value = model.GroupID;
            parameters[3].Value = model.ModuleID;
            parameters[4].Value = model.AuthorityTag;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 判断用户权限是否存在
        /// </summary>
        /// <param name="UserID">UID</param>
        /// <param name="ModuleID">菜单ID</param>
        /// <param name="AuthorityTag">标限标识</param>
        /// <returns></returns>
        public bool UserAuthorityExists(int UserID, int ModuleID, string AuthorityTag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XF_RoleAuthorityList");
            strSql.Append(" where UserID=@UserID and ModuleID=@ModuleID and AuthorityTag=@AuthorityTag");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@ModuleID", SqlDbType.Int,4),
                    new SqlParameter("@AuthorityTag", SqlDbType.NVarChar,50)};
            parameters[0].Value = UserID;
            parameters[1].Value = ModuleID;
            parameters[2].Value = AuthorityTag;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 修改用户菜单权限
        /// </summary>
        public bool UpdateUserAuthority(ArrayList list,string loginName)
        {
            ArrayList AuthorityList = new ArrayList();

            for (int i = 0; i < list.Count; i++)
            {
                string[] val = list[i].ToString().Split('|');

                switch (val[3])
                {
                    case "0"://加入允许权限
                        //判断记录是否存在
                        if (UserAuthorityExists(int.Parse(val[0]), int.Parse(val[1]), val[2]))
                        {
                            //存在则更新权限Flag=flase(禁止)
                            AuthorityList.Add("update XF_RoleAuthorityList set Flag=0,LastUpdateDate='" + DateTime.Now.ToString() + "',LastUpdateUser='" + loginName + "' where UserID=" + val[0] + " and ModuleID=" + val[1] + " and AuthorityTag='" + val[2] + "'");
                        }
                        else
                        {
                            //如果不存在则新增一条
                            AuthorityList.Add("insert into XF_RoleAuthorityList(UserID,ModuleID,AuthorityTag,Flag,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser) values (" + val[0] + "," + val[1] + ",'" + val[2] + "',0,'" + DateTime.Now.ToString() + "','" + loginName + "','" + DateTime.Now.ToString() + "','" + loginName + "')");
                        }
                        break;
                    case "1"://加入禁止权限
                        if (UserAuthorityExists(int.Parse(val[0]), int.Parse(val[1]), val[2]))
                        {
                            //存在则更新权限Flag=True(允许)
                            AuthorityList.Add("update XF_RoleAuthorityList set Flag=1,LastUpdateDate='" + DateTime.Now.ToString() + "',LastUpdateUser='" + loginName + "' where UserID=" + val[0] + " and ModuleID=" + val[1] + " and AuthorityTag='" + val[2] + "'");
                        }
                        else
                        {
                            //如果不存在则新增一条
                            AuthorityList.Add("insert into XF_RoleAuthorityList(UserID,ModuleID,AuthorityTag,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser) values (" + val[0] + "," + val[1] + ",'" + val[2] + "','" + DateTime.Now.ToString() + "','" + loginName + "','" + DateTime.Now.ToString() + "','" + loginName + "')");
                        }
                        break;
                    case "2"://删除权限
                        if (UserAuthorityExists(int.Parse(val[0]), int.Parse(val[1]), val[2]))
                            AuthorityList.Add("delete XF_RoleAuthorityList where UserID=" + val[0] + " and ModuleID=" + val[1] + " and AuthorityTag='" + val[2] + "'");
                        break;
                }
            }

            try
            {
                SqlServerHelper.ExecuteSqlTran(AuthorityList);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 读取用户的菜单权限
        /// </summary>
        public DataSet GetUserAuthorityList(int UserID, int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM XF_RoleAuthorityList where UserID=" + UserID.ToString() + " and ModuleID=" + ModuleID.ToString());

            return SqlServerHelper.Query(strSql.ToString());
        }
        #endregion

        #region 角色授权
        /// <summary>
        /// 修改角色菜单权限
        /// </summary>
        public bool UpdateRoleAuthority(ArrayList list,string loginName)
        {
            ArrayList AuthorityList = new ArrayList();

            for (int i = 0; i < list.Count; i++)
            {
                string[] val = list[i].ToString().Split('|');
                if (val[3] == "0")//如果为0就删除权限
                {
                    AuthorityList.Add("delete XF_RoleAuthorityList where RoleID=" + val[0] + " and ModuleID=" + val[1] + " and AuthorityTag='" + val[2] + "'");
                }
                else
                {
                    AuthorityList.Add("insert into XF_RoleAuthorityList(RoleID,ModuleID,AuthorityTag,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser) values (" + val[0] + "," + val[1] + ",'" + val[2] + "','" + DateTime.Now.ToString() + "','" + loginName + "','" + DateTime.Now.ToString() + "','" + loginName + "')");
                }
            }

            try
            {
                SqlServerHelper.ExecuteSqlTran(AuthorityList);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 读取角色的菜单权限
        /// </summary>
        public DataSet GetRoleAuthorityList(int RoleID, int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM XF_RoleAuthorityList where RoleID=" + RoleID.ToString() + " and ModuleID=" + ModuleID.ToString());

            return SqlServerHelper.Query(strSql.ToString());
        }
        #endregion

        #region 分组授权
        /// <summary>
        /// 修改用户菜单权限
        /// </summary>
        public bool UpdateGroupAuthority(ArrayList list,string loginName)
        {
            ArrayList AuthorityList = new ArrayList();

            for (int i = 0; i < list.Count; i++)
            {
                string[] val = list[i].ToString().Split('|');
                if (val[3] == "0")//如果为0就删除权限
                {
                    AuthorityList.Add("delete XF_RoleAuthorityList where GroupID=" + val[0] + " and ModuleID=" + val[1] + " and AuthorityTag='" + val[2] + "'");
                }
                else
                {
                    AuthorityList.Add("insert into XF_RoleAuthorityList(GroupID,ModuleID,AuthorityTag,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser) values (" + val[0] + "," + val[1] + ",'" + val[2] + "','" + DateTime.Now.ToString() + "','" + loginName + "','" + DateTime.Now.ToString() + "','" + loginName + "')");
                }
            }

            try
            {
                SqlServerHelper.ExecuteSqlTran(AuthorityList);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 读取用户的菜单权限
        /// </summary>
        public DataSet GetGroupAuthorityList(int GroupID, int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM XF_RoleAuthorityList where GroupID=" + GroupID.ToString() + " and ModuleID=" + ModuleID.ToString());

            return SqlServerHelper.Query(strSql.ToString());
        }
        #endregion

        #endregion

    }
}

