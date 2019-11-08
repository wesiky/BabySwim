using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using XF.DBUtility;
using XF.IDAL;

namespace XF.SQLServerDAL
{
    public class XF_Configuration : IXF_Configuration
    {
        public XF_Configuration() { }
        #region BaseMethod
        /// <summary>
        /// 判断配置项是否存在
        /// </summary>
        /// <param name="ItemName">配置项名称</param>
        /// <returns></returns>
        public bool Exists(string ItemName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XF_Configuration");
            strSql.Append(" where ItemName=@ItemName ");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemName", SqlDbType.NVarChar,50)};
            parameters[0].Value = ItemName;

            return SqlServerHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 创建新配置
        /// </summary>
        /// <param name="ItemName">配置名称</param>
        /// <param name="ItemValue">配置值</param>
        /// <returns></returns>
        public int CreateItem(string ItemName, string ItemValue,string ItemDescription,string LoginName)
        {
            int ret = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into XF_Configuration(");
            strSql.Append("ItemName,ItemValue,ItemDescription,CreateDate,CreateUser,LastUpdateDate,LastUpdateUser)");
            strSql.Append(" values (");
            strSql.Append("@ItemName,@ItemValue,@ItemDescription,@CreateDate,@CreateUser,@LastUpdateDate,@LastUpdateUser)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemName", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemValue", SqlDbType.NVarChar,500),
                    new SqlParameter("@ItemDescription", SqlDbType.NVarChar,500),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime),
                    new SqlParameter("@CreateUser", SqlDbType.NVarChar,128),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128)};
            parameters[0].Value = ItemName;
            parameters[1].Value = ItemValue;
            parameters[2].Value = ItemDescription;
            parameters[3].Value = DateTime.Now;
            parameters[4].Value = LoginName;
            parameters[5].Value = DateTime.Now;
            parameters[6].Value = LoginName;

            object obj = SqlServerHelper.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                ret = int.Parse(obj.ToString());
            }
            return ret;
        }

        /// <summary>
        /// 更新配置
        /// </summary>
        /// <param name="id">配置项ID</param>
        /// <param name="ItemName">配置名称</param>
        /// <param name="ItemValue">配置值</param>
        /// <returns></returns>
        public bool UpdateItem(int id, string ItemName, string ItemValue,string ItemDescription,string LoginName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update XF_Configuration set ");
            strSql.Append("ItemName=@ItemName,");
            strSql.Append("ItemValue=@ItemValue,");
            strSql.Append("ItemDescription=@ItemDescription,");
            strSql.Append("LastUpdateDate=@LastUpdateDate,");
            strSql.Append("LastUpdateUser=@LastUpdateUser ");
            strSql.Append(" where ItemID=@ItemID;");
            SqlParameter[] parameters = {					
					new SqlParameter("@ItemName", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemValue",SqlDbType.NVarChar,500),
                    new SqlParameter("@ItemDescription",SqlDbType.NVarChar,500),
                    new SqlParameter("@ItemID", SqlDbType.Int,4),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128)};
            parameters[0].Value = ItemName;
            parameters[1].Value = ItemValue;
            parameters[2].Value = ItemDescription;
            parameters[3].Value = id;
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
        /// 更新配置值
        /// </summary>
        /// <param name="id">配置项ID</param>
        /// <param name="ItemValue">配置值</param>
        /// <returns></returns>
        public bool UpdateItem(int id, string ItemValue,string LoginName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update XF_Configuration set ");
            strSql.Append("ItemValue=@ItemValue,");
            strSql.Append("LastUpdateDate=@LastUpdateDate,");
            strSql.Append("LastUpdateUser=@LastUpdateUser ");
            strSql.Append("where ItemID=@ItemID");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemID", SqlDbType.Int,4),
					new SqlParameter("@ItemValue",SqlDbType.NVarChar),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128)};
            parameters[0].Value = id;
            parameters[1].Value = ItemValue;
            parameters[2].Value = DateTime.Now;
            parameters[3].Value = LoginName;

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
        /// 更新配置值
        /// </summary>
        /// <param name="id">配置项ID</param>
        /// <param name="ItemValue">配置值</param>
        /// <returns></returns>
        public bool UpdateItem(string ItemName, string ItemValue, string LoginName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update XF_Configuration set ");
            strSql.Append("ItemValue=@ItemValue,");
            strSql.Append("LastUpdateDate=@LastUpdateDate,");
            strSql.Append("LastUpdateUser=@LastUpdateUser ");
            strSql.Append("where ItemName=@ItemName");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemName", SqlDbType.NVarChar,50),
					new SqlParameter("@ItemValue",SqlDbType.NVarChar),
                    new SqlParameter("@LastUpdateDate", SqlDbType.DateTime),
                    new SqlParameter("@LastUpdateUser", SqlDbType.NVarChar,128)};
            parameters[0].Value = ItemName;
            parameters[1].Value = ItemValue;
            parameters[2].Value = DateTime.Now;
            parameters[3].Value = LoginName;

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
        /// 删除配置项
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool DeleteItem(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete XF_Configuration ");
            strSql.Append(" where ItemID=@ItemID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemID", SqlDbType.Int,4)};
            parameters[0].Value = id;

            if (SqlServerHelper.ExecuteSql(strSql.ToString(), parameters) >= 1)
                return true;
            else
                return false;

        }

        /// <summary>
        /// 获取配置项的址
        /// </summary>
        /// <param name="ItemName">配置项名称</param>
        /// <returns></returns>
        public string GetItemValue(string ItemName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ItemValue FROM XF_Configuration where ItemName=@ItemName");
            SqlParameter[] parameters = {
					new SqlParameter("@ItemName", SqlDbType.NVarChar,50)};
            parameters[0].Value = ItemName;

            object obj = SqlServerHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// 获取配置的列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetItemList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM XF_Configuration ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            return SqlServerHelper.Query(strSql.ToString());
        }
        #endregion

        #region ExtendMethod
        public DataTable GetItemListByPage(string strWhere, string strOrder, int pageIndex, int pageSize, ref int count)
        {
            string tbName = " XF_Configuration ";
            string tbGetFields = " XF_Configuration.* ";
            return SqlServerHelper.GetPageList(tbName, tbGetFields, strOrder, pageSize, pageIndex, strWhere, ref count);
        }
        /// <summary>
        /// 删除配置项
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool DeleteItems(string IDs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete XF_Configuration ");
            strSql.Append(" where ItemID in (" + IDs + ")");
            if (SqlServerHelper.ExecuteSql(strSql.ToString()) >= 1)
                return true;
            else
                return false;
        }
        #endregion

    }
}

