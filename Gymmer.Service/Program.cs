using FluentValidation;
using Gymmer.Application.EndpointDefinitions.ExerciseOptions;
using Gymmer.Application.EndpointDefinitions.ExerciseOptions.ApiQueries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Gymmer.Core.Extensions;
using Gymmer.Service.EndpointDefinitions;
using Gymmer.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddLogging();
builder.Services.AddPersistence();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}/";
    options.Audience = builder.Configuration["Auth0:Audience"];
});

builder.Services.AddValidatorsFromAssemblyContaining<PostExerciseOptionValidator>();

builder.Services.AddEndpointDefinitions(typeof(SwaggerEndpointDefinition), 
    typeof(ExerciseOptionsEndpointDefinition));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpointDefinitions();

app.SetupDatabase();
app.SeedDatabase();

app.Run();

public partial class Program
{
}