using System;
using System.Collections.Generic;
using MangoWiki.Models;

namespace MangoWiki.Configuration
{
    public interface IErrorLog
    {
        void Log(Exception exception, ErrorSeverity severity);
        void Log(Exception exception, ErrorSeverity severity, string additionalContext);
        List<ErrorLogEntry> GetErrors(int pageIndex, int pageSize, out PagerContext pagerContext);
        PagedList<ErrorLogEntry> GetErrors(int pageIndex, int pageSize);
        void DeleteError(int errorID);
        void DeleteAllErrors();
    }
}
