using APP.Core;
using APP.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.EntityFramework.Repository
{
    public class ContractRepository<TEntity> : RepositoryBase<APPContext, TEntity>, IRepository<TEntity>
        where TEntity : class
    {
        public sealed override APPContext Context { get; set; }

        public ContractRepository(APPContext context)
        {
            Context = context;
        }
    }

    public class ContractRepository<TEntity, TPrimaryKey> : RepositoryBase<APPContext, TEntity, TPrimaryKey>, IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public sealed override APPContext Context { get; set; }

        public ContractRepository(APPContext context)
        {
            Context = context;
        }
    }
}
