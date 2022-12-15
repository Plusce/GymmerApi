using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Gymmer.Core.Interfaces;
using Gymmer.Core.Models;
using Gymmer.Infrastructure.Persistence.Models;
using Gymmer.Infrastructure.Persistence.Repository;

namespace Gymmer.Application.EndpointDefinitions.Exercise;

public record PostExerciseCommand
{
    [Required, MinLength(3), MaxLength(200)]
    public string? Name { get; set; }

    [MaxLength(500)] public string? Description { get; set; }
}

public class PostExerciseValidator : AbstractValidator<PostExerciseCommand>
{
    public PostExerciseValidator(IExercisesRepository repository)
    {
        RuleFor(cmd => cmd.Name)
            .Must(name => repository.FindByName(name) != null)
            .WithMessage(cmd => $"Cannot name an exercise '{cmd.Name}'. Exercise with this specific name has been already added.");
    }
}