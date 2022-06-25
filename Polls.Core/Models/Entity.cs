namespace Polls.Core.Models;

public abstract class Entity
{
    public long Id { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? EditionDate { get; set; }
    public long CreatedById { get; set; }
    public string? CreatedByName { get; set; }
    public long EditedById { get; set; }
    public string? EditedByName { get; set; }
}