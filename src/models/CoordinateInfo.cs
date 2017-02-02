using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Coordinate Info
    /// </summary>
    public class CoordinateInfo
    {
        /// <summary>
        /// Latitude
        /// </summary>
        public Decimal? latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public Decimal? longitude { get; set; }


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
