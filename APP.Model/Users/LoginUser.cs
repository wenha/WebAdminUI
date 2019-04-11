using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Model.Users
{
    public class LoginUser
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string RealName { get; set; }

        public int RoleId { get; set; }
    }
}
