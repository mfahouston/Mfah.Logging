using System;
using System.Collections.Generic;
using System.Text;

namespace Mfah.Logging
{
    public static class ILoggerExtensions
    {
        public static void Log(this ILogger logger, LogLevel level, object message)
            => logger.Log(new LogEntry { Level = level, Message = message });

        public static void Log(this ILogger logger, LogLevel level, object message, params object[] args)
            => logger.Log(new LogEntry { Level = level, Message = message, Args = args });

        public static void Log(this ILogger logger, LogLevel level, Exception exception)
            => logger.Log(new LogEntry { Level = level, Exception = exception });

        public static void Log(this ILogger logger, LogLevel level, Exception exception, object message)
            => logger.Log(new LogEntry { Level = level, Exception = exception, Message = message });

        public static void Log(this ILogger logger, LogLevel level, Exception exception, object message, params object[] args)
            => logger.Log(new LogEntry { Level = level, Exception = exception, Message = message, Args = args });


        public static void Trace(this ILogger logger, object message)
            => logger.Log(LogLevel.Trace, message);

        public static void Trace(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Trace, message, args);

        public static void Trace(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Trace, exception);

        public static void Trace(this ILogger logger, Exception exception, object message)
            => logger.Log(LogLevel.Trace, exception, message);

        public static void Trace(this ILogger logger, Exception exception, object message, params object[] args)
            => logger.Log(LogLevel.Trace, exception, message, args);


        public static void Debug(this ILogger logger, object message)
            => logger.Log(LogLevel.Debug, message);

        public static void Debug(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Debug, message, args);

        public static void Debug(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Debug, exception);

        public static void Debug(this ILogger logger, Exception exception, object message)
            => logger.Log(LogLevel.Debug, exception, message);

        public static void Debug(this ILogger logger, Exception exception, object message, params object[] args)
            => logger.Log(LogLevel.Debug, exception, message, args);


        public static void Information(this ILogger logger, object message)
            => logger.Log(LogLevel.Information, message);

        public static void Information(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Information, message, args);

        public static void Information(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Information, exception);

        public static void Information(this ILogger logger, Exception exception, object message)
            => logger.Log(LogLevel.Information, exception, message);

        public static void Information(this ILogger logger, Exception exception, object message, params object[] args)
            => logger.Log(LogLevel.Information, exception, message, args);
        

        public static void Warning(this ILogger logger, object message)
            => logger.Log(LogLevel.Warning, message);

        public static void Warning(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Warning, message, args);

        public static void Warning(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Warning, exception);

        public static void Warning(this ILogger logger, Exception exception, object message)
            => logger.Log(LogLevel.Warning, exception, message);

        public static void Warning(this ILogger logger, Exception exception, object message, params object[] args)
            => logger.Log(LogLevel.Warning, exception, message, args);


        public static void Error(this ILogger logger, object message)
            => logger.Log(LogLevel.Error, message);

        public static void Error(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Error, message, args);

        public static void Error(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Error, exception);

        public static void Error(this ILogger logger, Exception exception, object message)
            => logger.Log(LogLevel.Error, exception, message);

        public static void Error(this ILogger logger, Exception exception, object message, params object[] args)
            => logger.Log(LogLevel.Error, exception, message, args);


        public static void Critical(this ILogger logger, object message)
            => logger.Log(LogLevel.Critical, message);

        public static void Critical(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Critical, message, args);

        public static void Critical(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Critical, exception);

        public static void Critical(this ILogger logger, Exception exception, object message)
            => logger.Log(LogLevel.Critical, exception, message);

        public static void Critical(this ILogger logger, Exception exception, object message, params object[] args)
            => logger.Log(LogLevel.Critical, exception, message, args);
    }
}
