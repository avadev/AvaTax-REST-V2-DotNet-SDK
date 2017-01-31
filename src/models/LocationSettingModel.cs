using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents the answer to one local jurisdiction question for a location.
    /// </summary>
    public class LocationSettingModel
    {
        /// <summary>
        /// The unique ID number of the location question answered.
        /// </summary>
        public Int32? questionId { get; set; }

        /// <summary>
        /// The answer the user provided.
        /// </summary>
        public String value { get; set; }


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
