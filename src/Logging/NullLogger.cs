using System;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// A no-op implementation
    /// </summary>
    internal class NullLogger : ILog
    {
        public bool IsEnabled
        {
            get { return false; }
        }

        public void Write(LogEntry message) { }
    }
}
