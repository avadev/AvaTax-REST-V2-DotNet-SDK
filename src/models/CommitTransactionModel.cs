using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Commit this transaction as permanent
    /// </summary>
    public class CommitTransactionModel
    {
        /// <summary>
        /// Set this value to be true to commit this transaction.
        /// Committing a transaction allows it to be reported on a tax return. Uncommitted transactions will not be reported.
        /// </summary>
        public Boolean commit { get; set; }


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
