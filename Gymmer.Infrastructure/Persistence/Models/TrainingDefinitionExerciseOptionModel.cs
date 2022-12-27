using Gymmer.Core.Interfaces;
using Gymmer.Infrastructure.Persistence.Models.Base;

namespace Gymmer.Infrastructure.Persistence.Models;

public class TrainingDefinitionExerciseOptionModel
{
    public required long TrainingDefinitionId { get; set; }
    public TrainingDefinitionModel? TrainingDefinition { get; set; }
    
    public required long ExerciseOptionId { get; set; }
    public ExerciseOptionModel? ExerciseOption { get; set; }
    
    public required ushort Order { get; set; }
}