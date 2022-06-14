using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.BusinessAspects;
using CozProjectBackend.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
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
        private readonly ILanguageMessage _languageMessage;
        public RoleReadManager(IRoleReadDal roleReadDal, ILanguageMessage language)
        {
            _roleReadDal = roleReadDal;
            _languageMessage = language;
        }
        [SecuredOperation("Admin")]
        [CacheAspect]
        public async Task<IDataResult<List<Role>>> GetListAsync(bool tracking = true)
        {
            return new SuccessDataResult<List<Role>>(await _roleReadDal.GetAll(tracking).ToListAsync(), _languageMessage.SuccessList);
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<Role>> GetByIdAsync(int id, bool tracking = true)
        {
            Role role = await _roleReadDal.GetByIdAsync(id, tracking);
            if (role == null)
                return new SuccessDataResult<Role>(_languageMessage.RoleNotFound);
            return new SuccessDataResult<Role>(role, _languageMessage.SuccessGet);
        }

        public async Task<IResult> IsInRole(int userId, int roleId)
        {
            var result = await _roleReadDal.IsInRole(userId, roleId);
            if (result)
                return new SuccessResult();
            return new ErrorResult();
        }
    }
}
