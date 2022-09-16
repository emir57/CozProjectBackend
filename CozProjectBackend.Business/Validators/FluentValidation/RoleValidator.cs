using Core.Entities.Concrete;
using FluentValidation;

namespace CozProject.Business.Validators.FluentValidation
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Name).MaximumLength(30);
        }
    }
}
