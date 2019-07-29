using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using MangoWiki.Configuration;

namespace MangoWiki.Services
{
    public class BackgroundServices
    {
        public static void SetupServices(IServiceProvider serviceProvider, IServiceCollection services)
        {
            var startupService = serviceProvider.GetService<ISetupService>();

            if (!startupService.IsDatabaseSetup())
            {
                var repositoryService = serviceProvider.GetService<IRepositoryService>();
                var configService = serviceProvider.GetService<IConfig>();
                repositoryService.SetupDatabase(services, configService);
            }
        }
    }
}
