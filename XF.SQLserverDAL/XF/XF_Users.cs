using System;
using System.Data;
using System.Collections;
using System.Text;
using System.Data.SqlClient;

using XF.DBUtility;
using XF.IDAL;

namespace XF.SQLServerDAL
{
    /// <summary>
    /// 数据访问类XF_Users。
    /// </summary>
    public class XF_Users : IXF_Users
    {
        public XF_Users()
        { }

        #region 用户操作
        #region BaseMethod
        /// <summary>
        /// 用户是否存在该
        /// </summary>
        public bool UserExists(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XF_Users");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,128)};
            parameters[0].Value = UserName;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 创建一个新用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CreateUser(XF.Model.XF_Users model)
        {
            int ret = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into XF_Users(");
            strSql.Append("UserName,Password,Email,UserGroup,LastLoginTime,IsLimit,Status,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,RealName)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Password,@Email,@UserGroup,@LastLoginTime,@IsLimit,@Status,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser,@RealName)");
            strSql.Append(";select @@IDENTITY;");
            strSql.Append("insert into XF_Users_Extend(");
            strSql.Append("UserID,Phone,WarehouseID,LGORT,MRP)");
            strSql.Append(" values (");
            strSql.Append("@@IDENTITY,@Phone,@WarehouseID,@LGORT,@MRP)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,128),
					new SqlParameter("@Password", SqlDbType.NVarChar,128),
                    new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@UserGroup", SqlDbType.Int,4),
                    new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@IsLimit", SqlDbType.Bit,1),
                    new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@CreateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@RealName",SqlDbType.NVarChar,10),
                    new SqlParameter("@Phone",SqlDbType.NVarChar,11),
                    new SqlParameter("@WarehouseID",SqlDbType.Int,4),
                    new SqlParameter("@LGORT",SqlDbType.NVarChar,10),
                    new SqlParameter("@MRP",SqlDbType.NVarChar,10)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.UserGroup;
            parameters[4].Value = model.CreateDate;
            parameters[5].Value = model.IsLimit;
            parameters[6].Value = model.Status;
            parameters[7].Value = model.CreateDate;
            parameters[8].Value = model.CreateUser;
            parameters[9].Value = model.LastUpdateDate;
            parameters[10].Value = model.LastUpdateUser;
            parameters[11].Value = model.RealName;
            parameters[12].Value = model.Phone;
            parameters[13].Value = model.WarehouseID;
            parameters[14].Value = model.LGORT;
            parameters[15].Value = model.MRP;

            object obj = SqlServerHelper.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                ret = int.Parse(obj.ToString());
            }

            return ret;
        }

        /// <summary>
        /// 更新用户基本信息
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public int UpdateUser(XF.Model.XF_Users model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update XF_Users set UserName=@UserName,UserGroup=@UserGroup,Email=@Email,Status=@Status,LastUpdateDate=@LastUpdateDate,LastUpdateUser=@LastUpdateUser,Enable=@Enable,RealName=@RealName where UserID=@UserID;");
            strSql.Append("update XF_Users_Extend set Phone=@Phone,WarehouseID=@WarehouseID,LGORT=@LGORT,MRP=@MRP where UserID=@UserID;").AppendLine();
            strSql.Append("iF @@ROWCOUNT = 0").AppendLine();
            strSql.Append("BEGIN").AppendLine();
            strSql.Append("insert into XF_Users_Extend(UserID, WarehouseID, Phone, LGORT, MRP) values(@UserID, @WarehouseID, @Phone, @LGORT, @MRP)").AppendLine();
            strSql.Append("END;");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@UserName", SqlDbType.NVarChar,128),
                    new SqlParameter("@UserGroup", SqlDbType.Int,4),
                    new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@Enable",SqlDbType.Bit),
                    new SqlParameter("@RealName",SqlDbType.NVarChar,10),
                    new SqlParameter("@Phone",SqlDbType.NVarChar,11),
                    new SqlParameter("@WarehouseID",SqlDbType.Int,4),
                    new SqlParameter("@LGORT",SqlDbType.NVarChar,10),
                    new SqlParameter("@MRP",SqlDbType.NVarChar,10)};
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserGroup;
            parameters[3].Value = model.Email;
            parameters[4].Value = model.Status;
            parameters[5].Value = model.LastUpdateDate;
            parameters[6].Value = model.LastUpdateUser;
            parameters[7].Value = model.Enable;
            parameters[8].Value = model.RealName;
            parameters[9].Value = model.Phone;
            parameters[10].Value = model.WarehouseID;
            parameters[11].Value = model.LGORT;
            parameters[12].Value = model.MRP;

            return SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);

        }

