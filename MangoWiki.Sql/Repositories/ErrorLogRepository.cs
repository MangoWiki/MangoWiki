using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MangoWiki.Configuration;
using MangoWiki.Models;
using MangoWiki.Repositories;
using MangoWiki.Data;

namespace MangoWiki.Sql.Repositories
{
    public class ErrorLogRepository : IErrorLogRepository
    {
        private MangoWikiDbContext _dbContext;

        public ErrorLogRepository(MangoWikiDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public ErrorLogEntry Create(DateTime timeStamp, string message, string stackTrace, string data, ErrorSeverity severity)
        {
            var errorLog = new ErrorLogEntry
            {
                Timestamp = timeStamp,
                Message = message,
                Stacktrace = stackTrace,
                Data = data,
                Severity = severity
            };


             _dbContext.Add(errorLog);
            return errorLog;
        }

        public int GetErrorCount()
        {
            return _dbContext.ErrorLogs.Count();
        }

        public List<ErrorLogEntry> GetErrors()
        {
            return _dbContext.ErrorLogs.ToList();
        }

        public void DeleteError(int errorId)
        {
            ErrorLogEntry error = _dbContext.ErrorLogs.Where(enity => enity.ID == errorId).First();
            _dbContext.Remove(error);
        }

        public void DeleteAllErrors()
        {
           foreach (ErrorLogEntry error in _dbContext.ErrorLogs.ToList())
           {
                _dbContext.Remove(error);
           }
        }
    }
}
