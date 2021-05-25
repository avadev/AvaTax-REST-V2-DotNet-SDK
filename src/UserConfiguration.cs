namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Class for User configuration
    /// </summary>
    public class UserConfiguration
    {
        /// <summary>
        /// Gets or sets timeout in minutes
        /// </summary>
        public int TimeoutInMinutes { get; set; } = 20;

        /// <summary>
        /// Gets or sets Maximum retry attempts
        /// </summary>
        public int MaxRetryAttempts { get; set; } 
    }
}
