using Shared.Errors;

namespace Shared.Primitives
{
    public interface IValidationResult
    {
        public static readonly Error ValidationError = new("A validation proble occured.");

        Error[] Errors { get; }
    }
}
