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
    /// Replace an existing transaction recorded in AvaTax with a new one.
    /// </summary>
    public class BatchAdjustTransactionModel
    {
        /// <summary>
        /// Specifies the code of the company for this transaction.
        /// </summary>
        public String companyCode { get; set; }

        /// <summary>
        /// Please specify the transaction code of the transaction to void.
        /// </summary>
        public String transactionCode { get; set; }

        /// <summary>
        /// Specifies the type of document to void.
        /// </summary>
        public String documentType { get; set; }

        /// <summary>
        /// A reason code indicating why this adjustment was made
        /// </summary>
        public AdjustmentReason adjustmentReason { get; set; }

        /// <summary>
        /// If the AdjustmentReason is "Other", specify the reason here.
        ///  
        /// This is required when the AdjustmentReason is 8 (Other).
        /// </summary>
        public String adjustmentDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CreateTransactionModel newTransaction { get; set; }


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
