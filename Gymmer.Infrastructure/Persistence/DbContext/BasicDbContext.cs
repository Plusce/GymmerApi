using Gymmer.Infrastructure.Persistence.Extensions;
using Gymmer.Infrastructure.Persistence.Models;

namespace Gymmer.Infrastructure.Persistence.DbContext;

public class BasicDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    protected readonly IConfiguration Configuration;
    
    public DbSet<ExerciseModel> Exercise => Set<ExerciseModel>();
    
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