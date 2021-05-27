using System;
using System.Net.Http;
using Polly;
using Polly.Retry;


namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Class for Exception Retry Policy
    /// </summary>
    public class ExceptionRetry
    {
        /// <summary>
        /// Gets or sets Retry policy
        /// </summary>
        public AsyncRetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Initializes <see cref="ExceptionRetry"/> class.
        /// </summary>
        /// <param name="maxRetryAttempt">Maximum retry attempt</param>
        public ExceptionRetry(int maxRetryAttempt)
        {
            // Handling HttpRequestException and AvataxServerError - InternalServerError and RequestTimeout 
            RetryPolicy = Policy
                           .Handle<HttpRequestException>()
                           .Or<AvaTaxServerError>()
                           .WaitAndRetryAsync(maxRetryAttempt, retryAttempt =>
                           {
                               return TimeSpan.FromSeconds(2 * retryAttempt); 
                           });
        }
    }
}
