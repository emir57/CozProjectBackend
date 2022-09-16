using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CozProject.DataAccess.Concrete.EntityFramework
{
    public class EfAnswerWriteDal : EfWriteRepository<Answer>, IAnswerWriteDal
    {
        public EfAnswerWriteDal(DbContext context) : base(context)
        {
        }
    }
}
