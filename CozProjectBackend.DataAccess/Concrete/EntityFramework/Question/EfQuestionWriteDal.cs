using Core.DataAccess.EntityFramework;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CozProjectBackend.DataAccess.Concrete.EntityFramework
{
    public class EfQuestionWriteDal : EfWriteRepository<Question>, IQuestionWriteDal
    {
        public EfQuestionWriteDal(DbContext context) : base(context)
        {
        }
    }
}
