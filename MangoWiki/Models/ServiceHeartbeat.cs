using System;

namespace MangoWiki.Models
{
    public class ServiceHeartbeat
    {
        public string ServiceName { get; set; }
        public string MachineName { get; set; }
        public DateTime LastRun { get; set; }
    }
}
