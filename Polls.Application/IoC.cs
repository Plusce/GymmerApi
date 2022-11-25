namespace Polls.Application;

public static class IoC
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);
        return services;
    }
}