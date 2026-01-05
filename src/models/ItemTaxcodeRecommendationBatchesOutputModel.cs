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
    /// Represents the output model for tax code recommendation batches (both synchronous and asynchronous).
    /// </summary>
    public class ItemTaxcodeRecommendationBatchesOutputModel
    {
        /// <summary>
        /// A brief description of the item.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The category of the item.
        /// </summary>
        public String category { get; set; }

        /// <summary>
        /// The type of item. Examples: "Physical", "Digital", "Service", "Freight"
        /// </summary>
        public String itemType { get; set; }

        /// <summary>
        /// The Universal Product Code (UPC) associated with the item.
        /// </summary>
        public String upc { get; set; }

        /// <summary>
        /// A summary or detailed description of the item.
        /// </summary>
        public String summary { get; set; }

        /// <summary>
        /// The list of generated tax code recommendations for this item.
        /// </summary>
        public List<TaxCodeRecommendationOutputModel> taxCodeRecommendations { get; set; }


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
