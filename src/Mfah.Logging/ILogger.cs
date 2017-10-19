using System;
using System.Collections.Generic;
using System.Text;

namespace Mfah.Logging
{
    public interface ILogger
    {
        void Log(LogEntry logEntry);
    }
}
