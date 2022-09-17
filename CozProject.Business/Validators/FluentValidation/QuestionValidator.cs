using CozProject.Entities.Concrete;
using FluentValidation;

namespace CozProject.Business.Validators.FluentValidation
{
    public class QuestionValidator : AbstractValidator<Question>
    {
        public QuestionValidator()
        {
            RuleFor(q => q.CategoryId).NotNull();
            RuleFor(q => q.Content).NotEmpty();
            RuleFor(q => q.Content).MaximumLength(250);
            RuleFor(q => q.Score).GreaterThan(0);
            RuleFor(q => q.TeacherId).NotEmpty();
        }
    }
}
