using System;
using MangoWiki.Configuration;

namespace MangoWiki.Models
{
    public class ErrorLogEntry
    {
        public int ID { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public string Stacktrace { get; set; }
        public string Data { get; set; }
        public ErrorSeverity Severity { get; set; }
        public string SeverityString => Severity.ToString();
    }
}
