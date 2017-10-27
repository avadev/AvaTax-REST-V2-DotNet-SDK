using System;

namespace Avalara.AvaTax.RestClient
{
    public interface ILog
    {
        /// <summary>
        /// True if calls to <see cref="Write(LogEntry)"/> persist the log entry; otherwise false
        /// </summary>
        bool IsEnabled { get; }


        /// <summary>
        /// Implementers should Persists the LogEntry.
        /// </summary>
        /// <remarks>
        /// Write should not throw any exceptions.</remarks>
        /// <param name="entry">The log entry to persist.</param>
        void Write(LogEntry entry);
    }
}
