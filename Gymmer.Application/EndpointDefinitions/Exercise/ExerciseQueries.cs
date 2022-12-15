using Gymmer.Infrastructure.Persistence.Models;
using Gymmer.Infrastructure.Persistence.Repository;

namespace Gymmer.Application.EndpointDefinitions.Exercise;

public class ExerciseQueries
{
    internal static readonly Func<IExercisesRepository, CancellationToken, Task<IResult>> Read =
        async (repository, ct) =>
        {
            var politicalParties = (await repository.FindAllAsync(ct)).Select(party => party?.Name).ToList();
            return politicalParties.Count < 1 ? Results.Empty : Results.Ok(politicalParties);
        };
    
    internal static readonly Func<PostExerciseCommand, IExercisesRepository, CancellationToken, Task<IResult>> Post =
        async (command, repository, ct) =>
        {
            var newExercise = new ExerciseModel(command.Name, command.Description);
            
            await repository.AddAsync(newExercise, ct);

            return Results.Created("/exercises", newExercise);
        };
}