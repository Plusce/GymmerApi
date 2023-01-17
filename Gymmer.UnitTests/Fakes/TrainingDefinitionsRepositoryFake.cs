using Gymmer.Infrastructure.Persistence.Models;
using Gymmer.Infrastructure.Persistence.Repository;

namespace Gymmer.UnitTests.Fakes;

public class TrainingDefinitionsRepositoryFake : ITrainingDefinitionsRepository
{
    private readonly Dictionary<string, TrainingDefinitionModel> _definitions = new Dictionary<string, TrainingDefinitionModel>
    {
        {
            "A1_1",
            new()
            {
                Id = 1,
                Name = "A1_1",
                Description = "Trening pierwszy w miesiącu pierwszym",
                Exercises = new List<TrainingDefinitionExerciseOptionModel>
                {
                    new TrainingDefinitionExerciseOptionModel
                    {
                        Order = 1,
                        ExerciseOptionId = 1,
                        ExerciseOption = new ExerciseOptionModel
                        {
                            Id = 1,
                            Name = "Pompka"
                        },
                        TrainingDefinitionId = 1
                    },
                    new TrainingDefinitionExerciseOptionModel
                    {
                        Order = 2,
                        ExerciseOptionId = 2,
                        ExerciseOption = new ExerciseOptionModel
                        {
                            Id = 2,
                            Name = "Martwy ciąg rumuński"
                        },
                        TrainingDefinitionId = 1
                    }
                }
            }
        },
        {
            "A1_2",
            new()
            {
                Id = 2,
                Name = "A1_2",
                Description = "Trening drugi w miesiącu pierwszym",
                Exercises = new List<TrainingDefinitionExerciseOptionModel>
                {
                    new TrainingDefinitionExerciseOptionModel
                    {
                        Order = 1,
                        ExerciseOptionId = 3,
                        ExerciseOption = new ExerciseOptionModel
                        {
                            Id = 3,
                            Name = "Wiosło hantlami"
                        },
                        TrainingDefinitionId = 2
                    },
                    new TrainingDefinitionExerciseOptionModel
                    {
                        Order = 2,
                        ExerciseOptionId = 4,
                        ExerciseOption = new ExerciseOptionModel
                        {
                            Id = 4,
                            Name = "Przysiad zakroczny (w miejscu)"
                        },
                        TrainingDefinitionId = 2
                    }
                }
            }
        },
        {
            "A2_1",
            new()
            {
                Id = 3,
                Name = "A2_1",
                Description = "Trening pierwszy w miesiącu drugim",
                Exercises = new List<TrainingDefinitionExerciseOptionModel>
                {
                    new TrainingDefinitionExerciseOptionModel
                    {
                        Order = 1,
                        ExerciseOptionId = 5,
                        ExerciseOption = new ExerciseOptionModel
                        {
                            Id = 5,
                            Name = "Ściąganie wyciągu jednorącz"
                        },
                        TrainingDefinitionId = 3
                    },
                    new TrainingDefinitionExerciseOptionModel
                    {
                        Order = 2,
                        ExerciseOptionId = 6,
                        ExerciseOption = new ExerciseOptionModel
                        {
                            Id = 6,
                            Name = "Wyciskanie leżąc bokiem"
                        },
                        TrainingDefinitionId = 3
                    }
                }
            }
        },
        {
            "A2_2",
            new()
            {
                Id = 4,
                Name = "A2_2",
                Description = "Trening drugi w miesiącu drugim",
                Exercises = new List<TrainingDefinitionExerciseOptionModel>
                {
                    new TrainingDefinitionExerciseOptionModel
                    {
                        Order = 1,
                        ExerciseOptionId = 7,
                        ExerciseOption = new ExerciseOptionModel
                        {
                            Id = 8,
                            Name = "Przyciąganie \"kocyka\" w leżeniu tyłem"
                        },
                        TrainingDefinitionId = 4
                    },
                    new TrainingDefinitionExerciseOptionModel
                    {
                        Order = 2,
                        ExerciseOptionId = 8,
                        ExerciseOption = new ExerciseOptionModel
                        {
                            Id = 8,
                            Name = "Wyciskanie końca sztangi"
                        },
                        TrainingDefinitionId = 4
                    }
                }
            }
        }
    };

    public Task<TrainingDefinitionModel?> FindByIdAsync(long id, CancellationToken ct = default)
    {
        return Task.FromResult(_definitions.Values.FirstOrDefault(value => value.Id == id));
    }

    public Task<List<TrainingDefinitionModel?>> FindAllAsync(CancellationToken ct = default)
    {
        return Task.FromResult(_definitions.Values.ToList())!;
    }

    public IQueryable<TrainingDefinitionModel> ReadOnlyQuery()
    {
        return _definitions.Values.AsQueryable();
    }

    public TrainingDefinitionModel? FindByName(string? name)
    {
        return name != null ? _definitions[name] : null;
    }

    public Task<TrainingDefinitionModel> AddAsync(TrainingDefinitionModel definitionModel, CancellationToken ct)
    {
        _definitions.TryAdd(definitionModel.Name, definitionModel);
        return Task.FromResult(definitionModel);
    }

    public Task RemoveAsync(long id, CancellationToken ct)
    {
        var name = _definitions.Values.FirstOrDefault(value => value.Id == id)?.Name;

        if (name == null)
        {
            return Task.CompletedTask;
        }
        
        _definitions.Remove(name);
        return Task.CompletedTask;
    }
} 