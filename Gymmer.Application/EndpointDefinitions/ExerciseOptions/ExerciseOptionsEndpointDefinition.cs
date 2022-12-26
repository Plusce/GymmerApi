using Gymmer.Application.EndpointDefinitions.ExerciseOptions.ApiQueries;
using Gymmer.Core.Filters;
using Gymmer.Core.Interfaces;
using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Application.EndpointDefinitions.ExerciseOptions;

public class ExerciseOptionsEndpointDefinition : IEndpointDefinition
{
    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IExerciseOptionsRepository, ExerciseOptionsRepository>();
        services.AddTransient<IPutExerciseOptionValidationService, PutExerciseOptionValidationService>();
    }

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/exercise-options", GetExerciseOption.Query)
            .Produces<IEnumerable<string?>>();
        app.MapPost("/exercise-options", PostExerciseOption.Query)
            .Produces<ExerciseOptionModel>()
            .AddEndpointFilter<ValidationFilter<PostExerciseOptionCommand>>();
        app.MapPut("/exercise-options", PutExerciseOption.Query)
            .Produces<ExerciseOptionModel>()
            .AddEndpointFilter<ValidationFilter<PutExerciseOptionCommand>>();
        app.MapDelete("/exercise-options", DeleteExerciseOption.Query);
    }
}