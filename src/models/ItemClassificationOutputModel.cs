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
    /// Product classification output model.
    /// </summary>
    public class ItemClassificationOutputModel
    {
        /// <summary>
        /// The unique ID number of this product.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The unique ID number of the item this product belongs to.
        /// </summary>
        public Int64? itemId { get; set; }

        /// <summary>
        /// The system id which the product belongs.
        /// </summary>
        public Int32? systemId { get; set; }

        /// <summary>
        /// A unique code representing this item.
        /// </summary>
        public String productCode { get; set; }

        /// <summary>
        /// A unique code representing this item.
        /// </summary>
        public String systemCode { get; set; }

        /// <summary>
        /// If there is an premium classification justification present for this classification
        /// </summary>
        public Boolean? isPremium { get; set; }


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
