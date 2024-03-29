﻿using FluentAssertions;
using Gymmer.Application.EndpointDefinitions.ExerciseOptions.ApiQueries;
using Gymmer.Infrastructure.Persistence.Models;
using Gymmer.Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Gymmer.UnitTests.EndpointDefinitions.ExerciseOptions;

public class ExerciseOptionsEndpointDefinition_Tests
{
    private readonly IExerciseOptionsRepository _exerciseOptionsRepository =
        Substitute.For<IExerciseOptionsRepository>();

    [Fact]
    public async Task Get_FindAllExerciseOptions_Successfully()
    {
        // Arrange
        _exerciseOptionsRepository.FindAllAsync().ReturnsForAnyArgs(new List<ExerciseOptionModel?>
        {
            new() { Id = 1, Name = "Zakroki", Description = "Spokojne tempo do tyłu i do przodu" },
            new() { Id = 2, Name = "Wyciskanie bokiem", Description = "Ćwiczenie w celu otwierania 2x w tygodniu" }
        });

        // Act
        var result =
            await GetExerciseOption.Query(_exerciseOptionsRepository, CancellationToken.None);

        // Assert
        result.As<Ok<List<ExerciseOptionDto>>>().Value.Should()
            .BeEquivalentTo(new List<ExerciseOptionDto>
            {
                new ExerciseOptionDto { Id = 1, Name = "Zakroki" },
                new ExerciseOptionDto { Id = 2, Name = "Wyciskanie bokiem" }
            });
        result.As<Ok<List<ExerciseOptionDto>>>().StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Post_AddNewExerciseOption_Successfully()
    {
        // Arrange
        _exerciseOptionsRepository
            .AddAsync(Substitute.For<ExerciseOptionModel>(), CancellationToken.None)
            .ReturnsNull();

        // Act
        var result =
            await PostExerciseOption.Query(new PostExerciseOptionCommand
                {
                    Name = "Pompka"
                },
                _exerciseOptionsRepository,
                CancellationToken.None);

        // Assert
        result.As<Created>().StatusCode.Should().Be(201);
    }

    [Fact]
    public async Task Put_UpdateExerciseOption_Successfully()
    {
        // Arrange
        _exerciseOptionsRepository
            .FindByIdAsync(Arg.Any<long>(), CancellationToken.None)
            .Returns(new ExerciseOptionModel
            {
                Id = 1,
                Name = "Pompka"
            });
        _exerciseOptionsRepository
            .UpdateAsync(Substitute.For<ExerciseOptionModel>(), CancellationToken.None)
            .ReturnsNull();

        // Act
        var result =
            await PutExerciseOption.Query(new PutExerciseOptionCommand
                {
                    Id = 1,
                    Name = "Pompka"
                },
                _exerciseOptionsRepository,
                CancellationToken.None);

        // Assert
        result.As<Accepted>().StatusCode.Should().Be(202);
    }

    [Fact]
    public async Task Delete_RemoveExerciseOption_Successfully()
    {
        // Arrange
        _exerciseOptionsRepository
            .RemoveAsync(Arg.Any<long>(), CancellationToken.None)
            .ReturnsNull();

        // Act
        var result =
            await DeleteExerciseOption.Query(Arg.Any<long>(),
                _exerciseOptionsRepository,
                CancellationToken.None);

        // Assert
        result.As<NoContent>().StatusCode.Should().Be(204);
    }
}