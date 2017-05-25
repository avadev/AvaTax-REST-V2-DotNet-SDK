using System;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a request and response for the AvaTax API.
    /// </summary>
    public class LogEntry
    {

        public LogEntry()
        {
            Request = new Request();
            Response = new Response();
        }

        /// <summary>
        /// The Request made to AvaTax
        /// </summary>
        public Request Request { get; private set; }


        /// <summary>
        /// The Response received from AvaTax
        /// </summary>
        public Response Response { get; private set; }

        /// <summary>
        /// The Timing information for the Request and Response.
        /// </summary>
        public CallDuration CallDuration { get; set; }

        /// <summary>
        /// Any exception thrown during the request.
        /// </summary>
        public Exception Exception { get; set; }
    }

}
