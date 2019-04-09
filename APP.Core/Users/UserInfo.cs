using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core.Users
{
    public class UserInfo : IEntity<int>
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string CertNo { get; set; }

        public string Phone { get; set; }

        public string Sex { get; set; }

        public string Province { get; set; }

        public string ProvinceCode { get; set; }

        public bool IsDelete { get; set; }
    }
}
