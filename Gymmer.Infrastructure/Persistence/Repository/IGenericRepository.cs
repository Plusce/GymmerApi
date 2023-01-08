namespace Gymmer.Infrastructure.Persistence.Repository;

public interface IGenericRepository<T, I> 
    where T : class 
{
    public Task<T?> FindByIdAsync(I id, CancellationToken ct = default);
    public Task<List<T?>> FindAllAsync(CancellationToken ct = default);
}