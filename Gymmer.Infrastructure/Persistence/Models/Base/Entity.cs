namespace Gymmer.Infrastructure.Persistence.Models.Base;

public abstract class Entity : ICreationDate, IEditionDate
{
    public long Id { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? EditionDate { get; set; }
}