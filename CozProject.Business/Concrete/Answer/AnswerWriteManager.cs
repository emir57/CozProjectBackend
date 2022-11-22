using AutoMapper;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess;
using Core.Utilities.Business;
using Core.Utilities.Message;
using Core.Utilities.Result;
using CozProject.Business.Abstract;
using CozProject.Business.BusinessAspects;
using CozProject.Business.Validators.FluentValidation;
using CozProject.DataAccess.Abstract;
using CozProject.Dto.Concrete;
using CozProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CozProject.Business.Concrete;

public class AnswerWriteManager : WriteBaseService<Answer, AnswerWriteDto, AnswerReadDto>, IAnswerWriteService
{
    public AnswerWriteManager(IAnswerWriteDal writeRepository, IMapper mapper, ILanguageMessage languageMessage, IReadRepository<Answer> readRepository) : base(writeRepository, mapper, languageMessage, readRepository)
    {
    }

    [SecuredOperation("Admin,Teacher")]
    [ValidationAspect(typeof(AnswerValidator))]
    public override Task<IResult> AddAsync(AnswerWriteDto writeDto)
    {
        return base.AddAsync(writeDto);
    }

    [SecuredOperation("Admin,Teacher")]
    public override async Task<IResult> AddRangeAsync(List<AnswerWriteDto> writeDtos)
    {
        var result = BusinessRules.Run(
            checkAnswersLength(writeDtos),
            checkTrueAnswers(writeDtos),
            checkContentAnswers(writeDtos));
        if (result != null)
            return result;
        return await base.AddRangeAsync(writeDtos);
    }

    private IResult checkAnswersLength(List<AnswerWriteDto> answers)
    {
        if (answers.Count > 1)
            return new SuccessResult();
        return new ErrorResult(LanguageMessage.ShouldBeLeastTwoAnswer);
    }

    private IResult checkContentAnswers(List<AnswerWriteDto> answers)
    {
        foreach (var answer in answers)
        {
            if (string.IsNullOrEmpty(answer.Content))
                return new ErrorResult(LanguageMessage.PleaseCheckEnteredAnswers);
        }
        return new SuccessResult();
    }

    private IResult checkTrueAnswers(List<AnswerWriteDto> answers)
    {
        int count = 0;
        foreach (var answer in answers)
        {
            count += answer.IsTrue ? 1 : 0;
        }
        if (count == 0)
            return new ErrorResult(LanguageMessage.ShouldBeTrueAnswer);
        if (count > 1)
            return new ErrorResult(LanguageMessage.CannotShouldMoreThanOneTrueAnswer);
        return new SuccessResult();
    }

    [SecuredOperation("Admin,Teacher")]
    public override Task<IResult> DeleteAsync(int id)
    {
        return base.DeleteAsync(id);
    }

    [SecuredOperation("Admin,Teacher")]
    [ValidationAspect(typeof(AnswerValidator))]
    public override Task<IResult> UpdateAsync(int id, AnswerWriteDto writeDto)
    {
        return base.UpdateAsync(id, writeDto);
    }

    [SecuredOperation("Admin,Teacher")]
    public override Task<IResult> DeleteRangeAsync(int[] ids)
    {
        return base.DeleteRangeAsync(ids);
    }

    [SecuredOperation("Admin,Teacher")]
    [ValidationAspect(typeof(AnswerValidator))]
    public void UpdateRange(List<Answer> answers)
    {
        WriteRepository.UpdateRange(answers);
    }
}
