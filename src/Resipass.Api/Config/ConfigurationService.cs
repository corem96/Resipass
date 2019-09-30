using System.IO;
using Microsoft.Extensions.Configuration;

namespace Resipass.Api.Config
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IEnvironmentService _environmentService;
        public string CurrentDirectory { get; set; }

        public ConfigurationService(IEnvironmentService environmentService)
        {
            _environmentService = environmentService;
        }
        
        public IConfiguration GetConfiguration()
        {
            CurrentDirectory = CurrentDirectory ?? Directory.GetCurrentDirectory();
            
            return new ConfigurationBuilder()
                .SetBasePath(CurrentDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{_environmentService.EnvironmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}