using Microsoft.Azure.Cosmos;

namespace Gymmer.Infrastructure.Persistence.DbContext.Cosmos;

public interface ICosmosDbContainerFactory
{
    ICosmosDbContainer GetContainer(string containerName);
}

public interface ICosmosDbContainer
{
    Container _container { get; }
}