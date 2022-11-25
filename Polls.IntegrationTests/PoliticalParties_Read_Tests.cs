using System.Net;
using Xunit;
using Assert = Xunit.Assert;

namespace Polls.IntegrationTests;

public partial class PoliticalParties_Read_Tests
{
    [Fact]
    public async Task Read_PoliticalParties_SuccessfulResponse()
    {
        await using var application = new PlaygroundApplication("Development");

        var client = application.CreateClient();
        var response = await client.GetAsync("/political-parties/");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task SwaggerUI_Redirects_To_Canonical_Path_In_Development()
    {
        await using var application = new PlaygroundApplication("Development");

        var client = application.CreateClient(new () { AllowAutoRedirect = false });
        var response = await client.GetAsync("/docs");

        Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
        Assert.Equal("/docs/", response.Headers.Location?.ToString());
    }
}