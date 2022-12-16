using Gymmer.Infrastructure.Persistence.DbContext;
using Gymmer.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Gymmer.Infrastructure.Persistence.Seed;

public static class ExerciseOptionsSeed
{
    private static Dictionary<string, ExerciseOptionModel>? _exercises;

    public static void Seed(this BasicDbContext dbContext)
    {
        _exercises = new Dictionary<string, ExerciseOptionModel>
        {
            {
                "Pompka",
                new()
                {
                    Name = "Pompka",
                    Description = "3 sekundy schodzisz w dół"
                }
            },
            {
                "Martwy ciąg rumuński",
                new()
                {
                    Name = "Martwy ciąg rumuński",
                    Description = "Pupa do tyłu → pupa do przodu"
                }
            },
            {
                "Wiosło hantlami",
                new()
                {
                    Name = "Wiosło hantlami",
                    Description = "Barki daleko od uszu"
                }
            },
            {
                "Przysiad zakroczny (w miejscu)",
                new()
                {
                    Name = "Przysiad zakroczny (w miejscu)",
                    Description = "Pięta z tyłu cały czas wysoko"
                }
            },
            {
                "Ściąganie wyciągu jednorącz",
                new()
                {
                    Name = "Ściąganie wyciągu jednorącz",
                    Description = "Najpierw lewa strona, potem prawa"
                }
            },
            {
                "Wyciskanie leżąc bokiem",
                new()
                {
                    Name = "Wyciskanie leżąc bokiem",
                    Description = "Najpierw lewa strona, potem prawa"
                }
            },
            {
                "Podciąganie nachwyt",
                new()
                {
                    Name = "Podciąganie nachwyt",
                    Description = "Wydech do góry"
                }
            },
            {
                "Przyciąganie \"kocyka\" w leżeniu tyłem",
                new()
                {
                    Name = "Przyciąganie \"kocyka\" w leżeniu tyłem",
                    Description = "Powoli odjeżdżasz, szybciej do siebie"
                }
            },
            {
                "Wyciskanie końca sztangi",
                new()
                {
                    Name = "Wyciskanie końca sztangi",
                    Description = "Lekkie pochylenie na końcu ruchu"
                }
            },
            {
                "Rozpiętki",
                new()
                {
                    Name = "Rozpiętki",
                    Description = "Wdech w dół, wydech do góry"
                }
            },
            {
                "Zakroki",
                new()
                {
                    Name = "Zakroki",
                    Description = "Spokojne tempo do tyłu i do przodu"
                }
            },
            {
                "Wyciskanie bokiem",
                new()
                {
                    Name = "Wyciskanie bokiem",
                    Description = "Ćwiczenie w celu otwierania 2x w tygodniu"
                }
            },
        };

        dbContext.SeedExercises();

        dbContext.SaveChanges();
    }

    private static void SeedExercises(this BasicDbContext dbContext)
    {
        _exercises.ForEach(record =>
        {
            if (dbContext.ExerciseOption.FirstOrDefault(party => party.Name == record.Key) == null)
                dbContext.ExerciseOption.Add(record.Value);
        });
    }
}