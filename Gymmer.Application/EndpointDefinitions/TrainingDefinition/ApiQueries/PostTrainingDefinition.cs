using Gymmer.Core.Extensions;

namespace Gymmer.Application.EndpointDefinitions.TrainingDefinition.ApiQueries;

internal static class PostTrainingDefinition
{
    public static readonly
        Func<PostTrainingDefinitionCommand, ITrainingDefinitionsRepository, CancellationToken, Task<IResult>> Query =
            async (command, repository, ct) =>
            {
                var result = await repository.AddAsync(command.ToAddModel(), ct);
                return Results.Created(TrainingDefinitionsEndpointDefinition.BasePath, result);
            };
}

public record PostTrainingDefinitionCommand
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public List<long>? ExerciseIds { get; set; }
}

public class PostTrainingDefinitionValidator : AbstractValidator<PostTrainingDefinitionCommand>
{
    public PostTrainingDefinitionValidator(ITrainingDefinitionsRepository repository,
        ITrainingDefinitionsValidationService validation)
    {
        RuleFor(cmd => cmd.Name)
            .Cascade(CascadeMode.Stop)
            .MinimumLength(1)
            .MaximumLength(200)
            .Must(name => repository.FindByName(name) == null)
            .WithMessage(cmd => TrainingDefinitionsValidationMessages
                .Duplicated
                .AddParams(cmd.Name)
                .Message);
        
        RuleFor(cmd => cmd.Description)
            .MaximumLength(500);

        RuleFor(cmd => cmd.ExerciseIds)
            .Must(ids => validation.AllExerciseOptionIdsAreCorrect(ids!))
            .WithMessage(cmd => TrainingDefinitionsValidationMessages.IncorrectExerciseOptionIds.Message)
            .When(cmd => cmd.ExerciseIds is { Count: > 0 });
    }
}