using FluentAssertions;
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
    public async Task FindAll_ReturnAll()
    {
        // Arrange
        _exerciseOptionsRepository.FindAllAsync().ReturnsForAnyArgs(new List<ExerciseOptionModel?>
        {
            new (){ Name = "Zakroki", Description = "Spokojne tempo do tyłu i do przodu" },
            new (){ Name = "Wyciskanie bokiem", Description = "Ćwiczenie w celu otwierania 2x w tygodniu" }
        });

        // Act
        var result =
            await ExerciseOptionsApiQueries.Get(_exerciseOptionsRepository, CancellationToken.None);

        // Assert
        result.As<Ok<List<string?>?>>().Value.Should()
            .BeEquivalentTo("Zakroki", "Wyciskanie bokiem");
        result.As<Ok<List<string?>?>>().StatusCode.Should().Be(200);
    }
}