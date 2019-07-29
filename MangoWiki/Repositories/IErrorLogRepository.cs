using System;
using System.Collections.Generic;
using MangoWiki.Configuration;
using MangoWiki.Models;

namespace MangoWiki.Repositories
{
    public interface IErrorLogRepository
    {
        ErrorLogEntry Create(DateTime dateTime, string message, string stackTrace, string data, ErrorSeverity severity);
        int GetErrorCount();
        List<ErrorLogEntry> GetErrors(int startRow, int pageSize);
        void DeleteError(int errorID);
        void DeleteAllErrors();
    }
}
