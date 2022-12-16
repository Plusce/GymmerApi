using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Application.EndpointDefinitions.ExerciseOptions;

public static class ExerciseOptionsExtensions
{
    public static ExerciseOptionModel ToAddModel(this PostExerciseOptionCommand command)
        => new()
        {
            Name = command.Name,
            Description = command.Description,
            CreationDate = DateTime.UtcNow,
            EditionDate = DateTime.UtcNow
        };

    public static ExerciseOptionModel ToUpdateModel(this ExerciseOptionModel model, PutExerciseOptionCommand command)
    {
        model.Name = command.Name;
        model.Description = command.Description;
        model.EditionDate = DateTime.UtcNow;
        return model;
    }
}