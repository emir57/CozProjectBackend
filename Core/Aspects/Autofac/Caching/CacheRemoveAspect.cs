using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.IoC;
using Castle.DynamicProxy;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cache;
        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cache = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        protected override void OnSuccess(IInvocation invocation)
        {
            _cache.RemoveByPattern(_pattern);
        }
    }
}
