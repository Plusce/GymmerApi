using Microsoft.EntityFrameworkCore;
using Polls.Infrastructure.Persistence.DbContext;

namespace Polls.Application.Features.PoliticalParty.ReadPolitcalParties;

public class ReadPoliticalPartiesHandler : IRequestHandler<ReadPoliticalPartiesQuery, IEnumerable<string?>>
{
    private readonly BasicDbContext _dbContext;
    
    public ReadPoliticalPartiesHandler(BasicDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async ValueTask<IEnumerable<string?>> Handle(ReadPoliticalPartiesQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.PoliticalParty.Select(party => party.Name).ToListAsync(cancellationToken);
    }
}