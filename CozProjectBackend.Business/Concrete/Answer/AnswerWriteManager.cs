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
    public class AnswerWriteManager : IAnswerWriteService
    {
        private readonly IAnswerWriteDal _answerWriteDal;
        private readonly ILanguageMessage _language;

        public AnswerWriteManager(IAnswerWriteDal answerWriteDal, ILanguageMessage language)
        {
            _answerWriteDal = answerWriteDal;
            _language = language;
        }

        public async Task<IResult> AddAsync(Answer answer)
        {
            bool result = await _answerWriteDal.AddAsync(answer);
            if (result)
                return new SuccessResult(_language.SuccessAdd);
            return new ErrorResult(_language.FailureAdd);
        }

        public IResult Delete(Answer answer)
        {
            _answerWriteDal.Delete(answer);
            return new SuccessResult(_language.SuccessDelete);
        }

        public async Task<int> SaveAsync()
        {
            return await _answerWriteDal.SaveAsync();
        }

        public IResult Update(Answer answer)
        {
            bool result = _answerWriteDal.Update(answer);
            if (result)
                return new SuccessResult(_language.SuccessUpdate);
            return new ErrorResult(_language.FailureUpdate);
        }
    }
}
