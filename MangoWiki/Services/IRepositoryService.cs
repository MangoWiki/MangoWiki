using Microsoft.Extensions.DependencyInjection;
using MangoWiki.Configuration;

namespace MangoWiki.Services
{
    public interface IRepositoryService
    {
        bool IsDatabaseSetup();
        void SetupDatabase(IServiceCollection services, IConfig config);
    }
}
