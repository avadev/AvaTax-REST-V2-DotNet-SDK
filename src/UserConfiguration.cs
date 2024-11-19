namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Class for User configuration
    /// </summary>
    public class UserConfiguration
    {
        private int _timeOutInMinutes;
        private int _timeOutInSeconds;
        private int _maxRetryAttempts;

        /// <summary>
        /// Gets or sets timeout in minutes
        /// </summary>
        public int TimeoutInMinutes
        {
            get { return _timeOutInMinutes; }
            set
            {
                _timeOutInMinutes = value <= 0 ? 20 : value;
            }
        }

        /// <summary>
        /// Gets or sets timeout in seconds. If set to a non-zero value, overrides TimeoutInMinutes.
        /// </summary>
        public int TimeoutInSeconds
        {
            get { return _timeOutInSeconds; }
            set
            {
                _timeOutInSeconds = value <= 0 ? 0 : value;
            }
        }

        /// <summary>
        /// Get <see cref="TimeSpan"/> for the currently set timeout period.
        /// </summary>
        public TimeSpan GetTimeOutTimeSpan()
        {
            return _timeOutInSeconds > 0 ? TimeSpan.FromSeconds(_timeOutInSeconds) : TimeSpan.FromMinutes(_timeOutInMinutes);
        }

        /// <summary>
        /// Gets or sets Maximum retry attempts
        /// </summary>
        public int MaxRetryAttempts
        {
            get { return _maxRetryAttempts; }
            set
            {
                _maxRetryAttempts = value < 0 ? 0 : value;
            }
        }

        /// <summary>
        /// Initializes <see cref="UserConfiguration"/> class
        /// </summary>
        public UserConfiguration()
        {
            this._maxRetryAttempts = 0;
            this._timeOutInMinutes = 20;
            this._timeOutInSeconds = 0;
        }
    }
}
