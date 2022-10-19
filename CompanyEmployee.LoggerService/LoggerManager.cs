using CompanyEmployee.Contracts;
using NLog;

namespace CompanyEmployee.LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerManager()
        { 
            
        }

        public void LogDebug(string message)
        {
            throw new NotImplementedException();
        }

        public void LogError(string message)
        {
            throw new NotImplementedException();
        }

        public void LogInfo(string message)
        {
            throw new NotImplementedException();
        }

        public void LogWarn(string message)
        {
            throw new NotImplementedException();
        }
    }
}
