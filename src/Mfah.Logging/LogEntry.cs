using System;
using System.Collections.Generic;
using System.Text;

namespace Mfah.Logging
{
    /// <summary>
    /// Abstraction of logging method parameters to simplify interface implementation
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// The level or severity of the log entry
        /// </summary>
        public LogLevel Level { get; set; } = LogLevel.Debug;

        private object message;
        /// <summary>
        /// Message to log (supports string formatting when combined with <see cref="Args"/>)
        /// </summary>
        public object Message
        {
            get => message ?? Exception?.Message;
            set => message = value;
        }

        /// <summary>
        /// Argument array 
        /// </summary>
        public object[] Args { get; set; } = new object[0];

        /// <summary>
        /// Exceotion to log, if applicable
        /// </summary>
        public Exception Exception { get; set; }
    }
}
