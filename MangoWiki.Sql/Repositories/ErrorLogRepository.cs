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

        public async Task<ErrorLogEntry> Create(DateTime timeStamp, string message, string stackTrace, string data, ErrorSeverity severity)
        {
            var errorLog = new ErrorLogEntry
            {
                Timestamp = timeStamp,
                Message = message,
                Stacktrace = stackTrace,
                Data = data,
                Severity = severity
            };


            await _dbContext.AddAsync(errorLog);
            return errorLog;
        }

        public int GetErrorCount()
        {
            return _dbContext.ErrorLogs.Count();
        }

        public async Task<List<ErrorLogEntry>> GetErrors(int startRow, int pageSize)
        {
               
        }

        public async Task DeleteError(int errorId)
        {

        }

    }
}
