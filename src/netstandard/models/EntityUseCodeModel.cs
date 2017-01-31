using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a code describing the intended use for a product that may affect its taxability
    /// </summary>
    public class EntityUseCodeModel
    {
        /// <summary>
        /// The Avalara-recognized entity use code for this definition
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// The name of this entity use code
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Text describing the meaning of this use code
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// A list of countries where this use code is valid
        /// </summary>
        public List<String> validCountries { get; set; }


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
