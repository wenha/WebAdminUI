using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core
{
    /// <summary>
    /// 基础仓储接口
    /// </summary>
    public interface IRepository
    {
    }

    public interface IRepository<T> : IRepository where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        List<T> GetAllList();

        Task<List<T>> GetAllListAsync();

        List<T> GetAllList(Expression<Func<T, bool>> predicate);

        Task<List<T>> GetAllListAsync(Expression<Func<T, bool>> predicate);

        T Insert(T entity);

        IEnumerable<T> Insert(IEnumerable<T> entities);

        Task<T> InsertAsync(T entity);

        void InsertOrUpdate(params T[] entities);

        T Update(T entity);

        Task<T> UpdateAsync(T entity);

        void Delete(T entity);

        Task DeleteAsync(T entity);

        void Delete(Expression<Func<T, bool>> predicate);

        Task DeleteAsync(Expression<Func<T, bool>> predicate);

        int Count();

        Task<int> CountAsync();

        int Count(Expression<Func<T, bool>> predicate);

        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        IEnumerable<TModel> FindBySql<TModel>(string sql, params SqlParameter[] parameters);
    }

    public interface IRepository<T, TKey> : IRepository<T> where T : class, IEntity<TKey>
    {
        T Get(TKey id);

        Task<T> GetAsync(TKey id);

        T FirstOrDefault(TKey id);

        Task<T> FirstOrDefaultAsync(TKey id);

        TKey InsertAndGetId(T entity);

        Task<TKey> InsertAndGetIdAsync(T entity);

        T Update(TKey id, Action<T> updateAction);

        Task<T> UpdateAsync(TKey id, Func<T, Task> updateAction);

        void Delete(TKey id);

        Task DeleteAsync(TKey id);
    }


}
