using Mfah.Logging.Tests.Common;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Mfah.Logging.Tests
{
    [Trait("Category", "DebugLogger")]
    public class DebugLoggerTests : ILoggerTests
    {
        protected override ILogger GetLogger()
        {
            return new DebugLogger();
        }
    }
}
