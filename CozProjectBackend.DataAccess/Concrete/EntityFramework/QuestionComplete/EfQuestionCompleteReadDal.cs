using Core.DataAccess.EntityFramework;
using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CozProjectBackend.DataAccess.Concrete.EntityFramework
{
    public class EfQuestionCompleteReadDal : EfReadRepository<QuestionComplete>
    {
        public EfQuestionCompleteReadDal(DbContext context) : base(context)
        {
        }
    }
}
