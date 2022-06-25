using MediatR;

namespace Polls.Application;

public static class IoC
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMediatR(typeof(IoC).Assembly);
        return services;
    }
}