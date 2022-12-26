using Microsoft.EntityFrameworkCore;

namespace Gymmer.Application.EndpointDefinitions.ExerciseOptions.ApiQueries;

public static class PutExerciseOption
{
    internal static readonly Func<PutExerciseOptionCommand, IExerciseOptionsRepository, CancellationToken, Task<IResult>>
        Query =
            async (command, repository, ct) =>
            {
                var entity = await repository.FindByIdAsync(command.Id);
                var result = await repository.UpdateAsync(entity!.ToUpdateModel(command), ct);
                return Results.Accepted("/exercise-options", result);
            };
}

public class PutExerciseOptionCommand
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
}

public class PutExerciseOptionValidator : AbstractValidator<PutExerciseOptionCommand>
{
    public PutExerciseOptionValidator(IExerciseOptionsRepository repository,
        IPutExerciseOptionValidationService validationService)
    {
        When(cmd => cmd != null, () =>
        {
            RuleFor(cmd => cmd.Name)
                .Cascade(CascadeMode.Stop)
                .MinimumLength(2)
                .MaximumLength(200);

            RuleFor(cmd => cmd)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (cmd, ct) => await repository
                    .FindByIdAsync(cmd.Id, ct) != null)
                .WithMessage(cmd =>
                    $"Exercise with identifier '{cmd.Id}' has not been found.")
                .MustAsync(async (cmd, ct) => await validationService
                    .NameNotDuplicatedAsync(cmd.Id, cmd.Name, ct))
                .WithMessage(cmd =>
                    $"Cannot rename an exercise option with '{cmd.Name}' name. " +
                    "Exercise option with this specific name has been already added.")
                .When(cmd => cmd.Name.Length is >= 1 and <= 200);

            RuleFor(cmd => cmd.Description)
                .MaximumLength(500);
        });
    }
}

public interface IPutExerciseOptionValidationService
{
    Task<bool> NameNotDuplicatedAsync(long id, string name, CancellationToken ct);
}

public class PutExerciseOptionValidationService : IPutExerciseOptionValidationService
{
    private readonly IExerciseOptionsRepository _repository;

    public PutExerciseOptionValidationService(IExerciseOptionsRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> NameNotDuplicatedAsync(long id, string name, CancellationToken ct)
    {
        return await _repository.ReadOnlyQuery().AnyAsync(x => x.Id == id, cancellationToken: ct)
               && await _repository.ReadOnlyQuery().AllAsync(x => name != x.Name, ct);
    }
}