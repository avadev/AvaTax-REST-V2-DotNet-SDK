using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
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
    /// Refund a committed transaction
    /// </summary>
    public class RefundTransactionModel
    {
        /// <summary>
        /// the transaction code for this refund
        /// </summary>
        public String refundTransactionCode { get; set; }

        /// <summary>
        /// The date of the refund. If null, today's date will be used
        /// </summary>
        public DateTime? refundDate { get; set; }

        /// <summary>
        /// Type of this refund
        /// </summary>
        public RefundType? refundType { get; set; }

        /// <summary>
        /// Percentage for refund
        /// </summary>
        public Decimal? refundPercentage { get; set; }

        /// <summary>
        /// Process refund for these lines
        /// </summary>
        public List<String> refundLines { get; set; }

        /// <summary>
        /// Reference code for this refund
        /// </summary>
        public String referenceCode { get; set; }


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
