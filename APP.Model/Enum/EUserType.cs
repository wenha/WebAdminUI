using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Model.Enum
{
    public enum EUserType
    {
        None = 0,

        /// <summary>
        ///前台用户
        /// </summary>
        User = 1,

        /// <summary>
        /// 后台用户
        /// </summary>
        SystemAdmin = 2
    }
}
