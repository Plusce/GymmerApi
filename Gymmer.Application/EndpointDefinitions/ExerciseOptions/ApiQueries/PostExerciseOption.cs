using Gymmer.Core.Extensions;

namespace Gymmer.Application.EndpointDefinitions.ExerciseOptions.ApiQueries;

internal static class PostExerciseOption
{
    public static readonly Func<PostExerciseOptionCommand, IExerciseOptionsRepository, CancellationToken, Task<IResult>>
        Query =
            async (command, repository, ct) =>
            {
                var result = await repository.AddAsync(command.ToAddModel(), ct);
                return Results.Created(ExerciseOptionsEndpointDefinition.BasePath, result);
            };
}

public record PostExerciseOptionCommand
{
    public required string Name { get; set; }

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
                .AddParams(cmd.Name)
                .Message);

        RuleFor(cmd => cmd.Description)
            .MaximumLength(500);
    }
}