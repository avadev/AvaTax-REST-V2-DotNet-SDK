using System;
using System.Collections.Generic;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// The request made to AvaTax.
    /// </summary>
    public class Request
    {
        public Request()
        {
            Headers = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Headers { get; set; }
        public string Method { get; set; }
        public Uri RequestUri { get; set; }
        public string Body { get; set; }
    }

}
