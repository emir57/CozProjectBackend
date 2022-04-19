using Core.DataAccess;
using CozProjectBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.DataAccess.Abstract
{
    public interface IQuestionReadDal : IReadRepository<Question>
    {
        Task<List<Question>> GetAllWithAnswers();
    }
}
