using System.Collections.Generic;
using MangoWiki.Models;

namespace MangoWiki.Services
{
    public interface IServiceHeartbeatService
    {
        void RecordHeartbeat(string serviceName, string machineName);
        List<ServiceHeartbeat> GetAll();
        void ClearAll();
    }
}
