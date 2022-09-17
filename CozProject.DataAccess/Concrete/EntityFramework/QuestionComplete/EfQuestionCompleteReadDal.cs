using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CozProject.DataAccess.Concrete.EntityFramework
{
    public class EfQuestionCompleteReadDal : EfReadRepository<QuestionComplete>, IQuestionCompleteReadDal
    {
        public EfQuestionCompleteReadDal(DbContext context) : base(context)
        {
        }
    }
}
