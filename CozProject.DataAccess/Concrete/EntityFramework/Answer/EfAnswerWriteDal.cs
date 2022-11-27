using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.DataAccess.Contexts;
using CozProject.Entities.Concrete;

namespace CozProject.DataAccess.Concrete.EntityFramework;

public class EfAnswerWriteDal : EfWriteRepository<Answer>, IAnswerWriteDal
{
    public EfAnswerWriteDal(CozProjectDbContext context) : base(context)
    {
    }
}
