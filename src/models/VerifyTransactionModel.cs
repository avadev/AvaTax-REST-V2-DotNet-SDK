using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Verify this transaction by matching it to values in your accounting system.
    /// </summary>
    public class VerifyTransactionModel
    {
        /// <summary>
        /// Transaction Date - The date on the invoice, purchase order, etc.
        /// </summary>
        public DateTime? verifyTransactionDate { get; set; }

        /// <summary>
        /// Total Amount - The total amount (not including tax) for the document.
        /// </summary>
        public Decimal? verifyTotalAmount { get; set; }

        /// <summary>
        /// Total Tax - The total tax for the document.
        /// </summary>
        public Decimal? verifyTotalTax { get; set; }


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
