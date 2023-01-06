namespace Gymmer.Application.EndpointDefinitions.Trainings.ApiQueries;

internal static class GetTraining
{
    public static readonly Func<string, ITrainingsRepository, CancellationToken, Task<IResult>> Query =
        async (name, repository, ct) =>
        {
            var training = await repository.FindByIdAsync("A8 test:5726a22d-5304-4cc7-92b9-8bdef5e44a85", ct);
            return Results.Ok(training);
        };
}