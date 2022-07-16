using Polls.Core.Models;
using Polls.Infrastructure.Persistence.DbContext;

namespace Polls.IntegrationTests.Utilities
{
    public static class Utilities
    {
        public static void InitializeDbForTests(BasicDbContext db)
        {
            db.PoliticalParty.AddRange(ReadSeedingPoliticalParties());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(BasicDbContext db)
        {
            db.PoliticalParty.RemoveRange(db.PoliticalParty);
            InitializeDbForTests(db);
        }

        public static List<PoliticalPartyModel> ReadSeedingPoliticalParties()
        {
            return new List<PoliticalPartyModel>()
            {
                new PoliticalPartyModel(){ Name = "Platforma Obywatelska" },
                new PoliticalPartyModel(){ Name = "Prawo i Sprawiedliwość" },
                new PoliticalPartyModel(){ Name = "Nowa Lewica" },
                new PoliticalPartyModel(){ Name = "Polska 2050" },
                new PoliticalPartyModel(){ Name = "Polskie Stronnictwo Ludowe" },
                new PoliticalPartyModel(){ Name = "Konfederacja" },
            };
        }
    }
}