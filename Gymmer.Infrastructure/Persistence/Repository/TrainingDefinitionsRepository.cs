using Gymmer.Core.Interfaces;
using Gymmer.Infrastructure.Persistence.DbContext;
using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Infrastructure.Persistence.Repository;

public interface ITrainingDefinitionsRepository : IGenericRepository<TrainingDefinitionModel>
{
    TrainingDefinitionModel? FindByName(string? name);
    Task<TrainingDefinitionModel> AddAsync(TrainingDefinitionModel optionModel, CancellationToken ct);
    Task RemoveAsync(long id, CancellationToken ct);
}

public class TrainingDefinitionsRepository : ITrainingDefinitionsRepository
{
    private readonly BasicDbContext _dbContext;
    
    public TrainingDefinitionsRepository(BasicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TrainingDefinitionModel?> FindByIdAsync(long id, CancellationToken ct = default)
    {
        return await _dbContext.FindAsync<TrainingDefinitionModel>(id, ct);
    }

    public async Task<List<TrainingDefinitionModel?>> FindAllAsync(CancellationToken ct = default)
    {
        return (await ReadOnlyQuery().ToListAsync(ct))!;
    }

    public IQueryable<TrainingDefinitionModel> ReadOnlyQuery()
    {
        return _dbContext.TrainingDefinition;
    }

    public TrainingDefinitionModel? FindByName(string? name)
    {
        return ReadOnlyQuery().FirstOrDefault(x => x.Name == name);
    }

    public async Task<TrainingDefinitionModel> AddAsync(TrainingDefinitionModel model, CancellationToken ct)
    {
        await _dbContext.TrainingDefinition.AddAsync(model, ct);
        await _dbContext.SaveChangesAsync(ct);

        return model;
    }

    public async Task RemoveAsync(long id, CancellationToken ct)
    {
        var exerciseOption = await FindByIdAsync(id, ct);

        if (exerciseOption == null)
        {
            return;
        }

        _dbContext.Remove(exerciseOption);
        await _dbContext.SaveChangesAsync(ct);
    }
}