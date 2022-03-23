using Core.Aspects.Autofac.Validation;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
using CozProjectBackend.Business.Validators.FluentValidation;
using CozProjectBackend.DataAccess.Abstract;
using CozProjectBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CozProjectBackend.Business.Concrete
{
    public class IQuestionWriteManager : IQuestionWriteService
    {
        private readonly IQuestionWriteDal _questionWriteDal;
        private readonly ILanguageMessage _language;

        public IQuestionWriteManager(IQuestionWriteDal questionWriteDal, ILanguageMessage language)
        {
            _questionWriteDal = questionWriteDal;
            _language = language;
        }
        [ValidationAspect(typeof(QuestionValidator))]
        public async Task<IResult> AddAsync(Question question)
        {
            bool result = await _questionWriteDal.AddAsync(question);
            if (result)
                return new SuccessResult(_language.SuccessAdd);
            return new ErrorResult(_language.FailureAdd);
        }

        public IResult Delete(Question question)
        {
            _questionWriteDal.Delete(question);
            return new SuccessResult(_language.SuccessDelete);
        }

        public async Task<int> SaveAsync()
        {
            return await _questionWriteDal.SaveAsync();
        }
        [ValidationAspect(typeof(QuestionValidator))]
        public IResult Update(Question question)
        {
            bool result = _questionWriteDal.Update(question);
            if (result)
                return new SuccessResult(_language.SuccessUpdate);
            return new ErrorResult(_language.FailureUpdate);
        }
    }
}
