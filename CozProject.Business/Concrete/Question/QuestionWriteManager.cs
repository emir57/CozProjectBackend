using Core.Aspects.Autofac.Validation;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using CozProject.Business.Validators.FluentValidation;
using CozProject.DataAccess.Abstract;
using CozProject.Entities.Concrete;
using System.Threading.Tasks;

namespace CozProject.Business.Concrete;

public class QuestionWriteManager : IQuestionWriteService
{
    private readonly IQuestionWriteDal _questionWriteDal;
    private readonly ILanguageMessage _language;

    public QuestionWriteManager(IQuestionWriteDal questionWriteDal, ILanguageMessage language)
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
    public async Task<IResult> UpdateAsync(Question question)
    {
        bool result = await _questionWriteDal.UpdateAsync(question);
        if (result)
            return new SuccessResult(_language.SuccessUpdate);
        return new ErrorResult(_language.FailureUpdate);
    }
}
