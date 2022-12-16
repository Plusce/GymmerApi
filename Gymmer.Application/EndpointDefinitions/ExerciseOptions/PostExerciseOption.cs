namespace Gymmer.Application.EndpointDefinitions.ExerciseOptions;

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
            .WithMessage(cmd =>
                $"Cannot name an exercise option with '{cmd.Name}' name. ExerciseOption option with this specific name has been already added.");

        RuleFor(cmd => cmd.Description)
            .MaximumLength(500);
    }
}