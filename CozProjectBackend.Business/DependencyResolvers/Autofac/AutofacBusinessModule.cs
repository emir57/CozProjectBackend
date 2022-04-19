using Autofac;
using Autofac.Extras.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Message;
using Core.Utilities.Message.English;
using Core.Utilities.Message.Turkish;
using Core.Utilities.Security.JWT;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.Concrete;
using CozProjectBackend.Business.Concrete.QuestionComplete;
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
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            builder.RegisterType<CozProjectDbContext>().As<DbContext>();
            //DataAccess
            builder.RegisterType<EfRoleWriteDal>().As<IRoleWriteDal>();
            builder.RegisterType<EfRoleReadDal>().As<IRoleReadDal>();
            builder.RegisterType<EfUserWriteDal>().As<IUserWriteDal>();
            builder.RegisterType<EfUserReadDal>().As<IUserReadDal>();
            builder.RegisterType<EfQuestionWriteDal>().As<IQuestionWriteDal>();
            builder.RegisterType<EfQuestionReadDal>().As<IQuestionReadDal>();
            builder.RegisterType<EfAnswerReadDal>().As<IAnswerReadDal>();
            builder.RegisterType<EfAnswerWriteDal>().As<IAnswerWriteDal>();
            builder.RegisterType<EfCategoryReadDal>().As<ICategoryReadDal>();
            builder.RegisterType<EfCategoryWriteDal>().As<ICategoryWriteDal>();
            builder.RegisterType<EfCategoryCompleteReadDal>().As<ICategoryCompleteReadDal>();
            builder.RegisterType<EfCategoryCompleteWriteDal>().As<ICategoryCompleteWriteDal>();
            builder.RegisterType<EfQuestionCompleteReadDal>().As<IQuestionCompleteReadDal>();
            builder.RegisterType<EfQuestionCompleteWriteDal>().As<IQuestionCompleteWriteDal>();
            //Services
            builder.RegisterType<RoleReadManager>().As<IRoleReadService>();
            builder.RegisterType<RoleWriteManager>().As<IRoleWriteService>();
            builder.RegisterType<UserReadManager>().As<IUserReadService>();
            builder.RegisterType<UserWriteManager>().As<IUserWriteService>();
            builder.RegisterType<CategoryCompleteReadManager>().As<ICategoryCompleteReadService>();
            builder.RegisterType<CategoryCompleteWriteManager>().As<ICategoryCompleteWriteService>();
            builder.RegisterType<QuestionCompleteReadManager>().As<IQuestionCompleteReadService>();
            builder.RegisterType<QuestionCompleteWriteManager>().As<IQuestionCompleteWriteService>();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                });

            builder.RegisterType<TurkishLanguageMessage>().As<ILanguageMessage>();
            base.Load(builder);
        }
    }
}
