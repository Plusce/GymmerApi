using FluentAssertions;
using Gymmer.Application.EndpointDefinitions.Exercise;
using Gymmer.Application.EndpointDefinitions.ExerciseOptions;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using Gymmer.Infrastructure.Persistence.Models;
using Gymmer.Infrastructure.Persistence.Repository;
using Xunit;

namespace Gymmer.UnitTests;

public class ExerciseOptionsEndpointDefinition_Tests
{
    private readonly IExerciseOptionsRepository _exerciseOptionsRepository =
        Substitute.For<IExerciseOptionsRepository>();

    [Fact]
    public async Task FindAllOptions_ReturnAll()
    {
        // Arrange
        _exerciseOptionsRepository.FindAllAsync().ReturnsForAnyArgs(new List<ExerciseOptionModel?>
        {
            new("Zakroki", "Spokojne tempo do tyłu i do przodu"),
            new("Wyciskanie bokiem", "Ćwiczenie w celu otwierania 2x w tygodniu")
        });

        // Act
        var result =
            await ExerciseOptionsQueries.Get(_exerciseOptionsRepository, CancellationToken.None);

        // Assert
        result.As<Ok<List<string?>?>>().Value.Should()
            .BeEquivalentTo("Zakroki", "Wyciskanie bokiem");
        result.As<Ok<List<string?>?>>().StatusCode.Should().Be(200);
    }
}