using System;
using System.Net;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents an error returned by AvaTax
    /// </summary>
    public class AvaTaxError : Exception
    {
        /// <summary>
        /// The HTTP status code
        /// </summary>
        public HttpStatusCode statusCode { get; set; }

        /// <summary>
        /// The raw error message from the client
        /// </summary>
        public ErrorResult error { get; set; }

        /// <summary>
        /// The response correlation ID returned by AvaTax
        /// </summary>
        public string XCorrelationId { get; set; }

        /// <summary>
        /// Constructs an error object for an API call
        /// </summary>
        /// <param name="err"></param>
        /// <param name="code"></param>
        public AvaTaxError(ErrorResult err, HttpStatusCode code)
            : this(err, code, null)
        {
        }

        /// <summary>
        /// Constructs an error object for an API call
        /// </summary>
        /// <param name="err"></param>
        /// <param name="code"></param>
        /// <param name="xCorrelationId"></param>
        public AvaTaxError(ErrorResult err, HttpStatusCode code, string xCorrelationId)
        {
            this.error = err;
            this.statusCode = code;
            this.XCorrelationId = xCorrelationId;
        }
    }
}