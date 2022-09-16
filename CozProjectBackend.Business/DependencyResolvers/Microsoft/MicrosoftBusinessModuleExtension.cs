using Core.Utilities.Security.JWT;
using CozProject.DataAccess.Abstract;
using CozProject.DataAccess.Concrete.EntityFramework;
using CozProject.DataAccess.Contexts;
using CozProject.Business.Abstract;
using CozProject.Business.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CozProject.Business.DependencyResolvers.Microsoft
{
    public static class MicrosoftBusinessModuleExtension
    {
        public static IServiceCollection AddMicrosoftBusinessModule(this IServiceCollection services)
        {
            services.AddSingleton<ITokenHelper, JwtHelper>();
            services.AddScoped<DbContext, CozProjectDbContext>();
            services.AddScoped<IRoleWriteDal, EfRoleWriteDal>();
            services.AddScoped<IRoleReadDal, EfRoleReadDal>();
            services.AddScoped<IRoleReadService, RoleReadManager>();
            services.AddScoped<IRoleWriteService, RoleWriteManager>();

            services.AddScoped<IQuestionReadDal, EfQuestionReadDal>();
            services.AddScoped<IQuestionWriteDal, EfQuestionWriteDal>();

            services.AddScoped<IAnswerReadDal, EfAnswerReadDal>();
            services.AddScoped<IAnswerWriteDal, EfAnswerWriteDal>();

            services.AddScoped<ICategoryReadDal, EfCategoryReadDal>();
            services.AddScoped<ICategoryWriteDal, EfCategoryWriteDal>();
            return services;
        }
    }
}
