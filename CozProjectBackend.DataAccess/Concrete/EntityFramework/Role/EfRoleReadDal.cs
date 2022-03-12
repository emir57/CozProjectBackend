using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using CozProjectBackend.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.DataAccess.Concrete.EntityFramework
{
    public class EfRoleReadDal : EfReadRepository<Role>, IRoleReadDal
    {
        public EfRoleReadDal(DbContext context) : base(context)
        {
        }
    }
}
