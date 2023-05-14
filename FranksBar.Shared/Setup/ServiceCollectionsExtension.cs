using FranksBar.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FranksBar.DataAccess.Setup;

public static class ServiceCollectionsExtension
{
    public static void AddFranksBarShared(this IServiceCollection services)
    {
        services.AddScoped<IBeerService, BeerService>();
    }
}

