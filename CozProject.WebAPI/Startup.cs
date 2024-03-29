using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.Message.Turkish;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using CozProject.Business.Helpers;
using CozProject.DataAccess.Contexts;
using CozProject.WebAPI.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CozProjectBackend.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region SignalR
            services.AddSignalR();
            #endregion

            #region Context
            services.AddDbContext<CozProjectDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MsSqlConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                }));
            #endregion

            #region AutoMapper
            services.AddAutoMapper(typeof(AutoMapperHelper));
            #endregion

            //services.AddMicrosoftBusinessModule();
            services.AddControllers();

            #region JWT
            TokenOptions tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
            #endregion

            #region CoreModule
            services.AddDependencyResolvers(
                new CoreModule());
            #endregion

            #region Cors
            services.AddCors(opt =>
            {
                opt.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("http://localhost:8100");
                });
            });
            #endregion

            #region ResultMessage
            services.AddResultMessage((builder) =>
            {
                builder.LanguageMessage = new TurkishLanguageMessage();
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors();

            app.UseCustomMiddleware();

            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ScoreHub>("/scorehub");
            });
        }
    }
}
