namespace Gymmer.Application.EndpointDefinitions.TrainingDefinition.ApiQueries;

internal static class GetTrainingDefinition
{
    public static readonly Func<ITrainingDefinitionsRepository, CancellationToken, Task<IResult>> Query =
        async (repository, ct) =>
        {
            var trainingDefinitions = (await repository.FindAllAsync(ct))
                .Select(party => party?.Name)
                .ToList();
            return trainingDefinitions.Count < 1 ? Results.Empty : Results.Ok(trainingDefinitions);
        };
}