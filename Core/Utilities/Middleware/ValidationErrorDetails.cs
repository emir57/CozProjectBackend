using FluentValidation.Results;
using System.Collections.Generic;

namespace Core.Utilities.Middleware
{
    public class ValidationErrorDetails : ErrorDetail
    {
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
