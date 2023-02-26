using Gymmer.Infrastructure.Persistence.DbContext.Cosmos;
using Microsoft.AspNetCore.Builder;
using Microsoft.Azure.Cosmos;

namespace Gymmer.Infrastructure.Persistence.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static async Task<WebApplicationBuilder> AddCosmosDb(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var settings = configuration
            .GetSection("CosmosDb")
            .Get<CosmosDbSettings>()!;
        
        CosmosClientOptions cosmosClientOptions = new CosmosClientOptions()
        {
            HttpClientFactory = () =>
            {
                HttpMessageHandler httpMessageHandler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                return new HttpClient(httpMessageHandler);
            },
            ConnectionMode = ConnectionMode.Gateway
        };
        
        var client = new CosmosClient(settings.EndpointUri, settings.PrimaryKey, cosmosClientOptions);

        await CreateDatabaseAndContainerAsync(client, settings);
        RegisterCosmosDbClientFactory(client, settings, ref builder);

        return builder;
    }

    private static async Task CreateDatabaseAndContainerAsync(CosmosClient client, CosmosDbSettings settings)
    {
        var response = await client.CreateDatabaseIfNotExistsAsync(settings.DatabaseName);
        foreach (var containerToCreate in settings.Containers)
        {
            var container = response.Database.GetContainer(containerToCreate.Name);
            if(container == null)
                await response.Database.CreateContainerAsync(containerToCreate.Name, containerToCreate.PartitionKey, 400);
        }
    }

    private static void RegisterCosmosDbClientFactory(CosmosClient client, CosmosDbSettings settings, 
        ref WebApplicationBuilder builder)
    {
        var cosmosDbClientFactory = new CosmosDbContainerFactory(client, 
            settings.DatabaseName, 
            settings.Containers);
        
        builder.Services.AddSingleton<ICosmosDbContainerFactory>(cosmosDbClientFactory);
    }
}