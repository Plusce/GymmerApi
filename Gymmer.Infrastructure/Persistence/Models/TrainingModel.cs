using Gymmer.Infrastructure.Persistence.Models.Base;

namespace Gymmer.Infrastructure.Persistence.Models;

public class TrainingModel : NoSqlEntity
{
    public string TrainingDefinitionName { get; set; }
    public List<ExerciseModel> Exercises { get; set; }
}

public class ExerciseModel
{
    public string ExerciseName { get; set; }
    
    public List<TrainingSeriesModel> TrainingSeries { get; set; }
}

public class TrainingSeriesModel
{
    public int Repetitions { get; set; }
    
    public int Kilograms { get; set; }
}