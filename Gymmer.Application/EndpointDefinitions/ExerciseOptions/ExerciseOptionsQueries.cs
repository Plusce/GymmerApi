using Gymmer.Infrastructure.Persistence.Models;
using Gymmer.Infrastructure.Persistence.Repository;

namespace Gymmer.Application.EndpointDefinitions.ExerciseOptions;

public class ExerciseOptionsQueries
{
    internal static readonly Func<IExerciseOptionsRepository, CancellationToken, Task<IResult>> Get =
        async (repository, ct) =>
        {
            var exerciseOptions = (await repository.FindAllAsync(ct))
                .Select(party => party?.Name)
                .ToList();
            return exerciseOptions.Count < 1 ? Results.Empty : Results.Ok(exerciseOptions);
        };
    
    internal static readonly Func<PostExerciseOptionCommand, IExerciseOptionsRepository, CancellationToken, Task<IResult>> Post =
        async (command, repository, ct) =>
        {
            var newExercise = new ExerciseOptionModel(command.Name, command.Description);
            
            await repository.AddAsync(newExercise, ct);

            return Results.Created("/exercise-options", newExercise);
        };
}