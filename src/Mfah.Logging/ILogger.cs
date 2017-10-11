using System;
using System.Collections.Generic;
using System.Text;

namespace Mfah.Logging
{
    public interface ILogger
    {
        void Log(LogLevel level, object message, params object[] args);
        void Log(LogLevel level, object message, Exception exception);
    }
}
