using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
            var a = exp;
            var v = value;
            return this;
        }
    }
}
