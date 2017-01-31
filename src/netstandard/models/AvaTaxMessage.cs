using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Informational or warning messages returned by AvaTax with a transaction
    /// </summary>
    public class AvaTaxMessage
    {
        /// <summary>
        /// A brief summary of what this message tells us
        /// </summary>
        public String summary { get; set; }

        /// <summary>
        /// Detailed information that explains what the summary provided
        /// </summary>
        public String details { get; set; }

        /// <summary>
        /// Information about what object in your request this message refers to
        /// </summary>
        public String refersTo { get; set; }

        /// <summary>
        /// A category that indicates how severely this message affects the results
        /// </summary>
        public String severity { get; set; }

        /// <summary>
        /// The name of the code or service that generated this message
        /// </summary>
        public String source { get; set; }


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
