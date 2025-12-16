using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Reminder.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        return services;
    }
}
