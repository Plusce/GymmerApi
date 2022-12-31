using Microsoft.Azure.Cosmos;

namespace Gymmer.Infrastructure.Persistence.DbContext.Cosmos;

public class CosmosDbContainerFactory : ICosmosDbContainerFactory
{
    private readonly CosmosClient _cosmosClient;

    private readonly string _databaseName;
    private readonly List<ContainerInfo> _containers;
    
    public CosmosDbContainerFactory(CosmosClient cosmosClient,
        string databaseName,
        List<ContainerInfo> containers)
    {
        _databaseName = databaseName ?? throw new ArgumentNullException(nameof(databaseName));
        _containers = containers ?? throw new ArgumentNullException(nameof(containers));
        _cosmosClient = cosmosClient ?? throw new ArgumentNullException(nameof(cosmosClient));
    }

    public ICosmosDbContainer GetContainer(string containerName)
    {
        if (_containers.Where(x => x.Name == containerName) == null)
        {
            throw new ArgumentException($"Unable to find container: {containerName}");
        }

        return new CosmosDbContainer(_cosmosClient, _databaseName, containerName);
    }
}

public class CosmosDbContainer : ICosmosDbContainer
{
    public Container _container { get; }

    public CosmosDbContainer(CosmosClient cosmosClient,
        string databaseName,
        string containerName)
    {
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }
}