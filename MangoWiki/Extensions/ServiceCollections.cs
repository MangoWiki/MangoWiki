using Microsoft.Extensions.DependencyInjection;
using MangoWiki.Configuration;

namespace MangoWiki.Extensions
{
    public static class ServiceCollections
    {
        public static void AddMangoWikiBase(this IServiceCollection services)
        {
            // Config
            services.AddTransient<IConfig, Config>();
        }

        public static void AddMangoWikiBackgroundServices(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

        }
    }
}
