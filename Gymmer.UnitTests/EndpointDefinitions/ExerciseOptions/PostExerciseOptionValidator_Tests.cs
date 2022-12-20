using FluentAssertions;
using Gymmer.Application.EndpointDefinitions.ExerciseOptions;
using Gymmer.Core.Extensions;
using Gymmer.Infrastructure.Persistence.Repository;
using NSubstitute;

namespace Gymmer.UnitTests.EndpointDefinitions.ExerciseOptions;

public class PostExerciseOptionValidator_Tests
{
    private readonly IExerciseOptionsRepository _exerciseOptionsRepository =
        Substitute.For<IExerciseOptionsRepository>();
    
    [Fact]
    public void ValidateAsync_NoPossibleToDuplicate_ExerciseOptionName()
    {
        // Arrange
        var command = new PostExerciseOptionCommand
        {
            Name = "Pompka"
        };
        _exerciseOptionsRepository.FindByName(Arg.Any<string?>()).Returns(command.ToAddModel());
        var validator = new PostExerciseOptionValidator(_exerciseOptionsRepository);

        // Act
        var result = validator.Validate(command);
        
        // Assert
        var failureResponse = result.Errors.ToResponse();
        var error = failureResponse.Errors.Should().ContainSingle().Which;
        error.Should().Be(ExerciseOptionValidationMessages.Duplicated.AddParams("Pompka"));
    }
}