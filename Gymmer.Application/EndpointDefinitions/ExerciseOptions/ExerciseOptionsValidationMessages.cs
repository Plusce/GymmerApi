using Gymmer.Core.Models;

namespace Gymmer.Application.EndpointDefinitions.ExerciseOptions;

public sealed record ExerciseOptionValidationMessages(string Message) : ValidationMessage(Message)
{
    public static readonly ExerciseOptionValidationMessages Duplicated =
        new(
            "Cannot name an exercise option with '{0}' name. Exercise option with this specific name has been already added.");
}