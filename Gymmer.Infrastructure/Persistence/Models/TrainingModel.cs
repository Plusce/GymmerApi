using Gymmer.Infrastructure.Persistence.Models.Base;

namespace Gymmer.Infrastructure.Persistence.Models;

public class TrainingModel : NoSqlEntity
{
    public string TrainingDefinitionName { get; set; } = string.Empty;
    public List<ExerciseModel> Exercises { get; set; } = new();
}

public class ExerciseModel
{
    public string ExerciseName { get; set; } = string.Empty;

    public List<TrainingSeriesModel> TrainingSeries { get; set; } = new();
}

public class TrainingSeriesModel
{
    public int Repetitions { get; set; }
    
    public int Kilograms { get; set; }
}