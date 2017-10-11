using System;
using MEL = Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;

namespace Mfah.Logging.MicrosoftExtensionsLogging
{
    public class MicrosoftExtensionsLoggingLogger<T> : ILogger
    {
        private MEL.ILogger<T> _logger;

        public MicrosoftExtensionsLoggingLogger(MEL.ILogger<T> logger)
        {
            _logger = logger;
        }

        public void Log(LogLevel level, object message, params object[] args)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    _logger.LogDebug(message as string, args); break;
                case LogLevel.Information:
                    _logger.LogInformation(message as string, args); break;
                case LogLevel.Warning:
                    _logger.LogWarning(message as string, args); break;
                case LogLevel.Error:
                    _logger.LogError(message as string, args); break;
                case LogLevel.Fatal:
                    _logger.LogCritical(message as string, args); break;
            }
        }

        public void Log(LogLevel level, object message, Exception exception)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    _logger.LogDebug(exception, message as string, new object[0]); break;
                case LogLevel.Information:
                    _logger.LogInformation(exception, message as string, new object[0]); break;
                case LogLevel.Warning:
                    _logger.LogWarning(exception, message as string, new object[0]); break;
                case LogLevel.Error:
                    _logger.LogError(exception, message as string, new object[0]); break;
                case LogLevel.Fatal:
                    _logger.LogCritical(exception, message as string, new object[0]); break;
            }
        }
    }
}
