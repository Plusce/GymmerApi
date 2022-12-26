namespace Gymmer.Application.EndpointDefinitions.ExerciseOptions.ApiQueries;

public static class DeleteExerciseOption
{
    internal static readonly Func<long, IExerciseOptionsRepository, CancellationToken, Task<IResult>> Query =
        async (id, repository, ct) =>
        {
            await repository.RemoveAsync(id, ct);
            return Results.NoContent();
        };
}