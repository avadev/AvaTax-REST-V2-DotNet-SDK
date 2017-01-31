using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// FilingFrequency Model
    /// </summary>
    public class FilingFrequencyModel
    {
        /// <summary>
        /// The unique ID number of this filing frequency.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// The description name of this filing frequency
        /// </summary>
        public String description { get; set; }


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
