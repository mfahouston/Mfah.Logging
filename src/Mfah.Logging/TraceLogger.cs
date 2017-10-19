using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mfah.Logging
{
    public class TraceLogger : ILogger
    {
        private Dictionary<LogLevel, string> LevelPrefixes => new Dictionary<LogLevel, string>
        {
            [LogLevel.Trace] = "trce",
            [LogLevel.Debug] = "dbug",
            [LogLevel.Information] = "info",
            [LogLevel.Warning] = "warn",
            [LogLevel.Error] = "fail",
            [LogLevel.Critical] = "crit",
        };
        
        public TraceLogger()
        {
        }

        public TraceLogger(IEnumerable<TraceListener> listeners)
        {
            foreach (var listener in listeners)
            {
                Trace.Listeners.Add(listener);
            }
        }

        public void Log(LogEntry logEntry)
        {
            if (logEntry.Exception != null)
            {
                Trace.WriteLine(AddLevelPrefix(logEntry.Level, logEntry.Message));

                var exception = logEntry.Exception;
                while (exception != null)
                {
                    Trace.Indent();
                    Trace.WriteLine(ReplaceIdentNewLines(exception.ToString()));
                    exception = exception.InnerException;
                }
                Trace.IndentLevel = 0;
            }
            else if (logEntry.Message is string && logEntry.Args.Length > 0)
            {
                Trace.WriteLine(AddLevelPrefix(logEntry.Level, String.Format(logEntry.Message as string, logEntry.Args)));
            }
            else
            {
                Trace.WriteLine(AddLevelPrefix(logEntry.Level, logEntry.Message));
            }

            string AddLevelPrefix(LogLevel level, object obj)
            {
                return $"{LevelPrefixes[level]}: {obj.ToString()}";
            }

            string ReplaceIdentNewLines(string s)
            {
                return s.Replace(Environment.NewLine, PaddedNewLine());
            }

            string PaddedNewLine()
            {
                return Environment.NewLine + new string(' ', Trace.IndentLevel * Trace.IndentSize);
            }
        }
    }
}
