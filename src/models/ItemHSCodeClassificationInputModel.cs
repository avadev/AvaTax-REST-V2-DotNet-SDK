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
    /// Input model of the HS code classification.
    /// </summary>
    public class ItemHSCodeClassificationInputModel
    {
        /// <summary>
        /// The unique item ID.
        /// </summary>
        public Int64 itemId { get; set; }

        /// <summary>
        /// Country of destination for this HS code classification.
        /// </summary>
        public List<String> countryOfDestinations { get; set; }

        /// <summary>
        /// Used for checking the premium classification status.
        /// </summary>
        public Boolean? isPremiumClassification { get; set; }

        /// <summary>
        /// A field for checking whether this is a reclassification.
        /// </summary>
        public Boolean? isReclassification { get; set; }

        /// <summary>
        /// Whether this item classification is disputed.
        /// </summary>
        public Boolean? isDisputed { get; set; }

        /// <summary>
        /// Whether this item classification is a priority classification.
        /// </summary>
        public Boolean? isPriority { get; set; }

        /// <summary>
        /// the item is exported to other countries.
        /// </summary>
        public Boolean? isExport { get; set; }

        /// <summary>
        /// IsExportControl flag to identify cross border classification
        /// </summary>
        public Boolean? isExportControl { get; set; }

        /// <summary>
        /// Instructions related to this item classification.
        /// </summary>
        public String instructions { get; set; }

        /// <summary>
        /// The language used in this item classification.
        /// </summary>
        public String language { get; set; }


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
