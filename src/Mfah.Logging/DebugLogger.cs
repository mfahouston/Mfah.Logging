using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mfah.Logging
{
    /// <summary>
    /// <see cref="ILogger"/> implementation that utilizes <see cref="System.Diagnostics.Debug"/> to log
    /// </summary>
    public class DebugLogger : ILogger
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

        /// <summary>
        /// Log something
        /// </summary>
        /// <param name="logEntry"><see cref="LogEntry"/> instance to log</param>
        public void Log(LogEntry logEntry)
        {
            if (logEntry.Exception != null)
            {
                Debug.WriteLine(AddLevelPrefix(logEntry.Level, logEntry.Message));

                var exception = logEntry.Exception;
                while (exception != null)
                {
                    Debug.Indent();
                    Debug.WriteLine(ReplaceIdentNewLines(exception.ToString()));
                    exception = exception.InnerException;
                }
                Debug.IndentLevel = 0;
            }
            else if (logEntry.Message is string && logEntry.Args.Length > 0)
            {
                Debug.WriteLine(AddLevelPrefix(logEntry.Level, String.Format(logEntry.Message as string, logEntry.Args)));
            }
            else
            {
                Debug.WriteLine(AddLevelPrefix(logEntry.Level, logEntry.Message));
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
                return Environment.NewLine + new string(' ', Debug.IndentLevel * Debug.IndentSize);
            }
        }
    }
}
