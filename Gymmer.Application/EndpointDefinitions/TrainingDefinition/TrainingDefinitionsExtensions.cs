using Gymmer.Application.EndpointDefinitions.ExerciseOptions.ApiQueries;
using Gymmer.Application.EndpointDefinitions.TrainingDefinition.ApiQueries;
using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Application.EndpointDefinitions.TrainingDefinition;

public static class TrainingDefinitionsExtensions
{
    public static TrainingDefinitionModel ToAddModel(this PostTrainingDefinitionCommand command)
        => new()
        {
            Name = command.Name,
            CreationDate = DateTime.UtcNow,
            EditionDate = DateTime.UtcNow
        };
}