using Core.Entities.Concrete;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.Constants;
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
        private readonly ILanguage _language;
        public RoleReadManager(IRoleReadDal roleReadDal, ILanguage language)
        {
            _roleReadDal = roleReadDal;
            _language = language;
        }

        public IDataResult<IQueryable<Role>> GetAll()
        {
            return new SuccessDataResult<IQueryable<Role>>(_roleReadDal.GetAll(),_language.SuccessGet);
        }

        public async Task<IDataResult<Role>> GetByIdAsync(int id)
        {
            Role role = await _roleReadDal.GetByIdAsync(id);
            if(role == null)
                return new SuccessDataResult<Role>(_language.)
            return new SuccessDataResult<Role>();
        }
    }
}
