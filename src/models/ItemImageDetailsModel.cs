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
    /// Item image details model
    /// </summary>
    public class ItemImageDetailsModel
    {
        /// <summary>
        /// Guid Primary key for ItemImage
        /// </summary>
        public String itemImageId { get; set; }

        /// <summary>
        /// Numeric primary key for ItemImage
        /// </summary>
        public Int64? itemImageDetailId { get; set; }

        /// <summary>
        /// Gets or sets the company ID associated with the item image.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// Gets or sets the item ID.
        /// </summary>
        public Int64? itemId { get; set; }

        /// <summary>
        /// Gets or sets the creation timestamp of the item image.
        /// </summary>
        public DateTime? createdAt { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who created the item image.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// Gets or sets the last modification timestamp of the item image.
        /// </summary>
        public DateTime? modifiedAt { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who last modified the item image.
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
