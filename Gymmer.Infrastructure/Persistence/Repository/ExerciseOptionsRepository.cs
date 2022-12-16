using Gymmer.Core.Interfaces;
using Gymmer.Infrastructure.Persistence.DbContext;
using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Infrastructure.Persistence.Repository;

public class ExerciseOptionsRepository : IExerciseOptionsRepository
{
    private readonly BasicDbContext _dbContext;
    
    public ExerciseOptionsRepository(BasicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ExerciseOptionModel?> FindByIdAsync(long id, CancellationToken ct = default)
    {
        return await _dbContext.FindAsync<ExerciseOptionModel>(id, ct);
    }

    public async Task<List<ExerciseOptionModel?>> FindAllAsync(CancellationToken ct = default)
    {
        return (await ReadOnlyQuery().ToListAsync(ct))!;
    }

    public IQueryable<ExerciseOptionModel> ReadOnlyQuery()
    {
        return _dbContext.ExerciseOption;
    }

    public ExerciseOptionModel? FindByName(string? name)
    {
        return ReadOnlyQuery().FirstOrDefault(x => x.Name == name);
    }

    public async Task AddAsync(ExerciseOptionModel optionModel, CancellationToken ct)
    {
        await _dbContext.ExerciseOption.AddAsync(optionModel, ct);
        await _dbContext.SaveChangesAsync(ct);
    }
}

public interface IExerciseOptionsRepository : IGenericRepository<ExerciseOptionModel>
{
    public ExerciseOptionModel? FindByName(string? name);
    public Task AddAsync(ExerciseOptionModel optionModel, CancellationToken ct);
}