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
    /// Represent HS code classification for a given item.
    /// </summary>
    public class ItemHSCodeClassificationStatusModel
    {
        /// <summary>
        /// The unique ID of this HS code classification.
        /// </summary>
        public String id { get; set; }

        /// <summary>
        /// The unique ID of the company that owns this HS code classification.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// A unique code representing the item
        /// </summary>
        public Int64? itemId { get; set; }

        /// <summary>
        /// The country for which the item is getting classified.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The status of the HS code classification
        /// </summary>
        public String status { get; set; }

        /// <summary>
        /// The description for the HS code classification being created/updated.
        /// </summary>
        public String details { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdAt { get; set; }

        /// <summary>
        /// The ID of the user who created this record.
        /// </summary>
        public Int64? createdUserId { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedAt { get; set; }

        /// <summary>
        /// The ID of the user who last modified this record.
        /// </summary>
        public Int64? modifiedUserId { get; set; }

        /// <summary>
        /// The date/time when the request for this record was completed.
        /// </summary>
        public DateTime? completedAt { get; set; }


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
