using Microsoft.Extensions.DependencyInjection;
using MangoWiki.Configuration;
using MangoWiki.Services;

namespace MangoWiki.Extensions
{
    public static class ServiceCollections
    {
        public static void AddMangoWikiBase(this IServiceCollection services)
        {
            // Config
            services.AddTransient<IConfig, Config>();
            services.AddTransient<IErrorLog, ErrorLog>();
            services.AddTransient<ISettingsManager, SettingsManager>();

            // email

            // services
            services.AddTransient<IRepositoryService, RepositoryService>();
            services.AddTransient<ISetupService, SetupService>();
        }

        public static void AddMangoWikiBackgroundServices(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            BackgroundServices.SetupServices(serviceProvider, services);
        }
    }
}
