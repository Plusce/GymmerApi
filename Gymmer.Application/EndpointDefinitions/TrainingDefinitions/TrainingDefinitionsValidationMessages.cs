using Gymmer.Core.Models;

namespace Gymmer.Application.EndpointDefinitions.TrainingDefinitions;

public sealed record TrainingDefinitionsValidationMessages(string Message) : ValidationMessage(Message)
{
    public static readonly TrainingDefinitionsValidationMessages Duplicated =
        new(
            "Cannot name an training definition with '{0}' name. Training definition with this specific name has been already added.");

    public static readonly TrainingDefinitionsValidationMessages IncorrectExerciseOptionIds =
        new("Some of the provided exercise option ids do not exist in the database.");
}