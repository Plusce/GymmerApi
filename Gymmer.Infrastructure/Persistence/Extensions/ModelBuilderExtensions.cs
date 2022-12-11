using Gymmer.Core.Models;

namespace Gymmer.Infrastructure.Persistence.Extensions;

public static class ModelBuilderExtensions
{
    public static ModelBuilder SetupExercise(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExerciseModel>().HasKey(p => p.Id);
        modelBuilder.Entity<ExerciseModel>().Property(p => p.Name).IsRequired();
        modelBuilder.Entity<ExerciseModel>().Property(p => p.Description);
        modelBuilder.Entity<ExerciseModel>().Property(p => p.CreationDate)
            .HasConversion<ValueConverters.DateTimeUtcConverter>();
        modelBuilder.Entity<ExerciseModel>().Property(p => p.EditionDate)
            .HasConversion<ValueConverters.DateTimeUtcConverter>();

        return modelBuilder;
    }
    
    public static ModelBuilder SetupToTable(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExerciseModel>().ToTable("Exercise");

        return modelBuilder;
    }
}