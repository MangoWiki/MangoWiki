namespace MangoWiki.Configuration
{
    public class Config : IConfig
    {
        private static string _basePath;
        private static string _configFileName;
        private static ConfigContainer configContainer;

        public Config()
        {
            if (configContainer == null)
            {
                var loader = new ConfigLoader();
                configContainer = loader.GetConfig(_basePath, _configFileName);
            }
        }

        public static void SetMangoWikiAppEnvironment(string basePath, string configFileName = "MangoWiki.json")
        {
            _basePath = basePath;
            _configFileName = configFileName;
        }

        public string DatabaseConnectionString => configContainer.DatabaseConnectionString;
    }
}
