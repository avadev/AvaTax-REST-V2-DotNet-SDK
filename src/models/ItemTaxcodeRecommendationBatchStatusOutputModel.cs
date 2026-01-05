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
    /// Represents the output model containing the status and results of a tax code recommendation batch.
    /// </summary>
    public class ItemTaxcodeRecommendationBatchStatusOutputModel
    {
        /// <summary>
        /// The unique ID of the batch.
        /// </summary>
        public Int64? batchId { get; set; }

        /// <summary>
        /// The current processing status of the batch.
        /// Possible values: "Pending", "Processing", "Completed", "Failed", "Deleted"
        /// </summary>
        public String batchStatus { get; set; }

        /// <summary>
        /// The list of items with their tax code recommendations.
        /// This property is populated only when the batch status is "Completed".
        /// </summary>
        public List<ItemTaxcodeRecommendationBatchesOutputModel> value { get; set; }

        /// <summary>
        /// An optional message providing additional information about the batch.
        /// </summary>
        public String message { get; set; }


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
