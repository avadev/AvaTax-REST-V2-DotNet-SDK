using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Information about an API call
    /// </summary>
    public class AvaTaxCallResult : EventArgs
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
        /// The body of the request that was sent (for string-based payloads)
        /// </summary>
        public string RequestString { get; set; }

        /// <summary>
        /// The body of the request that was sent (for byte-array payloads)
        /// </summary>
        public byte[] RequestBytes { get; set; }

        /// <summary>
        /// The response body, if the response was received as a string
        /// </summary>
        public string ResponseString { get; set; }

        /// <summary>
        /// The response body, if the response was received as a file download attachment
        /// </summary>
        public byte[] ResponseBytes { get; set; }

        /// <summary>
        /// Information about the length of time this API call took to complete
        /// </summary>
        public CallDuration Duration { get; set; }

        /// <summary>
        /// The MIME Content-Type of the result 
        /// </summary>
        public string ResponseContentType { get; set; }

        /// <summary>
        /// The Content-Disposition value for the result
        /// </summary>
        public string ResponseFileName { get; set; }

        /// <summary>
        /// Decode the result as a specific object type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Deserialize<T>()
        {
            // If the result wasn't Json, give up
            if (!String.Equals("application/json", ResponseContentType)) return default(T);
            if (String.IsNullOrEmpty(ResponseString)) return default(T);

            // Configure the serializer
            var s = new JsonSerializerSettings();
            s.NullValueHandling = NullValueHandling.Ignore;
            s.Converters.Add(new StringEnumConverter());

            // Decode this object
            return JsonConvert.DeserializeObject<T>(ResponseString);
        }

        /// <summary>
        /// Returns true if this call result contains an error
        /// </summary>
        /// <returns></returns>
        public bool IsError()
        {
            var codeNum = (int)Code;
            return (codeNum >= 400 && codeNum < 600);
        }

        /// <summary>
        /// Returns the error object for this API call
        /// </summary>
        /// <returns></returns>
        public AvaTaxError GetError()
        {
            if (IsError()) {
                return Deserialize<AvaTaxError>();
            }
            return null;
        }

        /// <summary>
        /// Check if this result represents an error
        /// </summary>
        public void CheckAndThrow()
        {
            var err = GetError();
            if (err != null) throw err;
        }
    }
}
