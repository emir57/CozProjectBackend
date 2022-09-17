using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProject.DataAccess.Concrete.EntityFramework
{
    public class EfAnswerReadDal : EfReadRepository<Answer>, IAnswerReadDal
    {
        public EfAnswerReadDal(DbContext context) : base(context)
        {
        }
    }
}
