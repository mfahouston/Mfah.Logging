using System;
using MEL = Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Mfah.Logging.MicrosoftExtensionsLogging
{
    /// <summary>
    /// <see cref="ILogger"/> implementation that utilizes <see cref="Microsoft.Extensions.Logging"/> to log
    /// </summary>
    public class MicrosoftExtensionsLoggingLogger : ILogger
    {
        /// <summary>
        /// <see cref="MEL.ILogger"/> instance
        /// </summary>
        protected readonly MEL.ILogger _logger;

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

        /// <summary>
        /// Create a <see cref="MicrosoftExtensionsLoggingLogger"/> instance from an <see cref="MEL.ILoggerFactory"/> instance which will use the specified category to distinguish logs
        /// </summary>
        /// <param name="loggerFactory"><see cref="MEL.ILoggerFactory"/> to create <see cref="MEL.ILogger"/> instance from</param>
        /// <param name="categoryName">Category to use as a header for log entries</param>
        public MicrosoftExtensionsLoggingLogger(MEL.ILoggerFactory loggerFactory, string categoryName)
        {
            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));
            if (categoryName == null)
                throw new ArgumentNullException(nameof(categoryName));

            _logger = loggerFactory.CreateLogger(categoryName);
        }

        /// <summary>
        /// Create a <see cref="MicrosoftExtensionsLoggingLogger"/> instance from an <see cref="MEL.ILoggerFactory"/> instance which will use the specified type to distinguish logs
        /// </summary>
        /// <param name="loggerFactory"><see cref="MEL.ILoggerFactory"/> to create <see cref="MEL.ILogger"/> instance from</param>
        /// <param name="type">Type to use as a header for log entries</param>
        public MicrosoftExtensionsLoggingLogger(MEL.ILoggerFactory loggerFactory, Type type)
        {
            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            _logger = loggerFactory.CreateLogger(type);
        }

        /// <summary>
        /// Create a <see cref="MicrosoftExtensionsLoggingLogger"/> instance using the specified <see cref="MEL.ILogger"/> instance
        /// </summary>
        /// <param name="logger"><see cref="MEL.ILogger"/> instance to log via</param>
        public MicrosoftExtensionsLoggingLogger(MEL.ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Log something
        /// </summary>
        /// <param name="logEntry"><see cref="LogEntry"/> instance to log</param>
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

    /// <summary>
    /// Generic <see cref="ILogger"/> implementation that utilizes <see cref="Microsoft.Extensions.Logging"/> to log
    /// </summary>
    /// <typeparam name="T">The type that should be used to distinguish logs</typeparam>
    public class MicrosoftExtensionsLoggingLogger<T> : MicrosoftExtensionsLoggingLogger
    {
        /// <summary>
        /// Create a generic <see cref="MicrosoftExtensionsLoggingLogger{T}"/> instance from an <see cref="MEL.ILoggerFactory"/> instance which will use the specified type to distinguish logs
        /// </summary>
        /// <param name="loggerFactory"><see cref="MEL.ILoggerFactory"/> to create <see cref="MEL.ILogger{T}"/> instance from</param>
        public MicrosoftExtensionsLoggingLogger(MEL.ILoggerFactory loggerFactory)
            : base(loggerFactory.CreateLogger<T>())
        {
            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));
        }

        /// <summary>
        /// Create a generic <see cref="MicrosoftExtensionsLoggingLogger{T}"/> instance using the specified <see cref="MEL.ILogger{T}"/> instance
        /// </summary>
        /// <param name="logger"><see cref="MEL.ILogger{T}"/> instance to log via</param>
        public MicrosoftExtensionsLoggingLogger(MEL.ILogger<T> logger)
            : base(logger)
        {
        }
    }
}
