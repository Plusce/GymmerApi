namespace Gymmer.Application.EndpointDefinitions.ExerciseOptions.ApiQueries;

internal static class GetExerciseOption
{
    public static readonly Func<IExerciseOptionsRepository, CancellationToken, Task<IResult>> Query =
        async (repository, ct) =>
        {
            var exerciseOptions = (await repository.FindAllAsync(ct))
                .Select(party => party?.Name)
                .ToList();
            return exerciseOptions.Count < 1 ? Results.Empty : Results.Ok(exerciseOptions);
        };
}