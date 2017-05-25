using System;
using System.Collections.Generic;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// The Response from AvaTax
    /// </summary>
    public class Response
    {
        public Response()
        {
            Headers = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Headers { get; private set; }

        public string Body { get; set; }

        public int StatusCode { get; set; }

    }
}
