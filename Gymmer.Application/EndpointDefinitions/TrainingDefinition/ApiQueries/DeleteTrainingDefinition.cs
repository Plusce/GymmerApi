namespace Gymmer.Application.EndpointDefinitions.TrainingDefinition.ApiQueries;

internal static class DeleteTrainingDefinition
{
    public static readonly Func<long, ITrainingDefinitionsRepository, CancellationToken, Task<IResult>> Query =
        async (id, repository, ct) =>
        {
            await repository.RemoveAsync(id, ct);
            return Results.NoContent();
        };
}