using L2code.Manoelcaixas.Application.Interfaces;
using L2code.Manoelcaixas.Application.Services.TokenServices;
using L2code.Manoelcaixas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using System.IdentityModel.Tokens.Jwt;
namespace L2code.Manoelcaixas.Application.Services;

public static class ServicesApplication
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configurando o DbContext para usar o provedor InMemory
        services.AddDbContext<EmpacotamentoContext>(options =>
            options.UseInMemoryDatabase("InMemoryDb"));

        // Configuração do JwtBearer
        var secretKey = "yourSuperSecretKeyThatIsLongEnough123456"; // Deve ter pelo menos 32 caracteres
        var key = Encoding.ASCII.GetBytes(secretKey);


        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "yourIssuer",
                    ValidAudience = "yourAudience",
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    LifetimeValidator = (notBefore, expires, securityToken, validationParameters) =>
                    {
                        var jwtToken = securityToken as JsonWebToken;
                        if (jwtToken == null)
                            return false;

                        var handler = new JwtSecurityTokenHandler();
                        string tokenString = jwtToken.EncodedToken;
                        var jwtSecurityToken = handler.ReadJwtToken(tokenString);

                        return !RevokedTokens.IsTokenRevoked(jwtSecurityToken.RawData) &&
                               expires != null && expires > DateTime.UtcNow;
                    }
                };
            });


        services.AddSingleton<ITokenService>(provider => new TokenService(secretKey, "yourIssuer", "yourAudience"));
        services.AddScoped<IPackagingService, PackagingService>();

        return services;
    }
}
