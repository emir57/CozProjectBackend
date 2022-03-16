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
        public async Task<IDataResult<List<Role>>> GetAllAsync()
        {
            return new SuccessDataResult<List<Role>>(await _roleReadDal.GetAll().ToListAsync(),_languageMessage.SuccessGet);
        }

        public async Task<IDataResult<Role>> GetByIdAsync(int id)
        {
            Role role = await _roleReadDal.GetByIdAsync(id);
            if (role == null)
                return new SuccessDataResult<Role>(_languageMessage.RoleNotFound);
            return new SuccessDataResult<Role>(role,_languageMessage.SuccessGet);
        }
    }
}
