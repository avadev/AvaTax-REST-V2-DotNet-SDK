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
    /// Response for HS code verification batch requests. When Avalara.ItemMasterCoreService.Models.v2.ItemHSCodeVerificationOutputModel.failed is non-empty, no rows were persisted or published.
    /// </summary>
    public class ItemHSCodeVerificationOutputModel
    {
        /// <summary>
        /// Number of rows in the request (same as request array length).
        /// </summary>
        public Int32? total { get; set; }

        /// <summary>
        /// Rows that failed validation; empty when the full batch was accepted.
        /// </summary>
        public List<ItemHSCodeVerificationFailedRowModel> failed { get; set; }


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
