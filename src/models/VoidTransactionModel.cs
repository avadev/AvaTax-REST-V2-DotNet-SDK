using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// A request to void a previously created transaction
    /// </summary>
    public class VoidTransactionModel
    {
        /// <summary>
        /// Please specify the reason for voiding or cancelling this transaction
        /// </summary>
        public VoidReasonCode code { get; set; }


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
