using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using CozProject.Business.BusinessAspects;
using CozProject.Business.Validators.FluentValidation;
using CozProject.DataAccess.Abstract;
using CozProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Concrete
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

        [SecuredOperation("Admin,Teacher")]
        [ValidationAspect(typeof(AnswerValidator))]
        public async Task<IResult> AddAsync(Answer answer)
        {
            bool result = await _answerWriteDal.AddAsync(answer);
            if (result)
                return new SuccessResult(_language.SuccessAdd);
            return new ErrorResult(_language.FailureAdd);
        }

        [SecuredOperation("Admin,Teacher")]
        public async Task<IResult> AddRangeAsync(List<Answer> answers)
        {
            var result = BusinessRules.Run(
                checkAnswersLength(answers),
                checkTrueAnswers(answers),
                checkContentAnswers(answers));
            if (result != null)
                return result;
            await _answerWriteDal.AddRangeAsync(answers);
            return new SuccessResult(_language.SuccessAdd);
        }

        private IResult checkAnswersLength(List<Answer> answers)
        {
            if (answers.Count > 1)
                return new SuccessResult();
            return new ErrorResult(_language.ShouldBeLeastTwoAnswer);
        }

        private IResult checkContentAnswers(List<Answer> answers)
        {
            foreach (var answer in answers)
            {
                if (string.IsNullOrEmpty(answer.Content))
                    return new ErrorResult(_language.PleaseCheckEnteredAnswers);
            }
            return new SuccessResult();
        }

        private IResult checkTrueAnswers(List<Answer> answers)
        {
            int count = 0;
            foreach (var answer in answers)
            {
                count += answer.IsTrue ? 1 : 0;
            }
            if (count == 0)
                return new ErrorResult(_language.ShouldBeTrueAnswer);
            if (count > 1)
                return new ErrorResult(_language.CannotShouldMoreThanOneTrueAnswer);
            return new SuccessResult();
        }

        [SecuredOperation("Admin,Teacher")]
        public IResult Delete(Answer answer)
        {
            _answerWriteDal.Delete(answer);
            return new SuccessResult(_language.SuccessDelete);
        }

        public async Task<int> SaveAsync()
        {
            return await _answerWriteDal.SaveAsync();
        }

        [SecuredOperation("Admin,Teacher")]
        [ValidationAspect(typeof(AnswerValidator))]
        public IResult Update(Answer answer)
        {
            bool result = _answerWriteDal.Update(answer);
            if (result)
                return new SuccessResult(_language.SuccessUpdate);
            return new ErrorResult(_language.FailureUpdate);
        }

        [SecuredOperation("Admin,Teacher")]
        public IResult UpdateRange(List<Answer> answers)
        {
            _answerWriteDal.UpdateRange(answers);
            return new SuccessResult(_language.SuccessUpdate);
        }

        [SecuredOperation("Admin,Teacher")]
        public IResult DeleteRange(List<Answer> answers)
        {
            _answerWriteDal.DeleteRange(answers);
            return new SuccessResult(_language.SuccessDelete);
        }
    }
}
