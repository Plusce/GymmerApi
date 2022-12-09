using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Polls.Application.EndpointDefinitions.PoliticalParty;
using Polls.Core.Interfaces;
using Polls.Core.Models;
using Xunit;

namespace Polls.UnitTests;

public class PoliticalPartyEndpointDefinition_Tests
{
    private readonly IPoliticalPartiesRepository _politicalPartiesRepository =
        Substitute.For<IPoliticalPartiesRepository>();

    [Fact]
    public async Task FindAllPoliticalParties_ReturnAll()
    {
        // Arrange
        _politicalPartiesRepository.FindAllAsync().ReturnsForAnyArgs(new List<PoliticalPartyModel?>
        {
            new PoliticalPartyModel { Name = "Platforma Obywatelska" },
            new PoliticalPartyModel { Name = "LPR" }
        });

        // Act
        var result =
            await ReadPoliticalPartyQueries.ReadPoliticalParties(_politicalPartiesRepository, CancellationToken.None);

        // Assert
        result.As<Ok<List<string?>?>>().Value.Should()
            .BeEquivalentTo(new List<string> { "Platforma Obywatelska", "LPR" });
        result.As<Ok<List<string?>?>>().StatusCode.Should().Be(200);
    }
}