namespace Gymmer.Core.Models;

public abstract class Entity
{
    public long Id { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? EditionDate { get; set; }
}