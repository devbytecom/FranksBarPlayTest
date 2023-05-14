using FranksBar.Api.Controllers;
using FranksBar.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FranksBar.Api.Tests.Integration.Steps
{
    public class TestWebAppFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(ConfigureServices);
        }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile("appsettings.IntegrationTests.json", true, true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();
            
            AddFakes(serviceCollection);
        }

        private void AddFakes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<BeerController>();
            serviceCollection.AddDbContext<DBarContext>(
                options => options.UseSqlite("Data Source=:memory:"));
        }
    }
}
