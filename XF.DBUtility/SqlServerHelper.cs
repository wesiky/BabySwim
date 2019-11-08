/**************************************
* 作用：SQL Server操作实现
* 作者：Nick.Yan
* 日期: 2007-05-24
* 网址：www.XF.com.cn
**************************************/

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Text;

namespace XF.DBUtility
{
    public class SqlServerHelper
    {
        //数据库连接字符串(web.config来配置)，可以动态更改SQLString支持多数据库.		
        public static string connectionString = ConfigurationManager.AppSettings["SQLString"];

        public SqlServerHelper() { }

        #region 公用方法


        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        public static bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType, Int32 Size, object Value)
        {
            return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
        }

        public static SqlParameter MakeOutParam(string ParamName, SqlDbType DbType)
        {
            return MakeParam(ParamName, DbType, 0, ParameterDirection.Output, null);
        }

        public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName, DbType);

            param.Direction = Direction;
            if (!(Direction == ParameterDirection.Output && Value == null))
                param.Value = Value;

            return param;
        }

        /// <summary>
        /// 分页获取数据列表及总行数
        /// </summary>
        /// <param name="tbName">表名</param>
        /// <param name="tbGetFields">返回字段</param>
        /// <param name="OrderFldName">排序的字段名</param>
        /// <param name="PageSize">页尺寸</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="OrderType">false升序，true降序</param>
        /// <param name="strWhere">查询条件</param>
        protected static DataSet GetPageList(string tbName, string tbGetFields, string OrderFldName, int PageSize, int PageIndex, string strWhere)
        {
            SqlParameter[] parameters = {
                        MakeInParam("@tbName",SqlDbType.VarChar,255,tbName),
                        MakeInParam("@tbGetFields",SqlDbType.VarChar,1000,tbGetFields),
                         MakeInParam("@OrderfldName",SqlDbType.VarChar,255,OrderFldName),
                         MakeInParam("@PageSize",SqlDbType.Int,0,PageSize),
                         MakeInParam("@PageIndex",SqlDbType.Int,0,PageIndex),
                         MakeInParam("@strWhere",SqlDbType.VarChar,1000,strWhere)
                        };
            return RunProcedure("Proc_SqlPageByRownumber", parameters, "ds");
        }

        public static DataTable GetPageList(string tbName, string tbGetFields, string OrderFldName, int PageSize, int PageIndex, string strWhere, ref int TotalCount)
        {
            DataSet ds = GetPageList(tbName, tbGetFields, OrderFldName, PageSize, PageIndex, strWhere);
            TotalCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            return ds.Tables[0];
        }

        #endregion

        #region  执行简单SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，设置命令的执行等待时间
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="Times"></param>
        /// <returns></returns>
        public static int ExecuteSqlByTime(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static void ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>	
        /// <param name="ConnectionString">连接字符串</param>	
        public static void ExecuteSqlTran(ArrayList SQLStringList, string ConnectionString)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }

        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static object ExecuteSqlGet(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(strSQL, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@fs", SqlDbType.Image);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader(使用该方法切记要手工关闭SqlDataReader和连接)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string strSQL)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            //finally //不能在此关闭，否则，返回的对象将无法使用
            //{
            //	cmd.Dispose();
            //	connection.Close();
            //}	
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, string ConnectionString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet,设置命令的执行等待时间
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="Times"></param>
        /// <returns></returns>
        public static DataSet Query(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            trans.Commit();
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回SqlDataReader (使用该方法切记要手工关闭SqlDataReader和连接)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            //finally //不能在此关闭，否则，返回的对象将无法使用
            //{
            //	cmd.Dispose();
            //	connection.Close();
            //}	

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        public static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion

        #region 存储过程操作

        /// <summary>
        /// 执行存储过程  (使用该方法切记要手工关闭SqlDataReader和连接)
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader returnReader;
            connection.Open();
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader();
            //Connection.Close(); 不能在此关闭，否则，返回的对象将无法使用            
            return returnReader;

        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>结果中第一行第一列</returns>
        public static string RunProc(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string StrValue;
                connection.Open();
                SqlCommand cmd;
                cmd = BuildQueryCommand(connection, storedProcName, parameters);
                StrValue = cmd.ExecuteScalar().ToString();
                connection.Close();
                return StrValue;
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = Times;
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        public static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        public static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>结果中第一行第一列</returns>
        public static string RunSql(string query)
        {
            string str;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        str = (cmd.ExecuteScalar().ToString() == "") ? "" : cmd.ExecuteScalar().ToString();
                        return str;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        #endregion

        #region 其他操作
        #region 获取表的所有字段
        /// <summary>
        /// 获取表的所有字段
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <returns>所有字段名</returns>
        public static List<string> zGetFieldsname(string TableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = "Select name from syscolumns Where ID=OBJECT_ID('" + TableName + "')";
                    DataSet ds = Query(sql);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        List<string> list = new List<string>();
                        foreach (DataRow dr in dt.Rows)
                        {
                            list.Add(dr[0].ToString());
                        }
                        return list;
                    }
                }
                catch //(System.Data.SqlClient.SqlException E)
                {
                    connection.Close();
                    //throw new Exception(E.Message);
                }
                return null;
            }
        }
        #endregion
        #region 保存一条数据，可以自动补充表中其他数据
        /// <summary>
        /// 保存一条数据，可以自动补充表中其他数据
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="dtValues">保存的字段和值</param>
        /// <returns>影响的记录数</returns>
        public static int zSaveData(string sTableName, string sSaveRule, DataTable dtValues, int iUpdateID = -1, bool bAllwaysInsert = false)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                #region 准备sql命令
                string sSql = "";
                if (sSaveRule == "EveryTime")
                {
                    sSql = zGetInsert(sTableName, dtValues);
                }
                else if (sSaveRule == "OneDay")
                {
                    try
                    {
                        string sql = "select * from " + sTableName + " where datediff(dd,CreateDate,GETDATE())=0";
                        DataSet ds = Query(sql);
                        if (!bAllwaysInsert && ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            int iID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
                            sSql = zGetUpdate(sTableName, dtValues, iID);
                        }
                        else
                        {
                            sSql = zGetInsert(sTableName, dtValues);
                        }
                    }
                    catch { }
                }
                else if (sSaveRule == "SignIsOne")
                {
                    try
                    {
                        if (!bAllwaysInsert && iUpdateID != -1)
                        {
                            sSql = zGetUpdate(sTableName, dtValues, iUpdateID);
                        }
                        else
                        {
                            sSql = zGetInsert(sTableName, dtValues);
                        }
                    }
                    catch { }
                }
                if (sSql == "")
                    return -1;
                #endregion
                #region 执行语句
                using (SqlCommand cmd = new SqlCommand(sSql, connection))
                {
                    try
                    {
                        connection.Open();
                        int icount = cmd.ExecuteNonQuery();
                        return icount;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                    }
                }
                #endregion
                return -1;
            }
        }
        #region 补充LineNum,Device,CreateDate等
        /// <summary>
        /// 保存一条数据，可以自动补充表中其他数据
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="dtValues">保存的字段和值</param>
        /// <param name="sLineNum">产线号</param>
        /// <param name="sDevice">设备名称</param>
        /// <param name="bSaveOther">是否保存其他字段（创建时间等）</param>
        /// <returns></returns>
        public static int zSaveData(out string sDebug, string sTableName, string sSaveRule, DataTable dtValues, string sLineNum, string sDevice, string sLoginName, int iUpdateID = -1, bool bSaveOther = true, bool bAllwaysInsert = false)
        {
            sDebug = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                ///个性化——获取上报标志
                string sCallFlag = "";
                #region 获取上报标志
                for (int i = 0; i < dtValues.Rows.Count; i++)
                {
                    if (dtValues.Rows[i]["SaveField"].ToString() == "CallTime")
                    {
                        sCallFlag = dtValues.Rows[i]["SaveValue"].ToString();
                        break;
                    }
                }
                #endregion
                ///

                #region 更改特殊项（Field中含有|的）
                for (int i = 0; i < dtValues.Rows.Count; i++)
                {
                    if (dtValues.Rows[i]["SaveField"].ToString().IndexOf("|") != -1)
                    {
                        string[] arr = dtValues.Rows[i]["SaveField"].ToString().Split('|');
                        if (dtValues.Rows[i]["SaveFormat"].ToString() == "1")
                        {
                            dtValues.Rows[i]["SaveField"] = arr[0];
                            DataRow row = dtValues.NewRow();
                            row["SaveField"] = arr[1];
                            row["SaveValue"] = dtValues.Rows[i]["SaveValue"].ToString() == "" ? "1" : "0";
                            row["SaveFormat"] = "0";
                            dtValues.Rows.Add(row);
                        }
                        else if (dtValues.Rows[i]["SaveFormat"].ToString() == "3")
                        {
                            dtValues.Rows[i]["SaveField"] = arr[0];

                            int iTimes = -1;
                            string sTimesFlag = "";
                            for (int j = 0; j < dtValues.Rows.Count; j++)
                            {
                                if (dtValues.Rows[j]["SaveField"].ToString() == arr[1])
                                {
                                    sTimesFlag = dtValues.Rows[j]["SaveValue"].ToString();
                                    if (dtValues.Rows[j]["SaveFormat"].ToString() == "4")
                                    {
                                        sTimesFlag = sTimesFlag.Replace('\r', '~').Replace("~", "");
                                    }
                                    break;
                                }
                            }
                            string sql = "select " + arr[0] + " from " + sTableName + " where " + arr[1] + " ='" + sTimesFlag + "' order by " + arr[0] + " desc";
                            DataSet ds = Query(sql);
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0] != null)
                            {
                                iTimes = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                            }
                            iTimes++;
                            dtValues.Rows[i]["SaveValue"] = iTimes.ToString();
                            dtValues.Rows[i]["SaveFormat"] = "0";
                        }
                        else if (dtValues.Rows[i]["SaveFormat"].ToString() == "5")
                        {
                            string[] arrvalue = dtValues.Rows[i]["SaveValue"].ToString().Split('|');
                            if (arrvalue.Length == 2)
                            {
                                string sql = "select * from " + sTableName + " where " + arr[0] + " ='" + arrvalue[0] + "' and " + arr[1] + " is null";
                                DataSet ds = Query(sql);
                                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                {
                                    //有未处理完的记录（复位|上报）
                                    if (arrvalue[1] == "0" || sCallFlag == "1")
                                    {
                                        //复位或上报
                                        try
                                        {
                                            iUpdateID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());

                                            ///个性化——去掉AlarmTime和上报
                                            for (int a = 0; a < dtValues.Rows.Count; a++)
                                            {
                                                if (dtValues.Rows[a]["SaveField"].ToString() == "AlarmTime")
                                                {
                                                    dtValues.Rows[a]["SaveValue"] = "0";
                                                    break;
                                                }
                                            }

                                            if (sCallFlag == "1")
                                            {
                                                dtValues.Rows[i]["SaveField"] = arr[1];
                                                dtValues.Rows[i]["SaveValue"] = "0";
                                                dtValues.Rows[i]["SaveFormat"] = "2";
                                            }
                                            ///

                                            else
                                            {
                                                dtValues.Rows[i]["SaveField"] = arr[1];
                                                dtValues.Rows[i]["SaveValue"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                                dtValues.Rows[i]["SaveFormat"] = "1";
                                            }
                                        }
                                        catch { }
                                    }
                                    else
                                    {
                                        return -2;
                                    }
                                }
                                else
                                {
                                    //新记录（1：存异常  0：忽视）
                                    if (arrvalue[1] == "1")
                                    {
                                        dtValues.Rows[i]["SaveField"] = arr[0];
                                        dtValues.Rows[i]["SaveValue"] = arrvalue[0];
                                        dtValues.Rows[i]["SaveFormat"] = "1";
                                    }
                                    else
                                    {
                                        return -2;
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
                #region 补充产线号、设备名称
                DataRow dr;
                if (dtValues.Select("SaveField='LineNum'").Length == 0)
                {
                    dr = dtValues.NewRow();
                    dr["SaveField"] = "LineNum";
                    dr["SaveValue"] = sLineNum;
                    dr["SaveFormat"] = "1";
                    dtValues.Rows.Add(dr);
                }
                if (dtValues.Select("SaveField='Device'").Length == 0)
                {
                    dr = dtValues.NewRow();
                    dr["SaveField"] = "Device";
                    dr["SaveValue"] = sDevice;
                    dr["SaveFormat"] = "1";
                    dtValues.Rows.Add(dr);
                }
                #endregion
                if (bSaveOther)
                {
                    #region 补充其他项
                    List<string> listField = zGetFieldsname(sTableName);
                    foreach (string sField in listField)
                    {
                        switch (sField)
                        {
                            case "Status":
                                if (dtValues.Select("SaveField='Status'").Length == 0)
                                {
                                    dr = dtValues.NewRow();
                                    dr["SaveField"] = "Status";
                                    dr["SaveValue"] = "0";
                                    dr["SaveFormat"] = "0";
                                    dtValues.Rows.Add(dr);
                                }
                                break;
                            case "CreateDate":
                                if (dtValues.Select("SaveField='CreateDate'").Length == 0)
                                {
                                    dr = dtValues.NewRow();
                                    dr["SaveField"] = "CreateDate";
                                    dr["SaveValue"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                    dr["SaveFormat"] = "1";
                                    dtValues.Rows.Add(dr);
                                }
                                break;
                            case "CreateUser":
                                if (dtValues.Select("SaveField='CreateUser'").Length == 0)
                                {
                                    dr = dtValues.NewRow();
                                    dr["SaveField"] = "CreateUser";
                                    dr["SaveValue"] = sLoginName;
                                    dr["SaveFormat"] = "1";
                                    dtValues.Rows.Add(dr);
                                }
                                break;
                            case "UpdateDate":
                                if (dtValues.Select("SaveField='UpdateDate'").Length == 0)
                                {
                                    dr = dtValues.NewRow();
                                    dr["SaveField"] = "UpdateDate";
                                    dr["SaveValue"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                    dr["SaveFormat"] = "1";
                                    dtValues.Rows.Add(dr);
                                }
                                break;
                            case "LastOperator":
                                if (dtValues.Select("SaveField='LastOperator'").Length == 0)
                                {
                                    dr = dtValues.NewRow();
                                    dr["SaveField"] = "LastOperator";
                                    dr["SaveValue"] = sLoginName;
                                    dr["SaveFormat"] = "1";
                                    dtValues.Rows.Add(dr);
                                }
                                break;
                        }
                    }
                    #endregion
                }
                if (sTableName.IndexOf("Result") == sTableName.Length - "Result".Length)
                {
                    bAllwaysInsert = true;
                    StringBuilder sb = new StringBuilder("抓到一次结果数据： ");
                    foreach (DataRow drow in dtValues.Rows)
                    {
                        sb.Append("[").Append(drow[0].ToString()).Append(" : ").Append(drow[1].ToString()).Append("] ");
                    }
                    sDebug = sb.ToString();
                }
                else if (sTableName.IndexOf("OEE") == sTableName.Length - "OEE".Length)
                {
                    bAllwaysInsert = false;
                    StringBuilder sb = new StringBuilder("抓到一次OEE数据： ");
                    foreach (DataRow drow in dtValues.Rows)
                    {
                        sb.Append("[").Append(drow[0].ToString()).Append(" : ").Append(drow[1].ToString()).Append("] ");
                    }
                    //sDebug = sb.ToString();
                }
                else if (sTableName.IndexOf("Alarm") == sTableName.Length - "Alarm".Length)
                {

                    bAllwaysInsert = false;
                    StringBuilder sb = new StringBuilder("抓到一次报警数据： ");
                    foreach (DataRow drow in dtValues.Rows)
                    {
                        sb.Append("[").Append(drow[0].ToString()).Append(" : ").Append(drow[1].ToString()).Append("] ");
                    }
                    sDebug = sb.ToString();
                }
                int iRes = zSaveData(sTableName, sSaveRule, dtValues, iUpdateID, bAllwaysInsert);

                ///个性化——补充Status和Duration等状态
                StringBuilder strSql = new StringBuilder("delete from ").Append(sTableName).Append(" where AlarmTime is null;");
                strSql.Append("update ").Append(sTableName).Append(" set Status=5 where ResetTime is not null and Status < 5;");
                strSql.Append("update ").Append(sTableName).Append(" set Status=2 where CallTime is not null and ResetTime is null and Status<2;");
                strSql.Append("update ").Append(sTableName).Append(" set Duration=DATEDIFF(MILLISECOND, AlarmTime, ResetTime) where Duration is null and Status=5;");
                #region 执行语句
                using (SqlCommand cmd = new SqlCommand(strSql.ToString(), connection))
                {
                    try
                    {
                        connection.Open();
                        int icount = cmd.ExecuteNonQuery();
                        //return icount;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                    }
                }
                #endregion
                ///

                return iRes;
            }
        }
        #endregion
        #region 准备工作
        #region 拼insert语句
        private static string zGetInsert(string sTableName, DataTable dtValues)
        {
            StringBuilder sbSql = new StringBuilder();
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();
            sbSql.Append("insert into ").Append(sTableName);
            for (int i = 0; i < dtValues.Rows.Count; i++)
            {
                DataRow dr = dtValues.Rows[i];
                if (sbFields.ToString() != "")
                    sbFields.Append(",");
                if (sbValues.ToString() != "")
                    sbValues.Append(",");
                sbFields.Append(dr["SaveField"].ToString());
                #region 不同SaveFormat
                ///0：数字
                ///1：字符（两端加单引号）
                ///2：当前时间
                ///3：次数（在前面已经处理成0了）
                ///4：字符，去掉结尾的\r
                ///5：字符，每个一条[’;’分隔]
                if (dr["SaveFormat"].ToString() == "0")
                    sbValues.Append(dr["SaveValue"].ToString());
                else if (dr["SaveFormat"].ToString() == "1")
                    sbValues.Append("'").Append(dr["SaveValue"].ToString()).Append("'");
                else if (dr["SaveFormat"].ToString() == "4")
                    sbValues.Append("'").Append(dr["SaveValue"].ToString().Replace('\r', '~').Replace("~", "")).Append("'");
                else if (dr["SaveFormat"].ToString() == "2")
                {
                    if (dr["SaveValue"].ToString() == "1")
                        sbValues.Append("'").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append("'");
                    else
                        sbValues.Append("null");
                }
                else if (dr["SaveFormat"].ToString() == "5")
                {
                    sbValues.Append("'").Append(dr["SaveValue"].ToString()).Append("'");
                }
                #endregion
            }
            sbSql.Append(" (").Append(sbFields).Append(") values (").Append(sbValues).Append(")");
            return sbSql.ToString();
        }
        #endregion
        #region 拼update语句
        /// <summary>
        /// 拼update语句
        /// </summary>
        /// <param name="sTableName"></param>
        /// <param name="dtValues"></param>
        /// <param name="iID">更新的iID，iID为-1则把条件改为除了日期等固定四项外所有项一样</param>
        /// <returns></returns>
        private static string zGetUpdate(string sTableName, DataTable dtValues, int iID)
        {
            StringBuilder sbSql = new StringBuilder();
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbCondition = new StringBuilder();
            string sField = "";
            string sValue = "";
            string sFormat = "";
            sbSql.Append("update ").Append(sTableName).Append(" set ");
            for (int i = 0; i < dtValues.Rows.Count; i++)
            {
                DataRow dr = dtValues.Rows[i];
                sField = dr["SaveField"].ToString();
                sValue = dr["SaveValue"].ToString();
                sFormat = dr["SaveFormat"].ToString();
                if (sField == "CreateDate" || sField == "CreateUser")
                    continue;
                #region 不同SaveFormat
                ///0：数字
                ///1：字符（两端加单引号）
                ///2：当前时间
                ///3：次数（在前面已经处理成0了）
                ///4：字符，去掉结尾的\r
                ///5：字符，每个一条[’;’分隔]
                if (sFormat == "0")
                {
                    if (sbFields.ToString() != "")
                        sbFields.Append(",");
                    sbFields.Append(sField).Append("=").Append(sValue);
                }
                else if (sFormat == "1")
                {
                    if (sbFields.ToString() != "")
                        sbFields.Append(",");
                    sbFields.Append(sField).Append("='").Append(sValue).Append("'");
                }
                else if (sFormat == "4")
                {
                    if (sbFields.ToString() != "")
                        sbFields.Append(",");
                    sbFields.Append(sField).Append("='").Append(sValue.Replace('\r', '~').Replace("~", "")).Append("'");
                }
                else if (sFormat == "2")
                {
                    if (dr["SaveValue"].ToString() == "1")
                    {
                        if (sbFields.ToString() != "")
                            sbFields.Append(",");
                        sbFields.Append(sField).Append("='").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append("'");
                    }
                    //else
                    //    sbFields.Append(sField).Append("=null");
                }
                else if (sFormat == "5")
                {
                    if (sbFields.ToString() != "")
                        sbFields.Append(",");
                    sbFields.Append(sField).Append("='").Append(dr["SaveValue"].ToString()).Append("'");
                }
                #endregion
                #region 没有ID
                if (iID == -1 && sField.ToUpper() != "STATUS" && sField.ToUpper() != "CREATEDATE"
                    && sField.ToUpper() != "CREATEUSER" && sField.ToUpper() != "UPDATEDATE" && sField.ToUpper() != "LASTOPERATOR")
                {
                    if (sbCondition.ToString() != "")
                        sbCondition.Append(" and ");
                    #region 不同SaveFormat
                    ///0：数字
                    ///1：字符（两端加单引号）
                    ///2：当前时间
                    ///5：字符，每个一条[’;’分隔]
                    if (sFormat == "0")
                    {
                        if (sbFields.ToString() != "")
                            sbFields.Append(",");
                        sbCondition.Append(sField).Append("=").Append(sValue);
                    }
                    else if (sFormat == "1")
                    {
                        if (sbFields.ToString() != "")
                            sbFields.Append(",");
                        sbCondition.Append(sField).Append("='").Append(sValue).Append("'");
                    }
                    else if (sFormat == "2")
                    {
                        if (dr["SaveValue"].ToString() == "1")
                        {
                            if (sbFields.ToString() != "")
                                sbFields.Append(",");
                            sbFields.Append(sField).Append("='").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append("'");
                        }
                        else
                        {
                            if (sbFields.ToString() != "")
                                sbFields.Append(",");
                            sbFields.Append(sField).Append("=null");
                        }
                    }
                    else if (sFormat == "5")
                    {
                        if (sbFields.ToString() != "")
                            sbFields.Append(",");
                        sbFields.Append(sField).Append("='").Append(dr["SaveValue"].ToString()).Append("'");
                    }
                    #endregion
                }
                #endregion
            }
            if (iID == -1)
                sbSql.Append(sbFields).Append(" where ").Append(sbCondition);
            else
                sbSql.Append(sbFields).Append(" where ID=").Append(iID);
            return sbSql.ToString();
        }
        #endregion
        #region 检测该项是否存在，存在返回ID，不存在返回-1
        /// <summary>
        /// 检测该项是否存在，存在返回ID，不存在返回-1
        /// </summary>
        /// <param name="sTableName"></param>
        /// <param name="dtValues"></param>
        /// <param name="iID">更新的iID，iID为-1则把条件改为除了日期等固定四项外所有项一样</param>
        /// <returns></returns>
        public static int zExist(string sTableName, DataTable dtValues)
        {
            try
            {
                StringBuilder sbSql = new StringBuilder();
                //StringBuilder sbFields = new StringBuilder();
                //StringBuilder sbCondition = new StringBuilder();
                string sField = "";
                string sValue = "";
                string sFormat = "";
                sbSql.Append("select * from ").Append(sTableName).Append(" where 1=1 ");
                for (int i = 0; i < dtValues.Rows.Count; i++)
                {
                    DataRow dr = dtValues.Rows[i];
                    sField = dr["SaveField"].ToString();
                    sValue = dr["SaveValue"].ToString();
                    sFormat = dr["SaveFormat"].ToString();
                    if (sField == "CreateDate" || sField == "CreateUser" || sField == "UpdateDate" || sField == "LastOperator" || sField.IndexOf("|") != -1)
                        continue;
                    //if (sbFields.ToString() != "")
                    //    sbFields.Append(",");
                    #region 不同SaveFormat
                    ///0：数字
                    ///1：字符（两端加单引号）
                    ///2：当前时间
                    ///3：次数（在前面已经处理成0了）
                    ///4：字符，去掉结尾的\r
                    ///5：字符，每个一条[’;’分隔]
                    if (sFormat == "0")
                        sbSql.Append(" and ").Append(sField).Append("=").Append(sValue);
                    else if (sFormat == "1")
                        sbSql.Append(" and ").Append(sField).Append("='").Append(sValue).Append("'");
                    else if (sFormat == "4")
                        sbSql.Append(" and ").Append(sField).Append("='").Append(sValue.Replace('\r', '~').Replace("~", "")).Append("'");
                    else if (sFormat == "2")
                    {
                        if (dr["SaveValue"].ToString() == "1")
                            sbSql.Append(" and ").Append(sField).Append("='").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append("'");
                        else
                            sbSql.Append(" and ").Append(sField).Append("=null");
                    }
                    else if (sFormat == "5")
                    {
                        sbSql.Append(" and ").Append(sField).Append("='").Append(dr["SaveValue"].ToString()).Append("'");
                    }
                    #endregion
                }

                #region 执行语句
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DataSet ds = Query(sbSql.ToString());
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        return Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
                    }
                }
                #endregion
            }
            catch { }

            return -1;
        }
        #endregion
        #endregion
        #endregion
        #region 获取所有OEE
        public static DataSet zGetAllOEE()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Auto_StaticContactOEE;");
            sb.Append("select * from Auto_FixedScrewOEE;");
            sb.Append("select * from Auto_ShenKeJXMHOEE;");
            sb.Append("select * from Auto_ShenKeZYLOEE;");
            sb.Append("select * from Auto_ShenKeDZTKLOEE;");
            sb.Append("select * from Auto_ShenKeSSOEE;");
            sb.Append("select * from Auto_ShenKeYSOEE;");
            sb.Append("select * from Auto_InsulatingPlugOEE;");
            sb.Append("select * from Auto_InterrupterOEE;");
            sb.Append("select * from Auto_AssembleOEE;");
            sb.Append("select * from Auto_OnOffVoltageOEE;");
            sb.Append("select * from Auto_LaserMarkingOEE;");
            sb.Append("select * from AutoHL_DeviceRunOEE;");
            return Query(sb.ToString());
        }
        #endregion
        #region 获取所有Result
        public static DataSet zGetAllResult(string sDateBegin = "", string sDateEnd = "")
        {
            /*
            select * from Auto_StaticContactResult a where 1=1  and CreateDate > '2018-11-29' and CreateDate < '2018-11-30' order by CreateDate;
            select * from Auto_FixedScrewResult a where 1=1  and CreateDate > '2018-11-29' and CreateDate < '2018-11-30' order by CreateDate;
            select * from Auto_ShenKeJXMHTest a where 1=1  and TESTDATE > '2018/11/29' and TESTDATE < '2018/11/30' order by TESTDATE;
            select * from Auto_ShenKeZYLTest a where 1=1  and TESTDATE > '2018/11/29' and TESTDATE < '2018/11/30' order by TESTDATE;
            select * from Auto_ShenKeDZTKLTest a where 1=1  and TESTDATE > '2018/11/29' and TESTDATE < '2018/11/30' order by TESTDATE;
            select * from Auto_ShenKeSSTest a where CreateDate = (select min(CreateDate) from Auto_ShenKeSSTest where Barcode = a.Barcode)  
            and TESTDATE > '2018/11/29' and TESTDATE < '2018/11/30' order by TESTDATE;
            select * from Auto_ShenKeYSTest a where CreateDate = (select min(CreateDate) from Auto_ShenKeYSTest where Barcode = a.Barcode)  
            and TESTDATE > '2018/11/29' and TESTDATE < '2018/11/30' order by TESTDATE;
            select * from Auto_InsulatingPlugResult a where 1=1  and CreateDate > '2018-11-29' and CreateDate < '2018-11-30' order by CreateDate;
            select * from Auto_InterrupterResult a where 1=1  and CreateDate > '2018-11-29' and CreateDate < '2018-11-30' order by CreateDate;
            select * from Auto_AssembleResult a where 1=1  and CreateDate > '2018-11-29' and CreateDate < '2018-11-30' order by CreateDate;
            select * from Auto_OnOffVoltageResult a where 1=1  and CreateDate > '2018-11-29' and CreateDate < '2018-11-30' order by CreateDate;
            select * from Auto_LaserMarkingResult a where 1=1  and CreateDate > '2018-11-29' and CreateDate < '2018-11-30' order by CreateDate;
            select * from AutoHL_Local_CodeTree a where 1=1  and OuterBoxPrintTime > '2018-11-29' and OuterBoxPrintTime < '2018-11-30' order by OuterBoxPrintTime;
             */
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from Auto_StaticContactResult a where 1=1 ")//CreateDate = (select min(CreateDate) from Auto_StaticContactResult where Barcode = a.Barcode) ")
                 .Append((sDateBegin != "" && sDateEnd != "") ? " and CreateDate >= '" + sDateBegin + "' and CreateDate < '" + sDateEnd + "'" : "").Append(" order by CreateDate;");
            sb.Append("select * from Auto_FixedScrewResult a where 1=1 ")//CreateDate = (select min(CreateDate) from Auto_FixedScrewResult where Barcode = a.Barcode) ")
                 .Append((sDateBegin != "" && sDateEnd != "") ? " and CreateDate >= '" + sDateBegin + "' and CreateDate < '" + sDateEnd + "'" : "").Append(" order by CreateDate;");

            sb.Append("select * from Auto_ShenKeJXMHTest a where 1=1 ")//CreateDate = (select min(CreateDate) from Auto_ShenKeJXMHTest where Barcode = a.Barcode) ")
                 .Append((sDateBegin != "" && sDateEnd != "") ? " and TESTDATE >= '" + sDateBegin.Replace("-", "/") + "' and TESTDATE < '" + sDateEnd.Replace("-", "/") + "'" : "").Append(" order by TESTDATE;");
            sb.Append("select * from Auto_ShenKeZYLTest a where 1=1 ")//CreateDate = (select min(CreateDate) from Auto_ShenKeZYLTest where Barcode = a.Barcode) ")
                 .Append((sDateBegin != "" && sDateEnd != "") ? " and TESTDATE >= '" + sDateBegin.Replace("-", "/") + "' and TESTDATE < '" + sDateEnd.Replace("-", "/") + "'" : "").Append(" order by TESTDATE;");
            sb.Append("select * from Auto_ShenKeDZTKLTest a where 1=1 ")//CreateDate = (select min(CreateDate) from Auto_ShenKeDZTKLTest where Barcode = a.Barcode) ")
                 .Append((sDateBegin != "" && sDateEnd != "") ? " and TESTDATE >= '" + sDateBegin.Replace("-", "/") + "' and TESTDATE < '" + sDateEnd.Replace("-", "/") + "'" : "").Append(" order by TESTDATE;");
            sb.Append("select * from Auto_ShenKeSSTest a where 1=1 and (CheckTimes=0 or CheckTimes is null) ")// CreateDate = (select min(CreateDate) from Auto_ShenKeSSTest where Barcode = a.Barcode) ")
                 .Append((sDateBegin != "" && sDateEnd != "") ? " and TESTDATE >= '" + sDateBegin.Replace("-", "/") + "' and TESTDATE < '" + sDateEnd.Replace("-", "/") + "'" : "").Append(" order by TESTDATE;");
            sb.Append("select * from Auto_ShenKeYSTest a where 1=1 and (CheckTimes=0 or CheckTimes is null) ")// CreateDate = (select min(CreateDate) from Auto_ShenKeYSTest where Barcode = a.Barcode) ")
                 .Append((sDateBegin != "" && sDateEnd != "") ? " and TESTDATE >= '" + sDateBegin.Replace("-", "/") + "' and TESTDATE < '" + sDateEnd.Replace("-", "/") + "'" : "").Append(" order by TESTDATE;");

            sb.Append("select * from Auto_InsulatingPlugResult a where 1=1 ")//CreateDate = (select min(CreateDate) from Auto_InsulatingPlugResult where Barcode = a.Barcode) ")
                 .Append((sDateBegin != "" && sDateEnd != "") ? " and CreateDate >= '" + sDateBegin + "' and CreateDate < '" + sDateEnd + "'" : "").Append(" order by CreateDate;");
            sb.Append("select * from Auto_InterrupterResult a where 1=1 ")//CreateDate = (select min(CreateDate) from Auto_InterrupterResult where Barcode = a.Barcode) ")
                 .Append((sDateBegin != "" && sDateEnd != "") ? " and CreateDate >= '" + sDateBegin + "' and CreateDate < '" + sDateEnd + "'" : "").Append(" order by CreateDate;");
            sb.Append("select * from Auto_AssembleResult a where 1=1 ")//CreateDate = (select min(CreateDate) from Auto_AssembleResult where Barcode = a.Barcode) ")
                 .Append((sDateBegin != "" && sDateEnd != "") ? " and CreateDate >= '" + sDateBegin + "' and CreateDate < '" + sDateEnd + "'" : "").Append(" order by CreateDate;");
            sb.Append("select * from Auto_OnOffVoltageResult a where 1=1 ")//CreateDate = (select min(CreateDate) from Auto_OnOffVoltageResult where Barcode = a.Barcode) ")
                .Append((sDateBegin != "" && sDateEnd != "") ? " and CreateDate >= '" + sDateBegin + "' and CreateDate < '" + sDateEnd + "'" : "").Append(" order by CreateDate;");
            sb.Append("select * from Auto_LaserMarkingResult a where 1=1 ")//CreateDate = (select min(CreateDate) from Auto_LaserMarkingResult where Barcode = a.Barcode) ")
                 .Append((sDateBegin != "" && sDateEnd != "") ? " and CreateDate >= '" + sDateBegin + "' and CreateDate < '" + sDateEnd + "'" : "").Append(" order by CreateDate;");

            sb.Append("select * from AutoHL_Local_CodeTree a where 1=1 ")//OuterBoxPrintTime = (select min(OuterBoxPrintTime) from AutoHL_Local_CodeTree where DeviceCode = a.DeviceCode) ")
                 .Append((sDateBegin != "" && sDateEnd != "") ? " and OuterBoxPrintTime >= '" + sDateBegin + "' and OuterBoxPrintTime < '" + sDateEnd + "'" : "").Append(" order by OuterBoxPrintTime;");
            return Query(sb.ToString());
        }
        #endregion
        #endregion
    }
}
