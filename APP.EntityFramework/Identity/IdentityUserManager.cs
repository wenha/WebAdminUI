using APP.Core.Roles;
using APP.Core.Users;
using APP.EntityFramework.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.EntityFramework.Identity
{
    public class IdentityUserManager : UserManager<User, int>
    {
        public IdentityUserManager(IUserStore<User, int> store)
            : base(store)
        {
        }

        /// <summary>
        /// 提供给Startup中app.CreatePerOwinContext的委托
        /// </summary>
        /// <returns></returns>
        public static IdentityUserManager Create(IdentityFactoryOptions<IdentityUserManager> options, IOwinContext context)
        {
            var dbContext = context.Get<APPContext>();
            var manager = new IdentityUserManager(new UserStore<User, Role, int, UserLogin, UserRole, UserClaim>(dbContext));
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<User, int>(dataProtectionProvider.Create("FabCmp Identity"));
            }
            return manager;
        }

        public static IdentityUserManager Create(APPContext dbContext)
        {
            return new IdentityUserManager(
                new UserStore<User, Role, int, UserLogin, UserRole, UserClaim>(dbContext));
        }
    }
}
