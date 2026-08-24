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
    /// Represents a create transaction batch request model.
    /// </summary>
    public class CreateTransactionBatchRequestModel
    {
        /// <summary>
        /// The user-friendly readable name for this batch.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The list of transactions contained in this batch.
        /// </summary>
        public List<TransactionBatchItemModel> transactions { get; set; }

        /// <summary>
        /// Any optional flags provided for this batch
        /// </summary>
        public String options { get; set; }

        /// <summary>
        /// Skips upload-time transaction type, company code, and nested model validation when true.
        /// The transactions are instead validated individually while BatchV2 processes the batch,
        /// and transaction validation failures are written to the batch error file.
        ///  
        /// An explicit value overrides the BatchProcessing configuration default. If omitted, the
        /// configured SkipTransactionValidation value is used.
        /// </summary>
        public Boolean? skipTransactionValidation { get; set; }


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
