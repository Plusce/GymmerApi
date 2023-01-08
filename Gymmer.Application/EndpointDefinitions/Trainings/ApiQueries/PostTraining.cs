using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Application.EndpointDefinitions.Trainings.ApiQueries;

internal static class PostTraining
{
    public static readonly Func<PostTrainingCommand, ITrainingsRepository, CancellationToken, Task<IResult>> Query =
        async (command, repository, ct) =>
        {
            var result = await repository.AddAsync(command.ToAddModel(), ct);
            return Results.Created(TrainingsEndpointDefinition.BasePath, result);
        };
}

public record PostTrainingCommand
{
    public string TrainingDefinitionName { get; set; } = string.Empty;
    public string TrainingName { get; set; } = string.Empty;
    public Dictionary<string, List<TrainingSeriesModel>> Exercises { get; set; } = new();
}