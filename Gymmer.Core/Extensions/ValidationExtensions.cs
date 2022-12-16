using FluentValidation.Results;

namespace Gymmer.Core.Extensions;

public class ValidationFailureResponse
{
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
}

public static class ValidationFailureExtensions
{
    public static ValidationFailureResponse ToResponse(this IEnumerable<ValidationFailure> failures)
    {
        return new ValidationFailureResponse
        {
            Errors = failures.Select(failure => failure.ErrorMessage)
        };
    }
}