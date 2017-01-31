using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// 
    /// </summary>
    public class FilingAnswer
    {
        /// <summary>
        /// 
        /// </summary>
        public Int64 filingQuestionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> answer { get; set; }


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
