using APP.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APP.EntityFramework.Repository
{
    /// <summary>
    /// 仓储基类，DbContext的抽象，定义了常用的普通方法和异步方法
    /// </summary>
    /// <typeparam name="TDbContext"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class RepositoryBase<TDbContext, TEntity> where TEntity : class where TDbContext : DbContext, new()
    {
        public abstract TDbContext Context { get; set; }

        public virtual DbSet<TEntity> Table => Context.Set<TEntity>();

        public virtual IQueryable<TEntity> GetAll()
        {
            return Table;
        }

        /// <summary>
        /// 根据lambda表达式从数据表中获取数据，返回IQueryable类型
        /// </summary>
        /// <param name="predicate">lambda表达式</param>
        /// <returns>IQueryable类型</returns>
        public virtual IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        /// <summary>
        /// 获取数据表中所有数据，并返回List集合类型
        /// </summary>
        /// <returns>list类型</returns>
        public virtual List<TEntity> GetAllList()
        {
            return Table.ToList();
        }

        /// <summary>
        /// 异步获取数据表中所有数据，返回List集合类型
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> GetAllListAsync()
        {
            return await Table.ToListAsync();
        }

        /// <summary>
        /// 根据lambda表达式从数据表中获取数据，返回List集合类型
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        /// <summary>
        /// 根据lambda表达式从数据表中异步获取数据，返回List集合类型
        /// </summary>
        /// <param name="predicate">lambda表达式</param>
        /// <returns>List集合类型</returns>
        public virtual async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.Where(predicate).ToListAsync();
        }

        /// <summary>
        /// 向数据表中插入一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual TEntity Insert(TEntity entity)
        {
            return Table.Add(entity);
        }

        /// <summary>
        /// 向数据表中批量插入多条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Insert(IEnumerable<TEntity> entities)
        {
            return Table.AddRange(entities);
        }

        /// <summary>
        /// 向数据表中异步插入一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Task<TEntity> InsertAsync(TEntity entity)
        {
            return Task.FromResult(Table.Add(entity));
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            if (!Table.Local.Contains(entity))
            {
                Table.Attach(entity);
            }
        }

        /// <summary>
        /// 更改数据表中的一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        /// <summary>
        /// 异步更改数据表中的一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity);
        }

        /// <summary>
        /// 插入或更改数据表中多条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual void InsertOrUpdate(params TEntity[] entities)
        {
            Table.AddOrUpdate(entities);
        }

        /// <summary>
        /// 删除数据表中的一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual void Delete(TEntity entity)
        {
            AttachIfNot(entity);
            Table.Remove(entity);
        }

        /// <summary>
        /// 异步删除数据表中的一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Task DeleteAsync(TEntity entity)
        {
            Delete(entity);
            return Task.FromResult(0);
        }

        /// <summary>
        /// 根据lambda表达式删除数据表中的记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            foreach (var entity in GetAll().Where(predicate).ToList())
            {
                Delete(entity);
            }
        }

        /// <summary>
        /// 根据lambda表达式异步删除数据表中的记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            Delete(predicate);
            return Task.FromResult(0);
        }

        /// <summary>
        /// 统计数据表中的总记录数
        /// </summary>
        /// <returns></returns>
        public virtual int Count()
        {
            return GetAll().Count();
        }

        /// <summary>
        /// 异步统计数据表中的总记录数
        /// </summary>
        /// <returns></returns>
        public virtual async Task<int> CountAsync()
        {
            return await Table.CountAsync();
        }

        /// <summary>
        /// 根据lambda表达式统计数据表中的记录数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).Count();
        }

        /// <summary>
        /// 根据lambda表达式异步统计数据表中的记录数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.Where(predicate).CountAsync();
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parametes"></param>
        /// <returns></returns>
        public virtual IEnumerable<TModel> FindBySql<TModel>(string sql, params SqlParameter[] parametes)
        {
            return parametes.Any() ? Context.Database.SqlQuery<TModel>(sql, parametes) : Context.Database.SqlQuery<TModel>(sql);
        }
    }

    public abstract class RepositoryBase<TDbContext, TEntity, TPrimaryKey> : RepositoryBase<TDbContext, TEntity> where TEntity : class, IEntity<TPrimaryKey> where TDbContext : DbContext, new()
    {
        /// <summary>
        /// 创建外键关联
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressioinForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(Expression.PropertyOrField(lambdaParam, "Id"), Expression.Constant(id, typeof(TPrimaryKey)));

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }

        /// <summary>
        /// 根据外键Id查询数据表中记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity FirstOrDefault(TPrimaryKey id)
        {
            return GetAll().FirstOrDefault(CreateEqualityExpressioinForId(id));
        }

        /// <summary>
        /// 根据外键Id异步查询数据表中记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return await Table.FirstOrDefaultAsync(CreateEqualityExpressioinForId(id));
        }

        public virtual TEntity Get(TPrimaryKey id)
        {
            var entity = FirstOrDefault(id);
            if (entity == null)
            {
                throw new Exception("未找到对应实体");
            }
            return entity;
        }

        public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            var entity = await FirstOrDefaultAsync(id);
            if (entity == null)
            {
                throw new Exception("未找到对应实体");
            }
            return entity;
        }

        public virtual TPrimaryKey InsertAndGetId(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
            return entity.Id;
        }

        public virtual Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            return Task.FromResult(InsertAndGetId(entity));
        }

        public virtual TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
        {
            var entity = Get(id);
            updateAction(entity);
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction)
        {
            var entity = await GetAsync(id);
            await updateAction(entity);
            return entity;
        }
        public virtual void Delete(TPrimaryKey id)
        {
            var entity = Table.Local.FirstOrDefault(ent => EqualityComparer<TPrimaryKey>.Default.Equals(ent.Id, id));
            if (entity == null)
            {
                entity = FirstOrDefault(id);
                if (entity == null)
                {
                    return;
                }
            }
            Delete(entity);
        }
        public virtual Task DeleteAsync(TPrimaryKey id)
        {
            Delete(id);
            return Task.FromResult(0);
        }
    }
}
