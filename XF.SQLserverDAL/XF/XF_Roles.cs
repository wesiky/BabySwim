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
    /// ��ɫ�������ݷ�����
    /// </summary>
    public class XF_Roles : IXF_Roles
    {
        public XF_Roles()
        { }

        #region ��ɫ����
        #region BaseMethod
        /// <summary>
        /// �жϽ�ɫ�Ƿ����
        /// </summary>
        /// <param name="RoleName">��ɫ����</param>
        /// <param name="RoleGroupID">��ɫ����ID</param>
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
        /// ���ӽ�ɫ
        /// </summary>
        /// <param name="model">��ɫʵ����</param>
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
        /// ���½�ɫ
        /// </summary>
        /// <param name="model">��ɫʵ����</param>
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
        /// ɾ����ɫ
        /// </summary>
        /// <param name="RoleID">��ɫID</param>
        /// <returns></returns>
        public int DeleteRole(int RoleID)
        {
            int ret = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = RoleID;


            string strSql1 = "Select userid from XF_Users where RoleID=@RoleID";

            //ɾ����ɫ��ͬʱɾ����ص�Ȩ��
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
        /// ��ȡ��ɫʵ��
        /// </summary>
        /// <param name="RoleID">��ɫID</param>
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
        /// ��ý�ɫ�����б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <param name="strOrder">��������</param>
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
                    //ɾ����ɫ��ͬʱɾ����ص�Ȩ��
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

        #region ��Ȩ


        

        #region �û���Ȩ

        /// <summary>
        /// �жϼ�¼�Ƿ����
        /// </summary>
        public bool RoleAuthorityExists(XF.Model.XF_RoleAuthorityList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XF_RoleAuthorityList where ");
            if (model.UserID != 0)//�ж��ǽ�ɫȨ�޻����û�Ȩ��
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
        /// �ж��û�Ȩ���Ƿ����
        /// </summary>
        /// <param name="UserID">UID</param>
        /// <param name="ModuleID">�˵�ID</param>
        /// <param name="AuthorityTag">���ޱ�ʶ</param>
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
        /// �޸��û��˵�Ȩ��
        /// </summary>
        public bool UpdateUserAuthority(ArrayList list,string loginName)
        {
            ArrayList AuthorityList = new ArrayList();

            for (int i = 0; i < list.Count; i++)
            {
                string[] val = list[i].ToString().Split('|');

                switch (val[3])
                {
                    case "0"://��������Ȩ��
                        //�жϼ�¼�Ƿ����
                        if (UserAuthorityExists(int.Parse(val[0]), int.Parse(val[1]), val[2]))
                        {
                            //���������Ȩ��Flag=flase(��ֹ)
                            AuthorityList.Add("update XF_RoleAuthorityList set Flag=0,LastUpdateDate='" + DateTime.Now.ToString() + "',LastUpdateUser='" + loginName + "' where UserID=" + val[0] + " and ModuleID=" + val[1] + " and AuthorityTag='" + val[2] + "'");
                        }
                        else
                        {
                            //���������������һ��
                            AuthorityList.Add("insert into XF_RoleAuthorityList(UserID,ModuleID,AuthorityTag,Flag,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser) values (" + val[0] + "," + val[1] + ",'" + val[2] + "',0,'" + DateTime.Now.ToString() + "','" + loginName + "','" + DateTime.Now.ToString() + "','" + loginName + "')");
                        }
                        break;
                    case "1"://�����ֹȨ��
                        if (UserAuthorityExists(int.Parse(val[0]), int.Parse(val[1]), val[2]))
                        {
                            //���������Ȩ��Flag=True(����)
                            AuthorityList.Add("update XF_RoleAuthorityList set Flag=1,LastUpdateDate='" + DateTime.Now.ToString() + "',LastUpdateUser='" + loginName + "' where UserID=" + val[0] + " and ModuleID=" + val[1] + " and AuthorityTag='" + val[2] + "'");
                        }
                        else
                        {
                            //���������������һ��
                            AuthorityList.Add("insert into XF_RoleAuthorityList(UserID,ModuleID,AuthorityTag,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser) values (" + val[0] + "," + val[1] + ",'" + val[2] + "','" + DateTime.Now.ToString() + "','" + loginName + "','" + DateTime.Now.ToString() + "','" + loginName + "')");
                        }
                        break;
                    case "2"://ɾ��Ȩ��
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
        /// ��ȡ�û��Ĳ˵�Ȩ��
        /// </summary>
        public DataSet GetUserAuthorityList(int UserID, int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM XF_RoleAuthorityList where UserID=" + UserID.ToString() + " and ModuleID=" + ModuleID.ToString());

            return SqlServerHelper.Query(strSql.ToString());
        }
        #endregion

        #region ��ɫ��Ȩ
        /// <summary>
        /// �޸Ľ�ɫ�˵�Ȩ��
        /// </summary>
        public bool UpdateRoleAuthority(ArrayList list,string loginName)
        {
            ArrayList AuthorityList = new ArrayList();

            for (int i = 0; i < list.Count; i++)
            {
                string[] val = list[i].ToString().Split('|');
                if (val[3] == "0")//���Ϊ0��ɾ��Ȩ��
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
        /// ��ȡ��ɫ�Ĳ˵�Ȩ��
        /// </summary>
        public DataSet GetRoleAuthorityList(int RoleID, int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM XF_RoleAuthorityList where RoleID=" + RoleID.ToString() + " and ModuleID=" + ModuleID.ToString());

            return SqlServerHelper.Query(strSql.ToString());
        }
        #endregion

        #region ������Ȩ
        /// <summary>
        /// �޸��û��˵�Ȩ��
        /// </summary>
        public bool UpdateGroupAuthority(ArrayList list,string loginName)
        {
            ArrayList AuthorityList = new ArrayList();

            for (int i = 0; i < list.Count; i++)
            {
                string[] val = list[i].ToString().Split('|');
                if (val[3] == "0")//���Ϊ0��ɾ��Ȩ��
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
        /// ��ȡ�û��Ĳ˵�Ȩ��
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

