using Microsoft.Extensions.Configuration;

namespace MangoWiki.Configuration
{
    public class ConfigLoader
    {
        public ConfigContainer GetConfig(string basePath, string configFileName)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(basePath);
            builder.AddJsonFile(configFileName, optional: false);
            builder.AddEnvironmentVariables("APPSETTING_");
            var config = builder.Build();
            var container = new ConfigContainer();
            container.DatabaseConnectionString = config["MangoWiki:Database:ConnectionString"];

            return container;
        }
    }
}
