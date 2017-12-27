using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Information about the error that occurred
    /// </summary>
    public class ErrorInfo
    {
        /// <summary>
        /// Type of error that occurred.
        /// </summary>
        /// <remarks>
        /// This value is captured as a string so that if the server adds new error codes it will still parse.
        /// 
        /// You can compare this value to the ErrorCodeId enumeration.
        /// </remarks>
        public String code { get; set; }

        /// <summary>
        /// Short one-line message to summaryize what went wrong
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// What object or service caused the error?
        /// </summary>
        /// <remarks>
        /// This value is captured as a string so that if the server adds new error targets it will still parse.
        /// </remarks>
        public String target { get; set; }

        /// <summary>
        /// Array of detailed error messages
        /// </summary>
        public List<ErrorDetail> details { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}