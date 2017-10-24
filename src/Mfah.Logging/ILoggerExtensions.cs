using System;
using System.Collections.Generic;
using System.Text;

namespace Mfah.Logging
{
    /// <summary>
    /// Convenience extensions to <see cref="ILogger"/>
    /// </summary>
    public static class ILoggerExtensions
    {
        /// <summary>
        /// Log message with a level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="level">The level/severity of the log</param>
        /// <param name="message">Message to log</param>
        public static void Log(this ILogger logger, LogLevel level, object message)
            => logger.Log(new LogEntry { Level = level, Message = message });

        /// <summary>
        /// Log formatted message with a level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="level">The level/severity of the log</param>
        /// <param name="message">Message to log</param>
        /// <param name="args">Arguments to use in formatting the message</param>
        public static void Log(this ILogger logger, LogLevel level, object message, params object[] args)
            => logger.Log(new LogEntry { Level = level, Message = message, Args = args });

        /// <summary>
        /// Log exception with a level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="level">The level/severity of the log</param>
        /// <param name="exception">Exception to log</param>
        public static void Log(this ILogger logger, LogLevel level, Exception exception)
            => logger.Log(new LogEntry { Level = level, Exception = exception });

        /// <summary>
        /// Log exception with a level/severity and custom message
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="level">The level/severity of the log</param>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Custom message</param>
        public static void Log(this ILogger logger, LogLevel level, Exception exception, object message)
            => logger.Log(new LogEntry { Level = level, Exception = exception, Message = message });

        /// <summary>
        /// Log exception with a level/severity and custom formatted message
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="level">The level/severity of the log</param>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Custom message</param>
        /// <param name="args">Arguments to use in formatting the message</param>
        public static void Log(this ILogger logger, LogLevel level, Exception exception, object message, params object[] args)
            => logger.Log(new LogEntry { Level = level, Exception = exception, Message = message, Args = args });


        /// <summary>
        /// Log message with trace level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="message">Message to log</param>
        public static void Trace(this ILogger logger, object message)
            => logger.Log(LogLevel.Trace, message);

        /// <summary>
        /// Log formatted message with trace level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="message">Message to log</param>
        /// <param name="args">Arguments to use in formatting the message</param>
        public static void Trace(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Trace, message, args);

        /// <summary>
        /// Log exception with trace level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        public static void Trace(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Trace, exception);

        /// <summary>
        /// Log exception with trace level/severity and custom message
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Custom message</param>
        public static void Trace(this ILogger logger, Exception exception, object message)
            => logger.Log(LogLevel.Trace, exception, message);

        /// <summary>
        /// Log exception with trace level/severity and custom formatted message
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Custom message</param>
        /// <param name="args">Arguments to use in formatting the message</param>
        public static void Trace(this ILogger logger, Exception exception, object message, params object[] args)
            => logger.Log(LogLevel.Trace, exception, message, args);


        /// <summary>
        /// Log message with debug level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="message">Message to log</param>
        public static void Debug(this ILogger logger, object message)
            => logger.Log(LogLevel.Debug, message);
        
        /// <summary>
        /// Log formatted message with debug level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="message">Message to log</param>
        /// <param name="args">Arguments to use in formatting the message</param>
        public static void Debug(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Debug, message, args);

        /// <summary>
        /// Log exception with debug level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        public static void Debug(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Debug, exception);

        /// <summary>
        /// Log exception with debug level/severity and custom message
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Custom message</param>
        public static void Debug(this ILogger logger, Exception exception, object message)
            => logger.Log(LogLevel.Debug, exception, message);

        /// <summary>
        /// Log exception with debug level/severity and custom formatted message
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Custom message</param>
        /// <param name="args">Arguments to use in formatting the message</param>
        public static void Debug(this ILogger logger, Exception exception, object message, params object[] args)
            => logger.Log(LogLevel.Debug, exception, message, args);


        /// <summary>
        /// Log message with information level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="message">Message to log</param>
        public static void Information(this ILogger logger, object message)
            => logger.Log(LogLevel.Information, message);

