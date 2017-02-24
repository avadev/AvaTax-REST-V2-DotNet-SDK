using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
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
        public Int32 companyId { get; set; }

        /// <summary>
        /// A unique code representing this item.
        /// </summary>
        public String itemCode { get; set; }

        /// <summary>
        /// The unique ID number of the tax code that is applied when selling this item.
        ///When creating or updating an item, you can either specify the Tax Code ID number or the Tax Code string; you do not need to specify both values.
        /// </summary>
        public Int32? taxCodeId { get; set; }

        /// <summary>
        /// The unique code string of the Tax Code that is applied when selling this item.
        ///When creating or updating an item, you can either specify the Tax Code ID number or the Tax Code string; you do not need to specify both values.
        /// </summary>
        public String taxCode { get; set; }

        /// <summary>
        /// A friendly description of this item in your product catalog.
        /// </summary>
        public String description { get; set; }

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
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
