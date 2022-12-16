using FluentValidation;
using Gymmer.Application.EndpointDefinitions.ExerciseOptions;
using Gymmer.Core.Filters;
using Gymmer.Core.Interfaces;
using Gymmer.Infrastructure.Persistence.Models;
using Gymmer.Infrastructure.Persistence.Repository;

namespace Gymmer.Application.EndpointDefinitions.Exercise;

public class ExerciseOptionsEndpointDefinition : IEndpointDefinition
{
    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IExerciseOptionsRepository, ExerciseOptionsRepository>();
    }

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/exercise-options", ExerciseOptionsQueries.Get)
            .Produces<IEnumerable<string?>>();
        app.MapPost("/exercise-options", ExerciseOptionsQueries.Post)
            .Produces<ExerciseOptionModel>()
            .AddEndpointFilter<ValidationFilter<PostExerciseOptionCommand>>();
    }
}