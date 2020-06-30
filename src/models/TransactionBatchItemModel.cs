using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2019 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Genevieve Conty
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a transaction batch item.
    /// Only one child transaction model should contain data.
    /// </summary>
    public class TransactionBatchItemModel
    {
        /// <summary>
        /// Represents a transaction to be created.
        /// </summary>
        public CreateTransactionModel createTransactionModel { get; set; }

        /// <summary>
        /// Represents an existing transaction to be adjusted.
        /// </summary>
        public BatchAdjustTransactionModel adjustTransactionModel { get; set; }

        /// <summary>
        /// Represents an existing transaction to be voided.
        /// </summary>
        public BatchVoidTransactionModel voidTransactionModel { get; set; }


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
