using Gymmer.Core.Interfaces;
using Gymmer.Core.Models;
using Gymmer.Infrastructure.Persistence.DbContext;

namespace Gymmer.Infrastructure.Persistence.Repository;

public class PoliticalPartiesRepository : IPoliticalPartiesRepository
{
    private readonly BasicDbContext _dbContext;
    
    public PoliticalPartiesRepository(BasicDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PoliticalPartyModel?> FindByIdAsync(long id, CancellationToken ct = default)
    {
        return await _dbContext.FindAsync<PoliticalPartyModel>(id, ct);
    }

    public Task<List<PoliticalPartyModel?>> FindAllAsync(CancellationToken ct = default)
    {
        return ReadOnlyQuery().ToListAsync(ct)!;
    }

    public IQueryable<PoliticalPartyModel> ReadOnlyQuery()
    {
        return _dbContext.PoliticalParty;
    }
}