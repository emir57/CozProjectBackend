﻿using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.BusinessAspects;
using CozProjectBackend.Business.Validators.FluentValidation;
using CozProjectBackend.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Concrete
{
    public class RoleWriteManager : IRoleWriteService
    {
        private readonly IRoleWriteDal _roleWriteDal;
        private readonly IRoleReadService _roleReadService;
        private readonly ILanguageMessage _languageMessage;
        public RoleWriteManager(IRoleWriteDal roleWriteDal, ILanguageMessage language, IRoleReadService roleReadService)
        {
            _roleWriteDal = roleWriteDal;
            _languageMessage = language;
            _roleReadService = roleReadService;
        }
        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(RoleValidator))]
        [CacheRemoveAspect("IRoleReadService.Get")]
        public async Task<IResult> AddAsync(Role entity)
        {
            bool result = await _roleWriteDal.AddAsync(entity);
            if (result)
                return new SuccessResult(_languageMessage.SuccessAdd);
            return new ErrorResult(_languageMessage.FailureAdd);
        }
        
        public async Task AddUserRoleAsync(int userId, int roleId)
        {
            var checkRole = await _roleReadService.IsInRole()
            await _roleWriteDal.AddUserRoleAsync(userId, roleId);
        }

        [SecuredOperation("Admin")]
        [CacheRemoveAspect("IRoleReadService.Get")]
        public IResult Delete(Role entity)
        {
            _roleWriteDal.Delete(entity);
            return new SuccessResult(_languageMessage.SuccessDelete);
        }

        public async Task RemoveUserRoleAsync(int userId, int roleId)
        {
            await _roleWriteDal.RemoveUserRoleAsync(userId, roleId);
        }

        [CacheRemoveAspect("IRoleReadService.Get")]
        public Task<int> SaveAsync()
        {
            return _roleWriteDal.SaveAsync();
        }
        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(RoleValidator))]
        [CacheRemoveAspect("IRoleReadService.Get")]
        public IResult Update(Role entity)
        {
            bool result = _roleWriteDal.Update(entity);
            if (result)
                return new SuccessResult(_languageMessage.SuccessUpdate);
            return new ErrorResult(_languageMessage.FailureUpdate);
        }
    }
}
