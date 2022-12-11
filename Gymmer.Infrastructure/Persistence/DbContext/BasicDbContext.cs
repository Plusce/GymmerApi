using Gymmer.Core.Models;
using Gymmer.Infrastructure.Persistence.Extensions;

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