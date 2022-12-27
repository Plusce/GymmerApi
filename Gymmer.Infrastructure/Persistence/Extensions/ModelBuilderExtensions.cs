using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Infrastructure.Persistence.Extensions;

public static class ModelBuilderExtensions
{
    public static ModelBuilder SetupExercise(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExerciseOptionModel>().HasKey(p => p.Id);
        modelBuilder.Entity<ExerciseOptionModel>().Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);
        modelBuilder.Entity<ExerciseOptionModel>().Property(p => p.Description)
            .HasMaxLength(500);
        modelBuilder.Entity<ExerciseOptionModel>().Property(p => p.CreationDate)
            .HasConversion<ValueConverters.DateTimeUtcConverter>();
        modelBuilder.Entity<ExerciseOptionModel>().Property(p => p.EditionDate)
            .HasConversion<ValueConverters.DateTimeUtcConverter>();

        return modelBuilder;
    }

    public static ModelBuilder SetupTraining(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TrainingDefinitionModel>().HasKey(p => p.Id);
        modelBuilder.Entity<TrainingDefinitionModel>().Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);
        modelBuilder.Entity<TrainingDefinitionModel>().Property(p => p.Description)
            .HasMaxLength(500);
        modelBuilder.Entity<TrainingDefinitionModel>().Property(p => p.CreationDate)
            .HasConversion<ValueConverters.DateTimeUtcConverter>();
        modelBuilder.Entity<TrainingDefinitionModel>().Property(p => p.EditionDate)
            .HasConversion<ValueConverters.DateTimeUtcConverter>();

        return modelBuilder;
    }

    public static ModelBuilder SetupTrainingExercises(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TrainingDefinitionExerciseOptionModel>()
            .HasKey(p => new { p.TrainingDefinitionId, p.ExerciseOptionId });

        modelBuilder.Entity<TrainingDefinitionExerciseOptionModel>()
            .HasOne(p => p.TrainingDefinition)
            .WithMany(p => p.Exercises)
            .HasForeignKey(p => p.TrainingDefinitionId);

        modelBuilder.Entity<TrainingDefinitionExerciseOptionModel>()
            .HasOne(p => p.ExerciseOption)
            .WithMany(p => p.Exercises)
            .HasForeignKey(p => p.ExerciseOptionId);

        modelBuilder.Entity<TrainingDefinitionExerciseOptionModel>()
            .Property(p => p.Order)
            .IsRequired();
            
        return modelBuilder;
    }

    public static ModelBuilder SetupToTable(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExerciseOptionModel>().ToTable("ExerciseOption");
        modelBuilder.Entity<TrainingDefinitionModel>().ToTable("TrainingDefinition");
        modelBuilder.Entity<TrainingDefinitionExerciseOptionModel>().ToTable("TrainingDefinitionExerciseOption");
        
        return modelBuilder;
    }
}