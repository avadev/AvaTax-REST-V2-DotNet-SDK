using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Rebuild a set of filings.
    /// </summary>
    public class RebuildFilingsModel
    {
        /// <summary>
        /// Set this value to true in order to rebuild the filings.
        /// </summary>
        public Boolean rebuild { get; set; }


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
