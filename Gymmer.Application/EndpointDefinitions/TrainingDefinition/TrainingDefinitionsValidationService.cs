using Microsoft.EntityFrameworkCore;

namespace Gymmer.Application.EndpointDefinitions.TrainingDefinition;

public interface ITrainingDefinitionsValidationService
{
    bool AllExerciseOptionIdsAreCorrect(IEnumerable<long> ids);
}

public class TrainingDefinitionsValidationService : ITrainingDefinitionsValidationService
{
    private readonly ITrainingDefinitionsRepository _repository;
    
    public TrainingDefinitionsValidationService(ITrainingDefinitionsRepository repository)
    {
        _repository = repository;
    }
    
    public bool AllExerciseOptionIdsAreCorrect(IEnumerable<long> ids)
    {
        return ids.All(id => _repository.ReadOnlyQuery().Any(x => x.Id == id));
    }
}