using Gymmer.Application.EndpointDefinitions.Trainings.ApiQueries;
using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Application.EndpointDefinitions.Trainings;

public static class TrainingsExtensions
{
    public static TrainingModel ToAddModel(this PostTrainingCommand command)
        => new()
        {
            TrainingDefinitionName = command.TrainingDefinitionName,
            TrainingName = command.TrainingName,
            Exercises = command.Exercises
        };

}