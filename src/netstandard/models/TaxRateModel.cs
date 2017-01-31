using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Tax Rate Model
    /// </summary>
    public class TaxRateModel
    {
        /// <summary>
        /// Total Rate
        /// </summary>
        public Decimal? totalRate { get; set; }

        /// <summary>
        /// Rates
        /// </summary>
        public List<RateModel> rates { get; set; }


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
