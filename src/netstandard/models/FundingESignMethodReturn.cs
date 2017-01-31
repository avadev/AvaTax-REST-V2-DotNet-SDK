using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents the current status of a funding ESign method
    /// </summary>
    public class FundingESignMethodReturn
    {
        /// <summary>
        /// Method
        /// </summary>
        public String method { get; set; }

        /// <summary>
        /// JavaScriptReady
        /// </summary>
        public Boolean? javaScriptReady { get; set; }

        /// <summary>
        /// The actual javascript to use to render this object
        /// </summary>
        public String javaScript { get; set; }


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
