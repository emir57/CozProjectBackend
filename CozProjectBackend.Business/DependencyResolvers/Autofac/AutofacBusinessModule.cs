using Autofac;
using Autofac.Extras.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using CozProject.Business.Abstract;
using CozProject.Business.Concrete;
using CozProject.Business.Concrete.QuestionComplete;
using CozProject.DataAccess.Abstract;
using CozProject.DataAccess.Concrete.EntityFramework;
using CozProject.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CozProject.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region JWT
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
            #endregion

            #region Context
            builder.RegisterType<CozProjectDbContext>().As<DbContext>();
            #endregion

            #region DataAccess
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
            #endregion

            #region Services
            builder.RegisterType<RoleReadManager>().As<IRoleReadService>();
            builder.RegisterType<RoleWriteManager>().As<IRoleWriteService>();
            builder.RegisterType<UserReadManager>().As<IUserReadService>();
            builder.RegisterType<UserWriteManager>().As<IUserWriteService>();
            builder.RegisterType<CategoryCompleteReadManager>().As<ICategoryCompleteReadService>();
            builder.RegisterType<CategoryCompleteWriteManager>().As<ICategoryCompleteWriteService>();
            builder.RegisterType<QuestionCompleteReadManager>().As<IQuestionCompleteReadService>();
            builder.RegisterType<QuestionCompleteWriteManager>().As<IQuestionCompleteWriteService>();
            builder.RegisterType<AnswerReadManager>().As<IAnswerReadService>();
            builder.RegisterType<AnswerWriteManager>().As<IAnswerWriteService>();
            #endregion

            #region Register Assembly
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                });
            #endregion
        }
    }
}
