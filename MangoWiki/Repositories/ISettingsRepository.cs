using System;
using System.Collections.Generic;

namespace MangoWiki.Repositories
{
    public interface ISettingsRepository
    {
        Dictionary<string, string> Get();
        void Save(Dictionary<string, object> dictionary);
        bool IsStale(DateTime lastLoad);
    }
}
