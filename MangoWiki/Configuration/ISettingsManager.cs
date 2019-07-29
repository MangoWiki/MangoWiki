using System;
using System.Collections.Generic;

namespace MangoWiki.Configuration
{
    public interface ISettingsManager
    {
        Settings Current { get; }
        void SaveCurrent();
        void FlushCurrent();
        void Save(Settings settings);
        void SaveCurrent(Dictionary<string, object> dictionary);
        bool IsLoaded();
    }
}
