using Core.DataAccess;
using CozProjectBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.DataAccess.Abstract
{
    public interface ICategoryReadDal : IReadRepository<Category>
    {
    }
}
