namespace Gymmer.Core.Models;

public class ExerciseModel : Entity
{
    public ExerciseModel(string? name, string? description = null)
    {
        Name = name;
        Description = description;
    }
    
    public string? Name { get; set; }
    public string? Description { get; set; }
}