using System.Text;
using Gymmer.Application.EndpointDefinitions.ExerciseOptions;
using Gymmer.Application.EndpointDefinitions.ExerciseOptions.ApiQueries;
using Gymmer.Infrastructure.Persistence.DbContext;
using Gymmer.Infrastructure.Persistence.Repository;
using Gymmer.Service;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace Gymmer.DependencyValidationTests;

public class Tests
{
    private readonly List<(Type ServiceType, Type? ImplType, ServiceLifetime Lifetime)> _descriptors = new()
        {
            (typeof(BasicDbContext), typeof(SqliteDbContext), ServiceLifetime.Scoped),
            (typeof(IExerciseOptionsRepository), typeof(ExerciseOptionsRepository), ServiceLifetime.Scoped),
            (typeof(ITrainingDefinitionsRepository), typeof(TrainingDefinitionsRepository), ServiceLifetime.Scoped),
            (typeof(IPutExerciseOptionValidationService), typeof(PutExerciseOptionValidationService), ServiceLifetime.Transient)
        };
    
    [TestCase]
    public void DependencyRegistration_ConfiguredSuccessfully()
    {
        var app = new WebApplicationFactory<IApiMarker>()
            .WithWebHostBuilder(builder => builder.ConfigureTestServices(serviceCollection =>
            {
                var services = serviceCollection.ToList();
                var result = ValidateServices(services);
                if (!result.Success)
                {
                    Assert.Fail(result.Message);
                }

                Assert.Pass();
            }));

        app.CreateClient();
    }

    private class DependencyAssertionResult
    {
        public required bool Success { get; init; }
        public required string Message { get; init; }
    }

    private DependencyAssertionResult ValidateServices(List<ServiceDescriptor> services)
    {
        var searchFailed = false;
        var failedText = new StringBuilder();
        
        foreach (var descriptor in _descriptors)
        {
            var match = services.SingleOrDefault(
                x => x.ServiceType == descriptor.ServiceType &&
                     x.Lifetime == descriptor.Lifetime &&
                     x.ImplementationType == descriptor.ImplType);

            if (match is not null)
            {
                continue;
            }

            if (!searchFailed)
            {
                failedText.AppendLine("Failed to find registered service for:");
                searchFailed = true;
            }

            failedText.AppendLine(
                $"{descriptor.ServiceType.Name}|{descriptor.ImplType?.Name}|{descriptor.ServiceType.Name}");
        }

        return new DependencyAssertionResult
        {
            Success = !searchFailed,
            Message = failedText.ToString()
        };
    }
}