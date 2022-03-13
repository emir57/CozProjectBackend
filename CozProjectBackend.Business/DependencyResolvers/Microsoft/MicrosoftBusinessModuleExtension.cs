using Core.Utilities.Security.JWT;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.Concrete;
using CozProjectBackend.Business.Constants;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.DataAccess.Concrete.EntityFramework;
using CozProjectBackend.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.Business.DependencyResolvers.Microsoft
{
    public static class MicrosoftBusinessModuleExtension
    {
        public static IServiceCollection AddMicrosoftBusinessModule(this IServiceCollection services)
        {
            services.AddSingleton<ILanguage, EnglishLanguageMessage>();
            services.AddSingleton<ITokenHelper, JwtHelper>();
            services.AddScoped<DbContext, CozProjectDbContext>();
            services.AddScoped<IRoleWriteDal, EfRoleWriteDal>();
            services.AddScoped<IRoleReadDal, EfRoleReadDal>();
            services.AddScoped<IRoleReadService, RoleReadManager>();
            services.AddScoped<IRoleWriteService, RoleWriteManager>();
            return services;
        }
    }
}
