using System.Net;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Class for handling Avatax server errors - InternalServerError, RequestTimeout
    /// </summary>
    public class AvaTaxServerError: AvaTaxError
    {
        /// <summary>
        /// Initializes <see cref="AvaTaxServerError"/> class
        /// </summary>
        /// <param name="errorResult">Error Result</param>
        /// <param name="statusCode">HTTP status code</param>
        public AvaTaxServerError(ErrorResult errorResult, HttpStatusCode statusCode) 
            : base(errorResult, statusCode)
        {
        }
    }
}
