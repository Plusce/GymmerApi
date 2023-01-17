using Gymmer.Application.EndpointDefinitions.TrainingDefinitions.ApiQueries;
using Gymmer.Core.Filters;
using Gymmer.Core.Interfaces;
using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Application.EndpointDefinitions.TrainingDefinitions;

public class TrainingDefinitionsEndpointDefinition : IEndpointDefinition, IEndpointDefinitionBasePath
{
    public static string BasePath { get; } = "/training-definitions";

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<ITrainingDefinitionsRepository, TrainingDefinitionsRepository>();
        services.AddTransient<ITrainingDefinitionsValidationService, TrainingDefinitionsValidationService>();
    }

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet(BasePath, GetTrainingDefinitions.Query)
            .Produces<IEnumerable<string?>>();
        app.MapPost(BasePath, PostTrainingDefinition.Query)
            .Produces<TrainingDefinitionModel>()
            .AddEndpointFilter<ValidationFilter<PostTrainingDefinitionCommand>>();
        app.MapDelete(BasePath, DeleteTrainingDefinition.Query);
    }
}