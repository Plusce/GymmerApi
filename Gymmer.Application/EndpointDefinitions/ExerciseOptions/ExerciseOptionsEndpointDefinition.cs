using Gymmer.Application.EndpointDefinitions.ExerciseOptions.ApiQueries;
using Gymmer.Core.Filters;
using Gymmer.Core.Interfaces;
using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Application.EndpointDefinitions.ExerciseOptions;

public class ExerciseOptionsEndpointDefinition : IEndpointDefinition
{
    public static string BasePath { get; } = "/exercise-options";

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IExerciseOptionsRepository, ExerciseOptionsRepository>();
        services.AddTransient<IPutExerciseOptionValidationService, PutExerciseOptionValidationService>();
    }

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet(BasePath, GetExerciseOption.Query)
            .Produces<IEnumerable<string?>>();
        app.MapPost(BasePath, PostExerciseOption.Query)
            .Produces<ExerciseOptionModel>()
            .AddEndpointFilter<ValidationFilter<PostExerciseOptionCommand>>();
        app.MapPut(BasePath, PutExerciseOption.Query)
            .Produces<ExerciseOptionModel>()
            .AddEndpointFilter<ValidationFilter<PutExerciseOptionCommand>>();
        app.MapDelete(BasePath, DeleteExerciseOption.Query);
    }
}