using System;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// A decorator which ensures any exception thrown by the underlying logger
    /// it will not disrupt the normal flow of the AvaTaxClient.
    /// </summary>
    internal class DelegatingLogger : ILog
    {
        private readonly ILog _inner;

        public DelegatingLogger(ILog logger)
        {
            _inner = logger;
        }

        public bool IsEnabled
        {
            get
            {
                try
                {
                    return _inner.IsEnabled;
                }
                catch
                {
                    return false;
                }
            }
        }

        public void Write(LogEntry message)
        {
            try
            {
                _inner.Write(message);
            }
            catch { }
        }
    }
}
