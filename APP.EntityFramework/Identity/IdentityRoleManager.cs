using APP.Core.Roles;
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
    public class IdentityRoleManager : RoleManager<Role, int>
    {
        public IdentityRoleManager(IRoleStore<Role, int> store)
            : base(store)
        {
        }

        /// <summary>
        /// 提供给Startup中app.CreatePerOwinContext的委托
        /// </summary>
        /// <returns></returns>
        public static IdentityRoleManager Create(IdentityFactoryOptions<IdentityRoleManager> options, IOwinContext context)
        {
            return new IdentityRoleManager(new RoleStore<Role, int, UserRole>(context.Get<APPContext>()));
        }

        public static IdentityRoleManager Create(APPContext dbContext)
        {
            return new IdentityRoleManager(new RoleStore<Role, int, UserRole>(dbContext));
        }
    }
}
