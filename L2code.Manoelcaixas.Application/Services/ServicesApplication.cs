using L2code.Manoelcaixas.Application.Interfaces;
using L2code.Manoelcaixas.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace L2code.Manoelcaixas.Application.Services;
    
public static class ServicesApplication
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configurando o DbContext para usar o provedor InMemory
        services.AddDbContext<EmpacotamentoContext>(options =>
            options.UseInMemoryDatabase("InMemoryDb"));

        services.AddScoped<IPackagingService, PackagingService>();

        return services;
    }
}
