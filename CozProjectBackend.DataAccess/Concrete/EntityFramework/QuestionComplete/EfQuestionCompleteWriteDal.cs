using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProject.DataAccess.Concrete.EntityFramework
{
    public class EfQuestionCompleteWriteDal : EfWriteRepository<QuestionComplete>, IQuestionCompleteWriteDal
    {
        public EfQuestionCompleteWriteDal(DbContext context) : base(context)
        {
        }
    }
}
