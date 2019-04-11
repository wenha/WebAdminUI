using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using APP.Core;
using APP.Core.Users;

namespace APP.Application.Users
{
    public class UserApplication : ApplicationBase, IUserApplication
    {
        private readonly IRepository<User, int> UserRepository;

        public UserApplication(IRepository<User, int> userRepository)
        {
            UserRepository = userRepository;
        }

        public IQueryable<User> GetUsers(Expression<Func<User, bool>> predicate)
        {
            return UserRepository.GetAll(predicate);
        }
    }
}
