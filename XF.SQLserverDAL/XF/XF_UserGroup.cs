using System;
using System.Data;
using System.Collections;
using System.Text;
using System.Data.SqlClient;

using XF.DBUtility;
using XF.IDAL;

namespace XF.SQLServerDAL
{
    public class XF_UserGroup : IXF_UserGroup
    {
        public XF_UserGroup()
        { }

        #region 用户分组
        #region BaseMethod
        /// <summary>
        /// 判断用户分组是否存在
        /// </summary>
        /// <param name="UG_Name">用户分组名称</param>
        /// <returns></returns>
        public bool XF_UserGroupExists(string Name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XF_UserGroup");
            strSql.Append(" where UG_Name=@UG_Name ");
            SqlParameter[] parameters = {
					new SqlParameter("@UG_Name", SqlDbType.NVarChar,30)};
            parameters[0].Value = Name;


            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一个用户分组
        /// </summary>
        /// <param name="model">用户分组实体类</param>
        /// <returns></returns>
        public int CreateXF_UserGroup(XF.Model.XF_UserGroup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into XF_UserGroup(");
            strSql.Append("UG_Name,UG_Order,UG_SuperiorID,UG_Depth,UG_Description,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser)");
            strSql.Append(" values (");
            strSql.Append("@UG_Name,@UG_Order,@UG_SuperiorID,@UG_Depth,@UG_Description,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser)");

            SqlParameter[] parameters = {
					new SqlParameter("@UG_Name", SqlDbType.NVarChar,30),
					new SqlParameter("@UG_Order", SqlDbType.Int,4),
                    new SqlParameter("@UG_SuperiorID", SqlDbType.Int,4),
                    new SqlParameter("@UG_Depth", SqlDbType.Int,4),
					new SqlParameter("@UG_Description", SqlDbType.NVarChar,50),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@CreateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128)};
            parameters[0].Value = model.UG_Name;
            parameters[1].Value = model.UG_Order;
            parameters[2].Value = model.UG_SuperiorID;
            parameters[3].Value = GetXF_UserGroupDepth(model.UG_SuperiorID) + 1;//更新级别深度
            parameters[4].Value = model.UG_Description;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.CreateUser;
            parameters[7].Value = model.LastUpdateDate;
            parameters[8].Value = model.LastUpdateUser;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model">用户分组实体类</param>
        /// <returns></returns>
        public bool UpdateXF_UserGroup(XF.Model.XF_UserGroup model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update XF_UserGroup set ");
            strSql.Append("UG_Name=@UG_Name,");
            strSql.Append("UG_Order=@UG_Order,");
            strSql.Append("UG_SuperiorID=@UG_SuperiorID,");
            strSql.Append("UG_Depth=@UG_Depth,");
            strSql.Append("UG_Description=@UG_Description,");
            strSql.Append("LastUpdateDate=@LastUpdateDate,");
            strSql.Append("LastUpdateUser=@LastUpdateUser,");
            strSql.Append("Enable=@Enable ");
            strSql.Append(" where UG_ID=@UG_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UG_ID", SqlDbType.Int,4),
					new SqlParameter("@UG_Name", SqlDbType.NVarChar,30),
					new SqlParameter("@UG_Order", SqlDbType.Int,4),
                    new SqlParameter("@UG_SuperiorID", SqlDbType.Int,4),
                    new SqlParameter("@UG_Depth", SqlDbType.Int,4),
					new SqlParameter("@UG_Description", SqlDbType.NVarChar,50),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@Enable",SqlDbType.Bit)};
            parameters[0].Value = model.UG_ID;
            parameters[1].Value = model.UG_Name;
            parameters[2].Value = model.UG_Order;
            parameters[3].Value = model.UG_SuperiorID;
            parameters[4].Value = GetXF_UserGroupDepth(model.UG_SuperiorID) + 1;//更新级别深度
            parameters[5].Value = model.UG_Description;
            parameters[6].Value = model.LastUpdateDate;
            parameters[7].Value = model.LastUpdateUser;
            parameters[8].Value = model.Enable;

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
        /// 删除用户分组
        /// </summary>
        /// <param name="ID">用户分组ID</param>
        /// <returns></returns>
        public int DeleteXF_UserGroup(int id)
        {
            int ret = 0;
            string strSql1 = "Select UserID from XF_Users where XF_UserGroup=@UG_ID";
            string strSql2 = "Select UG_ID from XF_UserGroup where UG_SuperiorID=@UG_ID";
            string strSql3 = "delete XF_UserGroup where UG_ID=@UG_ID";

            SqlParameter[] parameters = {
					new SqlParameter("@UG_ID", SqlDbType.Int,4)};
            parameters[0].Value = id;

            if (!SqlServerHelper.Exists(strSql1, parameters) && !SqlServerHelper.Exists(strSql2, parameters))
            {
                if (SqlServerHelper.ExecuteSql(strSql3, parameters) >= 1)
                {
                    ret = 1;
                }
                else
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
        /// 获取菜单深度
        /// </summary>
        /// <param name="ID">菜单ID</param>
        /// <returns></returns>
        public int GetXF_UserGroupDepth(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UG_Depth from XF_UserGroup where UG_ID=@UG_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@UG_ID", SqlDbType.Int,4)};
            parameters[0].Value = id;

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
        /// 得到一个用户分组实体
        /// </summary>
        /// <param name="ID">用户分组ID</param>
        /// <returns></returns>
        public XF.Model.XF_UserGroup GetXF_UserGroupModel(int id)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select top 1 * from XF_UserGroup ");
            strSql.Append(" where UG_ID=@UG_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@UG_ID", SqlDbType.Int,4)};
            parameters[0].Value = id;

            XF.Model.XF_UserGroup model = new XF.Model.XF_UserGroup();
            DataSet ds = SqlServerHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UG_ID"].ToString() != "")
                {
                    model.UG_ID = int.Parse(ds.Tables[0].Rows[0]["UG_ID"].ToString());
                }
                model.UG_Name = ds.Tables[0].Rows[0]["UG_Name"].ToString();
                if (ds.Tables[0].Rows[0]["UG_Order"].ToString() != "")
                {
                    model.UG_Order = int.Parse(ds.Tables[0].Rows[0]["UG_Order"].ToString());
                }
                model.UG_Description = ds.Tables[0].Rows[0]["UG_Description"].ToString();
                if (ds.Tables[0].Rows[0]["UG_Depth"].ToString() != "")
                {
                    model.UG_Depth = int.Parse(ds.Tables[0].Rows[0]["UG_Depth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UG_SuperiorID"].ToString() != "")
                {
                    model.UG_SuperiorID = int.Parse(ds.Tables[0].Rows[0]["UG_SuperiorID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UG_Count"].ToString() != "")
                {
                    model.UG_Count = int.Parse(ds.Tables[0].Rows[0]["UG_Count"].ToString());
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
        /// 获得用户分组数据列表
        /// </summary>
        /// <param name="strWhere">Where条件</param>
        /// <returns></returns>
        public DataSet GetXF_UserGroupList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM XF_UserGroup ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by UG_Order,UG_SuperiorID desc");

            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得用户分组下级分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns></returns>
        public DataSet GetChildXF_UserGroupList(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM XF_UserGroup where UG_SuperiorID=" + id.ToString() + "order by UG_Order asc");
            return SqlServerHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 判断用户分组下是否有菜单
        /// </summary>
        /// <param name="ID">分类iD</param>
        /// <returns></returns>
        public bool IsUser(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID from XF_Users where UG_ID=" + id.ToString());
            if (SqlServerHelper.ExecuteSql(strSql.ToString()) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        #endregion
        #region ExtendMethod
        #endregion
        #endregion
    }
}