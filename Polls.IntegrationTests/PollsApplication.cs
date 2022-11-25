using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Hosting;
using Polls.Infrastructure.Persistence.DbContext;

namespace Polls.IntegrationTests;

internal class PlaygroundApplication : WebApplicationFactory<Program>
{
    private readonly string _environment;

    public PlaygroundApplication(string environment = "Development")
    {
        _environment = environment;
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment(_environment);

        // Add mock/test services to the builder here
        builder.ConfigureServices(services =>
        {
            services.AddScoped(sp =>
            {
                // Replace SQLite with in-memory database for tests
                return new DbContextOptionsBuilder<BasicDbContext>()
                    .UseInMemoryDatabase("Tests")
                    .UseApplicationServiceProvider(sp)
                    .Options;
            });

            MvcServiceCollectionExtensions.AddMvc(services, options => options.Filters.Add(new AllowAnonymousFilter()));
            
        });

        return base.CreateHost(builder);
    }
}