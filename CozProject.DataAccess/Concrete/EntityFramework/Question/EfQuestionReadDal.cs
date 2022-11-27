using Core.DataAccess.EntityFramework;
using CozProject.DataAccess.Abstract;
using CozProject.DataAccess.Contexts;
using CozProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CozProject.DataAccess.Concrete.EntityFramework;

public class EfQuestionReadDal : EfReadRepository<Question>, IQuestionReadDal
{
    private readonly CozProjectDbContext _context;
    public EfQuestionReadDal(CozProjectDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Question>> GetAllWithAnswers(int userId = 0)
    {
        var result = from q in _context.Questions
                     select new Question
                     {
                         Id = q.Id,
                         CategoryId = q.CategoryId,
                         TeacherId = q.TeacherId,
                         Score = q.Score,
                         Content = q.Content,
                         Answers = _context.Answers.Where(x => x.QuestionId == q.Id).ToList(),
                         Result = userId != 0 ? _context.QuestionCompletes.SingleOrDefault(x => x.QuestionId == q.Id && x.UserId == userId).Result : null,
                         CreatedDate = q.CreatedDate,
                         UpdatedDate = q.UpdatedDate
                     };
        return await result.ToListAsync();
    }

    public async Task<List<Question>> GetByCategoryIdWithAnswers(int categoryId, int userId)
    {
        var result = from q in _context.Questions
                     select new Question
                     {
                         Id = q.Id,
                         CategoryId = q.CategoryId,
                         TeacherId = q.TeacherId,
                         Score = q.Score,
                         Content = q.Content,
                         Answers = _context.Answers.Where(x => x.QuestionId == q.Id).ToList(),
                         Result = _context.QuestionCompletes.SingleOrDefault(x => x.QuestionId == q.Id && x.UserId == userId).Result
                     };
        return await result.Where(x => x.CategoryId == categoryId).ToListAsync();
    }

    public Question GetByIdWithAnswers(int questionId)
    {
        var result = from q in _context.Questions
                     where q.Id == questionId
                     select new Question
                     {
                         Id = q.Id,
                         CategoryId = q.CategoryId,
                         TeacherId = q.TeacherId,
                         Score = q.Score,
                         Content = q.Content,
                         Answers = _context.Answers.Where(x => x.QuestionId == q.Id).ToList(),
                         Result = null,
                         CreatedDate = q.CreatedDate,
                         UpdatedDate = q.UpdatedDate
                     };
        return result.First();
    }
}
