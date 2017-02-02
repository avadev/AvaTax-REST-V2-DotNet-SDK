using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Rate Model
    /// </summary>
    public class RateModel
    {
        /// <summary>
        /// Rate
        /// </summary>
        public Decimal? rate { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public JurisdictionType? type { get; set; }


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
