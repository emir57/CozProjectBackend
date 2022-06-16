using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Core.Entities.FluentEntities
{
    public class FluentEntity<T>
        where T : class, IEntity, new()
    {
        private T entity;
        public FluentEntity()
        {
            entity = new T();
        }
        public FluentEntity<T> AddParameter(Expression<Func<T, object>> exp, object value)
        {
            var a = exp.ToString();
            PropertyInfo propertyInfo = entity.GetType().GetProperty(exp.ToString());
            propertyInfo.SetValue(entity, value);
            return this;
        }
    }
}
