using APP.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APP.Application.Users
{
    public interface IUserApplication : IApplication
    {
        IQueryable<User> GetUsers(Expression<Func<User, bool>> predicate);
    }
}
