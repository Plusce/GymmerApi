using Gymmer.Application.EndpointDefinitions.TrainingDefinition.ApiQueries;
using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Application.EndpointDefinitions.TrainingDefinition;

public static class TrainingDefinitionsExtensions
{
    public static TrainingDefinitionModel ToAddModel(this PostTrainingDefinitionCommand command)
        => new()
        {
            Name = command.Name,
            Description = command.Description,
            CreationDate = DateTime.UtcNow,
            EditionDate = DateTime.UtcNow,
            Exercises = command.Exercises?.Select((id, i) => new TrainingDefinitionExerciseOptionModel
            {
                TrainingDefinitionId = 0,
                ExerciseOptionId = id,
                Order = Convert.ToUInt16(i)
            }).ToList()
        };
}