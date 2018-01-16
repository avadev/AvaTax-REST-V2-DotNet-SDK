using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Information about an API call
    /// </summary>
    public class AvaTaxCallEventArgs : EventArgs
    {
        /// <summary>
        /// The HTTP verb that was used for the API call
        /// </summary>
        public string HttpVerb { get; set; }

        /// <summary>
        /// The full request URI that was sent
        /// </summary>
        public Uri RequestUri { get; set; }

        /// <summary>
        /// The response code for this request
        /// </summary>
        public HttpStatusCode Code { get; set; }

        /// <summary>
        /// The body of the request that was sent
        /// </summary>
        public string RequestBody { get; set; }

        /// <summary>
        /// The response body, if the response was received as a string
        /// </summary>
        public string ResponseString { get; set; }

        /// <summary>
        /// The response body, if the response was received as a file download attachment
        /// </summary>
        public byte[] ResponseBody { get; set; }

        /// <summary>
        /// Information about the length of time this API call took to complete
        /// </summary>
        public CallDuration Duration { get; set; }
    }
}
