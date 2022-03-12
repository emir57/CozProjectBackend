using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.DataAccess
{
    public interface IRepository<T>
        where T:class,IEntity,new()
    {
        DbSet<T> Table { get; }
    }
}
