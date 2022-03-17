using Core.DataAccess.EntityFramework;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.DataAccess.Concrete.EntityFramework
{
    public class EfAnswerReadDal : EfReadRepository<Answer>, IAnswerReadDal
    {
        public EfAnswerReadDal(DbContext context) : base(context)
        {
        }
    }
}
