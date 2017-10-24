using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Mfah.Logging.Tests.Common
{
    public abstract class ILoggerTests
    {
        protected readonly ILogger _logger;

        public ILoggerTests()
        {
            _logger = GetLogger();
        }

        protected abstract ILogger GetLogger();

        [Fact]
        public void ShouldRespondToAllLogLevels()
        {
            var logger = GetLogger();
            var missingLogLevelImplementations = new List<string>();

            foreach (LogLevel level in Enum.GetValues(typeof(LogLevel)))
            {
                try
                {
                    logger.Log(level, "Test");
                }
                catch (Exception)
                {
                    missingLogLevelImplementations.Add(level.ToString());
                }
            }

            Assert.True(missingLogLevelImplementations.Count == 0, $"Missing LogLevel implementations: {(String.Join(", ", missingLogLevelImplementations))}");
        }
    }
}
