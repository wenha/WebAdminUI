using APP.Application;
using APP.Common;
using APP.Common.Reflect;
using APP.Core;
using APP.EntityFramework.Context;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APP.Web.App_Start
{
    public class IOCConfig
    {
        public static void RegisterDependency()
        {
            var assemblies = AssemblyFinder.GetAllAssemblies();
            var builder = new ContainerBuilder();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                // 注册所有实现了IDependency标记接口的类
                var dependencyTypes = types.Where(type =>
                    (typeof(IDependency).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)).ToArray();
                builder.RegisterTypes(dependencyTypes)
                    // 开启属性注入
                    .PropertiesAutowired()
                    .AsImplementedInterfaces()
                    .AsSelf()
                    // 相同作用域同一个实例
                    .InstancePerLifetimeScope();

                // 注册所有实现了IApplication标记接口的类
                var applicationTypes = types.Where(type =>
                    (typeof(IApplication).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)).ToArray();
                builder.RegisterTypes(applicationTypes)
                    // 开启属性注入
                    .PropertiesAutowired()
                    .AsImplementedInterfaces()
                    // 相同作用域同一个实例
                    .InstancePerLifetimeScope();

                // 注册所有泛型仓储类
                var repositoryTypes = types
                    .Where(type => typeof(IRepository).IsAssignableFrom(type) && !type.IsInterface).ToArray();
                foreach (var repositoryType in repositoryTypes)
                {
                    if (repositoryType.GetGenericArguments().Length == 1)
                    {
                        builder.RegisterGeneric(repositoryType)
                            .As(typeof(IRepository<>))
                            .InstancePerLifetimeScope();
                    }
                    else
                    {
                        builder.RegisterGeneric(repositoryType)
                            .As(typeof(IRepository<,>))
                            .InstancePerLifetimeScope();
                    }
                }

                // 注册所有数据库上下文
                var dbContextTypes = types.Where(type =>
                    (typeof(IContextDependency).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)).ToArray();
                builder.RegisterTypes(dbContextTypes)
                    // 开启属性注入
                    .PropertiesAutowired()
                    .AsSelf()
                    // 设置对象生命周期基于请求
                    .InstancePerRequest();
            }
            // 注册Mvc控制器
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            builder.RegisterFilterProvider();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}