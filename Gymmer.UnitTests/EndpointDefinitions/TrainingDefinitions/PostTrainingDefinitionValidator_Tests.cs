using FluentAssertions;
using Gymmer.Application.EndpointDefinitions.TrainingDefinition;
using Gymmer.Application.EndpointDefinitions.TrainingDefinition.ApiQueries;
using Gymmer.Core.Extensions;
using Gymmer.Infrastructure.Persistence.Repository;
using NSubstitute;

namespace Gymmer.UnitTests.EndpointDefinitions.TrainingDefinitions;

public class PostTrainingDefinitionValidator_Tests
{
    private readonly ITrainingDefinitionsRepository _trainingDefinitionsRepository =
        Substitute.For<ITrainingDefinitionsRepository>();
    
    [Fact]
    public void ValidateAsync_NoPossibleToDuplicate_TrainingDefinitionName()
    {
        // Arrange
        var command = new PostTrainingDefinitionCommand
        {
            Name = "A2"
        };
        _trainingDefinitionsRepository.FindByName(Arg.Any<string?>()).Returns(command.ToAddModel());
        var validator = new PostTrainingDefinitionValidator(_trainingDefinitionsRepository);

        // Act
        var result = validator.Validate(command);
        
        // Assert
        var failureResponse = result.Errors.ToResponse();
        var error = failureResponse.Errors.Should().ContainSingle().Which;
        error.Should().Be(TrainingDefinitionsValidationMessages.Duplicated.AddParams("A2"));
    }
}