using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2023 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Jonathan Wenger <jonathan.wenger@avalara.com>
 * @author Sachin Baijal <sachin.baijal@avalara.com>
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// A model for return payments.
    /// </summary>
    public class FilingPaymentModel
    {
        /// <summary>
        /// The unique ID number for the payment.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The filing return id that this applies too
        /// </summary>
        public Int64 filingId { get; set; }

        /// <summary>
        /// The payment amount.
        /// </summary>
        public Decimal paymentAmount { get; set; }

        /// <summary>
        /// The type of the payment.
        /// </summary>
        public PaymentType type { get; set; }

        /// <summary>
        /// Whether or not the payment has been calculated.
        /// </summary>
        public Boolean? isCalculated { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The User ID of the user who created this record.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The user ID of the user who last modified this record.
        /// </summary>
        public Int32? modifiedUserId { get; set; }


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
