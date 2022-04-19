using Core.DataAccess;
using CozProjectBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.DataAccess.Abstract
{
    public interface ICategoryReadDal : IReadRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithComplete(int userId);
    }
}
