using Core.DataAccess.EntityFramework;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CozProjectBackend.DataAccess.Concrete.EntityFramework
{
    public class EfQuestionReadDal : EfReadRepository<Question>, IQuestionReadDal
    {
        private readonly DbContext _context;
        public EfQuestionReadDal(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetAllWithAnswers()
        {
            var result = from q in _context.Set<Question>()
                         select new Question
                         {
                             Id = q.Id,
                             CategoryId = q.CategoryId,
                             TeacherId = q.TeacherId,
                             Score = q.Score,
                             Content = q.Content,
                             Answers = _context.Set<Answer>().Where(x => x.QuestionId == q.Id).ToList(),
                             
                         };
            return await result.ToListAsync();
        }
    }
}
