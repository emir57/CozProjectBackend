using Core.Utilities.Result;
using CozProject.Entities.Concrete;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract
{
    public interface ICategoryWriteService
    {
        Task<IResult> AddAsync(Category entity);
        IResult Update(Category entity);
        IResult Delete(Category entity);
        Task<int> SaveAsync();
    }
}
