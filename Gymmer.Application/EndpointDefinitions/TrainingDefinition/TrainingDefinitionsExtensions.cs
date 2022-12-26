using Gymmer.Application.EndpointDefinitions.ExerciseOptions;
using Gymmer.Application.EndpointDefinitions.ExerciseOptions.ApiQueries;
using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Application.EndpointDefinitions.TrainingDefinition;

public static class TrainingDefinitionsExtensions
{
    public static TrainingDefinitionModel ToAddModel(this PostExerciseOptionCommand command)
        => new()
        {
            Name = command.Name,
            CreationDate = DateTime.UtcNow,
            EditionDate = DateTime.UtcNow
        };
}