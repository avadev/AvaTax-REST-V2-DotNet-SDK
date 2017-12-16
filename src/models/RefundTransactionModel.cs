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
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Refund a committed transaction
    /// </summary>
    public class RefundTransactionModel
    {
        /// <summary>
        /// The transaction code for the refund. This code will be saved to the `ReturnInvoice` transaction, and does not need to match the code of the original sale.
        /// </summary>
        public String refundTransactionCode { get; set; }

        /// <summary>
        /// The date of the refund. For customers using Avalara's Managed Returns Service, this date controls the month in which the refund
        /// transaction will be reported on a tax filing.
        /// </summary>
        public DateTime refundDate { get; set; }

        /// <summary>
        /// Type of this refund. 
        /// 
        /// To submit a full refund, specify `Full`. 
        /// 
        /// To refund only specific lines from the transaction, specify `Partial` and indicate the lines you wish to apply in the `refundLines` field.
        /// 
        /// To refund the tax that was paid in the previous transaction, specify `TaxOnly`.
        /// 
        /// To issue a percentage-based discount, specify `Percentage`.
        /// </summary>
        public RefundType? refundType { get; set; }

        /// <summary>
        /// The percentage for refund.
        /// 
        /// This value only applies if you choose `refundType = Percentage` or `refundType = Partial`.
        /// </summary>
        public Decimal? refundPercentage { get; set; }

        /// <summary>
        /// If you chose a refund of type `Partial`, this indicates which lines from the original transaction are being refunded.
        /// </summary>
        public List<String> refundLines { get; set; }

        /// <summary>
        /// A user-defined reference field containing information about this refund.
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
