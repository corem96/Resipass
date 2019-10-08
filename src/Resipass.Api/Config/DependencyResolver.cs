using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resipass.Data.contexto;

namespace Resipass.Api.Config
{
    public class DependencyResolver
    {
        public IServiceProvider ServiceProvider { get; set; }
        public string CurrentDirectory { get; set; }

        public DependencyResolver()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Revisa env y configura servicios
            services.AddTransient<IEnvironmentService, EnvironmentService>();
            services.AddTransient<IConfigurationService, ConfigurationService>
            (provider => new ConfigurationService(provider.GetService<IEnvironmentService>())
            {
                CurrentDirectory = CurrentDirectory
            });
            
            // Registra clase DbContext
            services.AddTransient(provider =>
            {
                var configService = provider.GetService<IConfigurationService>();
                var connectionString = configService.GetConfiguration()
                    .GetConnectionString("Default");
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                
                optionsBuilder.UseSqlServer(connectionString,
                    builder => builder.MigrationsAssembly("Resipass.Data"));

                return new AppDbContext(optionsBuilder.Options);
            });
        }
    }
}