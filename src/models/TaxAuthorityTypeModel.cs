using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Tax Authority Type Model
    /// </summary>
    public class TaxAuthorityTypeModel
    {
        /// <summary>
        /// The unique ID number of this tax Authority customer type.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// The description name of this tax authority type.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// Tax Authority Group
        /// </summary>
        public String taxAuthorityGroup { get; set; }


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
