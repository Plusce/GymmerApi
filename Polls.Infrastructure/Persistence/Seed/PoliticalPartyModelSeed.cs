using Polls.Core.Models;
using Polls.Infrastructure.Persistence.DbContext;

namespace Polls.Infrastructure.Persistence.Seed;

public static class PoliticalPartyModelSeed
{
    public static void Seed(this BasicDbContext dbContext)
    {
        dbContext.SeedPoliticalParties();

        dbContext.SaveChanges();
    }
    
    private static void SeedPoliticalParties(this BasicDbContext dbContext)
    {
        if (dbContext.PoliticalParty.FirstOrDefault(party => party.Name == "Platforma Obywatelska") == null)
            dbContext.PoliticalParty.Add(new PoliticalPartyModel() { Name = "Platforma Obywatelska" });
        if (dbContext.PoliticalParty.FirstOrDefault(party => party.Name == "Prawo i Sprawiedliwość") == null)
            dbContext.PoliticalParty.Add(new PoliticalPartyModel() { Name = "Prawo i Sprawiedliwość" });
        if (dbContext.PoliticalParty.FirstOrDefault(party => party.Name == "Nowa Lewica") == null)
            dbContext.PoliticalParty.Add(new PoliticalPartyModel() { Name = "Nowa Lewica" });
        if (dbContext.PoliticalParty.FirstOrDefault(party => party.Name == "Polska 2050") == null)
            dbContext.PoliticalParty.Add(new PoliticalPartyModel() { Name = "Polska 2050" });
        if (dbContext.PoliticalParty.FirstOrDefault(party => party.Name == "Polskie Stronnictwo Ludowe") == null)
            dbContext.PoliticalParty.Add(new PoliticalPartyModel() { Name = "Polskie Stronnictwo Ludowe" });
        if (dbContext.PoliticalParty.FirstOrDefault(party => party.Name == "Konfederacja") == null)
            dbContext.PoliticalParty.Add(new PoliticalPartyModel() { Name = "Konfederacja" });
    }
}