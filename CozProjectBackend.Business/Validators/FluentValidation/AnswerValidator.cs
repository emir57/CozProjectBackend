using CozProjectBackend.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozProjectBackend.Business.Validators.FluentValidation
{
    public class AnswerValidator : AbstractValidator<Answer>
    {
        public AnswerValidator()
        {
            RuleFor(a => a.QuestionId).NotEmpty();
            RuleFor(a => a.Content).NotEmpty();
            RuleFor(a => a.Content).MaximumLength(150);
            RuleFor(a => a.IsTrue).NotNull();
        }
    }
}
