using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MangoWiki.Models;
using MangoWiki.Repositories;

namespace MangoWiki.Configuration
{
    public class ErrorLog : IErrorLog
    {
        private readonly IErrorLogRepository _errorLogRepository;

        public ErrorLog(IErrorLogRepository errorLogRepository)
        {
            _errorLogRepository = errorLogRepository;
        }

        public void Log(Exception exception, ErrorSeverity severity)
        {
            Log(exception, severity, null);
        }

        public void Log(Exception exception, ErrorSeverity severity, string additionalContext)
        {
            if (exception != null && exception is ErrorLogException)
            {
                return;
            }

            var message = String.Empty;
            var stackTrace = String.Empty;
            var errorString = new StringBuilder();

            if (additionalContext != null)
            {
                errorString.Append("Additional context:\r\n");
                errorString.Append(additionalContext);
                errorString.Append("\r\n\r\n");
            }

            if (exception != null)
            {
                message = exception.GetType().Name + ": " + exception.Message;
                if (exception.InnerException != null)
                {
                    message += "\r\n\r\nInner exception: " + exception.InnerException.Message;
                }

                stackTrace = exception.StackTrace ?? String.Empty;
                foreach(DictionaryEntry item in exception.Data)
                {
                    errorString.Append(item.Key);
                    errorString.Append(": ");
                    errorString.Append(item.Value);
                    errorString.Append("\r\n");
                }
            }

            errorString.Append("\r\n");

            try
            {
                _errorLogRepository.Create(DateTime.UtcNow, message, stackTrace, errorString.ToString(), severity);
            }
            catch
            {
                throw new ErrorLogException(String.Format("Can't log error: {0}\r\n\r\n{1}\r\n\r\n{2}", message, stackTrace, errorString));
            }
        }

        public List<ErrorLogEntry> GetErrors(int pageIndex, int pageSize, out PagerContext pagerContext)
        {
            var startRow = ((pageIndex - 1) * pageSize) + 1;
            var errors = _errorLogRepository.GetErrors(startRow, pageSize);
            var errorCount = _errorLogRepository.GetErrorCount();
            var totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(errorCount) / Convert.ToDouble(pageSize)));
            pagerContext = new PagerContext { PageCount = totalPages, PageIndex = pageIndex, PageSize = pageSize };
            return errors;
        }

        public PagedList<ErrorLogEntry> GetErrors(int pageIndex, int pageSize)
        {
            var errors = GetErrors(pageIndex, pageSize, out PagerContext pagerContext);
            var list = new PagedList<ErrorLogEntry> { PageCount = pagerContext.PageCount, PageIndex = pagerContext.PageIndex, PageSize = pagerContext.PageSize };
            return list;
        }

        public void DeleteError(int errorID)
        {
            _errorLogRepository.DeleteError(errorID);
        }

        public void DeleteAllErrors()
        {
            _errorLogRepository.DeleteAllErrors();
        }
    }
}
