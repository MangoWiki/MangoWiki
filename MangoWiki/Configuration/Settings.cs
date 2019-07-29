using System;
namespace MangoWiki.Configuration
{
    public class Settings
    {
        public Settings()
        {
            // log settings
            LogSecurity = true;
            LogPageEdits = true;
            LogModeration = true;
            LogErrors = true;

            IsMailerEnabled = false;
        }

        // log settings
        public bool LogSecurity { get; set; }
        public bool LogPageEdits { get; set; }
        public bool LogModeration { get; set; }
        public bool LogErrors { get; set; }

        // mail settings
        public bool IsMailerEnabled { get; set; }
    }
}
