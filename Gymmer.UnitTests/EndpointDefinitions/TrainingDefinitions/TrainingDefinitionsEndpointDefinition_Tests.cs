using FluentAssertions;
using Gymmer.Application.EndpointDefinitions.ExerciseOptions.ApiQueries;
using Gymmer.Application.EndpointDefinitions.TrainingDefinition.ApiQueries;
using Gymmer.Infrastructure.Persistence.Models;
using Gymmer.Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Gymmer.UnitTests.EndpointDefinitions.TrainingDefinitions;

public class TrainingDefinitionsEndpointDefinition_Tests
{
    private readonly ITrainingDefinitionsRepository _trainingDefinitionsRepository =
        Substitute.For<ITrainingDefinitionsRepository>();

    [Fact]
    public async Task Post_AddNewExerciseOption_Successfully()
    {
        // Arrange
        _trainingDefinitionsRepository
            .AddAsync(Substitute.For<TrainingDefinitionModel>(), CancellationToken.None)
            .ReturnsNull();

        // Act
        var result =
            await PostTrainingDefinition.Query(new PostTrainingDefinitionCommand
                {
                    Name = "A2"
                },
                _trainingDefinitionsRepository,
                CancellationToken.None);

        // Assert
        result.As<Created>().StatusCode.Should().Be(201);
    }
}