using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WeChat.IReponsitory
{
    public interface IBaseReponsitory<T> : IDisposable where T : class
    {
        #region 创建记录（异步与同步方法）

        bool Create(T model, bool isCommit = true);

        Task<bool> CreateAsync(T model, bool isCommit = true);

        /// <summary>
        /// 增加多条记录
        /// </summary>
        /// <param name="T1">实体模型集合</param>
        /// <param name="IsCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        bool CreateList<T1>(List<T1> T, bool IsCommit = true) where T1 : class;


        /// <summary>
        /// 增加多条记录（异步）
        /// </summary>
        /// <param name="T1">实体模型集合</param>
        /// <param name="IsCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        Task<bool> CreateListAsync<T1>(List<T1> T, bool IsCommit = true) where T1 : class;

        #endregion

        #region 修改记录（异步和同步方法）
        bool Edit(T model, bool isCommit = true);

        Task<bool> EditAsync(T model, bool isCommit = true);

        int BatchUpdate(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> updateLambda);

        Task<int> BatchUpdateAsync(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> updateLambda);

        bool EditList<T1>(List<T1> T, bool IsCommit = true) where T1 : class;

        #endregion

        #region 删除记录 (同步和异步方法)

        bool Delete(T model, bool isCommit = true);

        Task<bool> DeleteAsync(T model, bool isCommit = true);

        int Delete(params object[] keyValues);

        Task<int> DeleteAsync(params object[] keyValues);

        // m_Rep.BatchDelete(a=>a.CreateTime>DateTime.Now);
        int BatchDelete(Expression<Func<T, bool>> whereLambda);

        Task<int> BatchDeleteAsync(Expression<Func<T, bool>> whereLambda);


        #endregion

        #region 查询记录 (异步与同步方法)

        T GetById(params object[] keyValues);

        Task<T> GetByIdAsync(params object[] keyValues);

        T GetSingleWhere(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> GetList();

        IQueryable<T> GetList(Expression<Func<T, bool>> whereLambda);






        IQueryable<T> GetList<S>(int pageSize, int pageIndex, out int total
            , Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, bool>> orderByLambda);

        int ExecuteSqlCommand(string sql);

        int ExecuteSqlCommand(string sql, params SqlParameter[] sp);

        /// <summary>
        /// 异步执行一条SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        Task<int> ExecuteSqlCommandAsync(string sql);

        #endregion

        bool IsExist(object id);

        int SaveChanges();

        void Dispose(bool disposing);
    }
}
