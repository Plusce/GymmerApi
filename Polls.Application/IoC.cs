using Polls.Application.EndpointDefinitions.PoliticalParty;

namespace Polls.Application;

public static class IoC
{
    public static WebApplication AddApplication(this WebApplication app)
    {
        app.MapGet("/political-parties", ReadPoliticalPartyQueries.ReadPoliticalParties);
        return app;
    }
}