using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Entities.FluentEntities
{
    public interface IFluentEntity<T>
        where T : class, new()
    {
        IFluentEntity<T> AddParameter<P>(Expression<Func<T, P>> exp, object value);
    }
}
