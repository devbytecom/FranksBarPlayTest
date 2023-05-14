using FranksBar.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FranksBar.DataAccess.Setup;

public static class ServiceCollectionsExtension
{
    public static void AddFranksBarDataAccess(this IServiceCollection services)
    {
        services.AddScoped<IBeerRepository, BeerRepository>();
    }
}

