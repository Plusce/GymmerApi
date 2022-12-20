using FluentAssertions;
using Gymmer.Application.EndpointDefinitions.ExerciseOptions;
using Gymmer.Core.Extensions;
using Gymmer.Core.Models;

namespace Gymmer.UnitTests.Extensions;

public class ValidationMessageExtensions_Tests
{
    private sealed record FakeValidationMessages(string Message) : ValidationMessage(Message)
    {
        public static readonly ExerciseOptionValidationMessages Sample =
            new(
                "First param is placed here '{0}', third here '{2}', second here '{1}', fourth is 'omitted'.");
    }

    [Fact]
    public void AddParams_ApplyParamsCorrectly()
    {
        // Arrange & Act
        var message = FakeValidationMessages.Sample
            .AddParams("Param nr 1", "Param nr 2", "Param nr 3", "Param nr 4");

        // Assert
        message
            .Should()
            .Be(
                "First param is placed here 'Param nr 1', third here 'Param nr 3', second here 'Param nr 2', fourth is 'omitted'.");
    }
}