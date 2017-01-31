using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Ping Result Model
    /// </summary>
    public class PingResultModel
    {
        /// <summary>
        /// Version number
        /// </summary>
        public String version { get; set; }

        /// <summary>
        /// Returns true if you provided authentication for this API call; false if you did not.
        /// </summary>
        public Boolean? authenticated { get; set; }

        /// <summary>
        /// Returns the type of authentication you provided, if authenticated
        /// </summary>
        public AuthenticationTypeId? authenticationType { get; set; }

        /// <summary>
        /// The username of the currently authenticated user, if any.
        /// </summary>
        public String authenticatedUserName { get; set; }


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
