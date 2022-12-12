using Gymmer.Core.Interfaces;
using Gymmer.Infrastructure.Persistence.Models;
using Gymmer.Infrastructure.Persistence.Repository;

namespace Gymmer.Application.EndpointDefinitions.PoliticalParty;

public class ExerciseEndpointDefinition : IEndpointDefinition
{
    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IExercisesRepository, ExercisesRepository>();
    }

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/exercises", ExerciseQueries.Read)
            .Produces<IEnumerable<string?>>();
        app.MapPost("/exercises", ExerciseQueries.Post)
            .Produces<ExerciseModel>();
    }
}