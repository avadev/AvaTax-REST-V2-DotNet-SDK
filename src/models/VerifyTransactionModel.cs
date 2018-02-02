using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Verify this transaction by matching it to values in your accounting system.
    /// 
    /// You may specify one or more of the following fields to verify: `date`, `totalAmount`, or `totalTax`.
    /// This call will report an error if there is any difference between the data stored in AvaTax and
    /// the data stored in your accounting system.
    /// </summary>
    public class VerifyTransactionModel
    {
        /// <summary>
        /// Set this value if you wish to verify a match between `verifyTransactionDate` and
        /// the `documentDate` value on the transaction recorded in AvaTax.
        /// 
        /// If you leave this field empty, we will skip verification for this field.
        /// </summary>
        public DateTime? verifyTransactionDate { get; set; }

        /// <summary>
        /// Set this value if you wish to verify a match between `verifyTotalAmount` and
        /// the `totalAmount` value on the transaction recorded in AvaTax.
        /// 
        /// If you leave this field empty, we will skip verification for this field.
        /// </summary>
        public Decimal? verifyTotalAmount { get; set; }

        /// <summary>
        /// Set this value if you wish to verify a match between `verifyTotalTax` and
        /// the `totalTax` value on the transaction recorded in AvaTax.
        /// 
        /// If you leave this field empty, we will skip verification for this field.
        /// </summary>
        public Decimal? verifyTotalTax { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented, NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
