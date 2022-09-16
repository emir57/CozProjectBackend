using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CozProject.DataAccess.Concrete.EntityFramework
{
    public class EfQuestionWriteDal : EfWriteRepository<Question>, IQuestionWriteDal
    {
        public EfQuestionWriteDal(DbContext context) : base(context)
        {
        }
    }
}
