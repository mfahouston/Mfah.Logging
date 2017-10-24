using Mfah.Logging.Tests.Common;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Mfah.Logging.Tests
{
    [Trait("Category", "TraceLogger")]
    public class TraceLoggerTests : ILoggerTests
    {
        protected override ILogger GetLogger()
        {
            return new TraceLogger();
        }
    }
}
