using Polls.Core.Models;

namespace Polls.Infrastructure.Persistence.Extensions;

public static class ModelBuilderExtensions
{
    public static ModelBuilder SetupToTable(this ModelBuilder modelBuilder)
    {
        const string schema = "Polls";
        modelBuilder.Entity<PoliticalPartyModel>().ToTable("PoliticalParty", schema);

        return modelBuilder;
    }
}