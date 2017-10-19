using Common.Logging;
using System;
using System.Collections.Generic;

namespace Mfah.Logging.CommonLogging
{
    public class CommonLoggingLogger : ILogger
    {
        private readonly ILog _logger;

        private Dictionary<LogLevel, Action<LogEntry>> MessageMethods => new Dictionary<LogLevel, Action<LogEntry>>
        {
            [LogLevel.Trace] = x => { },
            [LogLevel.Debug] = x => _logger.Debug(x.Message),
            [LogLevel.Information] = x => _logger.Info(x.Message),
            [LogLevel.Warning] = x => _logger.Warn(x.Message),
            [LogLevel.Error] = x => _logger.Error(x.Message),
            [LogLevel.Critical] = x => _logger.Fatal(x.Message),
        };

        private Dictionary<LogLevel, Action<LogEntry>> FormatMethods => new Dictionary<LogLevel, Action<LogEntry>>
        {
            [LogLevel.Trace] = x => { },
            [LogLevel.Debug] = x => _logger.DebugFormat(x.Message as string, x.Args),
            [LogLevel.Information] = x => _logger.InfoFormat(x.Message as string, x.Args),
            [LogLevel.Warning] = x => _logger.WarnFormat(x.Message as string, x.Args),
            [LogLevel.Error] = x => _logger.ErrorFormat(x.Message as string, x.Args),
            [LogLevel.Critical] = x => _logger.FatalFormat(x.Message as string, x.Args),
        };

        private Dictionary<LogLevel, Action<LogEntry>> ExceptionMethods => new Dictionary<LogLevel, Action<LogEntry>>
        {
            [LogLevel.Trace] = x => { },
            [LogLevel.Debug] = x => _logger.Debug(x.Message, x.Exception),
            [LogLevel.Information] = x => _logger.Info(x.Message, x.Exception),
            [LogLevel.Warning] = x => _logger.Warn(x.Message, x.Exception),
            [LogLevel.Error] = x => _logger.Error(x.Message, x.Exception),
            [LogLevel.Critical] = x => _logger.Fatal(x.Message, x.Exception),
        };

        public CommonLoggingLogger(ILog logger)
        {
            _logger = logger;
        }

        public void Log(LogEntry logEntry)
        {
            if (logEntry.Exception != null)
            {
                ExceptionMethods[logEntry.Level](logEntry);
            }
            else if (logEntry.Message is string && logEntry.Args.Length > 0)
            {
                FormatMethods[logEntry.Level](logEntry);
            }
            else
            {
                MessageMethods[logEntry.Level](logEntry);
            }
        }
    }
}
