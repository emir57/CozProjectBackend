using Core.DataAccess.EntityFramework;
using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.DataAccess.Concrete.EntityFramework
{
    public class EfQuestionCompleteWriteDal : EfWriteRepository<QuestionComplete>
    {
        public EfQuestionCompleteWriteDal(DbContext context) : base(context)
        {
        }
    }
}
