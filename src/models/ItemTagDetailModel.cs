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
    /// Represents a tag for an item in your company's product catalog.
    /// </summary>
    public class ItemTagDetailModel
    {
        /// <summary>
        /// The unique ID number of the item-tag relation.
        /// </summary>
        public Int32? itemTagDetailId { get; set; }

        /// <summary>
        /// The unique tag Id for the tags.
        /// </summary>
        public Int32? tagId { get; set; }

        /// <summary>
        /// The tag name.
        /// </summary>
        public String tagName { get; set; }

        /// <summary>
        /// The unique ID number of this item.
        /// </summary>
        public Int64? itemId { get; set; }

        /// <summary>
        /// The unique ID number of the company that owns this item.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }


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
