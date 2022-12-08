using Polls.Core.Models;

namespace Polls.Application.EndpointDefinitions.PoliticalParty;

public class PoliticalPartyEndpointDefinition : IEndpointDefinition
{
    public void DefineServices(IServiceCollection services)
    {
    }

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/political-parties", ReadPoliticalPartyQueries.ReadPoliticalParties)
            .Produces<IEnumerable<string?>>();
    }
}