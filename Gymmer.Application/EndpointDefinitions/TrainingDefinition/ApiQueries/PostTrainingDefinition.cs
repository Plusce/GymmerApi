using Gymmer.Application.EndpointDefinitions.ExerciseOptions;
using Gymmer.Application.EndpointDefinitions.ExerciseOptions.ApiQueries;
using Gymmer.Core.Extensions;

namespace Gymmer.Application.EndpointDefinitions.TrainingDefinition.ApiQueries;

internal static class PostTrainingDefinition
{
    public static readonly
        Func<PostExerciseOptionCommand, ITrainingDefinitionsRepository, CancellationToken, Task<IResult>> Query =
            async (command, repository, ct) =>
            {
                var result = await repository.AddAsync(command.ToAddModel(), ct);
                return Results.Created("/exercise-options", result);
            };
}

public record PostTrainingDefinitionCommand
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}

public class PostTrainingDefinitionValidator : AbstractValidator<PostTrainingDefinitionCommand>
{
    public PostTrainingDefinitionValidator(ITrainingDefinitionsRepository repository)
    {
        RuleFor(cmd => cmd.Name)
            .Cascade(CascadeMode.Stop)
            .MinimumLength(2)
            .MaximumLength(200)
            .Must(name => repository.FindByName(name) == null)
            .WithMessage(cmd => ExerciseOptionValidationMessages
                .Duplicated
                .AddParams(cmd.Name));
    }
}