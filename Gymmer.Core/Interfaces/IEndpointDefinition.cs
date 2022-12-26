using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Gymmer.Core.Interfaces;

public interface IEndpointDefinition
{
    static abstract string BasePath { get; }
    void DefineServices(IServiceCollection services);

    void DefineEndpoints(WebApplication app);
}