using Gymmer.Core.Extensions;

namespace Gymmer.Application.EndpointDefinitions.TrainingDefinition.ApiQueries;

internal static class PostTrainingDefinition
{
    public static readonly
        Func<PostTrainingDefinitionCommand, ITrainingDefinitionsRepository, CancellationToken, Task<IResult>> Query =
            async (command, repository, ct) =>
            {
                var result = await repository.AddAsync(command.ToAddModel(), ct);
                return Results.Created("/training-definitions", result);
            };
}

public record PostTrainingDefinitionCommand
{
    public required string Name { get; set; }
}

public class PostTrainingDefinitionValidator : AbstractValidator<PostTrainingDefinitionCommand>
{
    public PostTrainingDefinitionValidator(ITrainingDefinitionsRepository repository)
    {
        RuleFor(cmd => cmd.Name)
            .Cascade(CascadeMode.Stop)
            .MinimumLength(1)
            .MaximumLength(200)
            .Must(name => repository.FindByName(name) == null)
            .WithMessage(cmd => TrainingDefinitionsValidationMessages
                .Duplicated
                .AddParams(cmd.Name));
    }
}