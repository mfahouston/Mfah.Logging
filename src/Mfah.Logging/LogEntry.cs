using System;
using System.Collections.Generic;
using System.Text;

namespace Mfah.Logging
{
    public class LogEntry
    {
        public LogLevel Level { get; set; } = LogLevel.Debug;

        private object message;
        public object Message
        {
            get => message ?? Exception?.Message;
            set => message = value;
        }

        public object[] Args { get; set; } = new object[0];

        public Exception Exception { get; set; }
    }
}
