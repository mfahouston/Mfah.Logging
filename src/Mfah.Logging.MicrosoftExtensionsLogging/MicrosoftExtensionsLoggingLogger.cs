using System;
using MEL = Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Mfah.Logging.MicrosoftExtensionsLogging
{
    public class MicrosoftExtensionsLoggingLogger<T> : ILogger
    {
        private readonly MEL.ILogger<T> _logger;

        private Dictionary<LogLevel, Action<LogEntry>> MessageMethods => new Dictionary<LogLevel, Action<LogEntry>>
        {
            [LogLevel.Trace] =
                x => _logger.LogTrace(x.Message as string, x.Args),
            [LogLevel.Debug] =
                x => _logger.LogDebug(x.Message as string, x.Args),
            [LogLevel.Information] =
                x => _logger.LogInformation(x.Message as string, x.Args),
            [LogLevel.Warning] =
                x => _logger.LogWarning(x.Message as string, x.Args),
            [LogLevel.Error] =
                x => _logger.LogError(x.Message as string, x.Args),
            [LogLevel.Critical] =
                x => _logger.LogCritical(x.Message as string, x.Args),
        };

        private Dictionary<LogLevel, Action<LogEntry>> ExceptionMethods => new Dictionary<LogLevel, Action<LogEntry>>
        {
            [LogLevel.Trace] =
                x => _logger.LogTrace(x.Exception, x.Message as string, x.Args),
            [LogLevel.Debug] =
                x => _logger.LogDebug(x.Exception, x.Message as string, x.Args),
            [LogLevel.Information] =
                x => _logger.LogInformation(x.Exception, x.Message as string, x.Args),
            [LogLevel.Warning] =
                x => _logger.LogWarning(x.Exception, x.Message as string, x.Args),
            [LogLevel.Error] =
                x => _logger.LogError(x.Exception, x.Message as string, x.Args),
            [LogLevel.Critical] =
                x => _logger.LogCritical(x.Exception, x.Message as string, x.Args),
        };

        public MicrosoftExtensionsLoggingLogger(MEL.ILogger<T> logger)
        {
            _logger = logger;
        }

        public void Log(LogEntry logEntry)
        {
            if (logEntry.Exception == null)
            {
                MessageMethods[logEntry.Level](logEntry);
            }
            else
            {
                ExceptionMethods[logEntry.Level](logEntry);
            }
        }
    }
}
