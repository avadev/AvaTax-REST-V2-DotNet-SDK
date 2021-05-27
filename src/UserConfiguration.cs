namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Class for User configuration
    /// </summary>
    public class UserConfiguration
    {
        private int _timeOutInMinutes;
        private int _maxRetryAttempts;

        /// <summary>
        /// Gets or sets timeout in minutes
        /// </summary>
        public int TimeoutInMinutes { 
            get { return _timeOutInMinutes; }
            set
            {
                _timeOutInMinutes = value <= 0 ? 20 : value;
            }
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
        }
    }
}
