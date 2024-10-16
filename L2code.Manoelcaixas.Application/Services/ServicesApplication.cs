using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace L2code.Manoelcaixas.Application.Services;
    
public static class ServicesApplication
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}
