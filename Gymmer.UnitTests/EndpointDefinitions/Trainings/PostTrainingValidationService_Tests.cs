using FluentAssertions;
using Gymmer.Application.EndpointDefinitions.Trainings;
using Gymmer.Application.EndpointDefinitions.Trainings.ApiQueries;
using Gymmer.Core.Extensions;
using Gymmer.UnitTests.Fakes;

namespace Gymmer.UnitTests.EndpointDefinitions.Trainings;

public class PostTrainingValidationService_Tests
{
    [Fact]
    public async Task ValidateAsync_TrainingDefinitionName_IsNotCorrect()
    {
        // Arrange
        var repositoryFake = new TrainingDefinitionsRepositoryFake();
        var validation = new PostTrainingValidationService(repositoryFake);
        var validator = new PostTrainingValidator(validation);

        var command = new PostTrainingCommand
        {
            TrainingDefinitionName = "A1_3",
            TrainingName = "A1_3_10.11.2022"
        };

        // Act
        var result = await validator.ValidateAsync(command, CancellationToken.None);

        // Assert
        var failureResponse = result.Errors.ToResponse();
        var error = failureResponse.Errors.Should().ContainSingle().Which;
        error.Should().Be(TrainingValidationMessages.TrainingDefinitionNameNotExists
            .AddParams(command.TrainingDefinitionName).Message);
    }
}