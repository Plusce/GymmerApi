using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Gymmer.Infrastructure.Persistence.Repository;

namespace Gymmer.Application.EndpointDefinitions.ExerciseOptions;

public record PostExerciseOptionCommand
{
    [Required, MinLength(3), MaxLength(200)]
    public string? Name { get; set; }

    [MaxLength(500)] public string? Description { get; set; }
}

public class PostExerciseOptionValidator : AbstractValidator<PostExerciseOptionCommand>
{
    public PostExerciseOptionValidator(IExerciseOptionsRepository repository)
    {
        RuleFor(cmd => cmd.Name)
            .Must(name => repository.FindByName(name) == null)
            .WithMessage(cmd =>
                $"Cannot name an exercise option with '{cmd.Name}' name. ExerciseOption option with this specific name has been already added.");
    }
}