using CozProject.Entities.Concrete;
using FluentValidation;

namespace CozProject.Business.Validators.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MaximumLength(30);
        }
    }
}
