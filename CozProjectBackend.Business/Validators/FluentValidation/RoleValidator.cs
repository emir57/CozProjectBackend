using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.Business.Validators.FluentValidation
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
