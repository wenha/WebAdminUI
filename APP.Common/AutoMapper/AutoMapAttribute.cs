using APP.Common.Collection;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Common.AutoMapper
{
    public class AutoMapAttribute : Attribute
    {
        public Type[] TargetTypes { get; }
        public AutoMapAttribute(params Type[] targetTypes)
        {
            TargetTypes = targetTypes;
        }

        public void CreateMap(IMapperConfigurationExpression configuration, Type type)
        {
            if (TargetTypes.IsNullOrEmpty())
            {
                return;
            }

            foreach (var targetType in TargetTypes)
            {
                configuration.CreateMap(type, targetType, MemberList.Source);
                configuration.CreateMap(targetType, type, MemberList.Destination);
            }
        }
    }
}
