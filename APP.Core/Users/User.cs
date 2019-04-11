using APP.Core.Roles;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core.Users
{
    public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>, IEntity<int>
    {
        public string RealName { get; set; }
    }
}
