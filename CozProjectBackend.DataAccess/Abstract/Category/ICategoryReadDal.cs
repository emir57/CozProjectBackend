using Core.DataAccess;
using CozProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.DataAccess.Abstract
{
    public interface ICategoryReadDal : IReadRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithComplete(int userId);
    }
}
