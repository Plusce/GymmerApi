using Gymmer.Core.Models;

namespace Gymmer.Application.EndpointDefinitions.ExerciseOptions;

public record ExerciseOptionValidationMessages(string Message) : ValidationMessage(Message)
{
    public static readonly ExerciseOptionValidationMessages Duplicated =
        new(
            "Cannot name an exercise option with '{0}' name. ExerciseOption option with this specific name has been already added.");
}