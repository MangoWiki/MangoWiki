  using System;

namespace MangoWiki.Services
{
    public class SetupService : ISetupService
    {
        private readonly IRepositoryService _repositoryService;

        public SetupService(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public bool IsDatabaseSetup()
        {
            return _repositoryService.IsDatabaseSetup();
        }
    }
}
