using Mfah.Logging.Tests.Common;
using Microsoft.Extensions.Logging;
using MEL = Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.Extensions.Logging.Internal;
using System.Linq;

namespace Mfah.Logging.MicrosoftExtensionsLogging.Tests
{
    [Trait("Category", "MicrosoftExtensionsLoggingLogger")]
    public class MicrosoftExtensionsLoggingLoggerTests : ILoggerTests
    {
        private Mock<MEL.ILogger> _logProviderMock = new Mock<MEL.ILogger>();

        private static Dictionary<LogLevel, MEL.LogLevel> _levelMapper = new Dictionary<LogLevel, MEL.LogLevel>
        {
            [LogLevel.Trace] = MEL.LogLevel.Trace,
            [LogLevel.Debug] = MEL.LogLevel.Debug,
            [LogLevel.Information] = MEL.LogLevel.Information,
            [LogLevel.Warning] = MEL.LogLevel.Warning,
            [LogLevel.Error] = MEL.LogLevel.Error,
            [LogLevel.Critical] = MEL.LogLevel.Critical
        };

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
            return new MicrosoftExtensionsLoggingLogger(_logProviderMock.Object);
        }

        [Theory, MemberData(nameof(LogMessageData))]
        public void ShouldLogMessage(LogLevel level, string message)
        {
            _logger.Log(new LogEntry { Level = level, Message = message });

            _logProviderMock.VerifyLog(_levelMapper[level], null, message);
        }

        [Theory, MemberData(nameof(LogMessageWithArgsData))]
        public void ShouldLogMessageWithArgs(LogLevel level, string message, params object[] args)
        {
            _logger.Log(new LogEntry { Level = level, Message = message, Args = args });

            _logProviderMock.VerifyLog(_levelMapper[level], null, message, args);
        }

        [Theory, MemberData(nameof(LogExceptionData))]
        public void ShouldLogException(LogLevel level, Exception exception)
        {
            _logger.Log(new LogEntry { Level = level, Exception = exception });

            _logProviderMock.VerifyLog(_levelMapper[level], exception, exception.Message);
        }

        [Theory, MemberData(nameof(LogExceptionWithMessageData))]
        public void ShouldLogExceptionWithMessage(LogLevel level, Exception exception, string message)
        {
            _logger.Log(new LogEntry { Level = level, Exception = exception, Message = message });

            _logProviderMock.VerifyLog(_levelMapper[level], exception, message);
        }

        [Theory, MemberData(nameof(LogExceptionWithMessageAndArgsData))]
        public void ShouldLogExceptionWithMessageAndArgs(LogLevel level, Exception exception, string message, params object[] args)
        {
            _logger.Log(new LogEntry { Level = level, Exception = exception, Message = message, Args = args });

            _logProviderMock.VerifyLog(_levelMapper[level], exception, message, args);
        }
    }

    internal static class MockExtensions
    {
        public static void VerifyLog(this Mock<MEL.ILogger> mock, MEL.LogLevel level, Exception exception, string message, params object[] args)
        {
            mock.Verify(logger => logger.Log(level, It.IsAny<EventId>(), It.Is<object>(o => o.ToString() == (args != null && args.Length > 0 ? String.Format(message, args) : message)), exception, It.IsAny<Func<object, Exception, string>>()));
        }
    }
}
