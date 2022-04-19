using Core.DataAccess.EntityFramework;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryCompleteReadDal : EfReadRepository<CategoryComplete>, ICategoryCompleteReadDal
    {
        public EfCategoryCompleteReadDal(DbContext context) : base(context)
        {
        }
    }
}
