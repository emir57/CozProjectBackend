using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.DataAccess.Contexts;
using CozProject.Entities.Concrete;

namespace CozProject.DataAccess.Concrete.EntityFramework;

public class EfQuestionCompleteReadDal : EfReadRepository<QuestionComplete>, IQuestionCompleteReadDal
{
    public EfQuestionCompleteReadDal(CozProjectDbContext context) : base(context)
    {
    }
}
