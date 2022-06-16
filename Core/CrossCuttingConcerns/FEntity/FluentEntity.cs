using System;
using System.Collections.Generic;
using System.Text;

namespace FluentEntity_ConsoleApp.FEntity
{
    public class FluentEntity<T> : FluentEntityBase<T>
        where T : class, new()
    {
        public FluentEntity()
        {
        }

        public FluentEntity(T entity) : base(entity)
        {
        }
    }
}
