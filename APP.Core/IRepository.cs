using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core
{
    public interface IRepository
    {
    }

    public interface IRepository<T> : IRepository where T : class
    {

    }

    public interface IRepository<T, TKey> : IRepository<T> where T : class, IEntity<TKey>
    {

    }


}
