using Gymmer.Core.Models;

namespace Gymmer.Application.EndpointDefinitions.Trainings;

public sealed record TrainingValidationMessages(string Message) : ValidationMessage(Message)
{
    public static readonly TrainingValidationMessages TrainingDefinitionNameNotExists =
        new("Training definition name '{0}' does not exists.");
    
    public static readonly TrainingValidationMessages IncorrectExerciseOptionNames =
        new("Some of the provided exercise option names do not exist in the training definition.");
}