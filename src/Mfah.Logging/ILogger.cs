using System;
using System.Collections.Generic;
using System.Text;

namespace Mfah.Logging
{
    /// <summary>
    /// Interface for logging facade
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log something
        /// </summary>
        /// <param name="logEntry"><see cref="LogEntry"/> instance to log</param>
        void Log(LogEntry logEntry);
    }
}
