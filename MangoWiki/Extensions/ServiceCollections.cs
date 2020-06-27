using Microsoft.Extensions.DependencyInjection;
using MangoWiki.Configuration;
using MangoWiki.Services;

namespace MangoWiki.Extensions
{
    public static class ServiceCollections
    {
        public static void AddMangoWikiConfig(this IServiceCollection services)
        {
            // Config
            services.AddTransient<IConfig, Config>();

            // database
            //services.AddTransient<IRepositoryService, RepositoryService>();
            //services.AddTransient<ISetupService, SetupService>();
            
        }

        public static void AddMangoWikiBase(this IServiceCollection services)
        {
            // services
            services.AddTransient<IErrorLog, ErrorLog>();
            services.AddTransient<ISettingsManager, SettingsManager>();

            // email
        }

        public static void AddMangoWikiBackgroundServices(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            BackgroundServices.SetupServices(serviceProvider, services);
        }
    }
}
