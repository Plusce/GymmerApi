namespace Gymmer.Application.EndpointDefinitions.Trainings.ApiQueries;

internal static class GetTraining
{
    public static readonly Func<string, ITrainingsRepository, CancellationToken, Task<IResult>> Query =
        async (name, repository, ct) =>
        {
            var training = await repository.FindByNameAsync(name, ct);
            return Results.Ok(training);
        };
}