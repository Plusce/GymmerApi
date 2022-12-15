using FluentAssertions;
using Gymmer.Application.EndpointDefinitions.Exercise;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Gymmer.Infrastructure.Persistence.Models;
using Gymmer.Infrastructure.Persistence.Repository;
using Xunit;

namespace Gymmer.UnitTests;

public class ExerciseEndpointDefinition_Tests
{
    private readonly IExercisesRepository _exercisesRepository =
        Substitute.For<IExercisesRepository>();

    [Fact]
    public async Task FindAllPoliticalParties_ReturnAll()
    {
        // Arrange
        _exercisesRepository.FindAllAsync().ReturnsForAnyArgs(new List<ExerciseModel?>
        {
            new("Zakroki", "Spokojne tempo do tyłu i do przodu"),
            new("Wyciskanie bokiem", "Ćwiczenie w celu otwierania 2x w tygodniu")
        });

        // Act
        var result =
            await ExerciseQueries.Read(_exercisesRepository, CancellationToken.None);

        // Assert
        result.As<Ok<List<string?>?>>().Value.Should()
            .BeEquivalentTo("Zakroki", "Wyciskanie bokiem");
        result.As<Ok<List<string?>?>>().StatusCode.Should().Be(200);
    }
}