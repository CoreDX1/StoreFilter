using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreFilter.Application.Interfaces;
using StoreFilter.Application.Services;

namespace StoreFilter.Application.Extensions;

public static class InjectionExtension
{
    public static IServiceCollection AddInjectionApplication(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddSingleton(configuration);
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IGameApplication, GameApplication>();
        return services;
    }
}
