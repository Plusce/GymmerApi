using System.ComponentModel.DataAnnotations;
using Gymmer.Core.Models;

namespace Gymmer.Infrastructure.Persistence.Models;

public class ExerciseOptionModel : Entity
{
    public string? Name { get; set; }
    
    public string? Description { get; set; }
}