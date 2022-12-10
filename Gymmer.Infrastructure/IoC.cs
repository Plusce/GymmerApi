using Gymmer.Infrastructure.Persistence.DbContext;

namespace Gymmer.Infrastructure;

public static class IoC
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<BasicDbContext, SqliteDbContext>();
        return services;
    }
}