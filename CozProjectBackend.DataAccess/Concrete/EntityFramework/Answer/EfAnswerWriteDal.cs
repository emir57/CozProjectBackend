using Core.DataAccess.EntityFramework;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CozProjectBackend.DataAccess.Concrete.EntityFramework
{
    public class EfAnswerWriteDal : EfWriteRepository<Answer>, IAnswerWriteDal
    {
        public EfAnswerWriteDal(DbContext context) : base(context)
        {
        }
    }
}
