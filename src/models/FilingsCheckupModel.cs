using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Results of the Worksheet Checkup report
    /// </summary>
    public class FilingsCheckupModel
    {
        /// <summary>
        /// A collection of authorities in the report
        /// </summary>
        public List<FilingsCheckupAuthorityModel> authorities { get; set; }


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
