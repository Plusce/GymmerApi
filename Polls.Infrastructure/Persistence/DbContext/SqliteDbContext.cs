using Microsoft.Extensions.Caching.Memory;

namespace Polls.Infrastructure.Persistence.DbContext;

public class SqliteDbContext : BasicDbContext
{
    public SqliteDbContext(IConfiguration configuration) : base(configuration)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
    }
}