using System.ComponentModel.DataAnnotations;
using Gymmer.Application.EndpointDefinitions.PoliticalParty;
using Gymmer.Core.Interfaces;
using Gymmer.Core.Models;
using Gymmer.Infrastructure.Persistence.Models;
using Gymmer.Infrastructure.Persistence.Repository;

namespace Gymmer.Application.EndpointDefinitions.Exercise;

public record PostExerciseCommand
{
    [Required, MinLength(3), MaxLength(200)]
    public string? Name { get; set; }
    
    [MaxLength(500)]
    public string? Description { get; set; }
}

public class PostExerciseValidator : IValidatableObject
{
    private readonly IExercisesRepository _repository;
    private readonly PostExerciseCommand _postExerciseCommand;

    public PostExerciseValidator(IExercisesRepository repository, PostExerciseCommand postExerciseCommand)
    {
        _repository = repository;
        _postExerciseCommand = postExerciseCommand;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (_repository.FindByName(_postExerciseCommand.Name) != null)
        {
            yield return new(
                $"Cannot name an exercise '{_postExerciseCommand.Name}'. Exercise has been already added.", 
                new[] { nameof(ExerciseModel.Name) });
        }
    }
}