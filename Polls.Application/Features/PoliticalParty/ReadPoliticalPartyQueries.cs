using Microsoft.EntityFrameworkCore;
using Polls.Infrastructure.Persistence.DbContext;

namespace Polls.Application.Features.PoliticalParty;

public class ReadPoliticalPartyQueries
{
    public static readonly Func<BasicDbContext, CancellationToken, Task<IEnumerable<string?>>> ReadPoliticalParties =
        async (dbContext, ct) =>
            await dbContext.PoliticalParty.Select(party => party.Name).ToListAsync(ct);
}