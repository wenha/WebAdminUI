﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APP.Common.AutoMapper
{
    internal static class AutoMapperConfigurationExtensions
    {
             public static void CreateAutoAttributeMaps(this IMapperConfigurationExpression configuration, Type type)
        {
            foreach (var autoMapAttribute in type.GetTypeInfo().GetCustomAttributes<AutoMapAttribute>())
            {
                autoMapAttribute.CreateMap(configuration, type);
            }
        }
    }
}