        /// <summary>
        /// Log formatted message with information level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="message">Message to log</param>
        /// <param name="args">Arguments to use in formatting the message</param>
        public static void Information(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Information, message, args);

        /// <summary>
        /// Log exception with information level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        public static void Information(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Information, exception);

        /// <summary>
        /// Log exception with information level/severity and custom message
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Custom message</param>
        public static void Information(this ILogger logger, Exception exception, object message)
            => logger.Log(LogLevel.Information, exception, message);

        /// <summary>
        /// Log exception with information level/severity and custom formatted message
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Custom message</param>
        /// <param name="args">Arguments to use in formatting the message</param>
        public static void Information(this ILogger logger, Exception exception, object message, params object[] args)
            => logger.Log(LogLevel.Information, exception, message, args);


        /// <summary>
        /// Log message with warning level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="message">Message to log</param>
        public static void Warning(this ILogger logger, object message)
            => logger.Log(LogLevel.Warning, message);

        /// <summary>
        /// Log formatted message with warning level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="message">Message to log</param>
        /// <param name="args">Arguments to use in formatting the message</param>
        public static void Warning(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Warning, message, args);

        /// <summary>
        /// Log exception with warning level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        public static void Warning(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Warning, exception);

        /// <summary>
        /// Log exception with warning level/severity and custom message
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Custom message</param>
        public static void Warning(this ILogger logger, Exception exception, object message)
            => logger.Log(LogLevel.Warning, exception, message);

        /// <summary>
        /// Log exception with warning level/severity and custom formatted message
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Custom message</param>
        /// <param name="args">Arguments to use in formatting the message</param>
        public static void Warning(this ILogger logger, Exception exception, object message, params object[] args)
            => logger.Log(LogLevel.Warning, exception, message, args);


        /// <summary>
        /// Log message with error level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="message">Message to log</param>
        public static void Error(this ILogger logger, object message)
            => logger.Log(LogLevel.Error, message);

        /// <summary>
        /// Log formatted message with error level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="message">Message to log</param>
        /// <param name="args">Arguments to use in formatting the message</param>
        public static void Error(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Error, message, args);

        /// <summary>
        /// Log exception with error level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        public static void Error(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Error, exception);

        /// <summary>
        /// Log exception with error level/severity and custom message
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Custom message</param>
        public static void Error(this ILogger logger, Exception exception, object message)
            => logger.Log(LogLevel.Error, exception, message);

        /// <summary>
        /// Log exception with error level/severity and custom formatted message
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Custom message</param>
        /// <param name="args">Arguments to use in formatting the message</param>
        public static void Error(this ILogger logger, Exception exception, object message, params object[] args)
            => logger.Log(LogLevel.Error, exception, message, args);


        /// <summary>
        /// Log message with critical level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="message">Message to log</param>
        public static void Critical(this ILogger logger, object message)
            => logger.Log(LogLevel.Critical, message);

        /// <summary>
        /// Log formatted message with critical level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="message">Message to log</param>
        /// <param name="args">Arguments to use in formatting the message</param>
        public static void Critical(this ILogger logger, object message, params object[] args)
            => logger.Log(LogLevel.Critical, message, args);

        /// <summary>
        /// Log exception with critical level/severity
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        public static void Critical(this ILogger logger, Exception exception)
            => logger.Log(LogLevel.Critical, exception);

        /// <summary>
        /// Log exception with critical level/severity and custom message
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Custom message</param>
        public static void Critical(this ILogger logger, Exception exception, object message)
            => logger.Log(LogLevel.Critical, exception, message);

        /// <summary>
        /// Log exception with critical level/severity and custom formatted message
        /// </summary>
        /// <param name="logger"><see cref="ILogger"/> instance</param>
        /// <param name="exception">Exception to log</param>
        /// <param name="message">Custom message</param>
        /// <param name="args">Arguments to use in formatting the message</param>
        public static void Critical(this ILogger logger, Exception exception, object message, params object[] args)
            => logger.Log(LogLevel.Critical, exception, message, args);
    }
}
