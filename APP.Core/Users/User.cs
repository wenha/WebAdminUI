using APP.Core.Roles;
using APP.Model.Enum;
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

        public int RoleId { get; set; }

        public EUserType UserType { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
