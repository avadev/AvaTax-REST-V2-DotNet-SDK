using System;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents an error returned by AvaTax
    /// </summary>
    public class AvaTaxError : Exception
    {
        /// <summary>
        /// The raw error message from the client
        /// </summary>
        public ErrorResult error { get; set; }

        /// <summary>
        /// Constructs an error object for an API call
        /// </summary>
        /// <param name="err"></param>
        public AvaTaxError(ErrorResult err)
        {
            this.error = err;
        }
    }
}