        /// <summary>
        /// 用户登录检测
        /// </summary>
        public bool CheckLogin(string UserName, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XF_Users");
            strSql.Append(" where UserName=@UserName and Password=@Password");
            SqlParameter[] parameters = {
                     new SqlParameter("@UserName", SqlDbType.NVarChar,128),
					 new SqlParameter("@Password", SqlDbType.NVarChar,128)};
            parameters[0].Value = UserName;
            parameters[1].Value = pwd;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新用户登录时间
        /// </summary>
        /// <param name="id"></param>
        public void UpdateLoginTime(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update XF_Users set LastLoginTime=@LastLoginTime where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime)};
            parameters[0].Value = id;
            parameters[1].Value = DateTime.Now;

            SqlServerHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 判断用户原密码是否正确
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="pwd">原密码</param>
        /// <returns></returns>
        public bool VerifyPassword(int id, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XF_Users");
            strSql.Append(" where UserID=@UserID and Password=@Password");
            SqlParameter[] parameters = {
                     new SqlParameter("@UserID", SqlDbType.Int,4),
					 new SqlParameter("@Password", SqlDbType.NVarChar,128)};
            parameters[0].Value = id;
            parameters[1].Value = pwd;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更改用户密码
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="pwd">新密码</param>
        /// <returns></returns>
        public bool ChangePassword(int id, string pwd)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update XF_Users set ");
            strSql.Append("Password=@Password");
            strSql.Append(" where UserID=@UserID");

            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Password", SqlDbType.NVarChar,128)};
            parameters[0].Value = id;
            parameters[1].Value = pwd;

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
        /// 更新安全信息
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="question">问题</param>
        /// <param name="answer">答案</param>
        /// <returns></returns>
        public bool ChangeSecureInfo(int id, string question, string answer)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update XF_Users set ");
            strSql.Append("Question=@Question,Answer=@Answer");
            strSql.Append(" where UserID=@UserID");

            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Question", SqlDbType.NVarChar,100),
					new SqlParameter("@Answer", SqlDbType.NVarChar,100)};
            parameters[0].Value = id;
            parameters[1].Value = question;
            parameters[2].Value = answer;

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
        /// 删除用户
        /// </summary>
        /// <param name="UserID">用户ID</param>
        public bool DeleteUser(int UserID)
        {

            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            ArrayList SQLList = new ArrayList();

            try
            {
                SQLList.Add("delete XF_RoleAuthorityList where UserID=" + parameters[0].Value);
                SQLList.Add("delete XF_UserRoles where UserID=" + parameters[0].Value);
                SQLList.Add("delete XF_Users_Extend where UserID=" + parameters[0].Value);
                SQLList.Add("delete XF_Users where UserID=" + parameters[0].Value);
                SqlServerHelper.ExecuteSqlTran(SQLList);
                return true;//删除成功
            }
            catch
            {
                return false;//删除失败
            }

        }

