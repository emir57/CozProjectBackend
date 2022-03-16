using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.AspectMessage;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _loggingType;
        public ValidationAspect(Type loggingType)
        {
            if (!typeof(IValidator).IsAssignableFrom(loggingType))
            {
                throw new System.Exception(AspectMessages.WrongValidationType);
            }
            _loggingType = loggingType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            IValidator validator = (IValidator)Activator.CreateInstance(_loggingType);
            var entityType = _loggingType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(x => x.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
