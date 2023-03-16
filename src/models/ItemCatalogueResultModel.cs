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
    /// 
    /// </summary>
    public class ItemCatalogueResultModel
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
        /// The Id of this item at the source
        /// </summary>
        public String sourceEntityId { get; set; }

        /// <summary>
        /// A CRUD event for item db operations
        /// </summary>
        public ItemCatalogueResultEvent? itemEvent { get; set; }

        /// <summary>
        /// Contains list of errors for item catalogue entry
        /// </summary>
        public List<String> errors { get; set; }


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
