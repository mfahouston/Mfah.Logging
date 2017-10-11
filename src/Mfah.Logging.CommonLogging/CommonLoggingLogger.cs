using Common.Logging;
using System;

namespace Mfah.Logging.CommonLogging
{
    public class CommonLoggingLogger : ILogger
    {
        private readonly ILog _logger;

        public CommonLoggingLogger(ILog logger)
        {
            _logger = logger;
        }

        public void Log(LogLevel level, object message, params object[] args)
        {
            LoggerLog(level, null, message, args);
        }

        public void Log(LogLevel level, object message, Exception exception)
        {
            LoggerLog(level, exception, message);
        }

        private void LoggerLog(LogLevel level, Exception exception, object message, params object[] args)
        {
            LoggerDebug(level, exception, message, args);
            LoggerInfo(level, exception, message, args);
            LoggerWarn(level, exception, message, args);
            LoggerError(level, exception, message, args);
            LoggerFatal(level, exception, message, args);
        }

        private void LoggerDebug(LogLevel level, Exception exception, object message, params object[] args)
        {
            if (level == LogLevel.Debug)
            {
                if (exception != null)
                {
                    _logger.Debug(message, exception);
                }
                if (message is string && args.Length > 0)
                {
                    _logger.DebugFormat(message as string, args);
                }
                else
                {
                    _logger.Debug(message);
                }
            }
        }

        private void LoggerInfo(LogLevel level, Exception exception, object message, params object[] args)
        {
            if (level == LogLevel.Information)
            {
                if (exception != null)
                {
                    _logger.Info(message, exception);
                }
                if (message is string && args.Length > 0)
                {
                    _logger.InfoFormat(message as string, args);
                }
                else
                {
                    _logger.Info(message);
                }
            }
        }

        private void LoggerWarn(LogLevel level, Exception exception, object message, params object[] args)
        {
            if (level == LogLevel.Warning)
            {
                if (exception != null)
                {
                    _logger.Warn(message, exception);
                }
                if (message is string && args.Length > 0)
                {
                    _logger.WarnFormat(message as string, args);
                }
                else
                {
                    _logger.Warn(message);
                }
            }
        }

        private void LoggerError(LogLevel level, Exception exception, object message, params object[] args)
        {
            if (level == LogLevel.Error)
            {
                if (exception != null)
                {
                    _logger.Error(message, exception);
                }
                if (message is string && args.Length > 0)
                {
                    _logger.ErrorFormat(message as string, args);
                }
                else
                {
                    _logger.Error(message);
                }
            }
        }

        private void LoggerFatal(LogLevel level, Exception exception, object message, params object[] args)
        {
            if (level == LogLevel.Fatal)
            {
                if (exception != null)
                {
                    _logger.Fatal(message, exception);
                }
                if (message is string && args.Length > 0)
                {
                    _logger.FatalFormat(message as string, args);
                }
                else
                {
                    _logger.Fatal(message);
                }
            }
        }
    }
}
