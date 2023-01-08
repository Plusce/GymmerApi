using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Application.EndpointDefinitions.Trainings.ApiQueries;

internal static class PostTraining
{
    public static readonly Func<TrainingModel, ITrainingsRepository, CancellationToken, Task<IResult>> Query =
        async (model, repository, ct) =>
        {
            var result = await repository.AddAsync(model, ct);
            return Results.Created(TrainingsEndpointDefinition.BasePath, result);
        };
}