using System;
using System.Collections.Generic;
using MangoWiki.Models;

namespace MangoWiki.Repositories
{
    public interface IServiceHeartbeatRepository
    {
        void RecordHeartbeat(string serviceName, string machineName, DateTime lastRun);
        List<ServiceHeartbeat> GetAll();
        void ClearAll();
    }
}
