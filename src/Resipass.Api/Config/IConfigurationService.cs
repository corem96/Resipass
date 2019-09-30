using Microsoft.Extensions.Configuration;

namespace Resipass.Api.Config
{
    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
    }
}