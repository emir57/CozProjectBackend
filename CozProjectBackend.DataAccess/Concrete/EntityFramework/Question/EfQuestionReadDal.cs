using Core.DataAccess.EntityFramework;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.DataAccess.Concrete.EntityFramework
{
    public class EfQuestionReadDal : EfReadRepository<Question>, IQuestionReadDal
    {
        public EfQuestionReadDal(DbContext context) : base(context)
        {
        }
    }
}
