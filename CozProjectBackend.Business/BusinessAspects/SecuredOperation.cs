using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Exception.UnAuthorizedException;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CozProject.Business.BusinessAspects
{
    public class SecuredOperation : MethodInterception
    {
        private IHttpContextAccessor _httpContextAccessor;
        private string[] _roles;
        private ILanguageMessage _languageMessage;
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(",");
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            _languageMessage = ServiceTool.ServiceProvider.GetService<ILanguageMessage>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            List<string> claims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (claims.Contains(role))
                    return;
            }
            throw new UnAuthorizedException(_languageMessage.UnAuthorize);
        }
    }
}
