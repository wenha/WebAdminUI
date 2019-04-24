using APP.Common.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP.Web.App_Start
{
    public class AutoMapConfig
    {
        public static void RegisterAutoMap()
        {
            AutoMapInit.Init();
        }
    }
}