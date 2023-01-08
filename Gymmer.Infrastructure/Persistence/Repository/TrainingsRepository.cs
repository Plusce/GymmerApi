using Gymmer.Infrastructure.Persistence.DbContext.Cosmos;
using Gymmer.Infrastructure.Persistence.Models;
using Microsoft.Azure.Cosmos;

namespace Gymmer.Infrastructure.Persistence.Repository;

public interface ITrainingsRepository : IGenericRepository<TrainingModel, string>
{
    Task<TrainingModel> AddAsync(TrainingModel model, CancellationToken ct);
    Task<TrainingModel?> FindByNameAsync(string name, CancellationToken ct);
}

public class TrainingsRepository : ITrainingsRepository
{
    public static readonly string ContainerName = "Trainings";
    private readonly Container _container;

    public TrainingsRepository(ICosmosDbContainerFactory cosmosDbContainerFactory)
    {
        _container = cosmosDbContainerFactory.GetContainer(ContainerName)._container;
    }

    private string GenerateId(TrainingModel entity) => $"{entity.TrainingDefinitionName}:{Guid.NewGuid()}";
    private PartitionKey ResolvePartitionKey(string entityId) => new(entityId.Split(':')[0]);

    public async Task<TrainingModel?> FindByIdAsync(string id, CancellationToken ct = default)
    {
        var sqlQueryText = $"SELECT * FROM c WHERE c.id = \"{id}\"";
        return await FindByQueryAsync(sqlQueryText, ct);
    }
    
    public async Task<TrainingModel?> FindByNameAsync(string name, CancellationToken ct = default)
    {
        var sqlQueryText = $"SELECT * FROM c WHERE c.name = \"{name}\"";
        return await FindByQueryAsync(sqlQueryText, ct);
    }

    private async Task<TrainingModel?> FindByQueryAsync(string sqlQueryText, CancellationToken ct = default)
    {
        var queryDefinition = new QueryDefinition(sqlQueryText);
        var queryResultSetIterator = _container.GetItemQueryIterator<TrainingModel>(queryDefinition);
        
        var result = await queryResultSetIterator.ReadNextAsync(ct);
        return result.Resource.FirstOrDefault();
    }

    public async Task<List<TrainingModel?>> FindAllAsync(CancellationToken ct = default)
    {
        var sqlQueryText = $"SELECT * FROM c";
        var queryDefinition = new QueryDefinition(sqlQueryText);
        var queryResultSetIterator = _container.GetItemQueryIterator<TrainingModel>(queryDefinition);
        
        var result = await queryResultSetIterator.ReadNextAsync(ct);
        return result.Resource.ToList()!;
    }
    
    public async Task<TrainingModel> AddAsync(TrainingModel model, CancellationToken ct)
    {
        model.Id = GenerateId(model);
        var partitionKey = ResolvePartitionKey(model.Id);
        await _container.CreateItemAsync(model, partitionKey, null, ct);

        return model;
    }
}