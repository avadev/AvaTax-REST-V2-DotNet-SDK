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
        /// A summary for selection of the tax code.
        /// </summary>
        public String summary { get; set; }

        /// <summary>
        /// The tax code of the item.
        /// </summary>
        public String taxCode { get; set; }

        /// <summary>
        /// The universal product code of the item.
        /// </summary>
        public String upc { get; set; }

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
        /// Additional key-description of the product.
        /// </summary>
        public object properties { get; set; }

        /// <summary>
        /// Classifications Attached to the Product
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
