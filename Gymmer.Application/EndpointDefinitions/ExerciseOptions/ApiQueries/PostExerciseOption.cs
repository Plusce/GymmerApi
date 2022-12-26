using Gymmer.Core.Extensions;

namespace Gymmer.Application.EndpointDefinitions.ExerciseOptions.ApiQueries;

public static class PostExerciseOption
{
    internal static readonly Func<PostExerciseOptionCommand, IExerciseOptionsRepository, CancellationToken, Task<IResult>>
        Query =
            async (command, repository, ct) =>
            {
                var result = await repository.AddAsync(command.ToAddModel(), ct);
                return Results.Created("/exercise-options", result);
            };
}

public record PostExerciseOptionCommand
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}

public class PostExerciseOptionValidator : AbstractValidator<PostExerciseOptionCommand>
{
    public PostExerciseOptionValidator(IExerciseOptionsRepository repository)
    {
        RuleFor(cmd => cmd.Name)
            .Cascade(CascadeMode.Stop)
            .MinimumLength(2)
            .MaximumLength(200)
            .Must(name => repository.FindByName(name) == null)
            .WithMessage(cmd => ExerciseOptionValidationMessages
                .Duplicated
                .AddParams(cmd.Name));

        RuleFor(cmd => cmd.Description)
            .MaximumLength(500);
    }
}