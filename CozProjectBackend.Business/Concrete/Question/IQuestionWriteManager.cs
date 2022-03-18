using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProjectBackend.Business.Abstract;
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

        public async Task<IResult> AddAsync(Question question)
        {
            bool result = await _questionWriteDal.AddAsync(question);
            if (result)
                return new SuccessResult(_language.SuccessAdd);
            return new ErrorResult(_language.FailureAdd);
        }

        public IResult Delete(Question question)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
