using Autofac;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.Concrete;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfRoleWriteDal>().As<IRoleWriteDal>();
            builder.RegisterType<EfRoleReadDal>().As<IRoleReadDal>();

            builder.RegisterType<RoleReadManager>().As<IRoleReadService>();
            builder.RegisterType<RoleWriteManager>().As<IRoleWriteService>();
            base.Load(builder);
        }
    }
}
