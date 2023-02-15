namespace Gymmer.Infrastructure.Persistence.DbContext.Cosmos;

public class CosmosDbSettings
{
    /// <summary>
    ///     CosmosDb Account - The Azure Cosmos DB endpoint
    /// </summary>
    public string EndpointUri { get; set; } = string.Empty;

    /// <summary>
    ///     Key - The primary key for the Azure DocumentDB account.
    /// </summary>
    public string PrimaryKey { get; set; } = string.Empty;

    public string DatabaseName { get; set; } = string.Empty;

    /// <summary>
    ///     List of containers in the database
    /// </summary>
    public List<ContainerInfo> Containers { get; set; } = new();
}

public class ContainerInfo
{
    /// <summary>
    ///     Container Name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///     Container partition Key
    /// </summary>
    public string PartitionKey { get; set; } = string.Empty;
}