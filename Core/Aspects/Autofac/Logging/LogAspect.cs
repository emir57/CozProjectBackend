using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.AspectMessage;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;

namespace Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        private IHttpContextAccessor _httpContextAccessor;
        public LogAspect(Type logger)
        {
            if (!typeof(LoggerServiceBase).IsAssignableFrom(logger))
            {
                throw new System.Exception(AspectMessages.WrongLoggingType);
            }
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(logger);
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase.Info(GetMethodDetail(invocation));
        }

        private LogDetail GetMethodDetail(IInvocation invocation)
        {
            List<LogParameter> parameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                parameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Type = invocation.Arguments[i].GetType().ToString(),
                    Value = invocation.Arguments[i]
                });
            }
            string userEmail = _httpContextAccessor.HttpContext.User.ClaimEmail();
            List<string> userRoles = _httpContextAccessor.HttpContext.User.ClaimRoles();
            LogDetail logDetail = new LogDetail
            {
                LogParameters = parameters,
                MethodName = invocation.Method.Name,
                UserEmail = userEmail,
                UserRoles = userRoles
            }
            return logDetail;
        }
    }
}
