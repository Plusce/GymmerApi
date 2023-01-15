using Gymmer.Application.EndpointDefinitions.Trainings.ApiQueries;
using Gymmer.Core.Filters;
using Gymmer.Core.Interfaces;
using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Application.EndpointDefinitions.Trainings;

public class TrainingsEndpointDefinition : IEndpointDefinition, IEndpointDefinitionBasePath
{
    public static string BasePath { get; } = "trainings";
    
    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<ITrainingsRepository, TrainingsRepository>();
        services.AddTransient<IPostTrainingValidationService, PostTrainingValidationService>();
    }

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet(BasePath, GetTraining.Query)
            .Produces<TrainingModel?>();
        app.MapPost(BasePath, PostTraining.Query)
            .Produces<TrainingModel>()
            .AddEndpointFilter<ValidationFilter<PostTrainingCommand>>();
    }
}