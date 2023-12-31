namespace StoreFilter.Infrastructure.Extension;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Infrastructure.Persistences.Interfaces;
using StoreFilter.Infrastructure.Persistences.Context;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var assembly = typeof(InjectionExtensions).Assembly.FullName;

        //Initialising my DbContext
        services.AddDbContext<StoreGamesContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("StringConnection"),
                b => b.MigrationsAssembly(assembly)
            );
        });

        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IGamesRepository, GamesRepository>();
        return services;
    }
}
