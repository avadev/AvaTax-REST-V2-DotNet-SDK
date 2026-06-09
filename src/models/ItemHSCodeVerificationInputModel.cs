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
    /// Represents a HsCodeClassification SLA Response for a given company.
    /// </summary>
    public class ItemHSCodeVerificationInputModel
    {
        /// <summary>
        /// The unique ID of this item.
        /// </summary>
        public Int64 itemId { get; set; }

        /// <summary>
        /// The country code for HS code verification (2-letter ISO 3166 country code).
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The HS code to verify.
        /// </summary>
        public String hsCode { get; set; }


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
