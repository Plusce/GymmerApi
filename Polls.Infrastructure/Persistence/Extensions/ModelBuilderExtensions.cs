using Polls.Core.Models;

namespace Polls.Infrastructure.Persistence.Extensions;

public static class ModelBuilderExtensions
{
    public static ModelBuilder SetupPoliticalParty(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PoliticalPartyModel>().HasKey(p => p.Id);
        modelBuilder.Entity<PoliticalPartyModel>().Property(p => p.Name).IsRequired();
        modelBuilder.Entity<PoliticalPartyModel>().Property(p => p.CreationDate)
            .HasConversion<ValueConverters.DateTimeUtcConverter>();
        modelBuilder.Entity<PoliticalPartyModel>().Property(p => p.EditionDate)
            .HasConversion<ValueConverters.DateTimeUtcConverter>();

        return modelBuilder;
    }
    
    public static ModelBuilder SetupToTable(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PoliticalPartyModel>().ToTable("PoliticalParty");

        return modelBuilder;
    }
}