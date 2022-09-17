using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProject.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryCompleteReadDal : EfReadRepository<CategoryComplete>, ICategoryCompleteReadDal
    {
        public EfCategoryCompleteReadDal(DbContext context) : base(context)
        {
        }
    }
}
