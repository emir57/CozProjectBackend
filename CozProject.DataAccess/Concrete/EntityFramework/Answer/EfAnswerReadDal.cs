using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.DataAccess.Contexts;
using CozProject.Entities.Concrete;

namespace CozProject.DataAccess.Concrete.EntityFramework;

public class EfAnswerReadDal : EfReadRepository<Answer>, IAnswerReadDal
{
    public EfAnswerReadDal(CozProjectDbContext context) : base(context)
    {
    }
}
