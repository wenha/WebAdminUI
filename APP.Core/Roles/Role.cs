using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core.Roles
{
    public class Role : IdentityRole<int, UserRole>, IEntity<int>
    {
        public string Description { get; set; }
    }
}
