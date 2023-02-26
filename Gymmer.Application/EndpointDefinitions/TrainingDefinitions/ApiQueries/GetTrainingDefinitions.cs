namespace Gymmer.Application.EndpointDefinitions.TrainingDefinitions.ApiQueries;

internal static class GetTrainingDefinitions
{
    public static readonly Func<ITrainingDefinitionsRepository, CancellationToken, Task<IResult>> Query =
        async (repository, ct) =>
        {
            var trainingDefinitions = (await repository.FindAllAsync(ct))
                .Select(party => new TrainingDefinitionDto
                {
                    Id = party!.Id,
                    Name = party.Name
                })
                .ToList();
            return trainingDefinitions.Count < 1 ? Results.Empty : Results.Ok(trainingDefinitions);
        };
}

public record TrainingDefinitionDto
{
    public long Id { get; init; }
    public string Name { get; init; } = string.Empty;
}