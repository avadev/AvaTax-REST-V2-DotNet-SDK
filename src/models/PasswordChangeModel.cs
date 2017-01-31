using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Password Change Model
    /// </summary>
    public class PasswordChangeModel
    {
        /// <summary>
        /// Old Password
        /// </summary>
        public String oldPassword { get; set; }

        /// <summary>
        /// New Password
        /// </summary>
        public String newPassword { get; set; }


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
