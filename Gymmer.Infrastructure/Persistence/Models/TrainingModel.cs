using Gymmer.Infrastructure.Persistence.Models.Base;

namespace Gymmer.Infrastructure.Persistence.Models;

public class TrainingModel : NoSqlEntity
{
    public string TrainingDefinitionName { get; set; } = string.Empty;
    public string TrainingName { get; set; } = string.Empty;
    public Dictionary<string, List<TrainingSeriesModel>> Exercises { get; set; } = new();
}

public class TrainingSeriesModel
{
    public int Repetitions { get; set; }
    
    public int Kilograms { get; set; }
}