using System.ComponentModel.DataAnnotations;
using Gymmer.Application.EndpointDefinitions.Exercise;
using Gymmer.Core.Interfaces;
using Gymmer.Core.Models;
using Gymmer.Infrastructure.Persistence.Models;
using Gymmer.Infrastructure.Persistence.Repository;
using MiniValidation;

namespace Gymmer.Application.EndpointDefinitions.PoliticalParty;

public class ExerciseQueries
{
    internal static readonly Func<IExercisesRepository, CancellationToken, Task<IResult>> Read =
        async (repository, ct) =>
        {
            var politicalParties = (await repository.FindAllAsync(ct)).Select(party => party?.Name).ToList();
            return politicalParties.Count < 1 ? Results.Empty : Results.Ok(politicalParties);
        };
    
    internal static readonly Func<PostExerciseCommand, IExercisesRepository, CancellationToken, Task<IResult>> Post =
        async (command, repository, ct) =>
        {
            var validator = new PostExerciseValidator(repository, command);

            if (!MiniValidator.TryValidate(validator, out var errors))
            {
                return Results.ValidationProblem(errors);
            }

            var newExercise = new ExerciseModel(command.Name, command.Description);
            
            await repository.AddAsync(newExercise, ct);

            return Results.Created("/exercises", newExercise);
        };
}