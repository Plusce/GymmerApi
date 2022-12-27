using Gymmer.Core.Models;
using Gymmer.Infrastructure.Persistence.Models;
using Gymmer.Infrastructure.Persistence.Models.Base;

namespace Gymmer.Infrastructure.Persistence.Repository;

public interface IGenericRepository<T> where T : Entity
{
    public Task<T?> FindByIdAsync(long id, CancellationToken ct = default);
    public Task<List<T?>> FindAllAsync(CancellationToken ct = default);
    public IQueryable<T> ReadOnlyQuery();
}