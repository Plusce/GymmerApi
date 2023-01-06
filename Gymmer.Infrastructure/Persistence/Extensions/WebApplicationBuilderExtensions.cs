using System.Configuration;
using Gymmer.Infrastructure.Persistence.DbContext.Cosmos;
using Microsoft.AspNetCore.Builder;
using Microsoft.Azure.Cosmos;

namespace Gymmer.Infrastructure.Persistence.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddCosmosDb(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var cosmosDbConfig = configuration
            .GetSection("ConnectionStrings:CosmosDb")
            .Get<CosmosDbSettings>()!;
        
        var client = new CosmosClient(cosmosDbConfig.EndpointUrl, cosmosDbConfig.PrimaryKey);
        
        client.CreateDatabaseIfNotExistsAsync(cosmosDbConfig.DatabaseName);
        
        var cosmosDbClientFactory = new CosmosDbContainerFactory(client, 
            cosmosDbConfig.DatabaseName, 
            cosmosDbConfig.Containers);
        
        builder.Services.AddSingleton<ICosmosDbContainerFactory>(cosmosDbClientFactory);
        
        return builder;
    }
}