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
    /// ���ܲ˵����ݷ�����
    /// </summary>
    public class XF_Modules : IXF_Modules
    {
        public XF_Modules()
        { }

        #region �˵�����
        #region BaseMethod
        /// <summary>
        /// �жϲ˵������Ƿ����
        /// </summary>
        /// <param name="ModuleTypeName">�˵���������</param>
        /// <returns></returns>
        public bool ModuleTypeExists(string ModuleTypeName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XF_ModuleType");
            strSql.Append(" where ModuleTypeName=@ModuleTypeName ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeName", SqlDbType.NVarChar,30)};
            parameters[0].Value = ModuleTypeName;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ����һ���˵�����
        /// </summary>
        /// <param name="model">�˵�����ʵ����</param>
        /// <returns></returns>
        public int CreateModuleType(XF.Model.XF_ModuleType model)
        {
            int ret = 0;
            if (!ModuleTypeExists(model.ModuleTypeName))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into XF_ModuleType(");
                strSql.Append("ModuleTypeName,ModuleTypeOrder,ModuleTypeSuperiorID,ModuleTypeDepth,ModuleTypeDescription,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Icon)");
                strSql.Append(" values (");
                strSql.Append("@ModuleTypeName,@ModuleTypeOrder,@ModuleTypeSuperiorID,@ModuleTypeDepth,@ModuleTypeDescription,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser,@Icon)");
                SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeName", SqlDbType.NVarChar,30),
					new SqlParameter("@ModuleTypeOrder", SqlDbType.Int,4),
                    new SqlParameter("@ModuleTypeSuperiorID", SqlDbType.Int,4),
                    new SqlParameter("@ModuleTypeDepth", SqlDbType.Int,4),
					new SqlParameter("@ModuleTypeDescription", SqlDbType.NVarChar,50),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@CreateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@Icon", SqlDbType.NVarChar,255)};
                parameters[0].Value = model.ModuleTypeName;
                parameters[1].Value = model.ModuleTypeOrder;
                parameters[2].Value = model.ModuleTypeSuperiorID;
                parameters[3].Value = GetModuleDepth(model.ModuleTypeSuperiorID) + 1;//���¼������
                parameters[4].Value = model.ModuleTypeDescription;
                parameters[5].Value = model.CreateDate;
                parameters[6].Value = model.CreateUser;
                parameters[7].Value = model.LastUpdateDate;
                parameters[8].Value = model.LastUpdateUser;
                parameters[9].Value = model.Icon;

                if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1)
                {
                    ret = 1;
                }
            }
            else
            {
                ret = 2;
            }
            return ret;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model">�˵�����ʵ����</param>
        /// <returns></returns>
        public bool UpdateModuleType(XF.Model.XF_ModuleType model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update XF_ModuleType set ");
            strSql.Append("ModuleTypeName=@ModuleTypeName,");
            strSql.Append("ModuleTypeOrder=@ModuleTypeOrder,");
            strSql.Append("ModuleTypeSuperiorID=@ModuleTypeSuperiorID,");
            strSql.Append("ModuleTypeDepth=@ModuleTypeDepth,");
            strSql.Append("ModuleTypeDescription=@ModuleTypeDescription,");
            strSql.Append("LastUpdateDate=@LastUpdateDate,");
            strSql.Append("LastUpdateUser=@LastUpdateUser,");
            strSql.Append("Icon=@Icon,");
            strSql.Append("Enable=@Enable ");
            strSql.Append(" where ModuleTypeID=@ModuleTypeID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeID", SqlDbType.Int,4),
					new SqlParameter("@ModuleTypeName", SqlDbType.NVarChar,30),
					new SqlParameter("@ModuleTypeOrder", SqlDbType.Int,4),
                    new SqlParameter("@ModuleTypeSuperiorID", SqlDbType.Int,4),
                    new SqlParameter("@ModuleTypeDepth", SqlDbType.Int,4),
					new SqlParameter("@ModuleTypeDescription", SqlDbType.NVarChar,50),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@Enable",SqlDbType.Bit),
                    new SqlParameter("@Icon", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.ModuleTypeID;
            parameters[1].Value = model.ModuleTypeName;
            parameters[2].Value = model.ModuleTypeOrder;
            parameters[3].Value = model.ModuleTypeSuperiorID;
            parameters[4].Value = GetModuleDepth(model.ModuleTypeSuperiorID) + 1;//���¼������
            parameters[5].Value = model.ModuleTypeDescription;
            parameters[6].Value = model.LastUpdateDate;
            parameters[7].Value = model.LastUpdateUser;
            parameters[8].Value = model.Enable;
            parameters[9].Value = model.Icon;

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
        /// ɾ���˵�����
        /// </summary>
        /// <param name="ModuleTypeID">�˵�����ID</param>
        /// <returns></returns>
        public int DeleteModuleType(int ModuleTypeID)
        {
            string strSql = "delete XF_ModuleType where ModuleTypeID=@ModuleTypeID";

            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeID", SqlDbType.Int,4)};
            parameters[0].Value = ModuleTypeID;

            return SqlServerHelper.ExecuteSql(strSql, parameters);
        }

        /// <summary>
        /// �õ�һ���˵�����ʵ��
        /// </summary>
        /// <param name="ModuleTypeID">�˵�����ID</param>
        /// <returns></returns>
        public XF.Model.XF_ModuleType GetModuleTypeModel(int ModuleTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from XF_ModuleType ");
            strSql.Append(" where ModuleTypeID=@ModuleTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeID", SqlDbType.Int,4)};
            parameters[0].Value = ModuleTypeID;

            XF.Model.XF_ModuleType model = new XF.Model.XF_ModuleType();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ModuleTypeID"].ToString() != "")
                {
                    model.ModuleTypeID = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeID"].ToString());
                }
                model.ModuleTypeName = ds.Tables[0].Rows[0]["ModuleTypeName"].ToString();
                if (ds.Tables[0].Rows[0]["ModuleTypeOrder"].ToString() != "")
                {
                    model.ModuleTypeOrder = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeOrder"].ToString());
                }
                model.ModuleTypeDescription = ds.Tables[0].Rows[0]["ModuleTypeDescription"].ToString();
                if (ds.Tables[0].Rows[0]["ModuleTypeDepth"].ToString() != "")
                {
                    model.ModuleTypeDepth = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeDepth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleTypeSuperiorID"].ToString() != "")
                {
                    model.ModuleTypeSuperiorID = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeSuperiorID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleTypeCount"].ToString() != "")
                {
                    model.ModuleTypeCount = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeCount"].ToString());
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
                model.Icon = ds.Tables[0].Rows[0]["Icon"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��ò˵����������б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <param name="strOrder">��������</param>
        /// <returns></returns>
        public DataSet GetModuleTypeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM XF_ModuleType ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ModuleTypeSuperiorID,ModuleTypeOrder asc");

            return SqlServerHelper.Query(strSql.ToString());
        }

        #endregion

        #region ExtendMethod
        /// <summary>
        /// ��ò˵������¼�����
        /// </summary>
        /// <param name="id">����ID</param>
        /// <returns></returns>
        public DataSet GetChildModuleTypeList(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM XF_ModuleType where ModuleTypeSuperiorID=" + id.ToString() + "order by ModuleTypeOrder asc");
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// ��ȡ�˵����
        /// </summary>
        /// <param name="ModuleTypeID">�˵�ID</param>
        /// <returns></returns>
        public int GetModuleDepth(int ModuleTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModuleTypeDepth from XF_ModuleType where ModuleTypeID=@ModuleTypeID");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeID", SqlDbType.Int,4)};
            parameters[0].Value = ModuleTypeID;

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
        /// �жϲ˵��������Ƿ��в˵�
        /// </summary>
        /// <param name="ModuleTypeID">����iD</param>
        /// <returns></returns>
        public bool HasChildModules(int ModuleTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModuleID from XF_Modules where ModuleTypeID=" + ModuleTypeID.ToString());
            if (SqlServerHelper.Query(strSql.ToString()).Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// �жϲ˵��������Ƿ����Ӳ˵�����
        /// </summary>
        /// <param name="ModuleTypeID">����iD</param>
        /// <returns></returns>
        public bool HasChildModuleType(int ModuleTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModuleTypeID from XF_ModuleType where ModuleTypeSuperiorID=" + ModuleTypeID.ToString());
            if (SqlServerHelper.Query(strSql.ToString()).Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #endregion

        #region �˵�����
        #region BaseMethod
        /// <summary>
        /// �жϲ˵��Ƿ����
        /// </summary>
        /// <param name="ModuleName">�˵�����</param>
        /// <returns></returns>
        public bool ModuleExists(string ModuleTag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XF_Modules");
            strSql.Append(" where ModuleTag=@ModuleTag");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTag", SqlDbType.NVarChar,50)};
            parameters[0].Value = ModuleTag;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ����ʱ�жϲ˵��Ƿ����
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <param name="ModuleName">�˵�����</param>
        /// <returns></returns>
        public bool UpdateExists(int ModuleID, string ModuleTag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XF_Modules");
            strSql.Append(" where ModuleID<>@ModuleID and ModuleTag=@ModuleTag");
            SqlParameter[] parameters = {
                    new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@ModuleTag", SqlDbType.NVarChar,50)};
            parameters[0].Value = ModuleID;
            parameters[1].Value = ModuleTag;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ����һ���˵�
        /// </summary>
        /// <param name="model">�˵�ʵ����</param>
        /// <returns></returns>
        public int CreateModule(XF.Model.XF_Modules model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into XF_Modules(");
            strSql.Append("ModuleTypeID,ModuleName,ModuleTag,ModuleURL,ModuleDisabled,ModuleOrder,ModuleDescription,IsMenu,ShowType,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser,Icon)");
            strSql.Append(" values (");
            strSql.Append("@ModuleTypeID,@ModuleName,@ModuleTag,@ModuleURL,@ModuleDisabled,@ModuleOrder,@ModuleDescription,@IsMenu,@ShowType,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser,@Icon)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTypeID", SqlDbType.Int,4),
					new SqlParameter("@ModuleName", SqlDbType.NVarChar,30),
					new SqlParameter("@ModuleTag", SqlDbType.NVarChar,50),
					new SqlParameter("@ModuleURL", SqlDbType.NVarChar,500),
					new SqlParameter("@ModuleDisabled", SqlDbType.Bit,1),
					new SqlParameter("@ModuleOrder", SqlDbType.Int,4),
					new SqlParameter("@ModuleDescription", SqlDbType.NVarChar,50),
                    new SqlParameter("@IsMenu", SqlDbType.Bit,1),
                    new SqlParameter("@ShowType",SqlDbType.Int,4),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@CreateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@Icon", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.ModuleTypeID;
            parameters[1].Value = model.ModuleName;
            parameters[2].Value = model.ModuleTag;
            parameters[3].Value = model.ModuleURL;
            parameters[4].Value = model.ModuleDisabled;
            parameters[5].Value = model.ModuleOrder;
            parameters[6].Value = model.ModuleDescription;
            parameters[7].Value = model.IsMenu;
            parameters[8].Value = model.ShowType;
            parameters[9].Value = model.CreateDate;
            parameters[10].Value = model.CreateUser;
            parameters[11].Value = model.LastUpdateDate;
            parameters[12].Value = model.LastUpdateUser;
            parameters[13].Value = model.Icon;

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
        /// ����һ������
        /// </summary>
        /// <param name="model">�˵�ʵ����</param>
        /// <returns></returns>
        public int UpdateModule(XF.Model.XF_Modules model)
        {
            int ret = 0;

            if (!UpdateExists(model.ModuleID, model.ModuleTag))
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update XF_Modules set ");
                strSql.Append("ModuleTypeID=@ModuleTypeID,");
                strSql.Append("ModuleName=@ModuleName,");
                strSql.Append("ModuleTag=@ModuleTag,");
                strSql.Append("ModuleURL=@ModuleURL,");
                strSql.Append("ModuleDisabled=@ModuleDisabled,");
                strSql.Append("ModuleOrder=@ModuleOrder,");
                strSql.Append("ModuleDescription=@ModuleDescription,");
                strSql.Append("IsMenu=@IsMenu,");
                strSql.Append("ShowType=@ShowType,");
                strSql.Append("LastUpdateDate=@LastUpdateDate,");
                strSql.Append("LastUpdateUser=@LastUpdateUser,");
                strSql.Append("Icon=@Icon,");
                strSql.Append("Enable=@Enable ");
                strSql.Append(" where ModuleID=@ModuleID ");
                SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,4),
					new SqlParameter("@ModuleTypeID", SqlDbType.Int,4),
					new SqlParameter("@ModuleName", SqlDbType.NVarChar,30),
					new SqlParameter("@ModuleTag", SqlDbType.NVarChar,50),
					new SqlParameter("@ModuleURL", SqlDbType.NVarChar,500),
					new SqlParameter("@ModuleDisabled", SqlDbType.Bit,1),
					new SqlParameter("@ModuleOrder", SqlDbType.Int,4),
					new SqlParameter("@ModuleDescription", SqlDbType.NVarChar,50),
                    new SqlParameter("@IsMenu", SqlDbType.Bit,1),
                    new SqlParameter("@ShowType",SqlDbType.Int,4),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@Enable",SqlDbType.Bit),
                    new SqlParameter("@Icon", SqlDbType.NVarChar,255)};
                parameters[0].Value = model.ModuleID;
                parameters[1].Value = model.ModuleTypeID;
                parameters[2].Value = model.ModuleName;
                parameters[3].Value = model.ModuleTag;
                parameters[4].Value = model.ModuleURL;
                parameters[5].Value = model.ModuleDisabled;
                parameters[6].Value = model.ModuleOrder;
                parameters[7].Value = model.ModuleDescription;
                parameters[8].Value = model.IsMenu;
                parameters[9].Value = model.ShowType;
                parameters[10].Value = model.LastUpdateDate;
                parameters[11].Value = model.LastUpdateUser;
                parameters[12].Value = model.Enable;
                parameters[13].Value = model.Icon;

                if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1)
                {
                    ret = 1;
                }
            }
            else
            {
                ret = 2;
            }
            return ret;
        }

        /// <summary>
        /// ɾ���˵����Լ���Ӧ��Ȩ��
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        public bool DeleteModule(int ModuleID)
        {

            ArrayList List = new ArrayList();
            List.Add("delete XF_Modules where ModuleID=" + ModuleID.ToString());
            List.Add("delete XF_ModuleAuthorityList where ModuleID=" + ModuleID.ToString());
            try
            {
                SqlServerHelper.ExecuteSqlTran(List);
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// �õ�һ���˵�ʵ��
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        public XF.Model.XF_Modules GetModuleModel(int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from XF_Modules ");
            strSql.Append(" where ModuleID=@ModuleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,4)};
            parameters[0].Value = ModuleID;

            XF.Model.XF_Modules model = new XF.Model.XF_Modules();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ModuleID"].ToString() != "")
                {
                    model.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleTypeID"].ToString() != "")
                {
                    model.ModuleTypeID = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeID"].ToString());
                }
                model.ModuleName = ds.Tables[0].Rows[0]["ModuleName"].ToString();
                model.ModuleTag = ds.Tables[0].Rows[0]["ModuleTag"].ToString();
                model.ModuleURL = ds.Tables[0].Rows[0]["ModuleURL"].ToString();
                if (ds.Tables[0].Rows[0]["ModuleDisabled"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ModuleDisabled"].ToString() == "1") || (ds.Tables[0].Rows[0]["ModuleDisabled"].ToString().ToLower() == "true"))
                    {
                        model.ModuleDisabled = true;
                    }
                    else
                    {
                        model.ModuleDisabled = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["ModuleOrder"].ToString() != "")
                {
                    model.ModuleOrder = int.Parse(ds.Tables[0].Rows[0]["ModuleOrder"].ToString());
                }
                model.ModuleDescription = ds.Tables[0].Rows[0]["ModuleDescription"].ToString();

                if (ds.Tables[0].Rows[0]["IsMenu"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsMenu"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsMenu"].ToString().ToLower() == "true"))
                    {
                        model.IsMenu = true;
                    }
                    else
                    {
                        model.IsMenu = false;
                    }
                }

                if (ds.Tables[0].Rows[0]["ShowType"].ToString() != "")
                {
                    model.ShowType = int.Parse(ds.Tables[0].Rows[0]["ShowType"].ToString());
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
                model.Icon = ds.Tables[0].Rows[0]["Icon"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��ò˵������б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <param name="strOrder">��������</param>
        /// <returns></returns>
        public DataSet GetModuleList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM XF_Modules where 1=1 ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }

            strSql.Append(" order by ModuleOrder asc");

            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// ��ò˵������б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <returns></returns>
        public DataSet GetModuleList2(string strWhere)
        {
            //ModuleDisabledΪ����ֵ����SQL Server��TRUEΪ1
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM XF_Modules where ModuleDisabled=1 and ModuleTypeID=" + strWhere + " order by ModuleOrder asc");

            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// ��ȡ�˵�ID
        /// </summary>
        /// <param name="ModuleTag">�˵���ʶ</param>
        /// <returns></returns>
        public int GetModuleID(string ModuleTag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModuleID from XF_Modules where ModuleTag=@ModuleTag");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTag", SqlDbType.NVarChar,50)};
            parameters[0].Value = ModuleTag;

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
        /// �˵��Ƿ�ر�
        /// </summary>
        /// <param name="ModuleTag">�˵���ʶ</param>
        /// <returns></returns>
        public bool IsModule(string ModuleTag)
        {
            bool ret = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModuleDisabled from XF_Modules where ModuleTag=@ModuleTag");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTag", SqlDbType.NVarChar,50)};
            parameters[0].Value = ModuleTag;

            object obj = SqlServerHelper.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                if ((obj.ToString() == "1") || (obj.ToString().ToLower() == "true"))
                    ret = true;
            }
            return ret;
        }

        #endregion
        #region ExtendMethod
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        public bool DeleteModules(string IDs)
        {
            ArrayList List = new ArrayList();
            List.Add("delete XF_Modules where ModuleID in (" + IDs + ")");
            List.Add("delete XF_ModuleAuthorityList where ModuleID in (" + IDs + ")");
            List.Add("delete XF_RoleAuthorityList where ModuleID in (" + IDs + ")");
            try
            {
                SqlServerHelper.ExecuteSqlTran(List);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// �õ�һ���˵�ʵ��
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        public XF.Model.XF_Modules GetModuleModel(string ModuleTag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from XF_Modules ");
            strSql.Append(" where ModuleTag=@ModuleTag ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleTag", SqlDbType.VarChar, 50)};
            parameters[0].Value = ModuleTag;

            XF.Model.XF_Modules model = new XF.Model.XF_Modules();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ModuleID"].ToString() != "")
                {
                    model.ModuleID = int.Parse(ds.Tables[0].Rows[0]["ModuleID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModuleTypeID"].ToString() != "")
                {
                    model.ModuleTypeID = int.Parse(ds.Tables[0].Rows[0]["ModuleTypeID"].ToString());
                }
                model.ModuleName = ds.Tables[0].Rows[0]["ModuleName"].ToString();
                model.ModuleTag = ds.Tables[0].Rows[0]["ModuleTag"].ToString();
                model.ModuleURL = ds.Tables[0].Rows[0]["ModuleURL"].ToString();
                if (ds.Tables[0].Rows[0]["ModuleDisabled"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ModuleDisabled"].ToString() == "1") || (ds.Tables[0].Rows[0]["ModuleDisabled"].ToString().ToLower() == "true"))
                    {
                        model.ModuleDisabled = true;
                    }
                    else
                    {
                        model.ModuleDisabled = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["ModuleOrder"].ToString() != "")
                {
                    model.ModuleOrder = int.Parse(ds.Tables[0].Rows[0]["ModuleOrder"].ToString());
                }
                model.ModuleDescription = ds.Tables[0].Rows[0]["ModuleDescription"].ToString();

                if (ds.Tables[0].Rows[0]["IsMenu"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsMenu"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsMenu"].ToString().ToLower() == "true"))
                    {
                        model.IsMenu = true;
                    }
                    else
                    {
                        model.IsMenu = false;
                    }
                }

                if (ds.Tables[0].Rows[0]["ShowType"].ToString() != "")
                {
                    model.ShowType = int.Parse(ds.Tables[0].Rows[0]["ShowType"].ToString());
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
                model.Icon = ds.Tables[0].Rows[0]["Icon"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion
        #endregion

        #region ��Ȩ

        #region BaseMethod
        /// <summary>
        /// ���Ӳ˵�Ȩ��
        /// </summary>
        /// <param name="list">Ȩ���б�</param>
        /// <returns></returns>
        public bool CreateAuthorityList(ArrayList list,string loginName)
        {
            ArrayList AuthorityList = new ArrayList();

            for (int i = 0; i < list.Count; i++)
            {
                string[] val = list[i].ToString().Split('|');
                AuthorityList.Add("insert into XF_ModuleAuthorityList(ModuleID,AuthorityTag,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser) values (" + val[0] + ",'" + val[1] + "','" + DateTime.Now.ToString() + "','" + loginName + "','" + DateTime.Now.ToString() + "','" + loginName + "')");
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
        /// ���²˵�Ȩ��
        /// </summary>
        public bool UpdateAuthorityList(ArrayList list,string loginName)
        {
            ArrayList AuthorityList = new ArrayList();

            for (int i = 0; i < list.Count; i++)
            {
                string[] val = list[i].ToString().Split('|');
                if (val[2] == "0")//���Ϊ0��ɾ��Ȩ��
                {
                    //ɾ���˵�Ȩ��
                    AuthorityList.Add("delete XF_ModuleAuthorityList where ModuleID=" + val[0] + " and AuthorityTag='" + val[1] + "'");
                    //ɾ����ɫ����Ӧ�ò˵���ʶ��Ȩ��
                    AuthorityList.Add("delete XF_RoleAuthorityList where ModuleID=" + val[0] + " and AuthorityTag='" + val[1] + "'");
                }
                else
                {
                    AuthorityList.Add("insert into XF_ModuleAuthorityList(ModuleID,AuthorityTag,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser) values (" + val[0] + ",'" + val[1] + "','" + DateTime.Now.ToString() + "','" + loginName + "','" + DateTime.Now.ToString() + "','" + loginName + "')");
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
        /// ɾ��ָ���˵���Ȩ���б�
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        public bool DeleteAuthority(int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete XF_ModuleAuthorityList ");
            strSql.Append(" where ModuleID=@ModuleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleID", SqlDbType.Int,4)};
            parameters[0].Value = ModuleID;

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
        /// ���ָ���˵���Ȩ���б�
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        public DataSet GetAuthorityList(int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from XF_ModuleAuthorityList where ModuleID=" + ModuleID.ToString());

            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// ���ָ���˵���Ȩ���б�
        /// </summary>
        /// <param name="ModuleID">�˵�ID</param>
        /// <returns></returns>
        public DataSet GetAuthorityNameList(int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT XF_ModuleAuthorityList.*, XF_AuthorityDir.AuthorityName FROM XF_ModuleAuthorityList INNER JOIN XF_AuthorityDir ON XF_ModuleAuthorityList.AuthorityTag = XF_AuthorityDir.AuthorityTag where ModuleID=" + ModuleID.ToString());

            return SqlServerHelper.Query(strSql.ToString());
        }

        #endregion

        #region ExtendMethod
        /// <summary>
        /// �������Ȩ�������б�
        /// </summary>
        /// <param name="strWhere">Where����</param>
        /// <param name="strOrder">��������</param>
        /// <returns></returns>
        public DataSet GetAllAuthorityList(int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,b.ID,b.ModuleID from XF_AuthorityDir a left join (select * from XF_ModuleAuthorityList where XF_ModuleAuthorityList.ModuleID = " + ModuleID.ToString() + ") b on a.AuthorityTag = b.AuthorityTag ");
            return SqlServerHelper.Query(strSql.ToString());
        }
        public DataSet GetModuleAuthorityList(int ModuleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.* from XF_ModuleAuthorityList a left join XF_AuthorityDir b on a.AuthorityTag = b.AuthorityTag where a.ModuleID = " + ModuleID.ToString() );
            return SqlServerHelper.Query(strSql.ToString());
        }
        #endregion
        #endregion

    }
}