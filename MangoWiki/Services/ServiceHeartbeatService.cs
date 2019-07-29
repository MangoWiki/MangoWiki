using System;
using System.Collections.Generic;
using MangoWiki.Models;
using MangoWiki.Repositories;

namespace MangoWiki.Services
{
    public class ServiceHeartbeatService : IServiceHeartbeatService
    {
        private readonly IServiceHeartbeatRepository _serviceHeartbeatRepository;

        public ServiceHeartbeatService(IServiceHeartbeatRepository serviceHeartbeatRepository)
        {
            _serviceHeartbeatRepository = serviceHeartbeatRepository;
        }

        public void RecordHeartbeat(string serviceName, string machineName)
        {
            _serviceHeartbeatRepository.RecordHeartbeat(serviceName, machineName, DateTime.UtcNow);
        }

        public List<ServiceHeartbeat> GetAll()
        {
            return _serviceHeartbeatRepository.GetAll();
        }

        public void ClearAll()
        {
            _serviceHeartbeatRepository.ClearAll();
        }
    }
}
