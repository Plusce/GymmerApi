using Gymmer.Infrastructure.Persistence.Extensions;
using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Infrastructure.Persistence.DbContext;

public class BasicDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    protected readonly IConfiguration Configuration;
    
    public DbSet<ExerciseOptionModel> ExerciseOption => Set<ExerciseOptionModel>();
    
    public DbSet<TrainingDefinitionModel> TrainingDefinition => Set<TrainingDefinitionModel>();
    
    protected BasicDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SetupExercise();
        modelBuilder.SetupToTable();
    }
}