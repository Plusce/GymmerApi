using Microsoft.EntityFrameworkCore;
using Polls.Infrastructure.Persistence.Seed;

namespace Polls.Service.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication SetupDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var services = scope.ServiceProvider;
        var dbContext = services.GetService<Infrastructure.Persistence.DbContext.BasicDbContext>();

        if (dbContext == null)
        {
            return app;
        }

        app.Logger.LogInformation("Executing migrations.");
        dbContext.Database.Migrate();

        return app;
    }

    public static WebApplication SeedDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var services = scope.ServiceProvider;
        var dbContext = services.GetService<Infrastructure.Persistence.DbContext.BasicDbContext>();

        if (dbContext == null)
        {
            return app;
        }

        dbContext.Seed();

        app.Logger.LogInformation("Executing seeding.");

        return app;
    }
}