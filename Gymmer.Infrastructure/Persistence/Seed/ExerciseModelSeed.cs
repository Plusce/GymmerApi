using Gymmer.Core.Models;
using Gymmer.Infrastructure.Persistence.DbContext;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Gymmer.Infrastructure.Persistence.Seed;

public static class ExerciseModelSeed
{
    private static Dictionary<string, ExerciseModel> _exercises;

    public static void Seed(this BasicDbContext dbContext)
    {
        _exercises = new Dictionary<string, ExerciseModel>
        {
            {
                "Pompka",
                new ExerciseModel("Pompka", "3 sekundy schodzisz w dół")
            },
            {
                "Martwy ciąg rumuński",
                new ExerciseModel("Martwy ciąg rumuński", "Pupa do tyłu → pupa do przodu")
            },
            {
                "Wiosło hantlami",
                new ExerciseModel("Wiosło hantlami", "Barki daleko od uszu")
            },
            {
                "Przysiad zakroczny (w miejscu)",
                new ExerciseModel("Przysiad zakroczny (w miejscu)", "Pięta z tyłu cały czas wysoko")
            },
            {
                "Ściąganie wyciągu jednorącz",
                new ExerciseModel("Ściąganie wyciągu jednorącz", "Najpierw lewa strona, potem prawa")
            },
            {
                "Wyciskanie leżąc bokiem",
                new ExerciseModel("Wyciskanie leżąc bokiem", "Najpierw lewa strona, potem prawa")
            },
            {
                "Podciąganie nachwyt",
                new ExerciseModel("Podciąganie nachwyt", "Wydech do góry")
            },
            {
                "Przyciąganie \"kocyka\" w leżeniu tyłem",
                new ExerciseModel("Przyciąganie \"kocyka\" w leżeniu tyłem", "Powoli odjeżdżasz, szybciej do siebie")
            },
            {
                "Wyciskanie końca sztangi",
                new ExerciseModel("Wyciskanie końca sztangi", "Lekkie pochylenie na końcu ruchu")
            },
            {
                "Rozpiętki",
                new ExerciseModel("Rozpiętki", "Wdech w dół, wydech do góry")
            },
            {
                "Zakroki",
                new ExerciseModel("Zakroki", "Spokojne tempo do tyłu i do przodu")
            },
            {
                "Wyciskanie bokiem",
                new ExerciseModel("Wyciskanie bokiem", "Ćwiczenie w celu otwierania 2x w tygodniu")
            },
        };

        dbContext.SeedExercises();

        dbContext.SaveChanges();
    }

    private static void SeedExercises(this BasicDbContext dbContext)
    {
        _exercises.ForEach(record =>
        {
            if (dbContext.Exercise.FirstOrDefault(party => party.Name == record.Key) == null)
                dbContext.Exercise.Add(record.Value);
        });
    }
}