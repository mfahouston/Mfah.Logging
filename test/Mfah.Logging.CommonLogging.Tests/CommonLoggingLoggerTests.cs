using Common.Logging;
using Mfah.Logging.Tests.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Mfah.Logging.CommonLogging.Tests
{
    [Trait("Category", "CommonLoggingLogger")]
    public class CommonLoggingLoggerTests : ILoggerTests
    {
        private static Mock<ILog> _logProviderMock = new Mock<ILog>();

        private static IEnumerable<LogLevel> _logLevels = Enum.GetValues(typeof(LogLevel)).Cast<LogLevel>();

        public static IEnumerable<object[]> LogMessageData
            => _logLevels.Select(level => new object[] { level, "Test Message" });
        public static IEnumerable<object[]> LogMessageWithArgsData
            => _logLevels.Select(level => new object[] { level, "Test Message {0}", "Test Arg" });
        public static IEnumerable<object[]> LogExceptionData
            => _logLevels.Select(level => new object[] { level, new Exception() });
        public static IEnumerable<object[]> LogExceptionWithMessageData
            => _logLevels.Select(level => new object[] { level, new Exception(), "Test Message" });
        public static IEnumerable<object[]> LogExceptionWithMessageAndArgsData
            => _logLevels.Select(level => new object[] { level, new Exception(), "Test Message {0}", "Test Arg" });

        protected override ILogger GetLogger()
        {
            return new CommonLoggingLogger(_logProviderMock.Object);
        }

        [Theory, MemberData(nameof(LogMessageData))]
        public void ShouldLogMessage(LogLevel level, string message)
        {
            _logger.Log(new LogEntry { Level = level, Message = message });

            switch (level)
            {
                case LogLevel.Trace:
                    _logProviderMock.Verify(logger => logger.Trace(message));
                    break;
                case LogLevel.Debug:
                    _logProviderMock.Verify(logger => logger.Debug(message));
                    break;
                case LogLevel.Information:
                    _logProviderMock.Verify(logger => logger.Info(message));
                    break;
                case LogLevel.Warning:
                    _logProviderMock.Verify(logger => logger.Warn(message));
                    break;
                case LogLevel.Error:
                    _logProviderMock.Verify(logger => logger.Error(message));
                    break;
                case LogLevel.Critical:
                    _logProviderMock.Verify(logger => logger.Fatal(message));
                    break;
            }
        }

        [Theory, MemberData(nameof(LogMessageWithArgsData))]
        public void ShouldLogMessageWithArgs(LogLevel level, string message, params object[] args)
        {
            _logger.Log(new LogEntry { Level = level, Message = message, Args = args });

            switch (level)
            {
                case LogLevel.Trace:
                    _logProviderMock.Verify(logger => logger.TraceFormat(message, args));
                    break;
                case LogLevel.Debug:
                    _logProviderMock.Verify(logger => logger.DebugFormat(message, args));
                    break;
                case LogLevel.Information:
                    _logProviderMock.Verify(logger => logger.InfoFormat(message, args));
                    break;
                case LogLevel.Warning:
                    _logProviderMock.Verify(logger => logger.WarnFormat(message, args));
                    break;
                case LogLevel.Error:
                    _logProviderMock.Verify(logger => logger.ErrorFormat(message, args));
                    break;
                case LogLevel.Critical:
                    _logProviderMock.Verify(logger => logger.FatalFormat(message, args));
                    break;
            }
        }

        [Theory, MemberData(nameof(LogExceptionData))]
        public void ShouldLogException(LogLevel level, Exception exception)
        {
            _logger.Log(new LogEntry { Level = level, Exception = exception });

            switch (level)
            {
                case LogLevel.Trace:
                    _logProviderMock.Verify(logger => logger.Trace(exception.Message, exception));
                    break;
                case LogLevel.Debug:
                    _logProviderMock.Verify(logger => logger.Debug(exception.Message, exception));
                    break;
                case LogLevel.Information:
                    _logProviderMock.Verify(logger => logger.Info(exception.Message, exception));
                    break;
                case LogLevel.Warning:
                    _logProviderMock.Verify(logger => logger.Warn(exception.Message, exception));
                    break;
                case LogLevel.Error:
                    _logProviderMock.Verify(logger => logger.Error(exception.Message, exception));
                    break;
                case LogLevel.Critical:
                    _logProviderMock.Verify(logger => logger.Fatal(exception.Message, exception));
                    break;
            }
        }

        [Theory, MemberData(nameof(LogExceptionWithMessageData))]
        public void ShouldLogExceptionWithMessage(LogLevel level, Exception exception, string message)
        {
            _logger.Log(new LogEntry { Level = level, Exception = exception, Message = message });

            switch (level)
            {
                case LogLevel.Trace:
                    _logProviderMock.Verify(logger => logger.Trace(message, exception));
                    break;
                case LogLevel.Debug:
                    _logProviderMock.Verify(logger => logger.Debug(message, exception));
                    break;
                case LogLevel.Information:
                    _logProviderMock.Verify(logger => logger.Info(message, exception));
                    break;
                case LogLevel.Warning:
                    _logProviderMock.Verify(logger => logger.Warn(message, exception));
                    break;
                case LogLevel.Error:
                    _logProviderMock.Verify(logger => logger.Error(message, exception));
                    break;
                case LogLevel.Critical:
                    _logProviderMock.Verify(logger => logger.Fatal(message, exception));
                    break;
            }
        }

        [Theory, MemberData(nameof(LogExceptionWithMessageAndArgsData))]
        public void ShouldLogExceptionWithMessageAndArgs(LogLevel level, Exception exception, string message, params object[] args)
        {
            _logger.Log(new LogEntry { Level = level, Exception = exception, Message = message, Args = args });

            switch (level)
            {
                case LogLevel.Trace:
                    _logProviderMock.Verify(logger => logger.TraceFormat(message, exception, args));
                    break;
                case LogLevel.Debug:
                    _logProviderMock.Verify(logger => logger.DebugFormat(message, exception, args));
                    break;
                case LogLevel.Information:
                    _logProviderMock.Verify(logger => logger.InfoFormat(message, exception, args));
                    break;
                case LogLevel.Warning:
                    _logProviderMock.Verify(logger => logger.WarnFormat(message, exception, args));
                    break;
                case LogLevel.Error:
                    _logProviderMock.Verify(logger => logger.ErrorFormat(message, exception, args));
                    break;
                case LogLevel.Critical:
                    _logProviderMock.Verify(logger => logger.FatalFormat(message, exception, args));
                    break;
            }
        }
    }
}

