using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.AspectMessage;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace Core.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        private IHttpContextAccessor _httpContextAccessor;
        public ExceptionLogAspect(Type logger)
        {
            if (!typeof(LoggerServiceBase).IsAssignableFrom(logger))
            {
                throw new System.Exception(AspectMessages.WrongLoggingType);
            }
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(logger);
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            base.OnException(invocation, e);
        }
    }
}
