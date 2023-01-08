using Gymmer.Core.Interfaces;
using Gymmer.Infrastructure.Persistence.DbContext;
using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Infrastructure.Persistence.Repository;

public interface IExerciseOptionsRepository : IGenericRepository<ExerciseOptionModel, long>
{
    IQueryable<ExerciseOptionModel> ReadOnlyQuery();
    ExerciseOptionModel? FindByName(string? name);
    Task<ExerciseOptionModel> AddAsync(ExerciseOptionModel optionModel, CancellationToken ct);
    Task<ExerciseOptionModel> UpdateAsync(ExerciseOptionModel optionModel, CancellationToken ct);
    Task RemoveAsync(long id, CancellationToken ct);
}

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

    public async Task<ExerciseOptionModel> AddAsync(ExerciseOptionModel model, CancellationToken ct)
    {
        await _dbContext.ExerciseOption.AddAsync(model, ct);
        await _dbContext.SaveChangesAsync(ct);

        return model;
    }
    
    public async Task<ExerciseOptionModel> UpdateAsync(ExerciseOptionModel model, CancellationToken ct)
    {
        _dbContext.Update(model);
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