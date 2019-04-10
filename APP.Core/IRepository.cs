using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core
{
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


    }

    public interface IRepository<T, TKey> : IRepository<T> where T : class, IEntity<TKey>
    {

    }


}
