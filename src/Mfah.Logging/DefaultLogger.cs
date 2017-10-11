using System;
using System.Collections.Generic;
using System.Text;

namespace Mfah.Logging
{
    public class DefaultLogger : ILogger
    {
        public void Log(LogLevel level, object message, params object[] args)
        {
        }

        public void Log(LogLevel level, object message, Exception exception)
        {
        }
    }
}
