using Gymmer.Infrastructure.Persistence.DbContext.Cosmos;
using Gymmer.Infrastructure.Persistence.Models;
using Microsoft.Azure.Cosmos;

namespace Gymmer.Infrastructure.Persistence.Repository;

public interface ITrainingsRepository : IGenericRepository<TrainingModel, string>
{
    Task<TrainingModel> AddAsync(TrainingModel model, CancellationToken ct);
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

    public Task<TrainingModel?> FindByIdAsync(string id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<TrainingModel?>> FindAllAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TrainingModel> ReadOnlyQuery()
    {
        throw new NotImplementedException();
    }

    public async Task<TrainingModel> AddAsync(TrainingModel model, CancellationToken ct)
    {
        model.Id = GenerateId(model);
        var partitionKey = ResolvePartitionKey(model.Id);
        await _container.CreateItemAsync(model, partitionKey, null, ct);

        return model;
    }
}