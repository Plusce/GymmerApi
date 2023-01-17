using FluentAssertions;
using Gymmer.Application.EndpointDefinitions.TrainingDefinitions;
using Gymmer.Application.EndpointDefinitions.TrainingDefinitions.ApiQueries;
using Gymmer.Core.Extensions;
using Gymmer.Infrastructure.Persistence.Repository;
using NSubstitute;

namespace Gymmer.UnitTests.EndpointDefinitions.TrainingDefinitions;

public class PostTrainingDefinitionValidator_Tests
{
    private readonly ITrainingDefinitionsRepository _repository =
        Substitute.For<ITrainingDefinitionsRepository>();

    private readonly ITrainingDefinitionsValidationService _validation =
        Substitute.For<ITrainingDefinitionsValidationService>();

    [Fact]
    public void ValidateAsync_NoPossibleToDuplicate_TrainingDefinitionName()
    {
        // Arrange
        var command = new PostTrainingDefinitionCommand
        {
            Name = "A2"
        };
        _repository.FindByName(Arg.Any<string?>()).Returns(command.ToAddModel());
        var validator = new PostTrainingDefinitionValidator(_repository, _validation);

        // Act
        var result = validator.Validate(command);

        // Assert
        var failureResponse = result.Errors.ToResponse();
        var error = failureResponse.Errors.Should().ContainSingle().Which;
        error.Should().Be(TrainingDefinitionsValidationMessages.Duplicated.AddParams("A2").Message);
    }

    [Fact]
    public void ValidateAsync_SomeOfExerciseOptionIds_NotExistInDatabase()
    {
        // Arrange
        var command = new PostTrainingDefinitionCommand
        {
            Name = "A2",
            ExerciseIds = new List<long> { 1, 2 }
        };
        _validation.AllExerciseOptionIdsAreCorrect(Arg.Any<IEnumerable<long>>()).Returns(false);
        var validator = new PostTrainingDefinitionValidator(_repository, _validation);

        // Act
        var result = validator.Validate(command);

        // Assert
        var failureResponse = result.Errors.ToResponse();
        var error = failureResponse.Errors.Should().ContainSingle().Which;
        error.Should().Be(TrainingDefinitionsValidationMessages.IncorrectExerciseOptionIds.Message);
    }
    
    [Fact]
    public void ValidateAsync_WhenExerciseOptionsListIsEmpty_NoValidationExecuted()
    {
        // Arrange
        var command = new PostTrainingDefinitionCommand
        {
            Name = "A2",
            ExerciseIds = null
        };
        _validation.AllExerciseOptionIdsAreCorrect(Arg.Any<IEnumerable<long>>()).Returns(false);
        var validator = new PostTrainingDefinitionValidator(_repository, _validation);

        // Act
        var result = validator.Validate(command);

        // Assert
        result.IsValid.Should().BeTrue();
    }
}