        /// <summary>
        /// 根据ID得到用户对象实体
        /// </summary>
        public XF.Model.XF_Users GetUserModel(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from V_Users ");
            strSql.Append(" where UserID=@UserID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;

            XF.Model.XF_Users model = new XF.Model.XF_Users();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Question = ds.Tables[0].Rows[0]["Question"].ToString();
                model.Answer = ds.Tables[0].Rows[0]["Answer"].ToString();

                if (ds.Tables[0].Rows[0]["UserGroup"].ToString() != "")
                {
                    model.UserGroup = int.Parse(ds.Tables[0].Rows[0]["UserGroup"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOnline"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsOnline"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsOnline"].ToString().ToLower() == "true"))
                    {
                        model.IsOnline = true;
                    }
                    else
                    {
                        model.IsOnline = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsLimit"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsLimit"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsLimit"].ToString().ToLower() == "true"))
                    {
                        model.IsLimit = true;
                    }
                    else
                    {
                        model.IsLimit = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                model.CreateUser = ds.Tables[0].Rows[0]["CreateUser"].ToString();
                if (ds.Tables[0].Rows[0]["LastUpdateDate"].ToString() != "")
                {
                    model.LastUpdateDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["LastUpdateDate"].ToString());
                }
                model.LastUpdateUser = ds.Tables[0].Rows[0]["LastUpdateUser"].ToString();

                //读取角色
                model.RoleID = GetUserRoleArray(model.UserID);
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

                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                if (ds.Tables[0].Rows[0]["WarehouseID"].ToString() != "")
                {
                    model.WarehouseID = int.Parse(ds.Tables[0].Rows[0]["WarehouseID"].ToString());
                }
                model.LGORT = ds.Tables[0].Rows[0]["LGORT"].ToString();
                model.MRP = ds.Tables[0].Rows[0]["MRP"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户名得到用户对象实体
        /// </summary>
        public XF.Model.XF_Users GetUserModel(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from V_Users ");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,128)};
            parameters[0].Value = UserName;

            XF.Model.XF_Users model = new XF.Model.XF_Users();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Question = ds.Tables[0].Rows[0]["Question"].ToString();
                model.Answer = ds.Tables[0].Rows[0]["Answer"].ToString();

                if (ds.Tables[0].Rows[0]["UserGroup"].ToString() != "")
                {
                    model.UserGroup = int.Parse(ds.Tables[0].Rows[0]["UserGroup"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOnline"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsOnline"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsOnline"].ToString().ToLower() == "true"))
                    {
                        model.IsOnline = true;
                    }
                    else
                    {
                        model.IsOnline = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsLimit"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsLimit"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsLimit"].ToString().ToLower() == "true"))
                    {
                        model.IsLimit = true;
                    }
                    else
                    {
                        model.IsLimit = false;
                    }
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
                //读取角色
                model.RoleID = GetUserRoleArray(model.UserID);
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
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString(); 
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                if (ds.Tables[0].Rows[0]["WarehouseID"].ToString() != "")
                {
                    model.WarehouseID = int.Parse(ds.Tables[0].Rows[0]["WarehouseID"].ToString());
                }
                model.LGORT = ds.Tables[0].Rows[0]["LGORT"].ToString();
                model.MRP = ds.Tables[0].Rows[0]["MRP"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据真实姓名得到用户对象实体
        /// </summary>
        public XF.Model.XF_Users GetUserModelByRealName(string RealName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from V_Users ");
            strSql.Append(" where RealName=@RealName ");
            SqlParameter[] parameters = {
					new SqlParameter("@RealName", SqlDbType.NVarChar,10)};
            parameters[0].Value = RealName;

            XF.Model.XF_Users model = new XF.Model.XF_Users();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Question = ds.Tables[0].Rows[0]["Question"].ToString();
                model.Answer = ds.Tables[0].Rows[0]["Answer"].ToString();

                if (ds.Tables[0].Rows[0]["UserGroup"].ToString() != "")
                {
                    model.UserGroup = int.Parse(ds.Tables[0].Rows[0]["UserGroup"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastLoginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsOnline"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsOnline"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsOnline"].ToString().ToLower() == "true"))
                    {
                        model.IsOnline = true;
                    }
                    else
                    {
                        model.IsOnline = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IsLimit"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsLimit"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsLimit"].ToString().ToLower() == "true"))
                    {
                        model.IsLimit = true;
                    }
                    else
                    {
                        model.IsLimit = false;
                    }
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
                //读取角色
                model.RoleID = GetUserRoleArray(model.UserID);
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
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                if (ds.Tables[0].Rows[0]["WarehouseID"].ToString() != "")
                {
                    model.WarehouseID = int.Parse(ds.Tables[0].Rows[0]["WarehouseID"].ToString());
                }
                model.LGORT = ds.Tables[0].Rows[0]["LGORT"].ToString();
                model.MRP = ds.Tables[0].Rows[0]["MRP"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetUserList(string strWhere, string strOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT V_Users.*, XF_UserGroup.UG_Name ");
            strSql.Append("FROM V_Users INNER JOIN ");
            strSql.Append("XF_UserGroup ON V_Users.UserGroup = XF_UserGroup.UG_ID ");

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

        /// <summary>
        /// 读取角色名称
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public object GetRoleName(int roleid)
        {
            return SqlServerHelper.GetSingle("select RoleName from XF_Roles where RoleID=" + roleid);
        }


        #endregion
        #region ExtendMethod
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="strOrder"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public DataTable GetUserListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count)
        {
            string tbName = " V_Users INNER JOIN XF_Groups ON V_Users.UserGroup = XF_Groups.GroupID ";
            string tbGetFields = " V_Users.*, XF_Groups.GroupName ";
            return SqlServerHelper.GetPageList(tbName, tbGetFields, strOrder,pageSize,pageIndex,strWhere,ref count);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="IDs">用户ID集合</param>
        public bool DeleteUsers(string IDs)
        {
            ArrayList SQLList = new ArrayList();

            try
            {
                SQLList.Add("delete XF_RoleAuthorityList where UserID in (" + IDs + ")");
                SQLList.Add("delete XF_UserRoles where UserID in (" + IDs + ")");
                SQLList.Add("delete XF_Users_Extend where UserID in (" + IDs + ")");
                SQLList.Add("delete XF_Users where UserID in (" + IDs + ")");
                SqlServerHelper.ExecuteSqlTran(SQLList);
                return true;//删除成功
            }
            catch
            {
                return false;//删除失败
            }

        }
        #endregion
        #endregion

        #region 角色操作

        /// <summary>
        /// 添加一用户角色
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public bool addUserRole(int UserID, int RoleID,string LoginName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into XF_UserRoles(");
            strSql.Append("UserID,RoleID,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser)");
            strSql.Append(" values (");
            strSql.Append("@UserID,@RoleID,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@RoleID", SqlDbType.Int,4),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@CreateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128)};
            parameters[0].Value = UserID;
            parameters[1].Value = RoleID;
            parameters[2].Value = DateTime.Now;
            parameters[3].Value = LoginName;
            parameters[4].Value = DateTime.Now;
            parameters[5].Value = LoginName;

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
        /// 批量添加用户角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool addUserRole(ArrayList list,string loginName)
        {
            ArrayList SQLList = new ArrayList();

            for (int i = 0; i < list.Count; i++)
            {
                string[] val = list[i].ToString().Split('|');
                SQLList.Add("insert into XF_UserRoles(UserID,RoleID,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser) values (" + val[0] + "," + val[1] + ",'" + DateTime.Now.ToString() +"','" + loginName + "','" + DateTime.Now.ToString() + "','" + loginName +"')");
            }

            try
            {
                SqlServerHelper.ExecuteSqlTran(SQLList);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一用户角色
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public bool DeleteUserRole(int UserID, int RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete XF_UserRoles where UserID=@UserID and RoleID=@RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = UserID;
            parameters[0].Value = RoleID;

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
        /// 批量删除用户角色
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteUserRole(ArrayList list)
        {
            ArrayList SQLList = new ArrayList();

            for (int i = 0; i < list.Count; i++)
            {
                string[] val = list[i].ToString().Split('|');
                SQLList.Add("delete XF_UserRoles where UserID=" + val[0] + " and RoleID=" + val[1]);
            }

            try
            {
                SqlServerHelper.ExecuteSqlTran(SQLList);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 读取用户角色列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public DataSet GetUserRole(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT XF_UserRoles.*, XF_Roles.RoleName ");
            strSql.Append("FROM XF_UserRoles INNER JOIN ");
            strSql.Append("XF_Roles ON XF_UserRoles.RoleID = XF_Roles.RoleID ");
            return SqlServerHelper.Query(strSql.ToString() + "where UserID=" + UserID.ToString());
        }

        /// <summary>
        /// 读取用户角色列表
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public ArrayList GetUserRoleArray(int UserID)
        {
            ArrayList ret = new ArrayList();
            DataSet rds = GetUserRole(UserID);
            if (rds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < rds.Tables[0].Rows.Count; i++)
                {
                    ret.Add(rds.Tables[0].Rows[i]["RoleID"].ToString() + "," + rds.Tables[0].Rows[i]["RoleName"].ToString());
                }
            }
            return ret;
        }

        #endregion
    }
}

