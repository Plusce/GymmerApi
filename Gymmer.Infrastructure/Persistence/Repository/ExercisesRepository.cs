using Gymmer.Core.Interfaces;
using Gymmer.Infrastructure.Persistence.DbContext;
using Gymmer.Infrastructure.Persistence.Models;

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

    public async Task<List<ExerciseModel?>> FindAllAsync(CancellationToken ct = default)
    {
        return (await ReadOnlyQuery().ToListAsync(ct))!;
    }

    public IQueryable<ExerciseModel> ReadOnlyQuery()
    {
        return _dbContext.Exercise;
    }

    public ExerciseModel? FindByName(string? name)
    {
        return ReadOnlyQuery().FirstOrDefault(exercise => exercise.Name == name);
    }

    public async Task AddAsync(ExerciseModel model, CancellationToken ct)
    {
        await _dbContext.Exercise.AddAsync(model, ct);
        await _dbContext.SaveChangesAsync(ct);
    }
}

public interface IExercisesRepository : IGenericRepository<ExerciseModel>
{
    public ExerciseModel? FindByName(string? name);
    public Task AddAsync(ExerciseModel model, CancellationToken ct);
}