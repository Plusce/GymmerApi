using Gymmer.Application.EndpointDefinitions.ExerciseOptions;
using Gymmer.Application.EndpointDefinitions.ExerciseOptions.ApiQueries;
using Gymmer.Application.EndpointDefinitions.TrainingDefinition.ApiQueries;
using Gymmer.Core.Filters;
using Gymmer.Core.Interfaces;
using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Application.EndpointDefinitions.TrainingDefinition;

public class TrainingDefinitionsEndpointDefinition : IEndpointDefinition
{
    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<ITrainingDefinitionsRepository, TrainingDefinitionsRepository>();
    }

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/exercise-options", GetTrainingDefinition.Query)
            .Produces<IEnumerable<string?>>();
        app.MapPost("/exercise-options", PostTrainingDefinition.Query)
            .Produces<ExerciseOptionModel>()
            .AddEndpointFilter<ValidationFilter<PostExerciseOptionCommand>>();
        app.MapDelete("/exercise-options", DeleteTrainingDefinition.Query);
    }
}