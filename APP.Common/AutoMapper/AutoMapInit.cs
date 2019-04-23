using APP.Common.Reflect;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APP.Common.AutoMapper
{
    public class AutoMapInit
    {
        public static void Init()
        {
            Mapper.Initialize(FindAndAutoMapTypes);
        }

        private static void FindAndAutoMapTypes(IMapperConfigurationExpression configuration)
        {
            var types = TypeFinder.Find(type =>
            {
                var typeInfo = type.GetTypeInfo();
                return typeInfo.IsDefined(typeof(AutoMapAttribute));
            }
            );
            foreach (var type in types)
            {
                configuration.CreateAutoAttributeMaps(type);
            }
        }
    }
}
