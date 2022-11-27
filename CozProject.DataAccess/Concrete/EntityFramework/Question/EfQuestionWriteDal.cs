using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.DataAccess.Contexts;
using CozProject.Entities.Concrete;

namespace CozProject.DataAccess.Concrete.EntityFramework;

public class EfQuestionWriteDal : EfWriteRepository<Question>, IQuestionWriteDal
{
    public EfQuestionWriteDal(CozProjectDbContext context) : base(context)
    {
    }
}
