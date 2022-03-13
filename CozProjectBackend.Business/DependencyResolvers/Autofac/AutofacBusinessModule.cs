using Autofac;
using Autofac.Extras.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.Concrete;
using CozProjectBackend.Business.Constants;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.DataAccess.Concrete.EntityFramework;
using CozProjectBackend.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TurkishLanguageMessage>().As<ILanguage>();

            builder.RegisterType<ITokenHelper>().As<JwtHelper>();

            builder.RegisterType<CozProjectDbContext>().As<DbContext>();

            builder.RegisterType<EfRoleWriteDal>().As<IRoleWriteDal>();
            builder.RegisterType<EfRoleReadDal>().As<IRoleReadDal>();

            builder.RegisterType<RoleReadManager>().As<IRoleReadService>();
            builder.RegisterType<RoleWriteManager>().As<IRoleWriteService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                });

            base.Load(builder);
        }
    }
}
