using Common.Logging;
using System;
using System.Collections.Generic;

namespace Mfah.Logging.CommonLogging
{
    /// <summary>
    /// <see cref="ILogger"/> implementation that utilizes <see cref="Common.Logging"/> to log
    /// </summary>
    public class CommonLoggingLogger : ILogger
    {
        /// <summary>
        /// <see cref="ILog"/> instance
        /// </summary>
        protected readonly ILog _logger;

        private Dictionary<LogLevel, Action<LogEntry>> MessageMethods => new Dictionary<LogLevel, Action<LogEntry>>
        {
            [LogLevel.Trace] = x => _logger.Trace(x.Message),
            [LogLevel.Debug] = x => _logger.Debug(x.Message),
            [LogLevel.Information] = x => _logger.Info(x.Message),
            [LogLevel.Warning] = x => _logger.Warn(x.Message),
            [LogLevel.Error] = x => _logger.Error(x.Message),
            [LogLevel.Critical] = x => _logger.Fatal(x.Message),
        };

        private Dictionary<LogLevel, Action<LogEntry>> FormatMethods => new Dictionary<LogLevel, Action<LogEntry>>
        {
            [LogLevel.Trace] = x => _logger.TraceFormat(x.Message.ToString(), x.Args),
            [LogLevel.Debug] = x => _logger.DebugFormat(x.Message.ToString(), x.Args),
            [LogLevel.Information] = x => _logger.InfoFormat(x.Message.ToString(), x.Args),
            [LogLevel.Warning] = x => _logger.WarnFormat(x.Message.ToString(), x.Args),
            [LogLevel.Error] = x => _logger.ErrorFormat(x.Message.ToString(), x.Args),
            [LogLevel.Critical] = x => _logger.FatalFormat(x.Message.ToString(), x.Args),
        };

        private Dictionary<LogLevel, Action<LogEntry>> ExceptionMethods => new Dictionary<LogLevel, Action<LogEntry>>
        {
            [LogLevel.Trace] = x => _logger.Trace(x.Message, x.Exception),
            [LogLevel.Debug] = x => _logger.Debug(x.Message, x.Exception),
            [LogLevel.Information] = x => _logger.Info(x.Message, x.Exception),
            [LogLevel.Warning] = x => _logger.Warn(x.Message, x.Exception),
            [LogLevel.Error] = x => _logger.Error(x.Message, x.Exception),
            [LogLevel.Critical] = x => _logger.Fatal(x.Message, x.Exception),
        };

        private Dictionary<LogLevel, Action<LogEntry>> ExceptionFormatMethods => new Dictionary<LogLevel, Action<LogEntry>>
        {
            [LogLevel.Trace] = x => _logger.TraceFormat(x.Message.ToString(), x.Exception, x.Args),
            [LogLevel.Debug] = x => _logger.DebugFormat(x.Message.ToString(), x.Exception, x.Args),
            [LogLevel.Information] = x => _logger.InfoFormat(x.Message.ToString(), x.Exception, x.Args),
            [LogLevel.Warning] = x => _logger.WarnFormat(x.Message.ToString(), x.Exception, x.Args),
            [LogLevel.Error] = x => _logger.ErrorFormat(x.Message.ToString(), x.Exception, x.Args),
            [LogLevel.Critical] = x => _logger.FatalFormat(x.Message.ToString(), x.Exception, x.Args),
        };

        /// <summary>
        /// Create a <see cref="CommonLoggingLogger"/> that uses the specified <see cref="ILog"/> instance to log
        /// </summary>
        /// <param name="logger"><see cref="ILog"/> instance to log via</param>
        public CommonLoggingLogger(ILog logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Log something
        /// </summary>
        /// <param name="logEntry"><see cref="LogEntry"/> instance to log</param>
        public void Log(LogEntry logEntry)
        {
            if (logEntry.Exception != null && logEntry.Args.Length > 0)
            {
                ExceptionFormatMethods[logEntry.Level](logEntry);
            }
            else if (logEntry.Exception != null)
            {
                ExceptionMethods[logEntry.Level](logEntry);
            }
            else if (logEntry.Args.Length > 0)
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
