using System;
using System.Collections.Generic;
using System.Text;

namespace Mfah.Logging
{
    public static class ILoggerExtensions
    {
        public static void Log(this ILogger logger, LogLevel level, object message)
            => logger.Log(level, message, new object[0]);

        public static void Log(this ILogger logger, LogLevel level, Exception exception)
            => logger.Log(level, exception.Message, exception);

        public static void Debug(this ILogger logger, object message)
            => logger.Log(LogLevel.Debug, message);

        public static void Information(this ILogger logger, object message)
            => logger.Log(LogLevel.Information, message);

        public static void Warning(this ILogger logger, object message)
            => logger.Log(LogLevel.Warning, message);

        public static void Error(this ILogger logger, object message)
            => logger.Log(LogLevel.Error, message);

        public static void Fatal(this ILogger logger, object message)
            => logger.Log(LogLevel.Fatal, message);

        public static void Debug(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Debug, message, args);

        public static void Information(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Information, message, args);

        public static void Warning(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Warning, message, args);

        public static void Error(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Error, message, args);

        public static void Fatal(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Fatal, message, args);

        public static void Debug(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Debug, exception);

        public static void Information(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Information, exception);

        public static void Warning(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Warning, exception);

        public static void Error(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Error, exception);

        public static void Fatal(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Fatal, exception);

        public static void Debug(this ILogger logger, object message, Exception exception)
            => logger.Log(LogLevel.Debug, message, exception);

        public static void Information(this ILogger logger, object message, Exception exception)
            => logger.Log(LogLevel.Information, message, exception);

        public static void Warning(this ILogger logger, object message, Exception exception)
            => logger.Log(LogLevel.Warning, message, exception);

        public static void Error(this ILogger logger, object message, Exception exception)
            => logger.Log(LogLevel.Error, message, exception);

        public static void Fatal(this ILogger logger, object message, Exception exception)
            => logger.Log(LogLevel.Fatal, message, exception);
    }
}
