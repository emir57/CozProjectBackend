using Core.Entities.Concrete;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Concrete
{
    public class RoleReadManager : IRoleReadService
    {
        private readonly IRoleReadDal _roleReadDal;

        public RoleReadManager(IRoleReadDal roleReadDal)
        {
            _roleReadDal = roleReadDal;
        }

        public IDataResult<IQueryable<Role>> GetAll()
        {
            return new SuccessDataResult<IQueryable<Role>>(_roleReadDal.GetAll());
        }

        public async Task<IDataResult<Role>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Role>(await _roleReadDal.GetByIdAsync(id));
        }
    }
}
