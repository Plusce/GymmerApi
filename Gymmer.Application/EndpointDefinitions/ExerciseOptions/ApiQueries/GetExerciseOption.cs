namespace Gymmer.Application.EndpointDefinitions.ExerciseOptions.ApiQueries;

internal static class GetExerciseOption
{
    public static readonly Func<IExerciseOptionsRepository, CancellationToken, Task<IResult>> Query =
        async (repository, ct) =>
        {
            var exerciseOptions = (await repository.FindAllAsync(ct))
                .Select(party => new ExerciseOptionDto
                {
                    Id = party!.Id,
                    Name = party.Name
                })
                .ToList();
            return exerciseOptions.Count < 1 ? Results.Empty : Results.Ok(exerciseOptions);
        };
}

public record ExerciseOptionDto
{
    public long Id { get; init; }
    public string Name { get; init; } = string.Empty;
}