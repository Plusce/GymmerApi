dotnet ef --project Polls.Infrastructure/Polls.Infrastructure.csproj --startup-project Polls.Service/Polls.Service.csproj migrations add InitialCreate --context SqliteDbContext --output-dir ./Persistence/SqliteMigrations --verbose