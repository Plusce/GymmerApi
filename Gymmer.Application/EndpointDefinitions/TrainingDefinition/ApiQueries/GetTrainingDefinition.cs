namespace Gymmer.Application.EndpointDefinitions.TrainingDefinition.ApiQueries;

internal static class GetTrainingDefinition
{
    public static readonly Func<ITrainingDefinitionsRepository, CancellationToken, Task<IResult>> Query =
        async (repository, ct) =>
        {
            var exerciseOptions = (await repository.FindAllAsync(ct))
                .Select(party => party?.Name)
                .ToList();
            return exerciseOptions.Count < 1 ? Results.Empty : Results.Ok(exerciseOptions);
        };
}