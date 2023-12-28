using Shared.Errors;
using Shared.Primitives;

namespace Shared.ValueObjects
{
    public sealed class ValidationResult : Result, IValidationResult
    {
        public Error[] Errors { get; }
        public ValidationResult(Error[] errors) : base()
        {
            Errors = errors;
        }
        public static ValidationResult WithErros(Error[] errors) => new(errors);
    }
}
