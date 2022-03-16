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
        public IDataResult<IQueryable<Role>> GetAll()
        {
            return new SuccessDataResult<IQueryable<Role>>(_roleReadDal.GetAll(),_languageMessage.SuccessGet);
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
