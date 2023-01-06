using Gymmer.Application.EndpointDefinitions.Trainings.ApiQueries;
using Gymmer.Core.Interfaces;
using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Application.EndpointDefinitions.Trainings;

public class TrainingsEndpointDefinition : IEndpointDefinition, IEndpointDefinitionBasePath
{
    public static string BasePath { get; } = "trainings";
    
    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<ITrainingsRepository, TrainingsRepository>();
    }

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet(BasePath, GetTraining.Query)
            .Produces<TrainingModel?>();
    }
}