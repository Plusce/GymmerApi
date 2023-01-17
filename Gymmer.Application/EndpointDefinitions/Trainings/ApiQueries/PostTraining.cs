using Gymmer.Core.Extensions;
using Gymmer.Infrastructure.Persistence.DbContext;
using Gymmer.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Gymmer.Application.EndpointDefinitions.Trainings.ApiQueries;

internal static class PostTraining
{
    public static readonly Func<PostTrainingCommand, ITrainingsRepository, CancellationToken, Task<IResult>> Query =
        async (command, repository, ct) =>
        {
            var result = await repository.AddAsync(command.ToAddModel(), ct);
            return Results.Created(TrainingsEndpointDefinition.BasePath, result);
        };
}

public record PostTrainingCommand
{
    public string TrainingDefinitionName { get; set; } = string.Empty;
    public string TrainingName { get; set; } = string.Empty;
    public Dictionary<string, List<TrainingSeriesModel>> Exercises { get; set; } = new();
}

public class PostTrainingValidator : AbstractValidator<PostTrainingCommand>
{
    public PostTrainingValidator(ITrainingDefinitionsRepository trainingDefinitionRepository,
        IPostTrainingValidationService validation)
    {
        RuleFor(cmd => cmd.TrainingDefinitionName)
            .Cascade(CascadeMode.Stop)
            .MinimumLength(1)
            .MaximumLength(200)
            .Must(name => trainingDefinitionRepository.FindByName(name) != null)
            .WithMessage(cmd => TrainingValidationMessages.IncorrectExerciseOptionNames
                .AddParams(cmd.TrainingDefinitionName)
                .Message);

        RuleFor(cmd => cmd.TrainingName)
            .MinimumLength(1)
            .MaximumLength(200);

        RuleFor(cmd => cmd.Exercises)
            .Must(x => validation.AllExerciseNamesAreCorrect(x.Keys.AsEnumerable()))
            .WithMessage(cmd => TrainingValidationMessages.IncorrectExerciseOptionNames.Message);
    }
}

public interface IPostTrainingValidationService
{
    public bool AllExerciseNamesAreCorrect(IEnumerable<string> exerciseNames);
}

public class PostTrainingValidationService : IPostTrainingValidationService
{
    private readonly ITrainingDefinitionsRepository _trainingDefinitionRepository;

    public PostTrainingValidationService(ITrainingDefinitionsRepository trainingDefinitionRepository)
    {
        _trainingDefinitionRepository = trainingDefinitionRepository;
    }

    public bool AllExerciseNamesAreCorrect(IEnumerable<string> exerciseNames)
    {
        return exerciseNames.All(name =>
            _trainingDefinitionRepository.FindByName(name) != null); // TODO: To optimize this method
    }
}