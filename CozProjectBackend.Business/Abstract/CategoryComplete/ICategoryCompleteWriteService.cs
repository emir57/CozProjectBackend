using Core.Utilities.Result;
using CozProject.Entities.Concrete;
using System.Threading.Tasks;

namespace CozProject.Business.Abstract
{
    public interface ICategoryCompleteWriteService
    {
        Task<IResult> AddAsync(CategoryComplete categoryComplete);
        IResult Delete(CategoryComplete categoryComplete);
    }
}
