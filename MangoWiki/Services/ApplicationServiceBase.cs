using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using MangoWiki.Configuration;

namespace MangoWiki.Services
{
    public abstract class ApplicationServiceBase
    {
        protected abstract void ServiceAction();
        protected abstract int GetInterval();

        private static int _errorCount;

        public DateTime? LastExecutionTime { get; private set; }
        public bool IsRunning { get; private set; }
        public string Name { get; private set; }
        public Timer Timer { get; private set; }
        public int Interval { get; private set; }
        public string ExceptionMessage { get; private set; }

        protected ApplicationServiceBase()
        {
            Name = GetType().FullName;
            LastExecutionTime = null;
            IsRunning = false;
            ExceptionMessage = String.Empty;
            _errorCount = 0;
            Interval = 1;
        }


    }
}
