using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
    public class AnswerWriteManager : IAnswerWriteService
    {
        private readonly IAnswerWriteDal _answerWriteDal;
        private readonly ILanguageMessage _language;

        public AnswerWriteManager(IAnswerWriteDal answerWriteDal, ILanguageMessage language)
        {
            _answerWriteDal = answerWriteDal;
            _language = language;
        }
        [ValidationAspect(typeof(AnswerValidator))]
        public async Task<IResult> AddAsync(Answer answer)
        {
            bool result = await _answerWriteDal.AddAsync(answer);
            if (result)
                return new SuccessResult(_language.SuccessAdd);
            return new ErrorResult(_language.FailureAdd);
        }

        public async Task<IResult> AddRangeAsync(List<Answer> answers)
        {
            var result = BusinessRules.Run(
                CheckTrueAnswers(answers));
            await _answerWriteDal.AddRangeAsync(answers);
            return new SuccessResult(_language.SuccessAdd);
        }

        private IResult CheckTrueAnswers(List<Answer> answers)
        {
            int count = 0;
            foreach (var answer in answers)
            {
                count += answer.IsTrue ? 1 : 0;
            }
            if(count == 0)
                return new ErrorResult("Lütfen doğru şık belirtiniz.");
            if (count > 1)
                return new ErrorResult("Birden fazla doğru şık olamaz");
            return new SuccessResult();
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
        [ValidationAspect(typeof(AnswerValidator))]
        public IResult Update(Answer answer)
        {
            bool result = _answerWriteDal.Update(answer);
            if (result)
                return new SuccessResult(_language.SuccessUpdate);
            return new ErrorResult(_language.FailureUpdate);
        }

        public IResult UpdateRange(List<Answer> answers)
        {
            _answerWriteDal.UpdateRange(answers);
            return new SuccessResult(_language.SuccessUpdate);
        }
    }
}
