using Gymmer.Application.EndpointDefinitions.TrainingDefinitions.ApiQueries;
using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Application.EndpointDefinitions.TrainingDefinitions;

public static class TrainingDefinitionsExtensions
{
    public static TrainingDefinitionModel ToAddModel(this PostTrainingDefinitionCommand command)
        => new()
        {
            Name = command.Name,
            Description = command.Description,
            CreationDate = DateTime.UtcNow,
            EditionDate = DateTime.UtcNow,
            Exercises = command.ExerciseIds?.Select((id, i) => new TrainingDefinitionExerciseOptionModel
            {
                TrainingDefinitionId = 0,
                ExerciseOptionId = id,
                Order = Convert.ToUInt16(i)
            }).ToList()
        };
}