using Gymmer.Core.Models;

namespace Gymmer.Infrastructure.Persistence.Models;

public class TrainingDefinitionModel : Entity
{
    public required string Name { get; set; }
}