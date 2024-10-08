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
    /// Represents an item in your company's product catalog.
    /// </summary>
    public class ItemCatalogueInputModel
    {
        /// <summary>
        /// The unique ID number of this item.
        /// </summary>
        public Int64? itemId { get; set; }

        /// <summary>
        /// A unique code representing this item.
        /// </summary>
        public String itemCode { get; set; }

        /// <summary>
        /// A friendly description of this item in your product catalog.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The tax code of the item.
        /// </summary>
        public String taxCode { get; set; }

        /// <summary>
        /// Type of item
        /// </summary>
        public String itemType { get; set; }

        /// <summary>
        /// The universal product code of the item.
        ///  
        /// Deprecated - As of 6/25/2024, this field is deprecated. Instead of using this field, you can pass this value as a parameter. The parameter name is UPC.
        /// </summary>
        public String upc { get; set; }

        /// <summary>
        /// Long Summary for Item
        ///  
        /// Deprecated - As of 6/25/2024, this field is deprecated. Instead of using this field, you can pass this value as a parameter. The parameter name is Summary.
        /// </summary>
        public String summary { get; set; }

        /// <summary>
        /// A way to group similar items.
        /// </summary>
        public String itemGroup { get; set; }

        /// <summary>
        /// A path to the category where item is included.
        /// </summary>
        public String category { get; set; }

        /// <summary>
        /// The source of creation of this item.
        /// </summary>
        public String source { get; set; }

        /// <summary>
        /// The unique identifier of this item at the source
        /// </summary>
        public String sourceEntityId { get; set; }

        /// <summary>
        /// Additional key-description of the product.
        /// </summary>
        public object properties { get; set; }

        /// <summary>
        /// Classifications Attached to the Product
        /// Please note: `taxCode` (ProductCode for SystemCode `AVATAXCODE`) is being removed from `classifications`. You can still find it in the `taxCode` field.
        /// </summary>
        public List<ClassificationModel> classifications { get; set; }

        /// <summary>
        /// Parameters Attached to the Product
        /// </summary>
        public List<ItemParameterModel> parameters { get; set; }


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
