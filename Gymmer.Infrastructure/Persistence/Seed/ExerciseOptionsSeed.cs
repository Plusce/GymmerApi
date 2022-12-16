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
                new ExerciseOptionModel("Pompka", "3 sekundy schodzisz w dół")
            },
            {
                "Martwy ciąg rumuński",
                new ExerciseOptionModel("Martwy ciąg rumuński", "Pupa do tyłu → pupa do przodu")
            },
            {
                "Wiosło hantlami",
                new ExerciseOptionModel("Wiosło hantlami", "Barki daleko od uszu")
            },
            {
                "Przysiad zakroczny (w miejscu)",
                new ExerciseOptionModel("Przysiad zakroczny (w miejscu)", "Pięta z tyłu cały czas wysoko")
            },
            {
                "Ściąganie wyciągu jednorącz",
                new ExerciseOptionModel("Ściąganie wyciągu jednorącz", "Najpierw lewa strona, potem prawa")
            },
            {
                "Wyciskanie leżąc bokiem",
                new ExerciseOptionModel("Wyciskanie leżąc bokiem", "Najpierw lewa strona, potem prawa")
            },
            {
                "Podciąganie nachwyt",
                new ExerciseOptionModel("Podciąganie nachwyt", "Wydech do góry")
            },
            {
                "Przyciąganie \"kocyka\" w leżeniu tyłem",
                new ExerciseOptionModel("Przyciąganie \"kocyka\" w leżeniu tyłem", "Powoli odjeżdżasz, szybciej do siebie")
            },
            {
                "Wyciskanie końca sztangi",
                new ExerciseOptionModel("Wyciskanie końca sztangi", "Lekkie pochylenie na końcu ruchu")
            },
            {
                "Rozpiętki",
                new ExerciseOptionModel("Rozpiętki", "Wdech w dół, wydech do góry")
            },
            {
                "Zakroki",
                new ExerciseOptionModel("Zakroki", "Spokojne tempo do tyłu i do przodu")
            },
            {
                "Wyciskanie bokiem",
                new ExerciseOptionModel("Wyciskanie bokiem", "Ćwiczenie w celu otwierania 2x w tygodniu")
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