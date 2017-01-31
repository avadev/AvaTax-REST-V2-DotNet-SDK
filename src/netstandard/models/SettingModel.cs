using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// This object is used to keep track of custom information about a company.
        /// A setting can refer to any type of data you need to remember about this company object.
        /// When creating this object, you may define your own "set", "name", and "value" parameters.
        /// To define your own values, please choose a "set" name that begins with "X-" to indicate an extension.
    /// </summary>
    public class SettingModel
    {
        /// <summary>
        /// The unique ID number of this setting.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// The unique ID number of the company this setting refers to.
        /// </summary>
        public Int32 companyId { get; set; }

        /// <summary>
        /// A user-defined "set" containing this name-value pair.
        /// </summary>
        public String set { get; set; }

        /// <summary>
        /// A user-defined "name" for this name-value pair.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The value of this name-value pair.
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
