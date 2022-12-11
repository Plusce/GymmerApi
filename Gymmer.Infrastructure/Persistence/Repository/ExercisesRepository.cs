using Gymmer.Core.Interfaces;
using Gymmer.Core.Models;
using Gymmer.Infrastructure.Persistence.DbContext;

namespace Gymmer.Infrastructure.Persistence.Repository;

public class ExercisesRepository : IExercisesRepository
{
    private readonly BasicDbContext _dbContext;
    
    public ExercisesRepository(BasicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ExerciseModel?> FindByIdAsync(long id, CancellationToken ct = default)
    {
        return await _dbContext.FindAsync<ExerciseModel>(id, ct);
    }

    public Task<List<ExerciseModel?>> FindAllAsync(CancellationToken ct = default)
    {
        return ReadOnlyQuery().ToListAsync(ct)!;
    }

    public IQueryable<ExerciseModel> ReadOnlyQuery()
    {
        return _dbContext.Exercise;
    }
}