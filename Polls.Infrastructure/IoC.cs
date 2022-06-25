using Polls.Infrastructure.Persistence.DbContext;

namespace Polls.Infrastructure;

public static class IoC
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<BasicDbContext, SqliteDbContext>();
        return services;
    }
}