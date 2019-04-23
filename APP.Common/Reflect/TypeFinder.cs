using APP.Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APP.Common.Reflect
{
    public static class TypeFinder
    {
        public static Type[] Find(Func<Type, bool> predicate)
        {
            return GetAllTypes().Where(predicate).ToArray();
        }

        public static Type[] FindAll()
        {
            return GetAllTypes().ToArray();
        }

        private static Type[] GetAllTypes()
        {
            return CreateTypeList().ToArray();
        }

        private static List<Type> CreateTypeList()
        {
            var allTypes = new List<Type>();

            var assemblies = AssemblyFinder.GetAllAssemblies();

            foreach (var assembly in assemblies)
            {
                Type[] typesInThisAssembly;

                try
                {
                    typesInThisAssembly = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException ex)
                {
                    typesInThisAssembly = ex.Types;
                }
                if (typesInThisAssembly.IsNullOrEmpty())
                {
                    continue;
                }
                allTypes.AddRange(typesInThisAssembly.Where(type => type != null));
            }
            return allTypes;
        }
    }
}
