using Core.Utilities.Result;
using CozProjectBackend.Entities.Concrete;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Abstract
{
    public interface ICategoryCompleteWriteService
    {
        Task<IResult> AddAsync(CategoryComplete categoryComplete);
        IResult Delet(CategoryComplete categoryComplete);
    }
}
