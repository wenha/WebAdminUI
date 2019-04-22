using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APP.Common.Reflect
{
    public class AssemblyFinder
    {
        private static readonly string[] AllAssemblies = {
            "APP.Application",
            "APP.Core",
            "APP.EntityFramework",
            "APP.Web",
            "APP.Common",
            "APP.Model"
        };

        public static List<Assembly> GetAllAssemblies()
        {
            var assemblies = AllAssemblies.Select(Assembly.Load).ToList();
            return assemblies.Distinct().ToList();
        }
    }
}
