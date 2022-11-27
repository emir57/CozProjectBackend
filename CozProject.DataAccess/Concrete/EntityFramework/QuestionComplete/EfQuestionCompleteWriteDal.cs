using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.DataAccess.Contexts;
using CozProject.Entities.Concrete;

namespace CozProject.DataAccess.Concrete.EntityFramework
{
    public class EfQuestionCompleteWriteDal : EfWriteRepository<QuestionComplete>, IQuestionCompleteWriteDal
    {
        public EfQuestionCompleteWriteDal(CozProjectDbContext context) : base(context)
        {
        }
    }
}
