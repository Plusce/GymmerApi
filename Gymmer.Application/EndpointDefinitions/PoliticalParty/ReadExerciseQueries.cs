using Gymmer.Core.Interfaces;

namespace Gymmer.Application.EndpointDefinitions.PoliticalParty;

public class ReadExerciseQueries
{
    internal static readonly Func<IExercisesRepository, CancellationToken, Task<IResult>> ReadExercises =
        async (repository, ct) =>
        {
            var politicalParties = (await repository.FindAllAsync(ct)).Select(party => party?.Name).ToList();
            return politicalParties.Count < 1 ? Results.Empty : Results.Ok(politicalParties);
        };
}