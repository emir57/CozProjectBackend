using Core.DataAccess.EntityFramework;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CozProjectBackend.DataAccess.Concrete.EntityFramework
{
    public class EfQuestionCompleteReadDal : EfReadRepository<QuestionComplete>, IQuestionCompleteReadDal
    {
        public EfQuestionCompleteReadDal(DbContext context) : base(context)
        {
        }
    }
}
