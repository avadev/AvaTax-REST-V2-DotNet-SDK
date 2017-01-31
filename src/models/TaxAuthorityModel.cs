using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Tax Authority Model
    /// </summary>
    public class TaxAuthorityModel
    {
        /// <summary>
        /// The unique ID number of this tax authority.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// The friendly name of this tax authority.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The type of this tax authority.
        /// </summary>
        public Int32? taxAuthorityTypeId { get; set; }

        /// <summary>
        /// The unique ID number of the jurisdiction for this tax authority.
        /// </summary>
        public Int32? jurisdictionId { get; set; }


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
