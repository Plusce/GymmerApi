namespace Gymmer.Application.EndpointDefinitions.ExerciseOptions;

public class ExerciseOptionsApiQueries
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
            var result = await repository.AddAsync(command.ToAddModel(), ct);
            return Results.Created("/exercise-options", result);
        };
    
    internal static readonly Func<PutExerciseOptionCommand, IExerciseOptionsRepository, CancellationToken, Task<IResult>> Put =
        async (command, repository, ct) =>
        {
            var entity = await repository.FindByIdAsync(command.Id);
            var result = await repository.UpdateAsync(entity!.ToUpdateModel(command), ct);
            return Results.Accepted("/exercise-options", result);
        };
    
    internal static readonly Func<long, IExerciseOptionsRepository, CancellationToken, Task<IResult>> Delete =
        async (id, repository, ct) =>
        {
            await repository.RemoveAsync(id, ct);
            return Results.NoContent();
        };
}