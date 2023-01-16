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
    public class ItemModel
    {
        /// <summary>
        /// The unique ID number of this item.
        /// </summary>
        public Int64 id { get; set; }

        /// <summary>
        /// The unique ID number of the company that owns this item.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// A unique code representing this item.
        /// </summary>
        public String itemCode { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 11/13/2018, Version: 18.12, Message: For identifying an `Item` with `Avalara TaxCode`, please call the [CreateItemClassification API] with your ItemCode and the Avalara TaxCode.
        /// The unique ID number of the tax code that is applied when selling this item.
        /// When creating or updating an item, you can either specify the Tax Code ID number or the Tax Code string; you do not need to specify both values.
        /// </summary>
        public Int32? taxCodeId { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 11/13/2018, Version: 18.12, Message: For identifying an `Item` with `Avalara TaxCode`, please call the [CreateItemClassification API] with your ItemCode and the Avalara TaxCode.
        /// The unique code string of the Tax Code that is applied when selling this item.
        /// When creating or updating an item, you can either specify the Tax Code ID number or the Tax Code string; you do not need to specify both values.
        /// </summary>
        public String taxCode { get; set; }

        /// <summary>
        /// A friendly description of this item in your product catalog.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// A way to group similar items.
        /// </summary>
        public String itemGroup { get; set; }

        /// <summary>
        /// A category of product
        /// </summary>
        public String category { get; set; }

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
        /// Source of creation of this item
        /// </summary>
        public String source { get; set; }

        /// <summary>
        /// Universal unique code for item
        /// </summary>
        public String upc { get; set; }

        /// <summary>
        /// List of classifications that belong to this item.
        /// A single classification consits of a productCode and a systemCode for a particular item.
        /// </summary>
        public List<ClassificationModel> classifications { get; set; }

        /// <summary>
        /// List of item parameters.
        /// </summary>
        public List<ItemParameterModel> parameters { get; set; }

        /// <summary>
        /// List of item tags.
        /// </summary>
        public List<ItemTagDetailInputModel> tags { get; set; }

        /// <summary>
        /// Additional key-description of the product.
        /// </summary>
        public object properties { get; set; }


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
