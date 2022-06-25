using Polls.Core.Models;
using Polls.Infrastructure.Persistence.Extensions;

namespace Polls.Infrastructure.Persistence.DbContext;

public class BasicDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    protected readonly IConfiguration Configuration;
    
    public DbSet<PoliticalPartyModel> PoliticalParty => Set<PoliticalPartyModel>();
    
    protected BasicDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SetupToTable();
    }
}